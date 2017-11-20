namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
//using aceCommonTypes.extensions;
    //using aceCommonTypes.extensions.enumworks;


    /// <summary>
    /// Based on aceConcurrentBag
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Concurrent.ConcurrentDictionary{TEnum, aceCommonTypes.collection.nested.aceConcurrentBag{T}}" />
    public class aceDictionarySet<TEnum, T> : ConcurrentDictionary<TEnum, aceConcurrentBag<T>>
    {
        public aceDictionarySet():base()
        {
            Type tenum = typeof(TEnum);

            if (tenum.IsEnum)
            {
                foreach (Object it in Enum.GetValues(tenum))
                {
                    this.TryAdd((TEnum)it, new aceConcurrentBag<T>());
                  //  Add(, new aceConcurrentBag<T>());
                }
            }
        }

        public void Add(TEnum key, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(key, item);
            }
        }

        public void AddUnique(TEnum key, T item)
        {
            if (!ContainsKey(key))
            {
                this.TryAdd(key, new aceConcurrentBag<T>());
            }

            base[key].AddUnique(item);
        }

        public void Add(TEnum key, T link)
        {
            if (!ContainsKey(key))
            {
                this.TryAdd(key, new aceConcurrentBag<T>());
            }

            base[key].Add(link);
        }


        public aceConcurrentBag<T> this[TEnum key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    this.TryAdd(key, new aceConcurrentBag<T>());

                }
                return base[key];
            }
        }
    }

}