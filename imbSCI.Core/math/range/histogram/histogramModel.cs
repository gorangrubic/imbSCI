using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using imbSCI.Core.extensions.table;
using imbSCI.Core.math.range.finder;

namespace imbSCI.Core.math.range.histogram
{


    /// <summary>
    /// Splits sampled data into <see cref="bins"/> bins, with equal value span.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbSCI.Core.math.range.histogram.histogramModelBin}" />
    public class histogramModel:IEnumerable<histogramModelBin> // where T:class
    {

        //  public Func<Object, double> valueSelector { get; set; }

        /// <summary>
        /// Gets the <see cref="histogramModelBin"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="histogramModelBin"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public histogramModelBin this[Int32 key]=>bins[key];

        /// <summary>
        /// Initializes a new instance of the <see cref="histogramModel"/> class.
        /// </summary>
        public histogramModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="histogramModel"/> class.
        /// </summary>
        /// <param name="_binCount">The bin count.</param>
        /// <param name="_name">The name.</param>
        public histogramModel(Int32 _binCount, String _name)
        {
            name = _name;
            targetBins = _binCount;
        }

        public String name { get; set; } = "histogram";

        internal void processData()
        {
            Double binSize = ranger.Range.GetRatio(targetBins);

            for (int i = 0; i < targetBins; i++)
            {
                Double binStart = ranger.Minimum + (binSize * i);
                Double binEnd =  binStart + (binSize);
                String binLabel = binLabelPrefix + binStart.ToString(binBorderFormat);
                if (!binLabelOnlyStart)
                {
                    binLabel = "→" + binEnd.ToString(binBorderFormat);
                }
                binLabel = binLabel + binLabelSuffix;
                bins.Add(new histogramModelBin(binLabel, binStart, binEnd, i));
            }

            foreach (Double vl in ranger.doubleEntries)
            {
                foreach (var bin in bins)
                {
                    if (bin.Add(vl)) break;
                }
            }
        }

        public const string DEFAULT_COLUMN_NAME = "name";
        public const string DEFAULT_COLUMN_VALUE = "value";

        public DataTable GetDataTableForFrequencies(DataTable output=null)
        {
            if (output==null) output = new DataTable();
            output.SetTitle(name);

            var cn_name = output.Columns.Add(DEFAULT_COLUMN_NAME);
            var cn_value = output.Columns.Add(DEFAULT_COLUMN_VALUE);

            foreach (var bin in bins)
            {
                var dr = output.NewRow();

                dr[cn_name] = bin.Label;
                dr[cn_value] = bin.values.Count;

                output.Rows.Add(dr);
            }


            return output;
        }

        public IEnumerator<histogramModelBin> GetEnumerator()
        {
            return ((IEnumerable<histogramModelBin>)bins).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<histogramModelBin>)bins).GetEnumerator();
        }

        public List<histogramModelBin> bins { get; protected set; } = new List<histogramModelBin>();
        
        //protected double SelectData(object source)
        //{
        //    if (source is T)
        //    {
        //        return valueSelector(source as T);
        //    }
        //    else
        //    {
        //        return Double.MinValue;
        //    }
        //}

        public Int32 targetBins { get; set; } = 10;

        public rangeFinderWithData ranger { get; protected set; } = new rangeFinderWithData();

        public String binLabelPrefix { get; set; } = "Bin ";
        public String binLabelSuffix { get; set; } = "";
        public String binBorderFormat { get; set; } = "F1";
        public Boolean binLabelOnlyStart { get; set; } = true;

        

    }

   
}
