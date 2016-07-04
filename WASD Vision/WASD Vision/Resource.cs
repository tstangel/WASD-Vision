using System;
using System.Drawing;
using System.Diagnostics;
using System.Resources;

namespace WASD_Vision
{
    internal class Resource
    {
        public Resource()
        {
            
        }

        public Image getImage(string objectName)
        {
            return (Image) Properties.Resources.ResourceManager.GetObject("Style_" + Properties.Settings.Default.Color + "_" + objectName);
        }

        public Color getColorKey()
        {
            return Color.FromName(Properties.Resources.ResourceManager.GetString("Style_" + Properties.Settings.Default.Color + "_Color_Key"));
        }
    }
}
