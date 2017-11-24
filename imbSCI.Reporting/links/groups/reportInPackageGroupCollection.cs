﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="reportInPackageGroupCollection.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
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
// Project: imbSCI.Reporting
// Author: Goran Grubić
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Reporting.links.groups
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

    public class reportInPackageGroupCollection : ObservableCollection<reportInPackageGroup>
    {
        
   

        public List<string> getPathList()
        {
            List<string> output = new List<string>();
            foreach (reportInPackageGroup group in this)
            {
                output.Add(group.getPath());
            }
            output.Sort(SortByLengthAscending);
            return output;
        }


        public int SortByLengthAscending(string name1, string name2)
        {
            if (name1.Length > name2.Length) return 1;
            if (name1.Length == name2.Length) return 0;
            return -1;
        }


        public reportInPackageGroup select(string groupName, bool createIfNotFind=true)
        {
            reportInPackageGroup output = null;
            if (this.Any(x => x.name == groupName))
            {
              output = this.First(x => x.name == groupName);
            }
            if (createIfNotFind)
            {
                if (output == null)
                {
                    output = new reportInPackageGroup();
                    output.name = groupName;
                    Add(output);
                }
            }
            return output;
        }

        /// <summary>
        /// Kreira sve grupe i hijerarhiju grupa - na osnovu putanje koja moze imati za spliter bilo koji karakter koji nije broj ili slovo
        /// </summary>
        /// <param name="groupNamePath"></param>
        /// <returns>Poslednju grupu koju je kreirao</returns>
        public reportInPackageGroup createByPath(string groupNamePath)
        {
            if (groupNamePath.isNullOrEmpty()) return null;
            
            List<string> glist = groupNamePath.getPathParts();
            
            reportInPackageGroup last = null;
            foreach (string pathPart in glist)
            {
                reportInPackageGroup output = select(pathPart);
                if (last == output)
                {
                    last = null;
                }
                if (last != null)
                {
                    output.parent = last;
                }
                last = output;
            }

            return last;
        }
    }
}