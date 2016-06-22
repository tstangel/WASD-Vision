using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// using System.Runtime.InteropServices;

namespace KeyboardMouseHooks
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            keyboardHookCallbackSetup();
            PositionForm();
        }

        /// <summary>
        /// Class declarations
        /// </summary>
        RamGecTools.KeyboardHook keyboardHook = new RamGecTools.KeyboardHook();

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
                    UI_Key_One.Image = Properties.Resources.Image_1_Up;
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = Properties.Resources.Image_2_Up;
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = Properties.Resources.Image_3_Up;
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = Properties.Resources.Image_4_Up;
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = Properties.Resources.Image_Q_Up;
                    break;
                case "KEY_W":
                    UI_Key_W.Image = Properties.Resources.Image_W_Up;
                    break;
                case "KEY_E":
                    UI_Key_E.Image = Properties.Resources.Image_E_Up;
                    break;
                case "KEY_A":
                    UI_Key_A.Image = Properties.Resources.Image_A_Up;
                    break;
                case "KEY_S":
                    UI_Key_S.Image = Properties.Resources.Image_S_Up;
                    break;
                case "KEY_D":
                    UI_Key_D.Image = Properties.Resources.Image_D_Up;
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = Properties.Resources.Image_Z_Up;
                    break;
                case "KEY_X":
                    UI_Key_X.Image = Properties.Resources.Image_X_Up;
                    break;
                case "KEY_C":
                    UI_Key_C.Image = Properties.Resources.Image_C_Up;
                    break;
                case "SPACE":
                    UI_Key_Space.Image = Properties.Resources.Image_Space_Up;
                    break;
            }
        }

        void keyboardHook_KeyDown(RamGecTools.KeyboardHook.VKeys key)
        {
            switch (key.ToString())
            {
                case "KEY_1":
                    UI_Key_One.Image = Properties.Resources.Image_1_Down;
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = Properties.Resources.Image_2_Down;
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = Properties.Resources.Image_3_Down;
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = Properties.Resources.Image_4_Down;
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = Properties.Resources.Image_Q_Down;
                    break;
                case "KEY_W":
                    UI_Key_W.Image = Properties.Resources.Image_W_Down;
                    break;
                case "KEY_E":
                    UI_Key_E.Image = Properties.Resources.Image_E_Down;
                    break;
                case "KEY_A":
                    UI_Key_A.Image = Properties.Resources.Image_A_Down;
                    break;
                case "KEY_S":
                    UI_Key_S.Image = Properties.Resources.Image_S_Down;
                    break;
                case "KEY_D":
                    UI_Key_D.Image = Properties.Resources.Image_D_Down;
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = Properties.Resources.Image_Z_Down;
                    break;
                case "KEY_X":
                    UI_Key_X.Image = Properties.Resources.Image_X_Down;
                    break;
                case "KEY_C":
                    UI_Key_C.Image = Properties.Resources.Image_C_Down;
                    break;
                case "SPACE":
                    UI_Key_Space.Image = Properties.Resources.Image_Space_Down;
                    break;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // there's no harm to call Uninstall method repeatedly even if hooks aren't installed
            keyboardHook.Uninstall();

            Application.Exit();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void UI_Key_E_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_C_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_X_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Z_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_A_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_S_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_D_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Space_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_W_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Q_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_One_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Two_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Three_Click(object sender, EventArgs e)
        {

        }

        private void UI_Key_Four_Click(object sender, EventArgs e)
        {

        }
    }
}
