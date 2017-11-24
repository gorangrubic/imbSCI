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
using imbSCI.Data.interfaces;

namespace imbSCI.Core.data
{
    using imbSCI.Data.enums.fields;
    using System.Data;

    /// <summary>
    /// Data set about authos and licence
    /// </summary>
    /// <seealso cref="imbBindable" />
    public class aceAuthorNotation:imbBindable, IAppendDataFields, IAppendDataFieldsExtended
    {


        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        public PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data = null)
        {
            if (data == null) data = new PropertyCollectionExtended();

            data.Add(templateFieldBasic.meta_author, author, "Author", "");
            data.Add(templateFieldBasic.meta_copyright, copyright, "Copyright", "Copyright statement");
            data.Add(templateFieldBasic.meta_organization, organization, "Organisation", "");
            data.Add(templateFieldBasic.meta_softwareName, AppDomain.CurrentDomain.FriendlyName, "Executable", "Name of executable ran");
            data.Add(templateFieldBasic.meta_year, DateTime.Now.Year, "Year", "");

            data.Add(templateFieldBasic.meta_softwareComment, software, "Software info", "");
            return data;
        }

        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>
        /// Updated or newly created property collection
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        PropertyCollection IAppendDataFields.AppendDataFields(PropertyCollection data)
        {
            return AppendDataFields(data as PropertyCollectionExtended);
        }





        private String _software = "imbVeles - semanticTerminal Experiment tool";
        /// <summary>
        /// 
        /// </summary>
        public String software
        {
            get { return _software; }
            set { _software = value; }
        }


        private String _author = "Goran Grubić";
        /// <summary>
        /// 
        /// </summary>
        public String author
        {
            get { return _author; }
            set { _author = value; }
        }


        private String _copyright = "All Rights reserved © 2013-2017.";
        /// <summary>
        /// 
        /// </summary>
        public String copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }


        private String _comment = "Part of PhD thesis research.";
        /// <summary>
        /// 
        /// </summary>
        public String comment
        {
            get { return _comment; }
            set { _comment = value; }
        }


        private String _organization = "KOPLAS PRO ltd Serbia | Faculty of Organizational Sciences, Belgrade University, Serbia";
        /// <summary>
        /// 
        /// </summary>
        public String organization
        {
            get { return _organization; }
            set { _organization = value; }
        }



        

    }
}
