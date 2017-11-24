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
    /// Part of report link collection
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, imbSCI.Reporting.links.reportLinkCollection}" />
    /// <seealso cref="imbSCI.Reporting.interfaces.IMakeHtml" />
    public class reportLinkCollectionSet : IEnumerable<KeyValuePair<string, reportLinkCollection>>
    {

        public IEnumerator<KeyValuePair<string, reportLinkCollection>> GetEnumerator() => items.GetEnumerator();
        public int Count() => items.Count;
        public reportLinkCollection Get(string key, bool autocreate)
        {
            if (!items.ContainsKey(key)) items.Add(key, new reportLinkCollection());
            return items[key];
        }


        public void AddBundled(params reportLinkCollection[] items)
        {
            foreach (reportLinkCollection item in items)
            {
                Add(item.title, item);
            }

          
        }

        public void AddInGroup(string key, reportLinkCollection item)
        {
            if (item != null)
            {
                if (item.Count() > 0)
                {
                    if (items.ContainsKey(key))
                    {
                        items[key].AddGroup(item.title, item.description);
                        items[key].AddLinks(item);
                    }
                    else
                    {
                        items.Add(key, item);
                    }
                }
            }
        }

        private int _lastNamingIteration = 0;
        /// <summary> </summary>
        public int lastNamingIteration
        {
            get
            {
                return _lastNamingIteration;
            }
            protected set
            {
                _lastNamingIteration = value;
                //OnPropertyChanged("lastNamingIteration");
            }
        }

        public void Add(string key, reportLinkCollection item)
        {
            if (item != null)
            {
                if (item.Count() > 0)
                {
                    if (items.ContainsValue(item))
                    {

                    }
                    else
                    {
                        key = items.makeUniqueDictionaryName(item.title, ref _lastNamingIteration, 10);
                        items.Add(key, item);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, reportLinkCollection>>)items).GetEnumerator();
        }

        public reportLinkCollection currentItem
        {
            get
            {
                return items.Values.imbLastSafe();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, reportLinkCollection> items { get; set; } = new Dictionary<string, reportLinkCollection>();


        /// <summary>
        /// Name for this instance
        /// </summary>
        public string name { get; set; } = "";

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public string description { get; set; } = "";


        #region --- main ------- Glavna/root grupa

        /// <summary>
        /// Main group - the root folder
        /// </summary>
        public reportLinkCollection main { get; set; } = new reportLinkCollection();

        //public reportHtmlDocument makeHtml(reportHtmlDocument htmlReport)
        //{
        //    return makeHtml(htmlReport, false);
        //}

        ///// <summary>
        ///// Generate HTML output for this set of links
        ///// </summary>
        ///// <param name="htmlReport"></param>
        ///// <param name="excludeShema"></param>
        ///// <returns></returns>
        //public reportHtmlDocument makeHtml(reportHtmlDocument htmlReport, bool excludeShema)
        //{
        //    if (htmlReport == null) htmlReport = new reportHtmlDocument();

        //    htmlReport.open("div");
            
        //    foreach (var ls in this)
        //    {
        //        ls.Value.makeHtml(htmlReport, excludeShema);
        //    }

        //    main.makeHtml(htmlReport, excludeShema);
            
        //    htmlReport.close();

        //    return htmlReport;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return ((IEnumerable<KeyValuePair<string, reportLinkCollection>>)items).GetEnumerator();
        //}

        #endregion


    }
}