using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardMouseHooks
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

            var keyboardVision = new mainForm();
            var mouseVision = new MouseVision();

            keyboardVision.Show();
            mouseVision.Show();

            Application.Run();
        }
    }
}
