using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using imbSCI.Core.reporting.colors;
using Accord.Imaging;
using System.Xml.Serialization;
using imbSCI.Core.math;

namespace imbSCI.Core.style.color
{

    public static class ColorWorks {


        /// <summary>
        /// Converts HEX code to color
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public static Color GetColor(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            Color c = Color.FromArgb(a, r, g, b);
           
            return c;
        }

        public static String ColorToHex(this Color actColor)

        {
            return actColor.ToString(); //"#" + IntToHex(actColor.R, 2) + IntToHex(actColor.G, 2) + IntToHex(actColor.B, 2);
        }
    }

}