namespace imbSCI.Core.math.measurement
{
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class measureDisplayGroups
    {
        protected Dictionary<String, measureDisplayGroup> items = new Dictionary<String, measureDisplayGroup>();

        /// <summary>
        /// Exports all groups to list
        /// </summary>
        /// <returns></returns>
        public List<measureDisplayGroup> export()
        {
            List<measureDisplayGroup> output = new List<measureDisplayGroup>();

            foreach (measureDisplayGroup gr in items.Values)
            {
                output.Add(gr);
            }
            return output;
        }

        public IMeasure find(String key)
        {
            foreach (measureDisplayGroup gr in items.Values)
            {
                IMeasure ot = gr.Values.First(x => x.name == key) as IMeasure;
                if (ot != null) return ot;
            }
            return null;
        }

        public measureDisplayGroup this[String key]
        {
            get
            {
                if (!items.ContainsKey(key))
                {
                    items.Add(key, new measureDisplayGroup(key, ""));
                }
                return items[key];
            }
        }
    }

}