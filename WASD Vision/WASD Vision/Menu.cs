using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Specialized;

namespace WASD_Vision
{
    public partial class MenuForm : Form
    {
        private KeyboardForm keyboardForm;
        private MouseForm mouseForm;
        private NameValueCollection charactersToKeyCodes = new NameValueCollection()
        {
            {"~", "`"},
            {"!", "1"},
            {"@", "2"},
            {"#", "3"},
            {"$", "4"},
            {"%", "5"},
            {"^", "6"},
            {"&", "7"},
            {"*", "8"},
            {"(", "9"},
            {")", "0"},
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

        Resource resource = new Resource();

        public MenuForm()
        {
            InitializeComponent();
            PositionForm();
        }

        private PictureBox GetPictureBox(string name)
        {
            return Controls.Find(name, false)[0] as PictureBox;
        }

        public void ShowLayoutPreference()
        {
            GetPictureBox("UI_Option_" + Properties.Settings.Default.Layout).Image = resource.getImage("option_" + Properties.Settings.Default.Layout + "_on");

            if (Properties.Settings.Default.Layout == "Custom")
            {
                keyboardForm.ShowKeyCustomization();
            }
            else
            {
                keyboardForm.HideKeyCustomization();
            }
        }

        private void Settings_Layout_Update(string layout)
        {
            // turn previous button off
            GetPictureBox("UI_Option_" + Properties.Settings.Default.Layout).Image = resource.getImage("option_" + Properties.Settings.Default.Layout + "_off");

            // save new layout setting
            Properties.Settings.Default.Layout = layout;
            Properties.Settings.Default.Save();

            // redraw elements
            ShowLayoutPreference();
            keyboardForm.ShowKeys();
            keyboardForm.SpacebarResize();

            // show key customization if selected layout is Custom
            if (Properties.Settings.Default.Layout == "Custom")
            {
                keyboardForm.ShowKeyCustomization();
            }
            else
            {
                keyboardForm.HideKeyCustomization();
            }
        }

        public void Set_Form_References(KeyboardForm instanceKeyboardForm, MouseForm instanceMouseForm)
        {
            keyboardForm = instanceKeyboardForm;
            mouseForm = instanceMouseForm;
        }

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(((workingArea.Right - Size.Width) / 2) + 143,
                                 workingArea.Bottom - Size.Height - 27);
        }

        private void Settings_Color_Update(string color)
        {
            Properties.Settings.Default.Color = color;
            keyboardForm.SetColors();
            mouseForm.SetColors();
            Properties.Settings.Default.Save();
        }

        private void UI_Option_Color_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update((string)((PictureBox)sender).Tag);
        }

        private void UI_Option_Layout_Click(object sender, System.EventArgs e)
        {
            Settings_Layout_Update((string)((PictureBox)sender).Tag);
        }
        
        private void UI_Menu_Close_Click(object sender, System.EventArgs e)
        {
            Close_Options();
            Hide();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Options();
        }

        private void Close_Options()
        {
            keyboardForm.HideKeyCustomization();
        }

        private void UI_Option_Add_Protected_Word_Click(object sender, System.EventArgs e)
        {
            // Show prompt for protected word
            string ProtectedWord = Prompt.ShowDialog(
                "You may enter email addresses, passwords, or any words you would like to protect. WASD Vision will pause for 30 seconds if you type the beginning of a protected word.",
                "Add protected word",
                "Add",
                true
            );

            // Convert protected word to uppercase, as protected word comparison is case-insensitive.
            // Typing "password" should be blocked even if user added the protected word "Password".
            ProtectedWord = ProtectedWord.ToUpper();

            // Truncate ProtectedWord to its first three characters, as we check only the last three keys pressed
            if(ProtectedWord.Length > 3)
            {
                ProtectedWord = ProtectedWord.Substring(0, 3);
            }

            // Initialize new character array for special character conversion
            char[] ProtectedWordConverted = ProtectedWord.ToCharArray();

            // Replace special characters with their lowercase equivalent
            for(int i = 0; i < ProtectedWordConverted.Length; i++)
            {
                char character = ProtectedWordConverted[i];

                foreach(string fromCharacter in charactersToKeyCodes)
                {
                    if(character.ToString() == fromCharacter)
                    {
                        ProtectedWordConverted[i] = System.Convert.ToChar(charactersToKeyCodes.GetValues(fromCharacter)[0]);
                        break;
                    }
                }
            }

            // Update ProtectedWord with result of special character replacement
            ProtectedWord = new string(ProtectedWordConverted);

            // Remove ProtectedWordConverted array
            ProtectedWordConverted = "".ToCharArray();
            
            // Convert protected word to byte array, encrypt, and convert to base 64 string
            string EncryptedProtectedWord = System.Convert.ToBase64String(ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(ProtectedWord), null, DataProtectionScope.CurrentUser));

            // Remove ProtectedWord variable
            ProtectedWord = "";

            // Add the encrypted protected word to program settings
            Properties.Settings.Default.Protected_Words.Add(EncryptedProtectedWord);

            // Save program settings
            Properties.Settings.Default.Save();
        }

        private void UI_Option_Delete_All_Protected_Words_Click(object sender, System.EventArgs e)
        {
            // Remove all protected words
            Properties.Settings.Default.Protected_Words.Clear();

            // Save program settings
            Properties.Settings.Default.Save();

            // Resume keyboard overlay as user may have been testing protected words feature
            keyboardForm.paused = false;

            // Show confirmation message
            MessageBox.Show("     " + "All protected words have been deleted.");
        }
    }
}
