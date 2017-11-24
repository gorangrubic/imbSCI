namespace imbSCI.DataComplex.tables.extensions
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
    using imbSCI.Data.enums.fields;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.extensions.data.modify;

    public static class DataTableReportTools
    {

        /// <summary>
        /// Columns the meta.
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <param name="default_table_metacolumns">The default table metacolumns.</param>
        /// <returns></returns>
        public static DataColumnMetaDictionary ColumnMeta(this DataTable dc, DataColumnMetaDictionary default_table_metacolumns)
        {
            if (!dc.ExtendedProperties.ContainsKey(templateFieldDataTable.table_metacolumns))
            {
                dc.ExtendedProperties.add(templateFieldDataTable.table_metacolumns, default_table_metacolumns);
            }
            return dc.ExtendedProperties[templateFieldDataTable.table_metacolumns] as DataColumnMetaDictionary;
        }
        public static DataColumnMetaDictionary GetColumnMeta(this DataTable dc)
        {
            if (!dc.ExtendedProperties.ContainsKey(templateFieldDataTable.table_metacolumns))
            {
                return new DataColumnMetaDictionary();
            }
            return dc.ExtendedProperties[templateFieldDataTable.table_metacolumns] as DataColumnMetaDictionary;
        }
        public static DataTable SetColumnMeta(this DataTable dc, DataColumnMetaDictionary table_metacolumns)
        {
            dc.ExtendedProperties.add(templateFieldDataTable.table_metacolumns, table_metacolumns);
            return dc;
        }



        /// <summary>
        /// The meta dictionary <see cref="imbSCI.DataComplex.tables.DataRowMetaDictionary"/> containing <see cref="imbSCI.DataComplex.tables.DataRowMetaDefinition"/> entries for extra rows in the table 
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <param name="default_table_metarows">The default table metarows.</param>
        /// <returns></returns>
        public static DataRowMetaDictionary RowMeta(this DataTable dc, DataRowMetaDictionary default_table_metarows)
        {
            if (!dc.ExtendedProperties.ContainsKey(templateFieldDataTable.table_metarows))
            {
                dc.ExtendedProperties.add(templateFieldDataTable.table_metarows, default_table_metarows);
            }
            return dc.ExtendedProperties[templateFieldDataTable.table_metarows] as DataRowMetaDictionary;
        }
        public static DataRowMetaDictionary GetRowMeta(this DataTable dc)
        {
            if (!dc.ExtendedProperties.ContainsKey(templateFieldDataTable.table_metarows))
            {
                return new DataRowMetaDictionary();
            }
            return dc.ExtendedProperties[templateFieldDataTable.table_metarows] as DataRowMetaDictionary;
        }
        public static DataTable SetRowMeta(this DataTable dc, DataRowMetaDictionary table_metarows)
        {
            dc.ExtendedProperties.add(templateFieldDataTable.table_metarows, table_metarows);
            return dc;
        }








        /// <summary>
        /// Adds the row title column as the first from left
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="columnTitle">The column title.</param>
        /// <returns></returns>
        public static DataColumn AddRowNameColumn(this DataTable dt, string columnTitle = "----", bool setAsFirst = true)
        {
            if (!dt.Columns.Contains(dataRowForStats.dc_name.ToString()))
            {
                DataColumn dc = dt.Columns.Add((string)dataRowForStats.dc_name);
                if (setAsFirst) dc.SetOrdinal(0);
                return dc;
            }
            else
            {
                return dt.Columns[(string)dataRowForStats.dc_name];
            }
        }

        public static DataColumn AddRowDescriptionColumn(this DataTable dt, string columnTitle = "----", bool setAsLast = true)
        {
            if (!dt.Columns.Contains(dataRowForStats.dc_description.ToString()))
            {
                DataColumn dc = dt.Columns.Add((string)dataRowForStats.dc_description);
                if (setAsLast) dc.SetOrdinal(dt.Columns.Count - 1);

                return dc;
            }
            else
            {
                return dt.Columns[(string)dataRowForStats.dc_description];
            }
        }
    }
}
