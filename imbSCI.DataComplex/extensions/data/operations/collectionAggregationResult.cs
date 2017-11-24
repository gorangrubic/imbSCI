namespace imbSCI.DataComplex.extensions.data.operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.math.aggregation;

    /// <summary>
    /// Results of collection aggregation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.Dictionary{aceCommonTypes.math.aggregation.dataPointAggregationType, T}" />
    public class collectionAggregationResult<T>:Dictionary<dataPointAggregationType, T> where T:class, new()
    {
        public T firstItem { get; set; }
        public T lastItem { get; set; }

        public int Count { get; set; } = 0;

        public dataPointAggregationType type { get; set; }
        public dataPointAggregationAspect aspect { get; set; }
    }
}