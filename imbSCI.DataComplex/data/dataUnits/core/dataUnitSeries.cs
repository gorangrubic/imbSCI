namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    using imbSCI.DataComplex.data.dataUnits.enums;

    /// <summary>
    /// Base data unit for time/ordinal series representation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class dataUnitSeries<T, TInstance> :dataUnitBase, IdataUnitSeries where T: dataUnitRow<TInstance>, IDataUnitSeriesEntry, new()
        where TInstance:class
    {


        /// <summary> </summary>
        protected List<T> items
        {
            get
            {
                return _items as List<T>;
            }
             set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Gets the current entry - if exists
        /// </summary>
        /// <value>
        /// The current entry.
        /// </value>
        public IDataUnitSeriesEntry currentEntry
        {
            get
            {
                return items.Last();
            }
        }

        public IDataUnitSeriesEntry GetFirstEntry()
        {
                       
                if (items.Count < 1) return null;
                return items[0];
            
        }

        /// <summary>
        /// Gets the last entry - if there are less then two entries it will return null
        /// </summary>
        /// <value>
        /// The last entry.
        /// </value>
        public IDataUnitSeriesEntry lastEntry
        {
            get
            {
                if (items.Count < 2) return null;
                return items[items.Count() - 2];
            }
        }

        public IDataUnitSeriesEntry lastDataPair
        {
            get
            {
                if (items.Count > 1)
                {
                    return this[items.Count() - 2];
                }
                return null;
            }
        }


        public T CreateEntry(TInstance source=null, int iSync=0)
        {
            T entry = null;
            int iter = 0;
            do
            {
                iter = items.Count();
                
                entry = new T();

                items.Add(entry);
                entry.iteration = iter;
                entry.prepare(map.monitor, this);

                if (source != null)
                {
                    entry.setData(source);
                }
                else
                {

                }
                map.monitor.unlock();
            } while (iter < iSync);

            return entry;
        }

        public List<T> GetData()
        {
            return items.ToList();
        }

        public DataTable GetTableWith(dataUnitPresenter presenter, bool isPreview = false)
        {
            return buildCustomDataTable(items, presenter, isPreview);
        }


        /// <summary>
        /// Gets the <see cref="T"/> with the specified iteration.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="iteration">The iteration.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">iteration - Larger then timeseries</exception>
        public T this[int iteration]
        {
            get
            {
                if (items.Count() < iteration) throw new ArgumentOutOfRangeException("iteration", "Larger then timeseries");
                return items[iteration];
            }
            
        }

        public dataUnitSeries(dataDeliveryAcquireEnum acquire, int __length):base(typeof(TInstance))
        {
            dataAcquireFlags = acquire;

            items = new List<T>();

        }
    }

}