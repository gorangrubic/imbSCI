using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;


using Accord;

using imbSCI.Core.reporting.colors;
using AForge.Imaging;
using System.Xml.Serialization;
using imbSCI.Core.math;

namespace imbSCI.Graph.Converters.tools
{


    public class ColorGradient
    {

        public static ColorGradient RedBlueAtoBPreset { get { return new ColorGradient("#FFD82323", "#FF224ECA", ColorGradientFunction.AllAToB); } }

        public static ColorGradient BlueGreenAtoBPreset
        {
            get
            {
                return new ColorGradient("#FF2258D8", "#FF7FCA23", ColorGradientFunction.AllAToB);
            }
        }

        public static ColorGradient BlueGrayAtoBPreset
        {
            get
            {
                return new ColorGradient("#FF1040B6", "#FF353535", ColorGradientFunction.AllAToB);
            }
        }

        public static ColorGradient ColorCircleCW
        {
            get
            {
                return new ColorGradient("#FF3b25a7", "#FF72a725", ColorGradientFunction.HueAToB);
            }
        }

        public ColorGradient()
        {

        }

        public ColorGradient(String HexA, String HexB, ColorGradientFunction options)
        {
            HexColorA = HexA;
            HexColorB = HexB;
            gradient = options;
            Prepare();
        }


        /// <summary>
        /// Gets the color of the hexadecimal.
        /// </summary>
        /// <param name="ratio">The ratio: from 0 to 1</param>
        /// <returns></returns>
        public String GetHexColor(Double ratio, Boolean withAlpha=true)
        {
            ratio = ratio % 1;

            if (!IsReady) Prepare();


            var r = PointRange * ratio;

            var output = PointA.Clone();

            if (gradient.HasFlag(ColorGradientFunction.CircleCW))
            {

            } else if (gradient.HasFlag(ColorGradientFunction.CircleCCW))
            {

            }

            if (gradient.HasFlag(ColorGradientFunction.Hue)) output.H = output.H + r.H;

            if (gradient.HasFlag(ColorGradientFunction.Value)) output.V = output.V + r.V;

            if (gradient.HasFlag(ColorGradientFunction.Saturation)) output.S = output.S + r.S;

            if (gradient.HasFlag(ColorGradientFunction.Alpha)) output.A = output.A + r.A;

            output.DeployValues();


            return r.GetHexColor(withAlpha);
        }

       

        /// <summary>
        /// Gets the hexadecimal color dictionary - where Key is color, Double is upper limit for the color segment
        /// </summary>
        /// <param name="colorSegments">The color segments.</param>
        /// <param name="withAlpha">if set to <c>true</c> [with alpha].</param>
        /// <returns></returns>
        public ColorGradientDictionary GetHexColorDictionary(Int32 colorSegments, Boolean withAlpha = true)
        {
            var output = new ColorGradientDictionary();

            if (colorSegments < 1) return output;
            Double c = 1.GetRatio(colorSegments);
            Double ci = c;

            var r = PointRange.GetRangeMultiplied(c);

            var head = PointA.Clone();


            if (!IsReady) Prepare();

            for (int i = 0; i < colorSegments; i++)
            {

                if (gradient.HasFlag(ColorGradientFunction.Hue)) head.H = head.H + r.H;

                if (gradient.HasFlag(ColorGradientFunction.Value)) head.V = head.V + r.V;

                if (gradient.HasFlag(ColorGradientFunction.Saturation)) head.S = head.S + r.S;

                if (gradient.HasFlag(ColorGradientFunction.Alpha)) head.A = head.A + r.A;

                head.DeployValues();


                var ci_hex = head.GetHexColor();
                if (!output.ContainsKey(ci_hex)) output.Add(ci_hex, ci);
                ci = ci + c;
            }


            return output;
        }

        protected void Prepare()
        {
            PointA = new ColorHSVPoint(HexColorA);
            PointB = new ColorHSVPoint(HexColorB);

            PointRange = PointA.GetRange(PointB);


            if (gradient.HasFlag(ColorGradientFunction.CircleCW))
            {
                PointRange.H = 360;
            } else if (gradient.HasFlag(ColorGradientFunction.CircleCCW)) {
                PointRange.H = - 360;
            }


            
        }

        protected ColorHSVPoint PointA { get; set; } = null;
        protected ColorHSVPoint PointB { get; set; } = null;

        protected ColorHSVPoint PointRange { get; set; } = null;

        [XmlIgnore]
        public Boolean IsReady { get
            {
                if (PointA == null) return false;
                if (PointB == null) return false;
                return true;
            }
        }

        public ColorGradientFunction gradient { get; set; } = ColorGradientFunction.HueSaturationAToB;


        public String HexColorA { get; set; } = "#D82323";

        public String HexColorB { get; set; } = "#224ECA";

    }
}
