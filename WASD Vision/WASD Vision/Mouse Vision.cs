using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool MouseLeftDown = false;
        private bool MouseRightDown = false;

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

            mouseHook.Install();
        }

        private void mouseHook_LeftButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseLeftDown = true;

            if (MouseRightDown)
            {
                MouseImage.Image = resource.getImage("Mouse_Left_Right_Down");
            }
            else
            {
                MouseImage.Image = resource.getImage("Mouse_Left_Down");
            }
        }

        private void mouseHook_LeftButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseLeftDown = false;

            if (MouseRightDown)
            {
                MouseImage.Image = resource.getImage("Mouse_Right_Down");
            }
            else
            {
                MouseImage.Image = resource.getImage("Mouse_Up");
            }
        }

        private void mouseHook_RightButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseRightDown = true;

            if (MouseLeftDown)
            {
                MouseImage.Image = resource.getImage("Mouse_Left_Right_Down");
            }
            else
            {
                MouseImage.Image = resource.getImage("Mouse_Right_Down");
            }
        }

        private void mouseHook_RightButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseRightDown = false;

            if (MouseLeftDown)
            {
                MouseImage.Image = resource.getImage("Mouse_Left_Down");
            }
            else
            {
                MouseImage.Image = resource.getImage("Mouse_Up");
            }
        }

        private void MouseForm_FormClosing(object sender, EventArgs e)
        {
            mouseHook.Uninstall();

            Application.Exit();
        }

        public void SetColors()
        {
            MouseImage.Image = resource.getImage("Mouse_Up");
            BackColor = resource.getColorKey();
            TransparencyKey = resource.getColorKey();
        }
    }
}
