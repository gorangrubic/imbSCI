namespace imbSCI.Core.collection
{
    using imbSCI.Data.data;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Simple generic dictionary used by: <see cref="aceCommonTypes.collection.reportOutputRepository"/>, <see cref="PropertyCollectionDictionary"/>/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public abstract class resourceDictionaryBase<T>:dataBindableBase, IEnumerable
    {
        /// <summary>
        /// The items
        /// </summary>
        protected Dictionary<String, T> items = new Dictionary<string, T>();


        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return items.Values.GetEnumerator();
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public Int32 Count() => items.Count();

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() => items.Clear();


        /// <summary>
        /// Gets the <see cref="T"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T this[Enum key] => this[key.ToString()];

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value.</param>
        public void Add(String key, T val) => items.Add(key, val);

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns></returns>
        protected abstract T getDefault();



        /// <summary>
        /// Gets or sets the <see cref="PropertyCollection"/> with the specified key. Automatically creates entry for new key
        /// </summary>
        /// <value>
        /// The <see cref="PropertyCollection"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T this[String key]
        {
            get
            {
                if (!items.ContainsKey(key)) items.Add(key, getDefault());
                return items[key];
            }
            set
            {
                if (!items.ContainsKey(key))
                {
                    items[key] = value;
                }
                else
                {
                    items.Add(key, value);
                }
            }
        }
    }

}