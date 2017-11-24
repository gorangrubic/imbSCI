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


    /// <summary>
    /// Set of results for IEnumerable query
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbACE.Core.files.search.fileTextSearchResult}" />
    public class fileTextSearchResultSet:IEnumerable<fileTextSearchResult>
    {



        protected fileTextSearchResultSet()
        {

        }


        public fileTextSearchResultSet(IEnumerable<String> __needleSet, String __filepath, Boolean __useRegex)
        {
            foreach (String needle in __needleSet)
            {
                if (!resultSet.ContainsKey(needle))
                {
                    resultSet.Add(needle, new fileTextSearchResult(needle, __filepath, __useRegex));
                }
            }
        }

        public virtual fileTextSearchResult this[String needle]
        {
            get
            {
                return resultSet[needle];
            }
        }



        private Dictionary<String, fileTextSearchResult> _resultSet = new Dictionary<String, fileTextSearchResult>();
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<String, fileTextSearchResult> resultSet
        {
            get
            {
                //if (_resultSet == null)_resultSet = new Dictionary<String, fileTextSearchResult>();
                return _resultSet;
            }
            set { _resultSet = value; }
        }


        private Object CountThreadLock = new Object();

        /// <summary>
        /// Gets the count thread safe.
        /// </summary>
        /// <value>
        /// The count thread safe.
        /// </value>
        public int CountThreadSafe {

            get
            {
                Int32 c = 0;

                lock (CountThreadLock)
                {
                    
                    foreach (var ci in resultSet)
                    {
                        c += ci.Value.Count();
                    }
                    
                }

                return c;
            }
            

        }
        public bool resultLimitTriggered { get; internal set; }

        public List<String> getNeedles()
        {
            return resultSet.Keys.ToList();
        }

        public List<fileTextSearchResult> getResults()
        {
            return resultSet.Values.ToList();
        }

        /// <summary>
        /// Gets the distinct lines
        /// </summary>
        /// <param name="distinct">if set to <c>true</c> it will return only distinct lines</param>
        /// <returns>List of resulting lines</returns>
        public List<String> getLines(Boolean distinct=true)
        {
            List<String> output = new List<string>();

            foreach (fileTextSearchResult res in this)
            {
                foreach (String ln in res.getLineContentList())
                {
                    if (distinct)
                    {
                        if (!output.Contains(ln))
                        {
                            output.Add(ln);
                        }
                    }
                    else
                    {
                        output.Add(ln);
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Gets the line numbers.
        /// </summary>
        /// <param name="distinct">if set to <c>true</c> [distinct].</param>
        /// <returns></returns>
        public List<Int32> getLineNumbers(Boolean distinct=true)
        {
            List<Int32> output = new List<Int32>();

            foreach (fileTextSearchResult res in this)
            {
                foreach (Int32 ln in res.getLineNumberList())
                {
                    if (distinct)
                    {
                        if (!output.Contains(ln))
                        {
                            output.Add(ln);
                        }
                    }
                    else
                    {
                        output.Add(ln);
                    }
                }
            }
            return output;
        }

        public IEnumerator<fileTextSearchResult> GetEnumerator()
        {
            return resultSet.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return resultSet.Values.GetEnumerator();
        }
    }

}