namespace imbSCI.Core.collection
{
    using imbSCI.Core.extensions.text;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Contains meta-information about entries in <see cref="PropertyCollectionExtended"/> 
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.Object, aceCommonTypes.collection.PropertyEntry}" />
    public sealed class PropertyEntryDictionary : IEnumerable<KeyValuePair<object, PropertyEntry>>, IDictionary<object, PropertyEntry>
    {
        

        

        private Dictionary<Object, PropertyEntry> _items = new Dictionary<Object, PropertyEntry>();
        /// <summary> </summary>
        public Dictionary<Object, PropertyEntry> items
        {
            get
            {
                return _items;
            }
            protected set
            {
                _items = value;
                //OnPropertyChanged("items");
            }
        }



        private PropertyEntryDictionaryFlags _flags;
        /// <summary>Flags giving special instructions for DataTable construction and other data transformations</summary>
        public PropertyEntryDictionaryFlags flags
        {
            get
            {
                return _flags;
            }
            set
            {
                _flags = value;
                //OnPropertyChanged("flags");
            }
        }

        public ICollection<object> Keys
        {
            get
            {
                return ((IDictionary<object, PropertyEntry>)items).Keys;
            }
        }

        public ICollection<PropertyEntry> Values
        {
            get
            {
                return ((IDictionary<object, PropertyEntry>)items).Values;
            }
        }

        public int Count
        {
            get
            {
                return ((IDictionary<object, PropertyEntry>)items).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IDictionary<object, PropertyEntry>)items).IsReadOnly;
            }
        }


        /// <summary>
        /// Gets or sets the <see cref="PropertyEntry"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="PropertyEntry"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public new PropertyEntry this[Object key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    Add(key, new PropertyEntry(key, ""));
                }
                return items[key];
            }
            set
            {
                if (!ContainsKey(key))
                {

                    Add(key, value);
                }
                else
                {
                    items[key] = value;
                    
                }
            }
        }

        /// <summary>
        /// Searches for property entry definition
        /// </summary>
        /// <param name="key">The key. It can be string, it will be used as lowercase</param>
        /// <returns>PropertyEntry</returns>
        public PropertyEntry Get(Object key)
        {
            if (key is Enum)
            {
                return items[key];
            } else
            {
                String key_str = key.toStringSafe().ToLower();
                foreach (var k in items.Keys)
                {
                    if (key_str == k.toStringSafe().ToLower())
                    {
                        return items[k];
                    }
                }
            }
            return null;
        }

        public IEnumerator<KeyValuePair<object, PropertyEntry>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<object, PropertyEntry>>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<object, PropertyEntry>>)items).GetEnumerator();
        }

        public bool ContainsKey(object key)
        {
            return ((IDictionary<object, PropertyEntry>)items).ContainsKey(key);
        }

        public void Add(object key, PropertyEntry value)
        {
            if (items.ContainsKey(key))
            {
                items[key] = value;
            }
            else
            {
                ((IDictionary<object, PropertyEntry>)items).Add(key, value);
            }
        }

        public bool Remove(object key)
        {
            return ((IDictionary<object, PropertyEntry>)items).Remove(key);
        }

        public bool TryGetValue(object key, out PropertyEntry value)
        {
            return ((IDictionary<object, PropertyEntry>)items).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<object, PropertyEntry> item)
        {
            item.Value.priority = item.Value.priority + items.Count;
            ((IDictionary<object, PropertyEntry>)items).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<object, PropertyEntry>)items).Clear();
        }

        public bool Contains(KeyValuePair<object, PropertyEntry> item)
        {
            return ((IDictionary<object, PropertyEntry>)items).Contains(item);
        }

        public void CopyTo(KeyValuePair<object, PropertyEntry>[] array, int arrayIndex)
        {
            ((IDictionary<object, PropertyEntry>)items).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<object, PropertyEntry> item)
        {
            return ((IDictionary<object, PropertyEntry>)items).Remove(item);
        }
    }

}