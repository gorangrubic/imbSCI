namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
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

    [Flags]
    public enum monitoringFunctionEnum
    {
        none = 0,

        summary = 2,
        /// <summary>
        /// The stability: adds +1 if value is above 0 and didn't change
        /// </summary>
        stability = 4,

        /// <summary>
        /// The change: calculates difference between earlier value and the current
        /// </summary>
        change = 8,


        final = 16,

        max = 32,

        min = 64,

        maxFreq = 128,

        minFreq = 256,


    }

}