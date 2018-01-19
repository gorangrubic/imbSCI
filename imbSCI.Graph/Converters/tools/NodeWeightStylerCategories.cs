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
    /// Managing styles for different categories
    /// </summary>
    public class NodeWeightStylerCategories
    {

        public NodeWeightStylerCategories(GraphStylerSettings _settings = null)
        {
            if (_settings != null) settings = _settings;
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public GraphStylerSettings settings { get; set; } = new GraphStylerSettings();

        protected Dictionary<Int32, NodeWeightStyler> stylers = new Dictionary<int, NodeWeightStyler>();

        /// <summary>
        /// Learns the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="weight">The weight.</param>
        public void learn(Int32 type, Double weight)
        {
            if (!stylers.ContainsKey(type))
            {
                stylers.Add(type, new NodeWeightStyler(type, settings.colorWheel.next()));
            }

            stylers[type].learn(weight);
        }

        /// <summary>
        /// Gets the border thickness.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public Int32 GetBorderThickness(Double weight, Int32 type, Boolean inverse = false)
        {
            if (inverse)
            {
                return Math.Abs(settings.lineMax - stylers[type].GetThickness(weight, settings));
            }
            return Math.Abs(stylers[type].GetThickness(weight, settings));
        }

        /// <summary>
        /// Gets the color of the hexadecimal.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public String GetHexColor(Double weight, Int32 type, Boolean inverse = false)
        {
            Byte a = stylers[type].GetAlpha(weight, settings);


            if (inverse) a = (byte)(Byte.MaxValue - a);
            var col = aceColorConverts.toMediaColor(stylers[type].color);
            col.A = a;
            return col.toHexColor();

        }

    }

}