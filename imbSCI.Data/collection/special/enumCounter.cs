namespace imbSCI.Data.collection.special
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
//using aceCommonTypes.core.exceptions;

    // using aceCommonTypes.extensions;

    /// <summary>
    /// Brojac enumeracija
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class enumCounter<T>:Dictionary<T, int>
    {
        public enumCounter() : base()
        {
            foreach (T en in Enum.GetValues(typeof (T)))
            {
                this.Add(en, 0);
            }
        }

        public String writeResult(String format = "{0}={2};", String separator=" ")
        {
            String output = "";
            foreach (T en in Keys)
            {
                output = output + String.Format(format, en.ToString(), this[en].ToString()) + separator;
            }
            output = output.TrimEnd(separator.ToCharArray());
            return output;
        }

        /// <summary>
        /// postavlja sve brojace na 0
        /// </summary>
        public void reset()
        {
            foreach (T en in Keys.ToList())
            {
                this[en] = 0;
            }
        }

        public Int32 count(T en)
        {
            
            this[en]++;
            return this[en];
        }
    }
}
