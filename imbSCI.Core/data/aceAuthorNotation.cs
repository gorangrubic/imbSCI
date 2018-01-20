// --------------------------------------------------------------------------------------------------------------------
// <copyright file="aceAuthorNotation.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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





        private String _software = "imbVeles - application";
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

        /// <summary>
        /// License information
        /// </summary>
        /// <value>
        /// The licence.
        /// </value>
        public String license { get; set; } = "GNU General Public License v3.0";

        private String _copyright = "All Rights reserved © 2013-2018.";
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


        private String _organization = "imbVeles";
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
