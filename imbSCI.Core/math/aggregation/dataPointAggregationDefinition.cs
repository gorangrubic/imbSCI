namespace imbSCI.Core.math.aggregation
{
    using System.ComponentModel;

    public class dataPointAggregationDefinition
    {

        public dataPointAggregationType this[dataPointAggregationAspect key]
        {
            get
            {
                switch (key)
                {
                    case dataPointAggregationAspect.lateralMultiTable:
                        return lateralRightColumns;
                        break;
                    case dataPointAggregationAspect.onTableMultiRow:
                        return multiRowType;
                        break;
                    case dataPointAggregationAspect.overlapMultiTable:
                        return multiTableType;
                        break;
                    case dataPointAggregationAspect.subSetOfRows:
                        return subSetOfRows;
                        break;
                    default:
                        return dataPointAggregationType.none;
                        break;
                }
            }
            set
            {
                switch (key)
                {
                    case dataPointAggregationAspect.lateralMultiTable:
                        lateralRightColumns = value;
                        break;
                    case dataPointAggregationAspect.onTableMultiRow:
                        multiRowType = value;
                        break;
                    case dataPointAggregationAspect.overlapMultiTable:
                        multiTableType = value;
                        break;
                    case dataPointAggregationAspect.subSetOfRows:
                        subSetOfRows = value;
                        break;
                    default:
                        
                        break;
                }
            }
        }

        /// <summary>
        /// Defines if some columns should be created for 
        /// </summary>
        /// <value>
        /// The lateral columns.
        /// </value>
        public dataPointAggregationType lateralRightColumns { get; set; } = dataPointAggregationType.none;
        //public dataPointAggregationType lateralLeftColumns { get; set; } = dataPointAggregationType.count;


        /// <summary>
        /// Grouped by a column
        /// </summary>
        public dataPointAggregationType subSetOfRows { get; set; } = dataPointAggregationType.none;

        /// <summary>
        /// Type to be used when multiple tables are aggregated one on top of other
        /// </summary>
        [Category("dataPointAggregationDefinition")]
        [DisplayName("multiTableType")]
        [Description("Type to be used when multiple tables are aggregated one on top of other")]
        public dataPointAggregationType multiTableType { get; set; } = dataPointAggregationType.sum;
        
        /// <summary>
        /// What types of aggregation it allows for multiRow scenario (on bottom of table)
        /// </summary>
        /// <value>
        /// The type of the multi row.
        /// </value>
        public dataPointAggregationType multiRowType { get; set; } = dataPointAggregationType.sum | dataPointAggregationType.avg;
        public int rowRangeStart { get; internal set; }
        public int rowRangeEnd { get; internal set; }
        public int columnStart { get; set; }
        public int columnEnd { get; set; }
    }
}
