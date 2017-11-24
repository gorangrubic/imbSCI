// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTableForStatisticsExtension.cs" company="imbVeles" >
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
    using imbSCI.Core.files.folders;
    using imbSCI.Core.files;
    using imbSCI.DataComplex.extensions.data.operations;
    using imbSCI.Data.enums;
    using imbSCI.Core.extensions.table;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Core.extensions.io;
    using imbSCI.DataComplex.extensions.data.schema;

    public static class DataTableForStatisticsExtension
    {

        /// <summary>
        /// Checks if data type is allowed for the DataTable
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static bool checkIfDataTypeIsAllowed(this Type type) {

            if (type == typeof(bool)) return true;
            if (type == typeof(byte)) return true;
            if (type == typeof(byte[])) return true;
            if (type == typeof(char)) return true;
            if (type == typeof(DateTime)) return true;
            if (type == typeof(decimal)) return true;
            if (type == typeof(double)) return true;
            if (type == typeof(Guid)) return true;
            if (type == typeof(short)) return true;
            if (type == typeof(int)) return true;
            if (type == typeof(long)) return true;
            if (type == typeof(sbyte)) return true;
            if (type == typeof(float)) return true;
            if (type == typeof(string)) return true;
            if (type == typeof(TimeSpan)) return true;
            if (type == typeof(ushort)) return true;
            if (type == typeof(uint)) return true;
            if (type == typeof(ulong)) return true;
            
            return false;
        }

      


        public static DataTable RenderPivoted(this DataTable source, int rows = 2, int rowsSkip = 1)
        {
            DataTable legend = new DataTable(source.TableName);

            DataColumn columnGroup = legend.Add("Group").SetWidth(20).SetValueType(typeof(string));
            DataColumn columnName = legend.Add("Name").SetWidth(30).SetValueType(typeof(string));
            DataColumn columnLetter = legend.Add("Letter").SetWidth(10).SetValueType(typeof(string));

            List<DataColumn> columnValues = new List<DataColumn>();
            for (int i = rowsSkip; i < rows; i++)
            {
                string dcn = "Data" + i.ToString("D2");
                var dc = legend.Add(dcn);
                dc.SetWidth(30);


                columnValues.Add(dc); // new DataColumn(dcn));

            }


            DataColumn columnUnit = legend.Add("Unit").SetWidth(15).SetValueType(typeof(string));
            DataColumn columnDescription = legend.Add("Description").SetWidth(180).SetValueType(typeof(string));





            foreach (DataColumn dc in source.Columns)
            {
                var dr = legend.NewRow();

                dr[columnGroup] = dc.GetGroup();
                dr[columnName] = dc.GetHeading();
                dr[columnLetter] = dc.GetLetter();

                for (int i = 0; i < columnValues.Count; i++)
                {
                    DataRow dro = source.Rows[i];
                    dr[columnValues[i]] = dro[dc];

                }


                dr[columnUnit] = dc.GetUnit();
                dr[columnDescription] = dc.GetDesc();

                legend.Rows.Add(dr);
            }



            return legend;
        }



        public static DataSetForStatistics GetReportVersion(this DataSet source, bool disablePrimaryKey=true)
        {

            DataSetForStatistics output = new DataSetForStatistics();
            output.DataSetName = source.DataSetName;

            foreach (DataTable dt in source.Tables)
            {
                output.AddTable(dt.GetReportTableVersion(disablePrimaryKey));
            }

            return output;

        }
        public static DataTableForStatistics GetReportTableVersion(this DataTable source, bool disablePrimaryKey=true)
        {
            DataTableForStatistics output = source.GetClonedShema<DataTableForStatistics>(disablePrimaryKey);

            //output.AddRowNameColumn("Row name", true);
            // output.AddRowDescriptionColumn("Description", true);
            //// output.AddRowDescriptionColumn("Row info", true);
            // // <--- ovde ubaciti da atributi klase odredjuju stra prikazuje 
            // output.AddExtraRow(templateFieldDataTable.col_group, 200);
            // output.AddExtraRow(PropertyEntryColumn.entry_unit, 200);
            // output.AddExtraRow(templateFieldDataTable.col_letter, 200);
            // output.AddExtraRow(templateFieldDataTable.col_desc, 200);

         //   output.SetDefaults();
            output.CopyRowsFrom(source);

            output.ApplyObjectTableTemplate();

            return output;
        }



        public static DataTable SaveXML(this DataTable source, folderNode folder, string filenamePrefix = "", bool clearMeta=true, bool checkContent=true, ILogBuilder logger = null)
        {
            if (source.TableName.isNullOrEmpty()) source.TableName = filenamePrefix + source.GetHashCode().ToString() + ".xml";

            string path = folder.pathFor(filenamePrefix + source.GetHashCode().ToString() + ".xml", getWritableFileMode.autoRenameExistingOnOtherDate);

            if (clearMeta) source = source.CleanMeta();


            if (checkContent)
            {
                foreach (DataRow row in source.Rows)
                {
                    foreach (DataColumn dc in source.Columns)
                    {
                        var t = row[dc]?.GetType();
                        if (t.IsClass)
                        {

                            if (logger != null) logger.log(" === unallowed content detected in the table to save " +  path);
                            row[dc] = dc.DataType.GetDefaultValue();
                        }
                    }

                }
            }

            bool notOkToSave = false;
            foreach (DataColumn dc in source.Columns)
            {
                bool okType = dc.DataType.checkIfDataTypeIsAllowed();
                if (!okType)
                {
                    notOkToSave = true;
                    break;
                }
            }

            if (!notOkToSave)
            {
                objectSerialization.saveObjectToXML(source, path);

            } else
            {
                if (logger != null) logger.log("Can't save XML for table: " + source.TableName + " to " + path);
                
            }

            return source;
        }


        public static DataTable Save(this DataTable source, folderNode folder, aceAuthorNotation notation = null, string filenamePrefix = "")
        {
            
            if (source is DataTable)
            {
              //  source.SetDefaults();
            }

            string path = source.serializeDataTable(dataTableExportEnum.excel, filenamePrefix, folder, notation);

            
            //source.serializeDataTable(enums.dataTableExportEnum.excel, filenamePrefix + "_source", folder, notation);


            return source;
        }

        public static bool tableReportCreation_useShortNames { get; set; }
        public static bool tableReportCreation_insertFilePathToTableExtra { get; set; } = true;

        public const string PREFIX_CLEANDATATABLE = "dc_";
        public const string PREFIX_REPORTDATATABLE = "dr_";
        public const string PREFIX_COLUMNINFO = "ci_";

        public const string EXTRAFOLDER = "data";

        public static DataTableForStatistics GetReportAndSave(this DataTable source, folderNode folder, aceAuthorNotation notation = null, string filenamePrefix = "", bool disablePrimaryKey = true)
        {

           // if (source == null) return new DataTableForStatistics();
            if (source.Columns.Count > 0)
            {
                if (DataTableForStatistics.AUTOSAVE_CleanDataTable)
                {
                    string cld = source.serializeDataTable(dataTableExportEnum.csv,  PREFIX_CLEANDATATABLE + filenamePrefix.getFilename() + ".csv", folder[EXTRAFOLDER], notation);
                    source.SetAdditionalInfoEntry("Clean data", cld);
                }

                if (DataTableForStatistics.AUTOSAVE_FieldsText)
                {
                    string cli = folder[EXTRAFOLDER].pathFor(PREFIX_COLUMNINFO + filenamePrefix.getFilename() + ".txt");
                    source.GetUserManualForTableSaved(cli);
                    source.SetAdditionalInfoEntry("Column info", cli);
                }

                if (tableReportCreation_insertFilePathToTableExtra)
                {

                }
            }


            DataTableForStatistics output = null;


            if (source is DataTableForStatistics)
            {
                output = source as DataTableForStatistics;
            }
            else
            {
                output = source.GetReportTableVersion(disablePrimaryKey);
               // output.SetDefaults();
              
                //source.serializeDataTable(enums.dataTableExportEnum.excel, filenamePrefix + "_source", folder, notation);
            }

            output.Save(folder, notation, filenamePrefix);

            return output;
        }


        public static void SetDefaults(this DataTable source)
        {
            foreach (DataColumn dc in source.Columns)
            {
                //if (dc.GetWidth()== dataColumnRenderingSetup.DEFAULT_WIDTH)
                //{
                //    if (dc.GetValueType() == typeof(String)) dc.SetWidth(40);
                //    if (dc.GetValueType() == typeof(Int32)) dc.SetWidth(10);
                //}
                if (dc.GetFormat() == "")
                {
                    if (dc.GetValueType() == typeof(double))
                    {
                        if (dc.GetUnit().Contains("%"))
                        {
                            dc.SetFormat("P2");
                        } else
                        {
                            dc.SetFormat("F5");
                        }
                    }
                }
            }


            

        }

        //public static String 
    }

}