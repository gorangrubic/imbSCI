namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Generic;

    public class aceEnumDictionarySet<TEnum, TKey, TValue> : aceEnumDictionary<TEnum, Dictionary<TKey,TValue>>
    {
        public aceEnumDictionarySet() : base()
        {
        }

        public void Add(TEnum flags, TKey key, TValue item)
        {
            Enum fl = flags as Enum;
            List<TEnum> flagList = fl.getEnumListFromFlags<TEnum>();
            foreach (TEnum flag in flagList)
            {
                if (!this[flag].ContainsKey(key))
                {
                    this[flag].Add(key, item);
                }
                
            }
        }
    }

}