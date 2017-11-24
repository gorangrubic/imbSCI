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

    /// <summary>
    /// Collection of dataUnitPresenter instances
    /// </summary>
    public class dataUnitPresenterDictionary
    {
        public dataUnitPresenter this[object key]
        {
            get
            {
                return items[key];
            }
            set
            {
                if (items.ContainsKey(key)) items.Remove(key);
                items.Add(key, value);
            }
        }

        /// <summary> </summary>
        public Dictionary<object, dataUnitPresenter> items { get; protected set; } = new Dictionary<object, dataUnitPresenter>();
    }

}