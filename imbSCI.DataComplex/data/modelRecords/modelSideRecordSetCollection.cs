namespace imbSCI.DataComplex.data.modelRecords
{
    using System;
    using System.Collections;
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

    /// <summary>
    /// Collection used to store side records tracked by <see cref="modelRecordSummaryBase{TInstance, TSideInstance, TSideRecord}"/>
    /// </summary>
    /// <typeparam name="TSideInstance">The type of the side instance.</typeparam>
    /// <typeparam name="TSideRecord">The type of the side record.</typeparam>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{TSideInstance, System.Collections.Generic.List{TSideRecord}}}" />
    public class modelSideRecordSetCollection<TSideInstance, TSideRecord> : imbBindable, IEnumerable<KeyValuePair<TSideInstance, List<TSideRecord>>>
    where TSideRecord : modelRecordBase, IModelRecord
    {

        private List<TSideInstance> _sideInstances = new List<TSideInstance>();
        /// <summary> </summary>
        public List<TSideInstance> sideInstances
        {
            get
            {
                return _sideInstances;
            }
            protected set
            {
                _sideInstances = value;
                OnPropertyChanged("sideInstances");
            }
        }


        public void AddRecord(TSideInstance __instance, TSideRecord __record)
        {
            var records = GetRecords(__instance);
            records.Add(__record);
            sideInstances.Add(__instance);
        }

        public List<TSideRecord> GetRecords(TSideInstance __instance)
        {
            if (!items.ContainsKey(__instance))
            {
                items.Add(__instance, new List<TSideRecord>());
            }
            return items[__instance];
        }

        public List<TSideInstance> GetInstances()
        {
            return sideInstances.ToList();

            //return items[__instance];
        }

        private Dictionary<TSideInstance, List<TSideRecord>> _items = new Dictionary<TSideInstance, List<TSideRecord>>();
        /// <summary> </summary>
        public Dictionary<TSideInstance, List<TSideRecord>> items
        {
            get
            {
                return _items;
            }
            protected set
            {
                _items = value;
                OnPropertyChanged("items");
            }
        }

        public IEnumerator<KeyValuePair<TSideInstance, List<TSideRecord>>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TSideInstance, List<TSideRecord>>>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TSideInstance, List<TSideRecord>>>)items).GetEnumerator();
        }
    }

}