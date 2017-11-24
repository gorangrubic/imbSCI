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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.DataComplex.special.translationEnumTable" />
    public class translationForValuesAndTypes:translationEnumTable
    {
        public string getTranslation(object value, string format = "{0,12} : {1}")
        {
            string typename = "";
            string valuename = "";

            if (ContainsKey(value.GetType()))
            {
                typename = this[value.GetType()];
            } else
            {
                typename = value.GetType().Name.imbTitleCamelOperation(true);
            }

            if (ContainsKey(value))
            {
                valuename = this[value];
            } else
            {
                valuename = value.ToString();
            }

            return string.Format(format, typename, valuename);
        }
    }

}