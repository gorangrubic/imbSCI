using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Node Weight styler
    /// </summary>
    public class NodeWeightStyler
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeWeightStyler"/> class.
        /// </summary>
        /// <param name="_type">The type.</param>
        /// <param name="_color">The color.</param>
        public NodeWeightStyler(Int32 _type, Color _color)
        {
            type = _type;
            color = _color;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Int32 type { get; set; } = 0;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color color { get; set; }


        /// <summary>
        /// Gets the thickness.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public Int32 GetThickness(Double weight, GraphStylerSettings s)
        {
            Double w = weight - min;
            w = w.GetRatio(range);

            w = s.lineMin+ ((s.lineMax - s.lineMin) * s.lineMax);

            return Convert.ToInt32(w);
        }


        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public Byte GetAlpha(Double weight, GraphStylerSettings s)
        {
            Double w = weight - min;
            w = w.GetRatio(range);
            w = s.alphaMin + ((s.alphaMax - s.alphaMin) * w);
            Byte b = Convert.ToByte(w * Byte.MaxValue);
            return b;
        }



        /// <summary>
        /// Learns the specified weight.
        /// </summary>
        /// <param name="weight">The weight.</param>
        public void learn(Double weight)
        {
            min = Math.Min(weight, min);
            max = Math.Max(weight, max);
            range = max - min;
        }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public Double range { get; set; } = 0;
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public Double min { get; set; } = Double.MaxValue;
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public Double max { get; set; } = Double.MinValue;



    }
}
