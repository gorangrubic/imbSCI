namespace imbSCI.DataComplex.special
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        /// 
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <seealso cref="imbSCI.Data.data.dataBindableBase" />
        public class translationTable<TKey, TValue> : dataBindableBase
    {

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return byKeys.Count;
            }
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public virtual void Add(TKey key, TValue value)
        {
            if (!_byKeys.ContainsKey(key))
            {
                byKeys.TryAdd(key, value);
                //return;
            }
            if (!_byValues.ContainsKey(value))
            {
                byValues.TryAdd(value, key);
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="notfound">The notfound.</param>
        /// <returns></returns>
        public virtual TValue getValue(TKey key, TValue notfound)
        {
            if (byKeys.ContainsKey(key))
            {
                return byKeys[key];
            } else
            {
                return notfound;
            }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="notfound">The notfound.</param>
        /// <returns></returns>
        public virtual TKey getKey(TValue value, TKey notfound)
        {
            if (byValues.ContainsKey(value))
            {
                return byValues[value];
            }
            else
            {
                return notfound;
            }
        }


        #region -----------  byValues  -------  [recnik kljuceva prema objektima]
        private ConcurrentDictionary<TValue, TKey> _byValues = new ConcurrentDictionary<TValue, TKey>();
        /// <summary>
        /// recnik kljuceva prema objektima
        /// </summary>
        // [XmlIgnore]
        [Category("translationTable")]
        [DisplayName("byValues")]
        [Description("recnik kljuceva prema objektima")]
        public ConcurrentDictionary<TValue, TKey> byValues
        {
            get
            {
                return _byValues;
            }
            set
            {
                // Boolean chg = (_byValues != value);
                _byValues = value;
                OnPropertyChanged("byValues");
                // if (chg) {}
            }
        }
        #endregion
        

        #region -----------  byKeys  -------  [recnik objekata prema kljucevima]
        private ConcurrentDictionary<TKey, TValue> _byKeys = new ConcurrentDictionary<TKey, TValue>();
        /// <summary>
        /// recnik objekata prema kljucevima
        /// </summary>
        // [XmlIgnore]
        [Category("translationTable")]
        [DisplayName("byKeys")]
        [Description("recnik objekata prema kljucevima")]
        public ConcurrentDictionary<TKey, TValue> byKeys
        {
            get
            {
                return _byKeys;
            }
            set
            {
                // Boolean chg = (_byKeys != value);
                _byKeys = value;
                OnPropertyChanged("byKeys");
                // if (chg) {}
            }
        }
        #endregion
        
    }
}
