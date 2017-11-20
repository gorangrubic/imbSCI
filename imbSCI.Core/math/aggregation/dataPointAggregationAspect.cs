namespace imbSCI.Core.math.aggregation
{

    public enum dataPointAggregationAspect
    {
        none=0,
        overlapMultiTable = 1,
        onTableMultiRow = 2,
        lateralMultiTable = 4,
        /// <summary>
        /// Sub set of some row
        /// </summary>
        subSetOfRows = 8,

        
    }

}