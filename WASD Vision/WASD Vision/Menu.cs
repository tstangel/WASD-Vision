using System.Drawing;
using System.Windows.Forms;

namespace WASD_Vision
{
    public partial class MenuForm : Form
    {
        private KeyboardForm keyboardForm;
        private MouseForm mouseForm;

        public MenuForm()
        {
            InitializeComponent();
            PositionForm();
        }

        public void Set_Form_References(KeyboardForm instanceKeyboardForm, MouseForm instanceMouseForm)
        {
            keyboardForm = instanceKeyboardForm;
            mouseForm = instanceMouseForm;
        }

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(((workingArea.Right - Size.Width) / 2) - 27,
                                 workingArea.Bottom - Size.Height - 27);
        }

        private void Settings_Color_Update(string color)
        {
            Properties.Settings.Default.Color = color;
            keyboardForm.SetColors();
            mouseForm.SetColors();
            Properties.Settings.Default.Save();
        }

        private void UI_Option_Turquoise_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Turquoise");
        }

        private void UI_Option_Pink_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Pink");
        }

        private void UI_Option_White_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("White");
        }

        private void UI_Option_Orange_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Orange");
        }

        private void UI_Option_Black_Mouse_Click(object sender, System.EventArgs e)
        {
            Settings_Color_Update("Black");
        }

        private void UI_Option_Green_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Green");
        }

        private void UI_Option_Purple_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Purple");
        }

        private void UI_Option_Yellow_Mouse_Click(object sender, MouseEventArgs e)
        {
            Settings_Color_Update("Yellow");
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            Hide();
        }
    }
}
