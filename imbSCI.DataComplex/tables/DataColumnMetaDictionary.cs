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
    using imbSCI.Core.math.aggregation;
    using imbSCI.Core.extensions.table;

    /// <summary>
    /// Describes what columns shall be created once <see cref="DataTable"/> is converted to <see cref="DataTableForStatistics"/> output
    /// </summary>
    /// <seealso cref="aceCommonTypes.collection.nested.aceEnumListSet{aceCommonTypes.data.tables.DataColumnInReportTypeEnum, aceCommonTypes.data.tables.DataColumnInReportDefinition}" />
    public class DataColumnMetaDictionary : aceDictionarySet<string, DataColumnInReportDefinition>
    {

        public DataColumnInReportDefinition Add(DataColumnInReportTypeEnum columnType, DataColumnInfoSourceEnum infoSource) {

            DataColumnInReportDefinition output = new DataColumnInReportDefinition();
            output.columnType = columnType;
            output.infoSource = infoSource;
            Add(columnType.ToString(), output);
            return output;
        } 

        public DataColumnInReportDefinition Add(DataColumnInReportTypeEnum columnType, DataColumn column, dataPointAggregationType aggregation, string unit = "")
        {
            DataColumnInReportDefinition output = new DataColumnInReportDefinition();
            output.columnType = columnType;
            output.aggregation = aggregation;
            output.columnSourceName = column.ColumnName;
            output.columnPriority = column.GetPriority();
            output.format = column.GetFormat();

            Type valueType = typeof(string);
            string name = ""; string description = ""; string letter = ""; 

            switch (aggregation)
            {
                default:
                case dataPointAggregationType.max:
                case dataPointAggregationType.min:
                case dataPointAggregationType.sum:
                case dataPointAggregationType.firstEntry:
                case dataPointAggregationType.lastEntry:
                case dataPointAggregationType.range:
                    valueType = column.DataType;
                    break;
                case dataPointAggregationType.avg:
                case dataPointAggregationType.stdev:
                case dataPointAggregationType.var:
                case dataPointAggregationType.entropy:
                    valueType = typeof(double);
                    if (output.format.isNullOrEmpty())
                    {
                        output.format = "F5";
                    } 
                    break;
                case dataPointAggregationType.count:
                    valueType = typeof(int);
                    break;
            }
            letter = column.GetLetter();

            if (columnType == DataColumnInReportTypeEnum.dataSummed)
            {
                if (!letter.isNullOrEmpty()) letter = aggregation.ToString() + "(" + letter + ")";
                output.columnLetter = letter;

                output.columnDescription = "(" + aggregation.ToString() + ") of " + column.ColumnName + ". " +column.GetDesc();

            }
            output.columnName = column.ColumnName + " (" + aggregation.ToString() + ")";
            output.columnSourceName = column.ColumnName;
         
            output.importance = column.GetImportance();
            output.columnUnit = column.GetUnit();
            output.columnValueType = valueType;
            output.columnDefault = valueType.GetDefaultValue();
            output.columnGroup = column.GetGroup();

            output.spe = column.GetSPE();
            Add(column.ColumnName, output);
            
            return output;
        }
    }

}