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
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, aceCommonTypes.extensions.data.collectionAggregationResult{T}}" />
    public class collectionAggregationResultSet<T>:Dictionary<string, collectionAggregationResult<T>> where T : class, new()
    {
        public Type recordType
        {
            get
            {
                return typeof(T);
            }
        }

        public new void Add(string key, collectionAggregationResult<T> result)
        {
            Count += result.Count;
            type = result.type;
            aspect = result.aspect;

            if (firstItem == null) firstItem = result.firstItem;
            lastItem = result.lastItem;
            base.Add(key, result);
        }

        public T firstItem { get; set; }
        public T lastItem { get; set; }

        public int Count { get; set; } = 0;

        public dataPointAggregationType type { get; set; }
        public dataPointAggregationAspect aspect { get; set; }
    }
}