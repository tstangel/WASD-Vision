using System;
using System.Drawing;
using System.Windows.Forms;

namespace WASD_Vision
{
    public partial class MouseForm : Form
    {
        public MouseForm()
        {
            InitializeComponent();
            mouseHookCallbackSetup();
            PositionForm();
            SetColors();
        }

        RamGecTools.MouseHook mouseHook = new RamGecTools.MouseHook();
        Resource resource = new Resource();
        private System.Timers.Timer delayTimer;

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(
                workingArea.Right - Size.Width,
                workingArea.Bottom - Size.Height
            );
        }

        private void mouseHookCallbackSetup()
        {
            // register events
            mouseHook.LeftButtonDown += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_LeftButtonDown);
            mouseHook.LeftButtonUp += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_LeftButtonUp);
            mouseHook.RightButtonDown += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_RightButtonDown);
            mouseHook.RightButtonUp += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_RightButtonUp);
            mouseHook.MouseWheelForward += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_WheelForward);
            mouseHook.MouseWheelBack += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_WheelBack);
            mouseHook.MiddleButtonDown += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_MiddleButtonDown);
            mouseHook.MiddleButtonUp += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_MiddleButtonUp);
            mouseHook.XButton1Down += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_XButton1Down);
            mouseHook.XButton1Up += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_XButton1Up);
            mouseHook.XButton2Down += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_XButton2Down);
            mouseHook.XButton2Up += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_XButton2Up);

            mouseHook.Install();
        }

        private void mouseHook_LeftButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            LeftButton.Image = resource.getStyledImage("Left_Down");
        }

        private void mouseHook_LeftButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            LeftButton.Image = resource.getStyledImage("Left_Up");
        }

        private void mouseHook_RightButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            RightButton.Image = resource.getStyledImage("Right_Down");
        }

        private void mouseHook_RightButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            RightButton.Image = resource.getStyledImage("Right_Up");
        }

        private void mouseHook_WheelForward(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            Wheel.Image = resource.getStyledImage("Wheel_Forward");

            // http://stackoverflow.com/questions/19388517/using-timer-to-delay-an-operation-a-few-seconds
            delayTimer = new System.Timers.Timer();
            delayTimer.Interval = 77;
            delayTimer.AutoReset = false;
            delayTimer.Elapsed += (s, args) => mouseHook_WheelUp();
            delayTimer.Start();
        }

        private void mouseHook_WheelBack(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            Wheel.Image = resource.getStyledImage("Wheel_Back");

            delayTimer = new System.Timers.Timer();
            delayTimer.Interval = 77;
            delayTimer.AutoReset = false;
            delayTimer.Elapsed += (s, args) => mouseHook_WheelUp();
            delayTimer.Start();
        }

        private void mouseHook_WheelUp()
        {
            Wheel.Image = resource.getStyledImage("Wheel_Up");
        }

        private void mouseHook_MiddleButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            mouseHook_WheelUp();
        }

        private void mouseHook_MiddleButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            Wheel.Image = resource.getStyledImage("Wheel_Down");
        }

        private void mouseHook_XButton1Down(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            ThumbForward.Image = resource.getStyledImage("Thumb_Forward_Down");
        }

        private void mouseHook_XButton1Up(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            ThumbForward.Image = resource.getStyledImage("Thumb_Forward_Up");
        }

        private void mouseHook_XButton2Down(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            ThumbBack.Image = resource.getStyledImage("Thumb_Back_Down");
        }

        private void mouseHook_XButton2Up(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            ThumbBack.Image = resource.getStyledImage("Thumb_Back_Up");
        }

        private void MouseForm_FormClosing(object sender, EventArgs e)
        {
            mouseHook.Uninstall();

            Application.Exit();
        }

        public void SetColors()
        {
            LeftButton.Image = resource.getStyledImage("Left_Up");
            RightButton.Image = resource.getStyledImage("Right_Up");
            Wheel.Image = resource.getStyledImage("Wheel_Up");
            ThumbForward.Image = resource.getStyledImage("Thumb_Forward_Up");
            ThumbBack.Image = resource.getStyledImage("Thumb_Back_Up");

            BackColor = resource.getColorKey();
            TransparencyKey = resource.getColorKey();
        }
    }
}
