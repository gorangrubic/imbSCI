namespace imbSCI.Data.enums.tableReporting
{
    using System;

    [Flags]
    public enum dataTableSummaryRowEnum
    {
        none = 0,
        sum = 1,
        mean = 2,
        max = 4,
        min = 8,
        range = 16,
        entropy = 32,
        variance = 64,
        diversity = 128,
        distinctValueCount = 256,
        /// <summary>
        /// The last value
        /// </summary>
        theLast = 512,
        /// <summary>
        /// The first value entry
        /// </summary>
        theFirst = 1024,

    }
}