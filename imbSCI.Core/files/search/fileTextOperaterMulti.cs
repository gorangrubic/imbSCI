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

    public class fileTextOperaterMulti:IEnumerable<KeyValuePair<String, fileTextOperater>>
    {

        public fileTextOperaterMulti(IEnumerable<String> filepaths)
        {
            foreach (String filepath in filepaths)
            {
                items.Add(filepath, new fileTextOperater(filepath));
            }
        }


        public IEnumerator<KeyValuePair<String, fileTextOperater>> GetEnumerator() => items.GetEnumerator();
        public Int32 Count() => items.Count;


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, fileTextOperater>>)_items).GetEnumerator();
        }

        private Dictionary<String, fileTextOperater> _items = new Dictionary<String, fileTextOperater>();
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<String, fileTextOperater> items
        {
            get
            {
                //if (_items == null)_items = new Dictionary<String, fileTextOperater>();
                return _items;
            }
            set { _items = value; }
        }

    }

}