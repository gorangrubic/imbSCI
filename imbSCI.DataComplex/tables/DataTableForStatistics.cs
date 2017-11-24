﻿namespace imbSCI.DataComplex.tables
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.table;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.exceptions;
    using imbSCI.DataComplex.extensions.data.modify;
    using OfficeOpenXml;
    using imbSCI.Data.enums.fields;
    using OfficeOpenXml.Style;
    using imbSCI.Core.reporting.zone;
    using imbSCI.DataComplex.extensions.data.schema;
    using imbSCI.Core.math.aggregation;
    using imbSCI.DataComplex.extensions.data.operations;
    using imbSCI.DataComplex.extensions.data;
    using imbSCI.Core.files.folders;

    /// <summary>
    /// IDEJA SAMO
    /// </summary>
    /// <seealso cref="System.Data.DataTable" />
    public class DataTableForStatistics : DataTable
    {
        public static bool AUTOSAVE_CleanDataTable = true;
        public static bool AUTOSAVE_FieldsText = true;


        public int RowStart { get; set; } = 1;
        /// <summary>
        /// Rel address of the last aggregated row having maximum number of rows aggregated (i.e. number of common rows)
        /// </summary>
        /// <value>
        /// The row aggregation all.
        /// </value>
        public int RowsWithMaxAggregation { get; set; } = 1;

        public int RowsWithDataCount { get; set; } = 1;

        public DataTableCategorySets categories { get; set; }

        public Dictionary<DataColumn, DataColumnInReportTypeEnum> extraColumnStyles { get; set; } = new Dictionary<DataColumn, DataColumnInReportTypeEnum>();


        public Dictionary<DataRow, DataRowInReportTypeEnum> extraRowStyles { get; set; } = new Dictionary<DataRow, DataRowInReportTypeEnum>();

        /// <summary>
        /// Last file path that used for save or load
        /// </summary>
        public string lastFilePath { get; protected set; }


        //public String Save(folderNode folder, aceAuthorNotation notation=null, String filenamePrefix = "")
        //{
        //    if (filenamePrefix.isNullOrEmpty()) filenamePrefix = TableName;
        //    if (notation == null) notation = new aceAuthorNotation();
        //    String path = this.serializeDataTable(aceCommonTypes.enums.dataTableExportEnum.excel, filenamePrefix, folder, notation);
        //    lastFilePath = path;
        //    return path;
        //}

        public DataTableForStatistics()
        {


        }

        public DataTable ApplyFilters(DataTable output)
        {
            List<DataColumn> toRemove = new List<DataColumn>();

            foreach (DataColumn dc in output.Columns)
            {
                if (dc.ExtendedProperties.ContainsKey(imbAttributeName.reporting_hide))
                {
                    toRemove.Add(dc);
                }
                else
                {
                    var def = dc.GetAggregation();
                    if (def != null)
                    {
                        switch (def.multiTableType)
                        {
                            case dataPointAggregationType.hidden:
                                toRemove.Add(dc);
                                break;
                        }
                    }
                }
            }

            foreach (DataColumn dc in toRemove)
            {
                output.Columns.Remove(dc);
            }
            return output;
        }


        public DataRowMetaDictionary metaRowInfo { get; set; }

        public DataColumnMetaDictionary metaColumnInfo { get; set; }

        public DataTable RenderDataTable()
        {
            DataTable output = new DataTable(TableName);
            output = this.GetClonedShema<DataTable>();


            ApplyFilters(output);


            //output.SetRowMeta(new DataRowMetaDictionary());
            //output.SetDescription(this.GetDescription());

            //foreach (DataColumnInReportDefinition cd in metaColumnInfo[nameof(DataColumnInReportTypeEnum.infoOnLeft)])
            //{
            //    DataColumn dtc = output.Add(cd.infoSource);
            //    dtc.SetOrdinal(0);
            //}

            //foreach (DataColumnInReportDefinition cd in metaColumnInfo[nameof(DataColumnInReportTypeEnum.infoOnRight)])
            //{
            //    DataColumn dtc = output.Add(cd.infoSource);
            //    dtc.SetOrdinal(output.Columns.Count-1);
            //}




            //  extraColumnStyles.Add(output.AddRowNameColumn("Row name", false), DataColumnInReportTypeEnum.infoOnLeft);
            // extraColumnStyles.Add(output.AddRowDescriptionColumn("Description", true), DataColumnInReportTypeEnum.infoOnRight);

            // output.AddRowDescriptionColumn("Row info", true);
            // <--- ovde ubaciti da atributi klase odredjuju stra prikazuje 
            extraRowStyles.Add(output.AddExtraRow(templateFieldDataTable.col_group, 200), DataRowInReportTypeEnum.mergedCategoryHeader);
            extraRowStyles.Add(output.AddExtraRow(templateFieldDataTable.col_caption, 200), DataRowInReportTypeEnum.columnCaption);
            //extraRowStyles.Add(output.AddExtraRow(templateFieldDataTable.col_unit, 200), DataRowInReportTypeEnum.columnInfo);
            extraRowStyles.Add(output.AddExtraRow(templateFieldDataTable.col_unit, 200), DataRowInReportTypeEnum.columnDescription);
            // extraRowStyles.Add(output.AddExtraRow(templateFieldDataTable.col_desc, 300), DataRowInReportTypeEnum.columnDesc);

            RowStart = output.Rows.Count;


            output.CopyRowsFrom(this);

            RowsWithDataCount = output.Rows.Count - RowStart;

            PropertyCollectionExtended pce = this.GetAdditionalInfo();
            var val = pce[DataTableAggregationDefinition.ADDPROPS_ROWSCOMMON];
            if (val != null) {
                RowsWithMaxAggregation = val.imbToNumber<int>();
            } else
            {
                RowsWithMaxAggregation = RowsWithDataCount;
            }
            categories = new DataTableCategorySets(output);




            extraRowStyles.Add(output.AddLineRow(), DataRowInReportTypeEnum.mergedHorizontally);



            //foreach (DataColumn dc in output.Columns)
            //{
            //    dc.GetAggregation().rowRangeStart = ri;
            //    dc.GetAggregation().rowRangeEnd = ri;
            //}





            foreach (string ext in this.GetExtraDesc())
            {
                extraRowStyles.Add(output.AddStringLine(ext), DataRowInReportTypeEnum.mergedHorizontally);
            }


            extraRowStyles.Add(output.AddLineRow(), DataRowInReportTypeEnum.mergedHorizontally);






            return output;
        }

        public string fontName { get; set; } = "Cambria"; //"Times New Roman";
        public System.Drawing.Color columnCaption = System.Drawing.Color.SteelBlue;
        public System.Drawing.Color extraEven = System.Drawing.Color.LightSlateGray;
        public System.Drawing.Color extraEvenOther = System.Drawing.Color.LightSteelBlue;
        public System.Drawing.Color extraOdd = System.Drawing.Color.SlateGray;
        public System.Drawing.Color dataOdd = System.Drawing.Color.WhiteSmoke;
        public System.Drawing.Color dataEven = System.Drawing.Color.Snow;


        public void DefineStyles(ExcelWorksheet ws)
        {
            if (ws.Workbook.Styles.NamedStyles.Count() > 0) return;


            var style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.data));
            style.Style.Font.Name = fontName;
            
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
            style.Style.Font.Bold = false;
            style.Style.Font.Size = 10;
           // style.StyleXfId = 1;


            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.mergedHeaderTitle));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SteelBlue);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.2);
            style.Style.Font.Bold = true;
            style.Style.Font.Size = 10;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //style.StyleXfId = 2;

            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.mergedHeaderInfo));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSlateGray);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.2);
            style.Style.Font.Bold = false;
            style.Style.Font.Size = 9;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
          //  style.StyleXfId = 3;

            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.columnCaption));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SteelBlue);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.4);
            style.Style.Font.Bold = true;
            style.Style.Font.Size = 10;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
           // style.StyleXfId = 4;



            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.columnDescription));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.4);
            style.Style.Font.Bold = false;
            style.Style.Font.Size = 8;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
           // style.StyleXfId = 5;


            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.columnInformation));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SlateGray);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.4);
            style.Style.Font.Bold = false;
            style.Style.Font.Size = 8;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
           // style.StyleXfId = 6;

            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.mergedCategoryHeader));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
            style.Style.Font.Bold = false;
            style.Style.Font.Size = 10;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
          //  style.StyleXfId = 7;

            style = ws.Workbook.Styles.CreateNamedStyle(nameof(DataRowInReportTypeEnum.mergedFooterInfo));
            style.Style.Font.Name = fontName;
            style.Style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSlateGray);
            style.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
            style.Style.Font.Bold = true;
            style.Style.Font.Size = 9;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            style.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //   style.StyleXfId = 8;

        }

        public void DeployStyle(DataTable table, ExcelWorksheet ws)
        {
            int rc = ws.Dimension.Rows;

            
            if (rc > ROW_LIMIT_TODISABLE_STYLING)
            {

            }
            else
            {
                for (int i = 0; i < rc; i++)
                {
                    var ex_row = ws.Row(i + 1);
                    var in_row = table.Rows[i];
                    if (i > ROW_LIMIT_FOR_STYLE) break;
                    DeployStyleToRow(ex_row, in_row, ws);
                }
            }

            foreach (DataColumn dc in table.Columns)
            {
                ws.Column(dc.Ordinal + 1).Width = dc.GetWidth();

                switch (dc.GetImportance())
                {
                    case dataPointImportance.alarm:
                        ws.Column(dc.Ordinal + 1).Style.Font.Color.SetColor(System.Drawing.Color.Red);
                        break;
                    case dataPointImportance.important:
                        ws.Column(dc.Ordinal + 1).Style.Font.Bold = true;
                        break;
                    case dataPointImportance.none:
                        break;
                    case dataPointImportance.normal:
                        break;
                }
                
            }

        }


        public void DeployStyleToRow(ExcelRow ex_row, DataRow in_row, ExcelWorksheet ws)
        {
            DataRowInReportTypeEnum style = DataRowInReportTypeEnum.data;


            if (extraRowStyles.ContainsKey(in_row))
            {
                style = extraRowStyles[in_row];
            }
            bool isEven = ((in_row.Table.Rows.IndexOf(in_row) % 2) > 0);

           // ex_row.Style.Font.Name = fontName;
            
            System.Drawing.Color clr = dataEven;
            System.Drawing.Color clr2 = extraEvenOther;

            ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;

            
          


            switch (style)
            {
                case DataRowInReportTypeEnum.mergedHeaderTitle:
                    ex_row.Height = 30;
                   ex_row.StyleName = nameof(DataRowInReportTypeEnum.mergedHeaderTitle);

                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    ws.Cells[ex_row.Row, 1, ex_row.Row, in_row.Table.Columns.Count].Merge = true;
                    clr = columnCaption;
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ex_row.Style.Font.Size = 9;
                    break;
                case DataRowInReportTypeEnum.mergedHeaderInfo:
                    ex_row.Height = 24;
                   ex_row.StyleName = nameof(DataRowInReportTypeEnum.mergedHeaderInfo);
                    ws.Cells[ex_row.Row, 1, ex_row.Row, in_row.Table.Columns.Count].Merge = true;
                    clr = extraOdd;
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    break;
                case DataRowInReportTypeEnum.columnCaption:
                    ex_row.Height = 30;
                   ex_row.StyleName = nameof(DataRowInReportTypeEnum.columnCaption);
                    clr = columnCaption;
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkGray);
                    ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.6);
                    ex_row.Style.Font.Size = 10;
                    break;
                case DataRowInReportTypeEnum.mergedFooterInfo:
                    ex_row.Height = 25;
                    ex_row.StyleName = nameof(DataRowInReportTypeEnum.mergedFooterInfo);
                    ws.Cells[ex_row.Row, 1, ex_row.Row, in_row.Table.Columns.Count].Merge = true;
                    if (isEven)
                    {
                        clr = extraEven;
                    }
                    else
                    {
                        clr = extraOdd;
                    }
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    break;
                case DataRowInReportTypeEnum.columnDescription:
                    ex_row.Height = 18;
                   ex_row.StyleName = nameof(DataRowInReportTypeEnum.columnDescription);

                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkGray);
                    ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
                    
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ex_row.Style.Font.Size = 9;
                    break;
                case DataRowInReportTypeEnum.columnInformation:
                    ex_row.Height = 28;
                    ex_row.StyleName = nameof(DataRowInReportTypeEnum.columnInformation);
                    if (isEven)
                    {
                        clr = extraEven;
                    }
                    else
                    {
                        clr = extraOdd;
                    }
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    break;
                case DataRowInReportTypeEnum.mergedHorizontally:
                    ex_row.Height = 20;
                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.8);

                    selectZone z = new selectZone(0, 0, Columns.Count-1, 0);
                    var s2l = ws.getExcelRange(ex_row, z);
                    s2l.Merge = true;
                    break;
                case DataRowInReportTypeEnum.mergedCategoryHeader:
                    ex_row.Height = 25;
                     ex_row.StyleName = nameof(DataRowInReportTypeEnum.mergedCategoryHeader);
                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                    ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.7);
                    double tn = 0.2;
                    int hlip = -1;
                    foreach (var cpair in categories)
                    {
                        if (hlip == -1)
                        {
                            tn = 0.3;
                        }
                        else
                        {
                            tn = 0.6;
                        }
                       
                        foreach (selectZone zone in categories.categoryZones[cpair.Key])
                        {

                            
                            var sl = ws.getExcelRange(ex_row, zone);
                            sl.Merge = true;
                            sl.Value = cpair.Key.ToUpper();
                            sl.Style.Fill.PatternType = ExcelFillStyle.Solid;

                            sl.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                            sl.Style.Fill.BackgroundColor.Tint = new decimal(tn);
                         
                        }

                        hlip = -hlip;
                        
                    }
                    isEven = !isEven;
                    ex_row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ex_row.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    break;
                default:
                case DataRowInReportTypeEnum.data:
                    ex_row.Height = 15;
                    //ex_row.Style.Font.Size = 9;
                   
                    foreach (DataColumn dc in in_row.Table.Columns)
                    {
                        string format = dc.GetFormatForExcel();
                        if (!format.isNullOrEmpty()) ws.Cells[ex_row.Row, dc.Ordinal + 1].Style.Numberformat.Format = format;
                    }

                   
                    ex_row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
                    ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
                    ex_row.Style.Font.Bold = false;
                    ex_row.Style.Font.Size = 9;

                    if (isEven)
                    {
                        ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.8);
                        clr = dataEven;
                    }
                    else
                    {
                        ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.2);
                        clr = dataOdd;
                    }

                    break;

            }




            //ex_row.StyleID = 1;
            ex_row.Style.Font.Name = fontName;
            ex_row.Style.WrapText = true;

            if (ex_row.Row == (RowStart + RowsWithMaxAggregation))
            {
                
                ex_row.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                ex_row.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Red);
            }

          
         //   ex_row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
          //  ex_row.Style.Fill.BackgroundColor.Tint = new decimal(0.2);

           

           //BackgroundColor.SetColor(clr);


           


            //ex_row.Style.WrapText = true;
        }





        public DataTable RenderLegend()
        {
            DataTable legend = new DataTable("LEGEND");

            DataColumn columnGroup = legend.Add("Group").SetDefaultBackground(columnCaption).SetWidth(25);
            DataColumn columnName = legend.Add("Name").SetDefaultBackground(extraEven).SetWidth(40);
            DataColumn columnLetter = legend.Add("Letter").SetDefaultBackground(extraOdd).SetWidth(25);
            DataColumn columnUnit = legend.Add("Unit").SetDefaultBackground(extraEven).SetWidth(25);
            DataColumn columnDescription = legend.Add("Description").SetDefaultBackground(dataOdd).SetWidth(180);


            extraRowStyles.Add(legend.AddRow("Table name", this.GetTitle()), DataRowInReportTypeEnum.columnDescription);
            extraRowStyles.Add(legend.AddRow("Table description", this.GetDescription()), DataRowInReportTypeEnum.columnDescription);
            extraRowStyles.Add(legend.AddRow("Aggregated aspect", this.GetAggregationAspect()), DataRowInReportTypeEnum.columnDescription);
            extraRowStyles.Add(legend.AddRow("Aggregated sources", this.GetAggregationOriginCount()), DataRowInReportTypeEnum.columnDescription);
            extraRowStyles.Add(legend.AddRow("Table class name", this.GetClassName()), DataRowInReportTypeEnum.columnDescription);
            legend.AddLineRow();
            //legend.AddRow("Table class name", this.);

            extraRowStyles.Add(legend.AddExtraRow(templateFieldDataTable.col_caption, 200), DataRowInReportTypeEnum.columnCaption);

            foreach (DataColumn dc in Columns)
            {
                var dr = legend.NewRow();

                dr[columnGroup] = dc.GetGroup();
                dr[columnName] = dc.GetHeading();
                dr[columnLetter] = dc.GetLetter();
                dr[columnUnit] = dc.GetUnit();
                dr[columnDescription] = dc.GetDesc();

                legend.Rows.Add(dr);
            }

            extraRowStyles.Add(legend.AddLineRow(), DataRowInReportTypeEnum.mergedHorizontally);

            
            foreach (string ext in this.GetExtraDesc())
            {
                extraRowStyles.Add(legend.AddStringLine(ext), DataRowInReportTypeEnum.mergedHorizontally);
            }


            extraRowStyles.Add(legend.AddLineRow(), DataRowInReportTypeEnum.mergedHorizontally);

            var pce = this.GetAdditionalInfo();

            extraRowStyles.Add(legend.AddRow("Additional information"), DataRowInReportTypeEnum.mergedFooterInfo);

            extraRowStyles.Add(legend.AddRow("Property", "Value", "Info"), DataRowInReportTypeEnum.columnCaption);
            foreach (KeyValuePair<object, PropertyEntry> entryPair in pce.entries)
            {
                extraRowStyles.Add(legend.AddRow(entryPair.Key, entryPair.Value[PropertyEntryColumn.entry_value], entryPair.Value[PropertyEntryColumn.entry_description]), DataRowInReportTypeEnum.columnInformation);
            }


            return legend;
        }

        public void SaveToLegendWorksheet(ExcelWorksheet ws)
        {
            DefineStyles(ws);
            DataTable legend = RenderLegend();
            ws.Cells["A1"].LoadFromDataTable(legend, false);
            DeployStyle(legend, ws);
        }

        public static int ROW_LIMIT_FOR_STYLE = 100;
        public static int ROW_LIMIT_TODISABLE_STYLING = 200;

        public void SaveToWorksheet(ExcelWorksheet ws)
        {
            DefineStyles(ws);
            DataTable source = RenderDataTable();
            
            ws.Cells["A1"].LoadFromDataTable(source, false);
            
            DeployStyle(source, ws);

        }


        public void InsertAggregation(ExcelWorksheet ws, DataTable dataTable)
        {

            
            int ri = 0;
            int re = 0;
            foreach (DataColumn dc in dataTable.Columns)
            {
                var aggregation = dc.GetAggregation();

                ri = Math.Max((int) aggregation.rowRangeStart, ri);

                re = Math.Max((int) aggregation.rowRangeEnd, re);

            }

            ExcelRow er = ws.Row(re + 2);

            foreach (DataColumn dc in dataTable.Columns)
            {
                if (dc.GetValueType() == typeof(string))
                {
                    ws.Cells[re + 2, dc.Ordinal].Value = "SUM()"; //ws.Cells[ri, dc.Ordinal, re, dc.Ordinal]
                    ws.Cells[re + 3, dc.Ordinal].Value = "AVG()";
                    ws.Cells[re + 4, dc.Ordinal].Value = "MAX()";
                    ws.Cells[re + 5, dc.Ordinal].Value = "MIN()";
                    ws.Cells[re + 6, dc.Ordinal].Value = "VAR()";
                    ws.Cells[re + 7, dc.Ordinal].Value = "STDEV()";
                }
                else
                {
                    ws.Cells[re + 2, dc.Ordinal].Formula = string.Format("SUM({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address); //ws.Cells[ri, dc.Ordinal, re, dc.Ordinal]
                    ws.Cells[re + 3, dc.Ordinal].Formula = string.Format("AVG({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address);
                    ws.Cells[re + 4, dc.Ordinal].Formula = string.Format("MAX({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address);
                    ws.Cells[re + 5, dc.Ordinal].Formula = string.Format("MIN({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address);
                    ws.Cells[re + 6, dc.Ordinal].Formula = string.Format("VAR({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address);
                    ws.Cells[re + 7, dc.Ordinal].Formula = string.Format("STDEV({0})", new ExcelAddress(ri, dc.Ordinal, re, dc.Ordinal).Address);
                }
            }
        }

        //public static String GetFileName(this DataTa)

        public string Save(folderNode folder, aceAuthorNotation notation = null, string filenamePrefix = "")
        {
            string msg = "tried to save a data table [" + this.GetTitle() + "][" + TableName + "] -> " + folder.path + " [" + DateTime.Now.ToLongTimeString() + "/" + DateTime.Now.ToLongDateString() + "]";
            string fl = "note_savefailed_" + GetHashCode() + ".txt";
            //FileInfo fi = msg.saveStringToFile(folder.pathFor(fl, getWritableFileMode.none), getWritableFileMode.autoRenameExistingToBack);
            FileInfo fileInfo = null;

            try
            {

                string output = "";
                string filename = "";
               
                if (DataTableForStatisticsExtension.tableReportCreation_useShortNames)
                {
                    if (filenamePrefix.isNullOrEmpty())
                    {
                        filename = "dt_".add(TableName, "_").getFilename();
                    }
                    else
                    {
                        filename = "dt_".add(filenamePrefix, "_").getFilename();
                    }
                }
                else
                {
                    filename = "dt_" + filenamePrefix.add(TableName).getFilename();
                }

                filename = filename.ensureEndsWith(".xlsx");
                filename = folder.pathFor(filename);

                fileInfo = filename.getWritableFile(getWritableFileMode.overwrite);

                if (DataTableForStatisticsExtension.tableReportCreation_insertFilePathToTableExtra)
                {
                    this.SetAdditionalInfoEntry("Folder", fileInfo.DirectoryName);
                    this.SetAdditionalInfoEntry("File", fileInfo.Name);
                    this.SetAdditionalInfoEntry("ID", filenamePrefix);

                }

                if (Rows.Count == 0) return fileInfo.FullName;

                //if (File.Exists(fileInfo.FullName)) File.Delete(fileInfo.FullName);
                try
                {
                    using (ExcelPackage pck = new ExcelPackage(fileInfo))
                    {

                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.GetTitle());
                        ExcelWorksheet wsL = pck.Workbook.Worksheets.Add("LEGEND");

                        pck.Workbook.Properties.Title = this.GetTitle();
                        pck.Workbook.Properties.Comments = notation.comment;
                        pck.Workbook.Properties.Category = "DataTable export";
                        pck.Workbook.Properties.Author = notation.author;
                        pck.Workbook.Properties.Company = notation.organization;
                        pck.Workbook.Properties.Application = notation.software;
                        //pck.Workbook.Properties.Keywords = meta.keywords.content.toCsvInLine();
                        pck.Workbook.Properties.Created = DateTime.Now;
                        pck.Workbook.Properties.Subject = this.GetDescription();

                        SaveToWorksheet(ws);

                        SaveToLegendWorksheet(wsL);

                        pck.Save();
                    }
                }
                catch (Exception ex)
                {
                    throw new dataException("Excell: " + ex.Message, ex, this, "Export to excell");

                    msg = msg.addLine(ex.Message);
                    msg = msg.addLine(ex.StackTrace);

                    msg.saveStringToFile(folder.pathFor(fl, getWritableFileMode.none), getWritableFileMode.autoRenameExistingToBack);
                }

                output = fileInfo.FullName;
                return output;
            } catch (Exception ex2) {

                msg = msg.addLine(ex2.Message);
                msg = msg.addLine(ex2.StackTrace);

                msg.saveStringToFile(folder.pathFor(fl, getWritableFileMode.none), getWritableFileMode.autoRenameExistingToBack);
            }

            //fi.Delete();
            if (fileInfo != null)
            {
                return fileInfo.FullName;
            } else
            {
                return "error";
            }
        }


        /// <summary>
        /// Applies the object table template.
        /// </summary>
        public void ApplyObjectTableTemplate()
        {
            if (metaRowInfo == null) metaRowInfo = new DataRowMetaDictionary();
            if (metaColumnInfo == null) metaColumnInfo = new DataColumnMetaDictionary();

            metaRowInfo.Add(DataRowInReportTypeEnum.mergedHeaderTitle, templateFieldDataTable.title);
            metaRowInfo.Add(DataRowInReportTypeEnum.mergedHeaderInfo, templateFieldDataTable.description);

            metaRowInfo.Add(DataRowInReportTypeEnum.mergedHorizontally, templateFieldDataTable.col_group);
            metaRowInfo.Add(DataRowInReportTypeEnum.columnCaption, templateFieldDataTable.col_caption);
            metaRowInfo.Add(DataRowInReportTypeEnum.columnDescription, templateFieldDataTable.col_letter);
            metaRowInfo.Add(DataRowInReportTypeEnum.columnDescription, templateFieldDataTable.col_unit);

            metaRowInfo.Add(DataRowInReportTypeEnum.columnFooterInfo, templateFieldDataTable.col_desc);


            metaRowInfo.Add(DataRowInReportTypeEnum.mergedFooterInfo, templateFieldDataTable.table_extraDesc);

         //   metaColumnInfo.Add(DataColumnInReportTypeEnum.infoOnLeft, DataColumnInfoSourceEnum.rowName);
          //  metaColumnInfo.Add(DataColumnInReportTypeEnum.infoOnRight, DataColumnInfoSourceEnum.rowDescription);


            // this.AddLineRow();

            //this.setColumnWidths(100);

           // this.AddLineRow();
         //   this.AddExtraRowInfo(templateFieldDataTable.col_group).SetName("Group").SetDesc("Group/Category of the property");
          //  this.AddExtraRowInfo(templateFieldDataTable.col_caption).SetName("Name").SetDesc("Descriptive name for the data point");
            //  output.AddExtraRowInfo(templateFieldDataTable.col_name).SetName("Code name").SetDesc("Code name used in the source code");
           // this.AddExtraRowInfo(templateFieldDataTable.col_letter).SetName("Notation").SetDesc("Letter-code notation used in the article");
           // this.AddExtraRowInfo(templateFieldDataTable.col_desc).SetName("Description").SetDesc("Description of the value columns below");

          //  this.AddLineRow();
          //  this.AddExtraLinesAsRows();
            
            

            //this.AddRow("Max. frequency").Set(1, max.ToString()).SetDesc("The highest number of occurences in the document");
            //this.AddRow("Max. cumulative weight").Set(1, maxWeight.ToString()).SetDesc("The highest cumulative weight in the document");
        }

        //public DataTableForStatistics():base()
        //{

        //}
    }
}