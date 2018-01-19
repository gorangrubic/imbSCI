using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using imbSCI.Core.data;
using imbSCI.Data.collection.special;
using imbSCI.DataComplex.special;
using imbSCI.Core.math;
using imbSCI.Core.reporting.colors;
using System.Xml.Serialization;

namespace imbSCI.Graph.Converters.tools
{

    /// <summary>
    /// Graph styler
    /// </summary>
    public class GraphStylerSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphStylerSettings"/> class.
        /// </summary>
        public GraphStylerSettings()
        {

        }

        public Boolean doMakeLinkLabel { get; set; } = true;

        public Boolean doLinkDirectionFromLowerTypeToHigher { get; set; } = true;
        public Boolean doAddNodeTypeToLabel { get; set; } = true;

        public String NodeWeightFormat { get; set; } = "F5";
        public String LinkWeightFormat { get; set; } = "F2";

        /// <summary>
        /// The colors
        /// </summary>
        public List<Color> colors = new List<Color>();

        /// <summary>
        /// Gets or sets the alpha maximum.
        /// </summary>
        /// <value>
        /// The alpha maximum.
        /// </value>
        public Double alphaMax { get; set; } = 1;
        /// <summary>
        /// Gets or sets the alpha minimum.
        /// </summary>
        /// <value>
        /// The alpha minimum.
        /// </value>
        public Double alphaMin { get; set; } = 0.5;

        /// <summary>
        /// Gets or sets the line minimum.
        /// </summary>
        /// <value>
        /// The line minimum.
        /// </value>
        public Int32 lineMin { get; set; } = 1;
        /// <summary>
        /// Gets or sets the line maximum.
        /// </summary>
        /// <value>
        /// The line maximum.
        /// </value>
        public Int32 lineMax { get; set; } = 3;

        private circularSelector<Color> _colorWheel = null;

        [XmlIgnore]
        public circularSelector<Color> colorWheel
        {
            get
            {
                if (_colorWheel == null)
                {
                    _colorWheel = new circularSelector<Color>();
                    var cls = new List<Color>();
                    cls.AddRange(colors);
                    if (!cls.Any())
                    {
                        cls.AddRange(new Color[] {  Color.Orange, Color.Teal, Color.Gray, Color.SeaGreen, Color.SteelBlue, Color.OrangeRed, Color.DarkOrange,
    Color.SlateBlue});
                    }
                    cls.ForEach(x => _colorWheel.Add(x));
                }
                return _colorWheel;
            }
        }


    }

}