namespace imbSCI.DataComplex.special
{
    using System;
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
    using imbSCI.Data;

    public class translationEnumTable:Dictionary<object, string>
    {

        /// <summary>
        /// Gets the keys for value.
        /// </summary>
        /// <param name="stringForm">The string form.</param>
        /// <returns></returns>
        public List<object> GetKeysForValue(string stringForm)
        {
            List<object> output = new List<object>();
            foreach (KeyValuePair<object, string> pair in this)
            {
                if (pair.Value == stringForm)
                {
                    output.Add(pair.Key);
                }
            }
            return output;
        }

        /// <summary>
        /// Gets the enum having the stringForm equal to the specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringForm">The string form.</param>
        /// <returns></returns>
        public T GetEnum<T>(string stringForm)
        {
            var keys = GetKeysForValue(stringForm);
            return keys.getFirstOfType<T>(false, default(T), true);
        }

        /// <summary>
        /// Gets the enums.
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="stringForm">The string form with multiple keys.</param>
        /// <returns></returns>
        public List<object> GetEnums(IEnumerable<Type> types, string stringForm)
        {
            List<object> output = new List<object>();
            //List<Object> candida
            string input = stringForm;
            foreach (Type t in types)
            {
                foreach (KeyValuePair<object, string> pair in this)
                {
                    if (pair.Key.GetType() == t)
                    {
                        if (stringForm.StartsWith(pair.Value))
                        {
                            if (pair.Key!="none")
                            {
                                output.Add(pair.Key);
                            }
                            
                            stringForm = stringForm.removeStartsWith(pair.Value);
                        }

                    }
                }
            }
            
            return output;
        }

        public object GetEnum(Type type, string stringForm)
        {
            var keys = GetKeysForValue(stringForm);
            if (keys.Any(x => x.GetType() == type))
            {
                return keys.Where(x => x.GetType() == type)?.First();
            } else
            {
                return type.GetDefaultValue();
            }
        }

    }
}
