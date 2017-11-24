namespace imbSCI.DataComplex.data.modelRecords
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
    using imbSCI.DataComplex.exceptions;

    public sealed class instanceWithRecordCollection<T, TRecord> : instanceWithRecordCollectionBase<T, TRecord>, IEnumerable<KeyValuePair<T, TRecord>>
        where T : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
        where TRecord : modelRecordBase, IModelRecord
    {
        public instanceWithRecordCollection(string __testRunStamp, params T[] Algorithms) : base(__testRunStamp, Algorithms)
        {
        }


        public int Count
        {
            get
            {
                return records.Count;
            }
        }

        public TRecord GetCurrentRecord()
        {
            if (childIndexAtEnd) throw new dataException("Child index at end [" + childIndexCurrent + "]", null, this, "modelRecordCollection [" + typeof(T).Name + "]:[" + typeof(TRecord) + "]");
            return this[childIndexCurrent];
        }

        public T GetCurrentInstance()
        {
            if (childIndexAtEnd) throw new dataException("Child index at end [" + childIndexCurrent + "]", null, this, "modelRecordCollection [" + typeof(T).Name + "]:[" + typeof(TRecord) + "]");
            return items[childIndexCurrent];
        }

        /// <summary>
        /// Finishes all started children
        /// </summary>
        /// <returns></returns>
        public int FinishAllStarted()
        {
            int c = 0;
            foreach (T tr in items)
            {
                if (recordsForTest[tr].state == modelRecordStateEnum.started)
                {
                    recordsForTest[tr]._recordFinish();
                    c++;
                }
            }
            return c;
        }


        /// <summary>
        /// Moves the child index to next position. 
        /// </summary>
        /// <returns>Returns false if childIntex is at end</returns>
        public bool MoveNext()
        {
            childIndexCurrent++;
            
            return !childIndexAtEnd;
        }

        public bool ResetIndex()
        {
            childIndexCurrent = 0;

            return !childIndexAtEnd;
        }

        public bool SetIndexTo(int _index)
        {
            childIndexCurrent = _index;

            return !childIndexAtEnd;
        }

        public bool childIndexAtEnd
        {
            get
            {
                return childIndexCurrent >= items.Count();
            }
            
        }

        private int _childIndexCurrent = 0; //= new Int32();
        /// <summary> </summary>
        public int childIndexCurrent
        {
            get
            {
                return _childIndexCurrent;
            }
            protected set
            {
                _childIndexCurrent = value;
                OnPropertyChanged("childIndexCurrent");
            }
        }

    }

}