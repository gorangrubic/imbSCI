using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.reporting.style.core;
using imbSCI.Core.reporting.style.shot;
using imbSCI.Core.style.color;
using imbSCI.Core.reporting.colors;
using imbSCI.Data.collection.nested;
using System.Text;

using System.Drawing;
using imbSCI.Core.reporting.style.enums;

using imbSCI.Core.extensions.data;
using imbSCI.Core.reporting.zone;
using System.Xml.Serialization;
using imbSCI.Core.files;

namespace imbSCI.Graph.Graphics.HeatMap
{

    /// <summary>
    /// Heat map rendering style
    /// </summary>
    public class HeatMapRenderStyle
    {
        public HeatMapRenderOptions options { get; set; } = HeatMapRenderOptions.addVerticalValueScale | HeatMapRenderOptions.addHorizontalLabels | HeatMapRenderOptions.addVerticalLabels;

        //public ColorGradient fieldGradient { get; set; } = ColorGradient.RedBlueAtoBPreset;

        public Color BaseColor { get; set; } = Color.Black;

        [XmlIgnore]
        public styleTextFontSingle axisText { get; set; } = new styleTextFontSingle();

        [XmlIgnore]
        public styleContainerShot fieldContainer { get; set; } = new styleContainerShot();

        public Int32 fieldWidth { get; set; } = 50;

        public Int32 fieldHeight { get; set; } = 50;

        public Double minimalOpacity { get; set; } = 0;

        public String valueFormat { get; set; } = "F1";
        /// <summary>
        /// Number of letters in key accronims
        /// </summary>
        /// <value>
        /// The length of the accronim.
        /// </value>
        public Int32 accronimLength { get; set; } = 3;

        public HeatMapRenderStyle Clone()
        {
            String xml = objectSerialization.ObjectToXML(this);
            var output = objectSerialization.ObjectFromXML<HeatMapRenderStyle>(xml);
            output.axisText = axisText;
            output.fieldContainer = fieldContainer;
            return output;
        }


        public HeatMapRenderStyle()
        {
            axisText.Color = Color.DarkGray;
            

            fieldContainer.aligment = textCursorZoneCorner.center;
            fieldContainer.minSize = new styleSize(fieldWidth, fieldHeight);
            fieldContainer.numberFormat = valueFormat;
            fieldContainer.sizeAndBorder.setup(1, 1, Color.White, 3, styleBorderType.Thick, styleSideDirection.bottom, styleSideDirection.top, styleSideDirection.left, styleSideDirection.right);


        }
    }

}