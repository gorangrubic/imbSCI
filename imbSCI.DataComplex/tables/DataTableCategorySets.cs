// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTableCategorySets.cs" company="imbVeles" >
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
// Project: imbSCI.DataComplex
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.DataComplex.tables
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Data.collection.nested;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Core.extensions.table;

    public class DataTableCategorySets:aceDictionarySet<string, DataColumn>
    {
        /// <summary> </summary>
        public aceDictionarySet<string, selectZone> categoryZones { get; protected set; } = new aceDictionarySet<string, selectZone>();


        /// <summary> </summary>
        public List<string> categoryList { get; protected set; } = new List<string>();


        public DataTableCategorySets(DataTable table)
        {
            process(table);
        }



        protected void process(DataTable table)
        {
           // categoryList = table.GetCategoryPriority();

            int i = 0;

            string cat = table.Columns.getFirstOfType<DataColumn>().GetGroup().ToUpper();
            int start = 0;
            int end = 1;
            DataColumn dcl = null;
            foreach (DataColumn dc in table.Columns)
            {
                dcl = dc;
                i++;
                
                if (dc.GetGroup().ToUpper() == cat)
                {
                    end = i;
                } else
                {
                    Add(cat.ToUpper(), dc);
                    int st = start - 1;
                    if (st < 0) st = 0;
                    int ln = (end - start)-1;
                    if (ln < 0) ln = 0;
                    var zone = new selectZone(st, 0, ln, 0);
                   // aceLog.log(cat + " " + zone.ToStringDump(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty, 10));
                    categoryZones.Add(cat.ToUpper(), zone);
                    start = i;
                    end = i;
                    cat = dc.GetGroup().ToUpper();
                    categoryList.Add(cat.ToUpper());
                }
            }

            if (start != end)
            {
                int ln2 = (end - start) - 1;
                if (ln2 < 0) ln2 = 0;

                Add(cat.ToUpper(), dcl);
                cat = dcl.GetGroup().ToUpper();
                categoryZones.Add(cat.ToUpper(), new selectZone(start, 0, ln2, 0));
                categoryList.Add(cat.ToUpper());
            }
            
        }
    }

}