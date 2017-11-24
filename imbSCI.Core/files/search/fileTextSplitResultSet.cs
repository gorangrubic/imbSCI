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
    /// <summary>
    /// Result set of file slitting operation
    /// </summary>
    /// <seealso cref="fileTextSearchResultSet" />
    public class fileTextSplitResultSet:fileTextSearchResultSet
    {

        private String _filepathFormat = "splits\\{0}.txt";
        /// <summary>
        /// 
        /// </summary>
        public String filepathFormat
        {
            get { return _filepathFormat; }
            set { _filepathFormat = value; }
        }

        public override fileTextSearchResult this[string needle]
        {
            get
            {
                if (!resultSet.ContainsKey(needle))
                {
                    String filepath = String.Format(filepathFormat, needle);
                    resultSet.Add(needle, new fileTextSearchResult(needle, filepath, false));
                }
                return base[needle];
            }
        }

        /// <summary>
        /// Saves the slits.
        /// </summary>
        /// <param name="pathPrefix">The path prefix.</param>
        /// <param name="mode">The mode.</param>
        public void saveSlits(String pathPrefix = "", getWritableFileMode mode = getWritableFileMode.overwrite)
        {
            foreach (fileTextSearchResult splitRes in this)
            {
                splitRes.saveLineContent(pathPrefix.add(splitRes.filePath, "\\"), mode);
            }
        }
       
        public fileTextSplitResultSet(String __filepathFormat="splits\\{0}.txt")
        {
            filepathFormat = __filepathFormat;

        }
    }

}