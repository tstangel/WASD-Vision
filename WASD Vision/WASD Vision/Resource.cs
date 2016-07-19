using System;
using System.Drawing;

namespace WASD_Vision
{
    internal class Resource
    {
        public Resource()
        {
            // Nothing needed
        }

        public String GetString(string stringName)
        {
            return Properties.Resources.ResourceManager.GetString(stringName);
        }

        public Image getImage(string objectName)
        {
            return (Image)Properties.Resources.ResourceManager.GetObject(objectName);
        }

        public Image getStyledImage(string objectName)
        {
            return getImage("Style_" + Properties.Settings.Default.Color + "_" + objectName);
        }

        public Color getColorKey()
        {
            return Color.FromName(Properties.Resources.ResourceManager.GetString("Style_" + Properties.Settings.Default.Color + "_Color_Key"));
        }
    }
}
