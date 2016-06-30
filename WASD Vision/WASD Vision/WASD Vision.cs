using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WASD_Vision
{
    public partial class KeyboardForm : Form
    {
        private MouseForm mouseForm;
        private MenuForm menuForm;

        public KeyboardForm()
        {
            InitializeComponent();
            keyboardHookCallbackSetup();
            PositionForm();
            SetColors();
        }

        public void Set_Form_References(MouseForm instanceMouseForm, MenuForm instanceMenuForm)
        {
            mouseForm = instanceMouseForm;
            menuForm = instanceMenuForm;
        }

        public void SetColors()
        {
            UI_Key_One.Image = resource.getImage("One_Up");
            UI_Key_Two.Image = resource.getImage("Two_Up");
            UI_Key_Three.Image = resource.getImage("Three_Up");
            UI_Key_Four.Image = resource.getImage("Four_Up");
            UI_Key_Q.Image = resource.getImage("Q_Up");
            UI_Key_W.Image = resource.getImage("W_Up");
            UI_Key_E.Image = resource.getImage("E_Up");
            UI_Key_A.Image = resource.getImage("A_Up");
            UI_Key_S.Image = resource.getImage("S_Up");
            UI_Key_D.Image = resource.getImage("D_Up");
            UI_Key_Z.Image = resource.getImage("Z_Up");
            UI_Key_X.Image = resource.getImage("X_Up");
            UI_Key_C.Image = resource.getImage("C_Up");
            UI_Key_Space.Image = resource.getImage("Space_Up");

            BackColor = resource.getColorKey();
            TransparencyKey = resource.getColorKey();
        }

        RamGecTools.KeyboardHook keyboardHook = new RamGecTools.KeyboardHook();
        Resource resource = new Resource();

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(
                workingArea.Left,
                workingArea.Bottom - Size.Height
            );
        }

        private void keyboardHookCallbackSetup()
        {
            // register evens
            keyboardHook.KeyDown += new RamGecTools.KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new RamGecTools.KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);

            keyboardHook.Install();
        }

        void keyboardHook_KeyUp(RamGecTools.KeyboardHook.VKeys key)
        {
            switch (key.ToString())
            {
                case "KEY_1":
                    UI_Key_One.Image = resource.getImage("One_Up");
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = resource.getImage("Two_Up");
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = resource.getImage("Three_Up");
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = resource.getImage("Four_Up");
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = resource.getImage("Q_Up");
                    break;
                case "KEY_W":
                    UI_Key_W.Image = resource.getImage("W_Up");
                    break;
                case "KEY_E":
                    UI_Key_E.Image = resource.getImage("E_Up");
                    break;
                case "KEY_A":
                    UI_Key_A.Image = resource.getImage("A_Up");
                    break;
                case "KEY_S":
                    UI_Key_S.Image = resource.getImage("S_Up");
                    break;
                case "KEY_D":
                    UI_Key_D.Image = resource.getImage("D_Up");
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = resource.getImage("Z_Up");
                    break;
                case "KEY_X":
                    UI_Key_X.Image = resource.getImage("X_Up");
                    break;
                case "KEY_C":
                    UI_Key_C.Image = resource.getImage("C_Up");
                    break;
                case "SPACE":
                    UI_Key_Space.Image = resource.getImage("Space_Up");
                    break;
            }
        }

        void keyboardHook_KeyDown(RamGecTools.KeyboardHook.VKeys key)
        {
            switch (key.ToString())
            {
                case "KEY_1":
                    UI_Key_One.Image = resource.getImage("One_Down");
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = resource.getImage("Two_Down");
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = resource.getImage("Three_Down");
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = resource.getImage("Four_Down");
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = resource.getImage("Q_Down");
                    break;
                case "KEY_W":
                    UI_Key_W.Image = resource.getImage("W_Down");
                    break;
                case "KEY_E":
                    UI_Key_E.Image = resource.getImage("E_Down");
                    break;
                case "KEY_A":
                    UI_Key_A.Image = resource.getImage("A_Down");
                    break;
                case "KEY_S":
                    UI_Key_S.Image = resource.getImage("S_Down");
                    break;
                case "KEY_D":
                    UI_Key_D.Image = resource.getImage("D_Down");
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = resource.getImage("Z_Down");
                    break;
                case "KEY_X":
                    UI_Key_X.Image = resource.getImage("X_Down");
                    break;
                case "KEY_C":
                    UI_Key_C.Image = resource.getImage("C_Down");
                    break;
                case "SPACE":
                    UI_Key_Space.Image = resource.getImage("Space_Down");
                    break;
            }
        }

        private void KeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;

            // there's no harm to call Uninstall method repeatedly even if hooks aren't installed
            keyboardHook.Uninstall();

            Application.Exit();
        }

        private void Tool_Strip_Menu_Item_Colors_Click(object sender, EventArgs e)
        {
            Focus();
            mouseForm.Focus();
            menuForm.Show();
            menuForm.Focus();
        }

        private void Tool_Strip_Menu_Item_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
