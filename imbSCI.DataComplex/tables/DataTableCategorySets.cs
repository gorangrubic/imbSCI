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

            string cat = table.Columns.getFirstOfType<DataColumn>().GetGroup();
            int start = 0;
            int end = 1;
            DataColumn dcl = null;
            foreach (DataColumn dc in table.Columns)
            {
                dcl = dc;
                i++;
                
                if (dc.GetGroup() == cat)
                {
                    end = i;
                } else
                {
                    Add(cat, dc);
                    int st = start - 1;
                    if (st < 0) st = 0;
                    int ln = (end - start)-1;
                    if (ln < 0) ln = 0;
                    var zone = new selectZone(st, 0, ln, 0);
                   // aceLog.log(cat + " " + zone.ToStringDump(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty, 10));
                    categoryZones.Add(cat, zone);
                    start = i;
                    end = i;
                    cat = dc.GetGroup();
                    categoryList.Add(cat);
                }
            }

            if (start != end)
            {
                int ln2 = (end - start) - 1;
                if (ln2 < 0) ln2 = 0;

                Add(cat, dcl);
                cat = dcl.GetGroup();
                categoryZones.Add(cat, new selectZone(start, 0, ln2, 0));
                categoryList.Add(cat);
            }
            
        }
    }

}