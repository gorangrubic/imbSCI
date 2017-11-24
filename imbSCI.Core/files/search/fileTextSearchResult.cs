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
using imbSCI.Core.reporting.render;

namespace imbSCI.Core.files.search
{

    /// <summary>
    /// Results for one needle
    /// </summary>
    /// <seealso cref="fileTextLineCollection" />
    public class fileTextSearchResult:fileTextLineCollection
    {

        public fileTextSearchResult(String __needle, String __filepath, Boolean __useRegex=false)
        {
            needle = __needle;
            filePath = __filepath;
            useRegex = __useRegex;
        }

        public override void ToString(ITextRender output, bool showNumber, string format = "{0,8} : {1}")
        {
            //if (showHeader)
            //{
                output.AppendLine("Source file [" + filePath + "] ");
                output.AppendLine("Needle [" + needle + "] Regex[" + useRegex.ToString() + "] Count[" + Count() + "]");
                if (resultLimitTriggered) output.AppendLine("Result limit was reached!!");

            //}
            base.ToString(output, showNumber, format);
        }


        private Boolean _useRegex = false;
        /// <summary> </summary>
        public Boolean useRegex
        {
            get
            {
                return _useRegex;
            }
            protected set
            {
                _useRegex = value;
            }
        }


        private Boolean _resultLimitTriggered = false;
        /// <summary> </summary>
        public Boolean resultLimitTriggered
        {
            get
            {
                return _resultLimitTriggered;
            }
            set
            {
                _resultLimitTriggered = value;
                
            }
        }




        private String _needle;
        /// <summary> </summary>
        public String needle
        {
            get
            {
                return _needle;
            }
            set
            {
                _needle = value;
            }
        }


        private String _filePath = "";
        /// <summary> </summary>
        public String filePath
        {
            get
            {
                return _filePath;
            }
            protected set
            {
                _filePath = value;
                
            }
        }

    }

}