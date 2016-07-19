using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Specialized;

namespace WASD_Vision
{
    public partial class KeyboardForm : Form
    {
        RamGecTools.KeyboardHook keyboardHook = new RamGecTools.KeyboardHook();
        Resource resource = new Resource();

        private System.Timers.Timer delayTimer;
        private MouseForm mouseForm;
        private MenuForm menuForm;
        private bool customizingKeys = false;
        public bool paused = false;
        public string lastThreeInputCharacters = "";

        private string[] keys = {
            "One", "Two", "Three", "Four", "Five",
            "Q",   "W",   "E",     "R",    "T",
            "A",   "S",   "D",     "F",    "G",
            "Z",   "X",   "C",     "V",    "B",
            "Space"
        };

        private string[] keysSpacebarLevel2 =
        {
            "R", "F", "V"
        };

        private string[] keysSpacebarLevel3 =
        {
            "T", "G", "B"
        };

        private string[] protectedKeys =
        {
            "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",
            "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "[", "]", "\\",
            "A", "S", "D", "F", "G", "H", "J", "K", "L", ";", "'",
            "Z", "X", "C", "V", "B", "N", "M", ",", ".", "/",
            "*", "+"
        };

        private NameValueCollection keyCodesToCharacters = new NameValueCollection()
        {
            {"OEM_3", "`"},
            {"OEM_MINUS", "-"},
            {"OEM_PLUS", "="},
            {"OEM_4", "["},
            {"OEM_6", "]"},
            {"OEM_5", "\\"},
            {"OEM_1", ";"},
            {"OEM_7", "'"},
            {"OEM_COMMA", ","},
            {"OEM_PERIOD", "."},
            {"OEM_2", "/"},
            {"DIVIDE", "/"},
            {"MULTIPLY", "*"},
            {"SUBTRACT", "-"},
            {"ADD", "+"},
            {"NUMPAD7", "7"},
            {"NUMPAD8", "8"},
            {"NUMPAD9", "9"},
            {"NUMPAD4", "4"},
            {"NUMPAD5", "5"},
            {"NUMPAD6", "6"},
            {"NUMPAD1", "1"},
            {"NUMPAD2", "2"},
            {"NUMPAD3", "3"},
            {"NUMPAD0", "0" },
            {"DECIMAL", "."},
            {"Space", " "},
            {"One", "1"},
            {"Two", "2"},
            {"Three", "3"},
            {"Four", "4"},
            {"Five", "5"},
            {"Six", "6"},
            {"Seven", "7"},
            {"Eight", "8"},
            {"Nine", "9"},
            {"Zero", "0"},
            {"_", "-"},
            {"+", "="},
            {"{", "["},
            {"}", "]"},
            {"|", "\\"},
            {":", ";"},
            {"\"", "'"},
            {"<", ","},
            {">", "."},
            {"?", "/"}
        };

        public KeyboardForm()
        {
            InitializeComponent();
            keyboardHookCallbackSetup();
            ShowKeys();
            SpacebarResize();
            PositionForm();
            SetColors();
        }

        public void Set_Form_References(MouseForm instanceMouseForm, MenuForm instanceMenuForm)
        {
            mouseForm = instanceMouseForm;
            menuForm = instanceMenuForm;
        }

        private PictureBox GetPictureBox(string name)
        {
            return Controls.Find(name, false)[0] as PictureBox;
        }

        public void SetColors()
        {
            foreach (string key in keys)
            {
                // all keys should be down when we are customizing keys
                if (customizingKeys)
                {
                    GetPictureBox("UI_Key_" + key).Image = resource.getStyledImage(key + "_Down");
                }
                else
                {
                    GetPictureBox("UI_Key_" + key).Image = resource.getStyledImage(key + "_Up");
                }
            }

            BackColor = resource.getColorKey();
            TransparencyKey = resource.getColorKey();
        }

        public void ShowKeys()
        {
            foreach (string key in keys)
            {
                string visible;

                if (Properties.Settings.Default.Layout == "Custom")
                {
                    visible = Properties.Settings.Default["Layout_Custom_" + key + "_Visible"] as String;
                }
                else
                {
                    visible = resource.GetString("Layout_" + Properties.Settings.Default.Layout + "_" + key + "_Visible");
                }

                if (visible == "True")
                {
                    GetPictureBox("UI_Key_" + key).Visible = true;
                }
                else
                {
                    GetPictureBox("UI_Key_" + key).Visible = false;
                }
            }
        }

        public void ShowKeyCustomization()
        {
            customizingKeys = true;

            KeysAllDown();

            foreach (string key in keys)
            {
                GetPictureBox("UI_Key_" + key).Visible = true;
                GetPictureBox("UI_Key_" + key).Cursor = Cursors.Hand;

                if ((string) Properties.Settings.Default["Layout_Custom_" + key + "_Visible"] == "True")
                {
                    GetPictureBox("UI_Key_" + key).BackColor = Color.LimeGreen;
                } else
                {
                    GetPictureBox("UI_Key_" + key).BackColor = Color.Red;
                }
            }
        }

        public void HideKeyCustomization()
        {
            customizingKeys = false;

            KeysAllUp();
            ShowKeys();

            foreach (string key in keys)
            {
                GetPictureBox("UI_Key_" + key).BackColor = Color.Transparent;
                GetPictureBox("UI_Key_" + key).Cursor = Cursors.Default;
            }
        }

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(
                workingArea.Left,
                workingArea.Bottom - Size.Height + 14
            );
        }

        private void keyboardHookCallbackSetup()
        {
            // register events
            keyboardHook.KeyDown += new RamGecTools.KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new RamGecTools.KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);

            keyboardHook.Install();
        }

        void keyboardHook_KeyUp(RamGecTools.KeyboardHook.VKeys key)
        {
            string keyString = key.ToString();

            if (customizingKeys || paused)
                return;

            // if the key released is supported
            if (Array.IndexOf(keys, keyString) > -1) {
                GetPictureBox("UI_Key_" + keyString).Image = resource.getStyledImage(keyString + "_Up");
            }
        }

        void keyboardHook_KeyDown(RamGecTools.KeyboardHook.VKeys key)
        {
            string keyString = key.ToString();

            if (customizingKeys || paused || ProtectedWord_Check(keyString))
                return;

            // if the key pressed is supported
            if (Array.IndexOf(keys, keyString) > -1)
            {
                GetPictureBox("UI_Key_" + keyString).Image = resource.getStyledImage(keyString + "_Down");
            }
        }

        public void KeysAllDown()
        {
            foreach (string key in keys)
            {
                GetPictureBox("UI_Key_" + key).Image = resource.getStyledImage(key + "_Down");
            }
        }

        public void KeysAllUp()
        {
            foreach (string key in keys)
            {
                GetPictureBox("UI_Key_" + key).Image = resource.getStyledImage(key + "_Up");
            }
        }

        private void KeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // remove tray icon
            trayIcon.Visible = false;

            // there's no harm to call Uninstall method repeatedly even if hooks aren't installed
            keyboardHook.Uninstall();

            Application.Exit();
        }

        private void Tool_Strip_Menu_Item_Options_Click(object sender, EventArgs e)
        {
            Focus();
            mouseForm.Focus();
            menuForm.Show();
            menuForm.Focus();
            menuForm.ShowLayoutPreference();
        }

        private void Tool_Strip_Menu_Item_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UI_Key_Click(object sender, EventArgs e)
        {
            if(customizingKeys)
            {
                string key = (string)((PictureBox)sender).Tag;
                string keyVisible = (string)Properties.Settings.Default["Layout_Custom_" + key + "_Visible"];

                // toggle key visibility
                Properties.Settings.Default["Layout_Custom_" + key + "_Visible"] = (keyVisible == "True") ? "False" : "True";
                Properties.Settings.Default.Save();

                ShowKeyCustomization();
                SpacebarResize();
            }
        }

        private bool KeyVisible(string key)
        {
            bool visible;

            if(Properties.Settings.Default.Layout == "Custom")
            {
                visible = ((string)Properties.Settings.Default["Layout_Custom_" + key + "_Visible"] == "True");
            }
            else
            {
                visible = (resource.GetString("Layout_" + Properties.Settings.Default.Layout + "_" + key + "_Visible") == "True");
            }

            return visible;
        }

        // resize the space bar based on which keys are enabled
        public void SpacebarResize()
        {
            // max width
            foreach (string key in keysSpacebarLevel3)
            {
                if (KeyVisible(key))
                {
                    UI_Key_Space.Width = 545;
                    return;
                }
            }

            // medium width
            foreach (string key in keysSpacebarLevel2)
            {
                if (KeyVisible(key))
                {
                    UI_Key_Space.Width = 422;
                    return;
                }
            }

            // minimum width
            UI_Key_Space.Width = 272;
        }

        private bool ProtectedWord_Check(string inputCharacter)
        {
            // Remove the first character of lastThreeInputCharacters if it is already three characters long
            if (lastThreeInputCharacters.Length > 2)
            {
                lastThreeInputCharacters = lastThreeInputCharacters.Substring(1, 2);
            }

            // Look for and replace special key codes with their character equivalent
            // Example: pressing / will produce OEM_3 as the key code. This will convert that to "/"
            foreach(string keyCode in keyCodesToCharacters)
            {
                if(inputCharacter == keyCode)
                {
                    inputCharacter = keyCodesToCharacters.GetValues(keyCode)[0];
                    break;
                }
            }

            // Check to see if the key pressed is supported, otherwise return.
            // This is to ignore control keys such as shift
            if(Array.IndexOf(protectedKeys, inputCharacter) == -1)
            {
                return false;
            }

            // Add the most recently typed key to lastThreeInputCharacters
            lastThreeInputCharacters = lastThreeInputCharacters + inputCharacter;

            foreach(string protectedWord in Properties.Settings.Default.Protected_Words)
            {
                // Decrypt the protected word for comparison
                string decryptedProtectedWord = System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(System.Convert.FromBase64String(protectedWord), null, DataProtectionScope.CurrentUser));

                // If input matches a protected word, pause keyboard display
                if (lastThreeInputCharacters == decryptedProtectedWord)
                {
                    ProtectedWord_Pause();
                    return true;
                }

                // Clear decrypted protected word
                decryptedProtectedWord = "";
            }

            // Protected word not found in input
            return false;
        }

        private void ProtectedWord_Pause()
        {
            // set paused flag to pause keyboard display
            paused = true;

            // Show all keys in default position
            KeysAllUp();

            // http://stackoverflow.com/questions/19388517/using-timer-to-delay-an-operation-a-few-seconds
            delayTimer = new System.Timers.Timer();
            delayTimer.Interval = 30000;
            delayTimer.AutoReset = false;
            delayTimer.Elapsed += (s, args) => ProtectedWord_Resume();
            delayTimer.Start();
        }

        private void ProtectedWord_Resume()
        {
            paused = false;
        }
    }
}
