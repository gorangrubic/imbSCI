namespace imbSCI.DataComplex.tables
{
    using System;
    using System.Collections.Generic;
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
    using imbSCI.Core.math.aggregation;
    using imbSCI.Core.enums;

    public class DataColumnInReportDefinition 
    {
        public DataColumnInReportTypeEnum columnType { get; set; } = DataColumnInReportTypeEnum.data;

        public DataColumnInfoSourceEnum infoSource { get; set; } = DataColumnInfoSourceEnum.none;

        public dataPointAggregationType aggregation { get; set; } = dataPointAggregationType.sum;

        public string columnSourceName { get; set; } = "";

        public string columnLetter { get; set; }
        public string columnUnit { get; set; }
        public string columnDescription { get; set; }
        public string columnName { get; set; }
        public Type columnValueType { get; set; }
        public string format { get; set; }
        public string columnGroup { get; set; }

        public settingsPropertyEntry spe { get; set; }

        public dataPointImportance importance { get; set; }
        public object columnDefault { get; set; }
        public int columnPriority { get; internal set; }
    }

}