namespace imbSCI.DataComplex.trends
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

    public class measureTrendTaker<T> : measureTrendTaker where T : class, IPerformanceTake, new()
    {
        internal Func<T, double> selector { get; set; }

        public measureTrendTaker(Func<T, double> __selector, string __name, string __unit, int __macroSampleSize, int __microSampleSize = -1, int __spearSampleSize = -1, double __zeroMargin = -1):base(__name, __unit, __macroSampleSize, __microSampleSize, __spearSampleSize, __zeroMargin)
        {
            selector = __selector;
        }
    }

}