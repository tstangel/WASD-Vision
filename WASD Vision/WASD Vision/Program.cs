﻿using System;
using System.Windows.Forms;

namespace WASD_Vision
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var keyboardForm = new KeyboardForm();
            var mouseForm = new MouseForm();
            var menuForm = new MenuForm();

            keyboardForm.Set_Form_References(mouseForm, menuForm);
            menuForm.Set_Form_References(keyboardForm, mouseForm);

            keyboardForm.Show();
            mouseForm.Show();

            Application.Run();
        }
    }
}
