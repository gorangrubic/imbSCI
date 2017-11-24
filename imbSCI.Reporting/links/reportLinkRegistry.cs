namespace imbSCI.Reporting.links
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// Global registry of links
    /// </summary>
    public class reportLinkRegistry:IEnumerable
    {

        public static string getCleanKey(string key)
        {
            if (key.isNullOrEmpty()) key = "-";
            string output = key.Replace("/", "-");
            output = output.Replace("\\", "-");
            
            output = output.Replace(".", "-");
            output = output.Replace(" ", "");
            return output;
        }

        /// <summary>
        /// Gets the link collection.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public reportLinkCollection getLinkCollection(string key)
        {
            

            string ikey = getCleanKey(key);

            if (!items.ContainsKey(ikey))
            {
                items.Add(ikey, new reportLinkCollection());
            }

            return items[ikey];
        }

        public reportLinkCollection getLinkOneCollection(params string[] keys)
        {
            foreach (string key in keys)
            {
                string ikey = getCleanKey(key);
                if (!ikey.isNullOrEmpty())
                {
                    if (items.ContainsKey(ikey))
                    {
                        return getLinkCollection(ikey);

                    }
                }
            }
            return null;
        }

        public List<reportLinkCollection> getLinkCollections(params string[] keys)
        {
            List<reportLinkCollection> output = new List<reportLinkCollection>();

            foreach (string key in keys)
            {
                string ikey = getCleanKey(key);
                if (!ikey.isNullOrEmpty())
                {
                    if (items.ContainsKey(ikey))
                    {
                        output.Add(getLinkCollection(ikey));
                    }
                }
            }
            return output;
        }



        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="reportLinkCollection"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="reportLinkCollection"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public reportLinkCollection this[string key]
        {
            get
            {
                return getLinkCollection(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, reportLinkCollection> items { get; set; } = new Dictionary<string, reportLinkCollection>();


        /// <summary>
        /// Initializes a new instance of the <see cref="reportLinkRegistry"/> class.
        /// </summary>
        public reportLinkRegistry()
        {

        }

    }

}