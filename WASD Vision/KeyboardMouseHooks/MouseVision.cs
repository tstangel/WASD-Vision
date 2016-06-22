using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyboardMouseHooks
{
    public partial class MouseVision : Form
    {
        public MouseVision()
        {
            InitializeComponent();
            mouseHookCallbackSetup();

            // move form to bottom right
            PositionForm();
        }

        RamGecTools.MouseHook mouseHook = new RamGecTools.MouseHook();

        private bool MouseLeftDown = false;
        private bool MouseRightDown = false;
        // private int GridPositionLeft = -5000;
        // private int GridPositionTop = -5000;
        // private int MousePositionDifferenceLeft = -1;
        // private int MousePositionDifferenceTop = -1;

        private void PositionForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width,
                                 workingArea.Bottom - Size.Height);
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

            if(MouseRightDown)
            {
                MouseImage.Image = Properties.Resources.Mouse_Left_Right_Down;
            }
            else
            {
                MouseImage.Image = Properties.Resources.Mouse_Left_Down;
            }
        }

        private void mouseHook_LeftButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseLeftDown = false;

            if (MouseRightDown)
            {
                MouseImage.Image = Properties.Resources.Mouse_Right_Down;
            }
            else
            {
                MouseImage.Image = Properties.Resources.Mouse_Default;
            }
        }

        private void mouseHook_RightButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseRightDown = true;

            if (MouseLeftDown)
            {
                MouseImage.Image = Properties.Resources.Mouse_Left_Right_Down;
            }
            else
            {
                MouseImage.Image = Properties.Resources.Mouse_Right_Down;
            }
        }

        private void mouseHook_RightButtonUp(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            MouseRightDown = false;

            if (MouseLeftDown)
            {
                MouseImage.Image = Properties.Resources.Mouse_Left_Down;
            }
            else
            {
                MouseImage.Image = Properties.Resources.Mouse_Default;
            }
        }

        private void MouseVision_Load(object sender, EventArgs e)
        {
            
        }

        // 
        // Grid movement under Mouse Vision form was too distracting
        //
        //void mouseHook_MouseMove(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        //{
        //    // set mouse position variables to initial mouse position once
        //    if(MousePositionDifferenceLeft < 0)
        //    {
        //        MousePositionDifferenceLeft = mouseStruct.pt.x;
        //        MousePositionDifferenceTop = mouseStruct.pt.y;
        //    }

        //    GridPositionLeft += (mouseStruct.pt.x - MousePositionDifferenceLeft);
        //    GridPositionTop += (mouseStruct.pt.y - MousePositionDifferenceTop);

        //    Grid.Location = new System.Drawing.Point(GridPositionLeft, GridPositionTop);

        //    MousePositionDifferenceLeft = mouseStruct.pt.x;
        //    MousePositionDifferenceTop = mouseStruct.pt.y;
        //}


        private void MouseVision_FormClosing(object sender, EventArgs e)
        {
            mouseHook.Uninstall();

            Application.Exit();
        }

        private void Grid_Click(object sender, EventArgs e)
        {

        }
    }
}
