using System;
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
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files.search
{
    using System.Collections;

    public class fileTextSearchMultiSourceSet:IEnumerable<KeyValuePair<String, fileTextSearchResultSet>>
    {
        public fileTextSearchMultiSourceSet(IEnumerable<String> __needleSet, List<String> __filepaths, Boolean __useRegex)
        {
            foreach (String filepath in __filepaths)
            {
                items.Add(filepath, new fileTextSearchResultSet(__needleSet, filepath, __useRegex));
            }
        }

        public fileTextSearchResultSet this[String filepath]
        {
            get
            {
                return items[filepath];
            }

            set
            {
                items[filepath] = value;
            }
        }

        private Dictionary<String, fileTextSearchResultSet> _items = new Dictionary<String, fileTextSearchResultSet>();
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<String, fileTextSearchResultSet> items
        {
            get
            {
                //if (_items == null)_items = new Dictionary<String, fileTextSearchResultSet>();
                return _items;
            }
            set { _items = value; }
        }

        public IEnumerator<KeyValuePair<string, fileTextSearchResultSet>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, fileTextSearchResultSet>>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, fileTextSearchResultSet>>)items).GetEnumerator();
        }
    }

}