namespace imbSCI.Core.collection
{
    using imbSCI.Core.extensions.data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PropertyCollectionHistoryRecord 
    {

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            throw new NotImplementedException("-- not implemented yet --");
            // var columns = shema.buildColumnDictionary(PropertyEntryColumn.entry_name, PropertyEntryColumn.entry_value, PropertyEntryColumn.entry_description);
            // DataTable output = columns.buildDataTableVertical("", "", timeSeries.Values);
            return null; // output;
        }

        /// <summary>
        /// Gets the data for entry.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public PropertyCollectionExtended getDataForEntry(Int32 key)
        {
            if (timeSeries.Count() < key) new ArgumentOutOfRangeException("key", "Larger then timeseries");
            PropertyCollectionExtended output = new PropertyCollectionExtended();
            output.AddRange(shema, false, false, false);
            output.AddRange(timeSeries[key], false);
            return output;
        }

        private PropertyCollectionExtended _shema = new PropertyCollectionExtended();
        /// <summary>
        /// Gets or sets the shema.
        /// </summary>
        /// <value>
        /// The shema.
        /// </value>
        public PropertyCollectionExtended shema
        {
            get { return _shema; }
            protected set { _shema = value; }
        }

        public void Add(PropertyCollection data)
        {
            if (!timeSeries.ContainsValue(data))
            {
                timeSeries.Add(timeSeries.Count(), data);
            }
            
        }

        public void Add(Int32 key, PropertyCollection data)
        {
            if (timeSeries.ContainsKey(key))
            {
                timeSeries[key].AddRange(data);
            } else
            {
                timeSeries.Add(key, data);
            }
        }
       

        private Dictionary<Int32, PropertyCollection> _timeSeries = new Dictionary<Int32, PropertyCollection>();
        /// <summary> </summary>
        public Dictionary<Int32, PropertyCollection> timeSeries
        {
            get
            {
                return _timeSeries;
            }
            protected set
            {
                _timeSeries = value;

            }
        }

    }

}