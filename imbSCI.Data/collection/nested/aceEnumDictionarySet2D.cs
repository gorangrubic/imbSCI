namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Generic;

    public class aceEnumDictionarySet2D<TEnum, TD1Key, TD2Key, TValue> : aceEnumDictionary<TEnum, Dictionary<TD1Key, Dictionary<TD2Key, TValue>>>
    {
        public aceEnumDictionarySet2D() : base()
        {
        }

        public void Add(TEnum flags, TD1Key d1_key, TD2Key d2_key, TValue item)
        {
            Enum fl = flags as Enum;
            List<TEnum> flagList = fl.getEnumListFromFlags<TEnum>();
            foreach (TEnum flag in flagList)
            {
                if (!this[flag].ContainsKey(d1_key))
                {

                    if (!this[flag][d1_key].ContainsKey(d2_key))
                    {
                        this[flag][d1_key].Add(d2_key, item);
                    }
                }

            }
        }
    }

}