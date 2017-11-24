namespace imbSCI.DataComplex.extensions.data.modify
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.table;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.tables;
    using imbSCI.Data.enums.fields;
    using imbSCI.Data.collection.nested;

    public static class dataRowForStats
    {
        public const string dc_letter = "dc_letter";
        public const string dc_description = "dc_description";
        public const string dc_name = "dc_name";
        public const string dc_value = "dc_value";

        public static DataRow SetDesc(this DataRow dr, string description)
        {
            dr[dc_description] = description;
            return dr;
        }

        /// <summary>
        /// Sets the letter column (dc_letter)
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="letter">The letter.</param>
        /// <returns></returns>
        public static DataRow SetLetter(this DataRow dr, string letter)
        {
            dr[dc_letter] = letter;
            return dr;
        }


        public static void AddExtraLinesAsRows(this DataTable dt, DataColumn column=null)
        {
            foreach (string line in dt.GetExtraDesc())
            {
                dt.AddStringLine(line, column);
            }
        }

        /// <summary>
        /// Adds row with extra information
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="columnInfo">The column information.</param>
        /// <param name="widthLimit">The width limit.</param>
        /// <returns></returns>
        public static DataRow AddExtraRowInfo(this DataTable dt, PropertyEntryColumn columnInfo, int widthLimit = 25)
        {
           return dt.AddExtraRow(columnInfo, widthLimit);
        }

        /// <summary>
        /// Adds row with extra information
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="columnInfo">The column information.</param>
        /// <param name="widthLimit">The width limit.</param>
        /// <returns></returns>
        public static DataRow AddExtraRowInfo(this DataTable dt, templateFieldDataTable columnInfo, int widthLimit=25)
        {
            return dt.AddExtraRow(columnInfo, widthLimit);
        }


        /// <summary>
        /// Adds the string line into table
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="text">The text.</param>
        /// <param name="col">The col.</param>
        public static DataRow AddStringLine(this DataTable dt, string text, DataColumn col = null)
        {
            if (col == null) col = dt.Columns[0];
            DataRow dr = dt.NewRow();
            dr[col] = text;
            dt.Rows.Add(dr);
            return dr;
        }

        public static DataRow AddLineRow(this DataTable dt)
        {

            return dt.AddExtraRowInfo(templateFieldDataTable.renderEmptySpace);
        }

        /// <summary>
        /// Adds row with extra information
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="columnInfo">The column information.</param>
        /// <param name="widthLimit">The width limit.</param>
        /// <returns></returns>
        public static DataRow AddExtraRow(this DataTable dt, templateFieldDataTable extra, int widthLimit = 25) => AddExtraRow(dt, (Enum)extra, widthLimit);
        /// <summary>
        /// Adds row with extra information
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="columnInfo">The column information.</param>
        /// <param name="widthLimit">The width limit.</param>
        /// <returns></returns>
        public static DataRow AddExtraRow(this DataTable dt, PropertyEntryColumn extra, int widthLimit = 25) => AddExtraRow(dt, (Enum)extra, widthLimit);


        /// <summary>
        /// Adds row with information taken from the <see cref="DataTable.ExtendedProperties" /> --- at the current position in the table
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="widthLimit">The width limit.</param>
        /// <returns></returns>
        public static DataRow AddExtraRow(this DataTable dt, Enum extra, int widthLimit = 25)
        {
            Dictionary<DataColumn, List<string>> extraLines = new Dictionary<DataColumn, List<string>>();
            aceDictionary2D<int, DataColumn, string> exLines = new aceDictionary2D<int, DataColumn, string>();
            DataRow dr = dt.NewRow();
            DataTableForStatistics dt_stat = null;
            if (dt is DataTableForStatistics) dt_stat = dt as DataTableForStatistics;
            
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ExtendedProperties.ContainsKey(extra))
                {
                    object vl = col.ExtendedProperties[extra];

                    if (vl is string)
                    {
                        string vlstr = vl as string;
                        List<string> lines = vlstr.wrapLineBySpace(widthLimit);
                        if (lines.Count>1)
                        {
                            dr[col] = lines[0];
                            for (int i = 1; i < lines.Count; i++)
                            {
                                exLines[i, col] = lines[i];
                            }

                        } else
                        {
                            dr[col] = vlstr;
                        }
                    }
                    else
                    {
                        dr[col] = vl;
                    }
                }
                else
                {
                    dr[col] = null;
                }
            }
            dt.Rows.Add(dr);
           // if (dt_stat != null) dt_stat.extraRows.Add(dr);

            if (exLines.Count > 0)
            {
                DataRow dre = dt.NewRow();
                foreach (var ex in exLines)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (ex.Value.ContainsKey(col))
                        {
                            dre[col] = ex.Value[col];
                        } else
                        {
                            dre[col] = null;
                        }
                    }
                }
                dt.Rows.Add(dre);
             //   if (dt_stat != null) dt_stat.extraRows.Add(dre);
            }

            
            
            return dr;
        }

        public static DataColumn GetColumn(this DataRow dr, object dc, bool autoCreate=true)
        {
            string key = "";

            if (dc is DataColumn)
            {
                DataColumn dc_DataColumn = (DataColumn)dc;
                key = dc_DataColumn.ColumnName;

            } else
            {
                key = dc.ToString();
            }

            

            if (dr.Table.Columns.Contains(key))
            {
                return dr.Table.Columns[key];
            } else
            {

                if (autoCreate)
                {
                    return dr.Table.Columns.Add(key).SetHeading(key.imbTitleCamelOperation(true));
                }
                else
                {
                    return null;
                }
            }
        }

        public static object Data(this DataRow dc, object columnKey, object default_value)
        {
            var col = dc.GetColumn(columnKey,false);
            if (col == null) return default_value;
            return dc[col];
        }
        public static object GetData(this DataRow dc, object columnKey)
        {
            var col = dc.GetColumn(columnKey,false);
            
            return dc[col];
            
        }

        /// <summary>
        /// Sets data in the row by columnName vs property match
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DataRow SetData(this DataRow dc, object value)
        {
            foreach (DataColumn column in dc.Table.Columns)
            {
                dc[column] = value.imbGetPropertySafe(column.ColumnName, column.DataType.GetDefaultValue());
            }
            return dc;
        }

        public static T SetFromRow<T>(this DataRow dc, T value = null) where T:class, new()
        {
            if (value == null) value = new T();

            foreach (DataColumn column in dc.Table.Columns)
            {
                value.imbSetPropertySafe(column.ColumnName, dc[column], true);
                //dc[column] = value.imbGetPropertySafe(column.ColumnName, column.DataType.GetDefaultValue());
            }
            return value;
        }

        public static DataRow SetData(this DataRow dc, object columnKey, object value)
        {
            var col = dc.GetColumn(columnKey, false);

            dc[col] = value;
            return dc;
        }

        public static DataRow Set(this DataRow dr, int columnIndex, object value)
        {
            dr[columnIndex] = value;
            return dr;
        }


        public static DataRow SetName(this DataRow dr, string name)
        {
            dr[dc_name] = name;
            return dr;
        }

        public static DataRow SetValue(this DataRow dr, int value)
        {
            dr[dc_value] = value;
            if ((value > 0) && (value < 1000))
            {

            }
            return dr;
        }

        /// <summary>
        /// Value is already in cents
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DataRow SetPercentValueInCents(this DataRow dr, Int32 value)
        {
            dr[dc_value] = string.Format("{##0}%", value);
            return dr;
        }


        public static DataRow SetPercentValue(this DataRow dr, int value)
        {
            dr[dc_value] = string.Format("{0:P}", value/100);
            return dr;
        }

        public static DataRow SetPercentValue(this DataRow dr, double value)
        {
            dr[dc_value] = string.Format("{0:P}", value / 100);
            return dr;
        }


        public static DataRow SetValue(this DataRow dr, string value)
        {
            dr[dc_value] = value;
            return dr;
        }

        public static DataRow SetValue(this DataRow dr, double value)
        {
            dr[dc_value] = value;
            if ((value > 0)&&(value < 1000))
            {

            }
            return dr;
        }


        public static DataRow AddRow(this DataTable dt, params object[] values)
        {
            int i = 0;
            DataRow dr = dt.NewRow();
            foreach (object vl in values)
            {
                if (dt.Columns.Count > i)
                {
                    dr[i] = vl;
                    i++;
                } else
                {
                    break;
                }
            }

            dt.Rows.Add(dr);
            return dr;
        }

        ///// <summary>
        ///// Creates new row for the statistics output
        ///// </summary>
        ///// <param name="dt">The dt.</param>
        ///// <param name="rowTitle">The row title.</param>
        ///// <returns></returns>
        //public static DataRow AddRow(this DataTable dt, String rowTitle)
        //{
        //    var dr = dt.NewRow();
        //    dr[dc_name] = rowTitle;
        //    dt.Rows.Add(dr);
        //    return dr;
        //}
    }
}