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
    using imbSCI.Core.reporting.render;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Collection of lines extracted/found in a file
    /// </summary>
    public class fileTextLineCollection:IEnumerable<KeyValuePair<Int32, String>>
    {

        private Object AddLock = new Object();


        public void Add(Int32 lineNumber, String lineContent, Boolean overwriteLineNumber=false)
        {
            lock (AddLock) {
                if (results.ContainsKey(lineNumber))
                {
                    if (overwriteLineNumber)
                    {
                        results.Remove(lineNumber);
                    }
                    results.Add(lineNumber, lineContent);
                } else
                {
                    results.Add(lineNumber, lineContent);
                    _CountThreadSafe++;
                }

            }
        }



        private Int32 _CountThreadSafe = 0; // = "";
                                    /// <summary>
                                    /// Bindable property
                                    /// </summary>
        public Int32 CountThreadSafe
        {
            get { return _CountThreadSafe; }
        }


        public Int32 Count()
        {
            return results.Count;
        }
        /// <summary>
        /// Returns the list of line numbers on which the lines were found
        /// </summary>
        /// <returns></returns>
        public List<Int32> getLineNumberList()
        {
            return results.Keys.ToList();
        }


        /// <summary>
        /// Returns the list of matched lines
        /// </summary>
        /// <returns></returns>
        public List<String> getLineContentList()
        {
            return results.Values.ToList();
        }

        /// <summary>
        /// Saves the content of the line.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>reference to file just saved</returns>
        public FileInfo saveLineContent(String filepath, getWritableFileMode mode=getWritableFileMode.overwrite)
        {
            FileInfo fi = filepath.getWritableFile(mode);
            saveBase.saveToFile(fi.FullName, getLineContentList());
            return fi;
        }


        /// <summary>
        /// String representation of the matched lines
        /// </summary>
        /// <param name="showNumber">if set to <c>true</c> [show number].</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public String ToString(Boolean showNumber, String format="{0,8} : {1}")
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<int, string> pair in results)
            {
                if (showNumber)
                {
                    sb.AppendFormat(format, pair.Key, pair.Value);
                    sb.AppendLine();
                } else
                {
                    sb.AppendLine(pair.Value);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// To the string.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="showNumber">if set to <c>true</c> [show number].</param>
        /// <param name="format">The format.</param>
        public virtual void ToString(ITextRender output, Boolean showNumber, String format="{0,8} : {1}")
        {
            
            foreach (KeyValuePair<int, string> pair in results)
            {
                try
                {
                    if (showNumber)
                    {
                        output.AppendLine(String.Format(format, pair.Key, pair.Value));
                    }
                    else
                    {
                        output.AppendLine(pair.Value);
                    }
                } catch (Exception ex)
                {
                    Thread.Sleep(250);
                    output.AppendLine("--- output broken: " + ex.Message);
                    break;
                }
            }
        }



        /// <summary>
        /// String representation of the matched lines with line number shown
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ToString(true);
        }

        public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<int, string>>)results).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<int, string>>)results).GetEnumerator();
        }

        private Dictionary<Int32, String> _results = new Dictionary<Int32, String>();
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<Int32, String> results
        {
            get
            {
                //if (_results == null)_results = new Dictionary<Int32, String>();
                return _results;
            }
            set { _results = value; }
        }
    }

}