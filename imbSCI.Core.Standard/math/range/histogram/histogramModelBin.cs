using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using imbSCI.Core.extensions.table;
using imbSCI.Core.math.range.finder;

namespace imbSCI.Core.math.range.histogram
{

    /// <summary>
    /// 
    /// </summary>
    public class histogramModelBin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="histogramModelBin"/> class.
        /// </summary>
        /// <param name="_lavel">The lavel.</param>
        /// <param name="_start">The start.</param>
        /// <param name="_end">The end.</param>
        /// <param name="_binPlace">The bin place.</param>
        public histogramModelBin(String _lavel, Double _start, Double _end, Int32 _binPlace) {

            Label = _lavel;
            start = _start;
            end = _end;
            binPlace = _binPlace;

        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public String Label { get; set; }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public Double start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public Double end { get; set; }

        /// <summary>
        /// Gets or sets the bin place.
        /// </summary>
        /// <value>
        /// The bin place.
        /// </value>
        public Int32 binPlace { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public List<Double> values { get; set; } = new List<double>();

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Boolean Add(Double value)
        {
            if (value > start && value <= end)
            {
                values.Add(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public Int32 Count
        {
            get
            {
                return values.Count;
            }
        }

    }

}