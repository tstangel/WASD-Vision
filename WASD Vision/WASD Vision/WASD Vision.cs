using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WASD_Vision
{
    public partial class KeyboardForm : Form
    {
        public KeyboardForm()
        {
            InitializeComponent();
            keyboardHookCallbackSetup();
            PositionForm();
        }

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
                    UI_Key_One.Image = Properties.Resources.One_Up;
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = Properties.Resources.Two_Up;
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = Properties.Resources.Three_Up;
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = Properties.Resources.Four_Up;
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = Properties.Resources.Q_Up;
                    break;
                case "KEY_W":
                    UI_Key_W.Image = Properties.Resources.W_Up;
                    break;
                case "KEY_E":
                    UI_Key_E.Image = Properties.Resources.E_Up;
                    break;
                case "KEY_A":
                    UI_Key_A.Image = Properties.Resources.A_Up;
                    break;
                case "KEY_S":
                    UI_Key_S.Image = Properties.Resources.S_Up;
                    break;
                case "KEY_D":
                    UI_Key_D.Image = Properties.Resources.D_Up;
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = Properties.Resources.Z_Up;
                    break;
                case "KEY_X":
                    UI_Key_X.Image = Properties.Resources.X_Up;
                    break;
                case "KEY_C":
                    UI_Key_C.Image = Properties.Resources.C_Up;
                    break;
                case "SPACE":
                    UI_Key_Space.Image = Properties.Resources.Space_Up;
                    break;
            }
        }

        void keyboardHook_KeyDown(RamGecTools.KeyboardHook.VKeys key)
        {
            switch (key.ToString())
            {
                case "KEY_1":
                    UI_Key_One.Image = Properties.Resources.One_Down;
                    break;
                case "KEY_2":
                    UI_Key_Two.Image = Properties.Resources.Two_Down;
                    break;
                case "KEY_3":
                    UI_Key_Three.Image = Properties.Resources.Three_Down;
                    break;
                case "KEY_4":
                    UI_Key_Four.Image = Properties.Resources.Four_Down;
                    break;
                case "KEY_Q":
                    UI_Key_Q.Image = Properties.Resources.Q_Down;
                    break;
                case "KEY_W":
                    UI_Key_W.Image = Properties.Resources.W_Down;
                    break;
                case "KEY_E":
                    UI_Key_E.Image = Properties.Resources.E_Down;
                    break;
                case "KEY_A":
                    UI_Key_A.Image = Properties.Resources.A_Down;
                    break;
                case "KEY_S":
                    UI_Key_S.Image = Properties.Resources.S_Down;
                    break;
                case "KEY_D":
                    UI_Key_D.Image = Properties.Resources.D_Down;
                    break;
                case "KEY_Z":
                    UI_Key_Z.Image = Properties.Resources.Z_Down;
                    break;
                case "KEY_X":
                    UI_Key_X.Image = Properties.Resources.X_Down;
                    break;
                case "KEY_C":
                    UI_Key_C.Image = Properties.Resources.C_Down;
                    break;
                case "SPACE":
                    UI_Key_Space.Image = Properties.Resources.Space_Down;
                    break;
            }
        }

        private void KeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // there's no harm to call Uninstall method repeatedly even if hooks aren't installed
            keyboardHook.Uninstall();

            Application.Exit();
        }

        private void KeyboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
