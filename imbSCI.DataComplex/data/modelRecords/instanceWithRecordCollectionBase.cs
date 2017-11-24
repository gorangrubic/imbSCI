namespace imbSCI.DataComplex.data.modelRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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
    using imbSCI.DataComplex.exceptions;

    /// <summary>
    /// Collection of algorithm instances with coresponding <see cref="modelRecordParentBase"/> records, indexed by algorithm <see cref="IObjectWithNameAndDescription"/> that produces it
    /// </summary>
    /// <typeparam name="T">Any object with name and description properties</typeparam>
    /// <typeparam name="TRecord">The type of the record.</typeparam>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public abstract class instanceWithRecordCollectionBase<T, TRecord> : modelRecordCollection<T, TRecord>, IEnumerable<KeyValuePair<T, TRecord>>
        where T : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
        where TRecord : modelRecordBase, IModelRecord
    {

        protected Dictionary<int, ConstructorInfo> constDict = new Dictionary<int, ConstructorInfo>();


        private object createRecordLock = new object();
        protected override TRecord CreateRecord(T item)
        {
            lock (createRecordLock)
            {
                if (constDict.Count == 0)
                {
                    Type rType = typeof(TRecord);


                    ConstructorInfo[] cInfos = rType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var ci in cInfos)
                    {
                        var cps = ci.GetParameters();
                        int c = cps.count();
                        constDict.Add(c, ci);
                    }
                }
            }

            if (constDict.ContainsKey(2))
            {
                return (TRecord)constDict[2].Invoke(new object[] { testRunStamp, item });
            }

            if (constDict.ContainsKey(1))
            {
                return (TRecord)constDict[1].Invoke(new object[] { item });
            }

            if (constDict.ContainsKey(0))
            {
                return (TRecord)constDict[0].Invoke(null);
            }

            return (TRecord)typeof(TRecord).getInstance(); //.CreateInstance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="instanceWithRecordCollectionBase{T, TRecord}"/> class.
        /// </summary>
        /// <param name="__testRunStamp">The test run stamp.</param>
        /// <param name="Algorithms">The items to create records for.</param>
        protected instanceWithRecordCollectionBase(string __testRunStamp, params T[] Algorithms):base()
        {
            testRunStamp = __testRunStamp;
            foreach (T Algorithm in Algorithms)
            {
                Add(Algorithm);
            }

        }
        
        /// <summary>
        /// Gets the record using one of supplied arguments. 
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="instanceID">Instance identifier - it will be tested against algorithm's <see cref="IObjectWithName.name"/>, <see cref="Type"/> name and against <see cref="IModelRecord.instanceID"/>, <see cref="IModelRecord.UID"/> </param>
        /// <param name="__UID">The uid.</param>
        /// <returns></returns>
        public override TRecord SeachForRecord(T algorithm=null, string instanceID="")
        {
            if (algorithm != null) return this[algorithm];
            if (!instanceID.isNullOrEmpty())
            {
                foreach (KeyValuePair<T, TRecord> kpair in this)
                {
                    if (kpair.Key.name == instanceID) return kpair.Value;
                    if (kpair.Key.GetType().Name == instanceID) return kpair.Value;
                    if (kpair.Value.instanceID == instanceID) return kpair.Value;
                    if (kpair.Value.UID == instanceID) return kpair.Value;
                }
            }

            if (DO_EXCEPTIONS) throw new dataException("No valid arguments supplied. At least one argument must be valid [null or empty string] to find the record in the collection");

            return null;
        }

        /// <summary>
        /// Gets instance of specified type
        /// </summary>
        /// <typeparam name="TSearch">The type of the search.</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Algorithm of type: " + typeof(TSearch).Name + " not found in the collection</exception>
        public TSearch GetAlgorithm<TSearch>() where TSearch:T
        {
            foreach (TSearch i in items)
            {
                if (i is TSearch) return (TSearch)i;
            }

            if (DO_EXCEPTIONS) throw new ArgumentException("Algorithm of type: " + typeof(TSearch).Name + " not found in the collection");


            return default(TSearch);
        }
        
    }

}