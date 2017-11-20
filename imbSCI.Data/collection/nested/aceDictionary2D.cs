namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
// using aceCommonTypes.extensions;
    //   using aceCommonTypes.extensions.enumworks;


    /// <summary>
    /// 2D dictionary with automatic dimension dictionary management.
    /// </summary>
    /// <typeparam name="TD1Key">The type of the d1 key - the key of the first dimension.</typeparam>
    /// <typeparam name="TD2Key">The type of the d2 key - the key of the second dimension.</typeparam>
    /// <typeparam name="TValue">The type of the value - the value stored in 2D matrix</typeparam>
    public class aceDictionary2D<TD1Key, TD2Key, TValue>:IEnumerable<KeyValuePair<TD1Key, ConcurrentDictionary<TD2Key, TValue>>>
    {

        public Boolean ContainsKey(TD1Key key1)
        {
            return items.ContainsKey(key1);
        }

        /// <summary>
        /// Gets the count of the first dimension entries
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public Int32 Count
        {
            get
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Determines whether contains key in second dimension of Key2, returns false if even key1 is not contained
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="key2">The key2.</param>
        /// <returns>
        ///   <c>true</c> if [contains key d2] [the specified key1]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean ContainsKey2InKey1(TD1Key key1, TD2Key key2)
        {
            if (!ContainsKey(key1)) return false;
            return items[key1].ContainsKey(key2);
            
        }

        public Boolean ContainsKey2AnyKey1(TD2Key key2)
        {
            foreach (var column in items)
            {
                if (column.Value.ContainsKey(key2)) return true;
            }
            return false;
        }

        /// <summary>
        /// Access to stored 2D value. Returns <see cref="TValue"/> default value if not defined within the matrix
        /// </summary>
        /// <value>
        /// The <see cref="TValue"/>.
        /// </value>
        /// <param name="key1">The key1.</param>
        /// <param name="key2">The key2.</param>
        /// <returns></returns>
        public TValue this[TD1Key key1, TD2Key key2]
        {
            get
            {
                return getForKeys(key1, key2);
            }
            set
            {
                setForKeys(key1, key2, value);
            }
        }

        public List<TD2Key> Get2ndKeys(TD1Key key1)
        {
            return items[key1].Keys.ToList();
        }

        public List<TD1Key> Get1stKeys()
        {
            return items.Keys.ToList();
        }

        /// <summary>
        /// Accessing whole nested dimension. Get will return dictionary with reference, Set will not replace existing dimension but update if with all <see cref="KeyValuePair{TKey, TValue}"/> pairs.
        /// </summary>
        /// <value>
        /// The <see cref="Dictionary{TD2Key, TValue}"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ConcurrentDictionary<TD2Key, TValue> this[TD1Key key]
        {
            get
            {
                return getOrMakeForKey1(key);
            }
            set
            {
                if (getOrMakeForKey1(key) == value) return;

                foreach (var pair in value)
                {
                    setForKeys(key, pair.Key, pair.Value);
                }
            }
        }

        private ConcurrentDictionary<TD2Key, TValue> getOrMakeForKey1(TD1Key key1)
        {
            ConcurrentDictionary<TD2Key, TValue> output = null;
            while(!items.TryGetValue(key1, out output))
            {
                if (!items.ContainsKey(key1))
                {
                    items.TryAdd(key1, new ConcurrentDictionary<TD2Key, TValue>());
                }
                Thread.SpinWait(1);
            }
            return output;
        }

        private TValue getForKeys(TD1Key key1, TD2Key key2)
        {
            var forKey1 = getOrMakeForKey1(key1);

            TValue output = default(TValue);

            while (!forKey1.TryGetValue(key2, out output))
            {
                if (!forKey1.ContainsKey(key2))
                {
                    forKey1.TryAdd(key2, default(TValue));
                }
                Thread.SpinWait(1);
            }

            return output;
        }

        private void setForKeys(TD1Key key1, TD2Key key2, TValue item)
        {
            var forKey1 = getOrMakeForKey1(key1);
            if (!forKey1.ContainsKey(key2))
            {
                forKey1.TryAdd(key2, item);
            } else
            {
                forKey1[key2] = item;
            }
        }

        public IEnumerator<KeyValuePair<TD1Key, ConcurrentDictionary<TD2Key, TValue>>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TD1Key, ConcurrentDictionary<TD2Key, TValue>>>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TD1Key, ConcurrentDictionary<TD2Key, TValue>>>)items).GetEnumerator();
        }

        private ConcurrentDictionary<TD1Key, ConcurrentDictionary<TD2Key, TValue>> _items = new ConcurrentDictionary<TD1Key, ConcurrentDictionary<TD2Key, TValue>>();
        /// <summary>
        /// 
        /// </summary>
        protected ConcurrentDictionary<TD1Key, ConcurrentDictionary<TD2Key, TValue>> items
        {
            get
            {
                //if (_items == null)_items = new Dictionary<TD1Key, Dictionary<TD2Key, TValue>>();
                return _items;
            }
            set { _items = value; }
        }

    }

}