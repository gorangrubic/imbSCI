namespace imbSCI.DataComplex.special
{
    using System;
    using System.Collections.Concurrent;
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

    public class instanceFreqTable<T>:changeBindableBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected ConcurrentDictionary<T, double> items { get; set; } = new ConcurrentDictionary<T, double>();
    }
}