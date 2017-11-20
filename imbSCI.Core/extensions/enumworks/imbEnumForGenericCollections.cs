namespace imbSCI.Core.extensions.enumworks
{
    using System;
    using System.Collections.Generic;

    public static class imbEnumForGenericCollections
    {
        /// <summary>
        /// Adds the specified item as key and its String form as Value
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="item">The item.</param>
        public static void Add(this IDictionary<Object, String> target, Enum item)
        {
            if ((item.ToInt32()) == 0)
            {
                target.Add(item, "");
            } else
            {
                target.Add(item, item.ToString());
            }
            
        }

        /// <summary>
        /// Add all enum values of the specified enum type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        public static void AddEnumAll<T>(this IDictionary<Object, String> target) where T:IConvertible
        {
            var enums = Enum.GetValues(typeof(T));
            foreach (Object en in enums)
            {
                target.Add(en as Enum);
            }
        }


        /// <summary>
        /// Adds all enum values from the type but as numeric string coresponding to the Enum member Int32 value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        public static void AddEnumAsNumericAll<T>(this IDictionary<Object, String> target) where T : IConvertible
        {
            var enums = Enum.GetValues(typeof(T));
            foreach (Enum en in enums)
            {
                Int32 n = en.ToInt32();

                target.Add(en, n.ToString());
            }
        }

    }
}