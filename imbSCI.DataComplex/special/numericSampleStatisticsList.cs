namespace imbSCI.DataComplex.special
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Data.enums.tableReporting;
    using imbSCI.Data;

    /// <summary>
    /// Ordinal collection of entries
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{aceCommonTypes.collection.special.numericSampleStatistics}" />
    public class numericSampleStatisticsList : List<numericSampleStatistics>, IDataTableBuilderCollection, IObjectWithNameAndDescription
    {
        /// <summary>
        /// Name for this instance
        /// </summary>
        public string name { get; set; } = "";

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public string description { get; set; } = "";

        public numericSampleStatisticsList(string __name, string __description)
        {
            name = __name;
            description = __description;
        }
        /// <summary>
        /// Starts new record in the list
        /// </summary>
        public void StartNew()
        {
            if (Count > 0)
            {
                Current().reCalculate();
            }
            Add(new numericSampleStatistics(Count));
        }

        public numericSampleStatistics Current()
        {
            if (Count == 0) return null;
            if (this[Count - 1] != null) this[Count - 1].reCalculate(instanceCountCollection<int>.preCalculateTasks.all);
            return this[Count - 1];
        }

        /// <summary>
        /// Makes new <see cref="numericSampleStatistics"/> by aggregating values designated by <c>whatToSummarize</c> parameter
        /// </summary>
        /// <param name="whatToSummarize">The what to summarize.</param>
        /// <returns></returns>
        public numericSampleStatistics GetSummary(dataTableSummaryRowEnum whatToSummarize)
        {
            numericSampleStatistics summary = new numericSampleStatistics(-1);
            summary.name = "Statistics of [" + whatToSummarize.ToString() + "] from [" + name + "][" + Count + "]";

            summary.name = "Descriptive aggregation of [" + whatToSummarize.ToStringEnumSmart() + "] values collected from n:[" + Count + "] entries of the [" + name + "] collection";

            if (whatToSummarize.getEnumListFromFlags<dataTableSummaryRowEnum>().Count>1)
            {
                string msg="Can't mix multiple kinds [" + whatToSummarize.ToString() + "] of variables in one summary. Use only one flag for " + nameof(whatToSummarize) +" parameters.";
                var ase = new ArgumentException(msg + "Forbiden mix of inputs [" + whatToSummarize.ToString() + "]");
                throw ase;
            }

            foreach (numericSampleStatistics row in this)
            {
                switch (whatToSummarize)
                {
                    case dataTableSummaryRowEnum.theFirst:
                        summary.Add(row.FirstOrDefault());
                        break;
                    case dataTableSummaryRowEnum.distinctValueCount:
                        summary.Add(row.Count);
                        break;
                    case dataTableSummaryRowEnum.mean:
                        summary.Add(row.avgValue);
                        break;
                    case dataTableSummaryRowEnum.min:
                        summary.Add(row.minValue);
                        break;
                    case dataTableSummaryRowEnum.max:
                        summary.Add(row.maxValue);
                        break;
                    case dataTableSummaryRowEnum.sum:
                        summary.Add(row.sumOfValues);
                        break;
                    case dataTableSummaryRowEnum.range:
                        summary.Add(row.range);
                        break;
                    case dataTableSummaryRowEnum.entropy:
                        summary.Add(row.entropyFreq);
                        //throw new aceScienceException("Entropy makes no sense if summed", null, this, "Statistics non-sesense");
                        break;
                    case dataTableSummaryRowEnum.diversity:
                        summary.Add(row.diversityRatio);
                        break;
                    case dataTableSummaryRowEnum.variance:
                        summary.Add(row.varianceFreq);
                        break;
                    case dataTableSummaryRowEnum.theLast:
                        summary.Add(row.LastOrDefault());
                        break;
                }
                
            }

            return summary;
        }

       
        /*
        public DataTable GetCrossLinkStats(dataTableDeliveryEnum format, dataTableSummaryRowEnum whatToSummarize=dataTableSummaryRowEnum.none)
        {
            if (format.HasFlag(dataTableDeliveryEnum.horizontal | dataTableDeliveryEnum.collection))
            {
                return getDataTableHorizontal();
            }

            if (format.HasFlag(dataTableDeliveryEnum.comparative))
            {
                return getDataTableComparative();
            }

            if (format.HasFlag(dataTableDeliveryEnum.singleRow | dataTableDeliveryEnum.vertical))
            {
                return Current().getDataTableVertical();
            }

            if (format.HasFlag(dataTableDeliveryEnum.verticalCalculatedSummary))
            {
                numericSampleStatistics summary = GetSummary(dataTableSummaryRowEnum.entropy)
                return Current().getDataTableVertical();
            }
        }*/

        public DataTable getDataTableComparative()
        {
            return Current().getDataTableComparative(this);
        }

        public DataTable getDataTableHorizontal()
        {
            return Current().getDataTableHorizontal(this);
        }
    }
}