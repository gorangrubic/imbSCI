using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using Accord;
using imbSCI.Core.reporting.colors;
using AForge.Imaging;
using System.Xml.Serialization;

namespace imbSCI.Graph.Converters.tools
{

    public class ColorHSVPoint
    {
        public ColorHSVPoint()
        {
            
        }

        public ColorHSVPoint Clone()
        {
            var output =  new ColorHSVPoint();
            output.H = H;
            output.V = V;
            output.S = S;
            output.A = A;
            return output;
            
        }

        /// <summary>
        /// Gets the range version --- values are allowed to be negative
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public ColorHSVPoint GetRange(ColorHSVPoint b)
        {
            var output = new ColorHSVPoint();
            output.H = H - b.H;
            
            output.V = V - b.V;
            output.S = S - b.S;
            output.A = A - b.A;
            return output;
        }

        public void DeployValues()
        {
            var output = this;
            while (H < 0)
            {
                H += 360;
            }
            H = H % 360;

            S = Math.Min(S, 1);
            V = Math.Min(V, 1);
            A = Math.Min(A, 1);
            S = Math.Max(S , 0);
            V = Math.Max(V , 0);
            A = Math.Max(A , 0);
        }

        public static ColorHSVPoint operator +(ColorHSVPoint a, ColorHSVPoint b)
        {
            ColorHSVPoint output = new ColorHSVPoint();
            output.H = (a.H + b.H);
            output.S += a.S;
            output.V += a.V;
            output.A += a.A;
            output.DeployValues();
            return output;
        }


        public static ColorHSVPoint operator *(ColorHSVPoint a, Double b)
        {
            ColorHSVPoint output = new ColorHSVPoint();
            output.H = Convert.ToInt32(a.H * b); // % 360;
            
            output.S = a.S * (float)b;
            output.V = a.V * (float)b;
            output.A = a.A * (float)b;

            output.DeployValues();

            return output;
        }

        /// <summary>
        /// Performs multiplication without <see cref="DeployValues"/> call
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public ColorHSVPoint GetRangeMultiplied(Double b)
        {
            ColorHSVPoint output = Clone();

            output.H = Convert.ToInt32(H * b); // % 360;

            output.S = S * (float)b;
            output.V = V * (float)b;
            output.A = A * (float)b;

            return output;

        }

        public static ColorHSVPoint operator -(ColorHSVPoint a, ColorHSVPoint b)
        {
            ColorHSVPoint output = new ColorHSVPoint();
            output.H = a.H - b.H;
            output.S -= a.S;
            output.V -= a.V;
            output.A -= a.A;
            output.DeployValues();
            return output;
        }

        public ColorHSVPoint(String hexColor)
        {
            SetHexColor(hexColor);
        }


        public String GetHexColor(Boolean withAlpha=true)
        {
            DeployValues();
            var c = GetColor().toMediaColor();
            
            c.A = Convert.ToByte(A * Byte.MaxValue);
            return aceColorConverts.toHexColor(c, !withAlpha);
            
        }

        public Color GetColor()
        {
            var hsl = new HSL(H, S, V);
            var c = hsl.ToRGB();
            return c.Color;

        }

        public void SetHexColor(String hex)
        {
            SetColor(aceColorConverts.getColorFromHex(hex));
        }

        public void SetColor(Color color)
        {
            var hsl = HSL.FromRGB(new RGB(color));
            H = hsl.Hue;
            S = hsl.Saturation;
            V = hsl.Luminance;
            A = color.A;
        }

        public Int32 H { get; set; }
        public float S { get; set; }
        public float V { get; set; }
        public float A { get; set; } = 1;
    }

}