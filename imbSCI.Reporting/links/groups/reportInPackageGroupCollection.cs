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