namespace imbSCI.DataComplex.special
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
    /// Translation table with multiple key capability
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="dataBindableBase" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{TKey, TValue}}" />
    public class translationTableMulti<TKey, TValue> : dataBindableBase, IEnumerable<KeyValuePair<TKey, TValue>>
    {

        public virtual void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            foreach (var pair in source)
            {
                Add(pair.Key, pair.Value);
            }
        }

        public virtual void Add(TKey key, TValue value)
        {
            KeyValuePair<TKey, TValue> t = new KeyValuePair<TKey, TValue>(key, value);
            //if (!entries.Any(x=>(x.Key.Equals(t.Key))&&(x.Value.Equals(t.Value))))
            //{
                entries.Add(t);
            //}
        }

        public List<TKey> GetKeys()
        {
            List<TKey> output = new List<TKey>();
            foreach (var pair in entries)
            {
                output.AddUnique(pair.Key);
            }
            return output;
        }

        public List<TValue> GetValues()
        {
            List<TValue> output = new List<TValue>();
            foreach (var pair in entries)
            {
                output.AddUnique(pair.Value);
            }
            return output;
        }

        public virtual List<TValue> GetByKey(TKey needle)
        {
            List<TValue> output = new List<TValue>();
            foreach (var pair in entries)
            {
                if (pair.Value.Equals(needle))
                {
                    output.AddUnique(pair.Value);
                }
            }
            return output;
        }


        public virtual List<TKey> GetByValue(TValue needle)
        {
            List<TKey> output = new List<TKey>();
            foreach (var pair in entries)
            {
                if (pair.Value.Equals(needle))
                {
                    output.AddUnique(pair.Key);
                }
            }
            return output;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)entries).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)entries).GetEnumerator();
        }

        /// <summary> </summary>
        protected List<KeyValuePair<TKey,TValue>> entries { get; set; } = new List<KeyValuePair<TKey, TValue>>();
    }

}