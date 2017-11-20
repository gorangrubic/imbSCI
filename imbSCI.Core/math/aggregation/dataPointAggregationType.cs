namespace imbSCI.Core.math.aggregation
{
    using System;

    [Flags]
    public enum dataPointAggregationType
    {
        none = 0,
        hidden = 1,
        lastEntry = 2,
        firstEntry = 4,
        sum = 8,
        avg = 16,
        min = 32,
        max = 64,
        /// <summary>
        /// The count of dataPoints (non null) sent to the aggregation
        /// </summary>
        count = 128,
        /// <summary>
        /// Shows the column but writes nothing
        /// </summary>
        clear = 256,
        stdev = 512,
        range = 1024,
        var = 2028,
        entropy = 4056,

        /// <summary>
        /// Value will be caption for column in multitable scenario
        /// </summary>
        groupCaption = 8112,
        rowSnap = 16224,
        


    }

}