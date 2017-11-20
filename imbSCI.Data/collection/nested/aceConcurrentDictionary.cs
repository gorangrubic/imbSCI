namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Concurrent;

    public class aceConcurrentDictionary<T>:ConcurrentDictionary<String, T>
    {
        public void Add(String key, T item)
        {
            if (ContainsKey(key))
            {
                AddOrUpdate(key, item, 
                (k, i) =>
                {
                    return item;
                });
            } else
            {
                TryAdd(key, item);
            }
        }
    }

}