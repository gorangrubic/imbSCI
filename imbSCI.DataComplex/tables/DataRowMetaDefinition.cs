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
    using imbSCI.Core.math.aggregation;
    using imbSCI.Data.enums.fields;

    public class DataRowMetaDefinition:PropertyCollectionExtended
    {
        public DataRowInReportTypeEnum rowType { get; set; } = DataRowInReportTypeEnum.data;
        public templateFieldDataTable cellDataSource { get; set; } = templateFieldDataTable.renderEmptySpace;


        public DataRow rowInstance { get; set; } = null;
        public dataPointAggregationType aggregation { get; set; } = dataPointAggregationType.none;

        public DataRowMetaDefinition(DataRowInReportTypeEnum __rowType, dataPointAggregationType __aggregation)
        {
            rowType = __rowType;
            aggregation = __aggregation;

        }


        public DataRowMetaDefinition(DataRowInReportTypeEnum __rowType, templateFieldDataTable __cellDataSource)
        {
            rowType = __rowType;
            cellDataSource = __cellDataSource;

        }

        public DataRowMetaDefinition()
        {

        }

        public DataRowMetaDefinition(DataRowInReportTypeEnum type)
        {
            rowType = type;
        }

        public DataRowMetaDefinition(DataRow instance, DataRowInReportTypeEnum type)
        {
            rowType = type;
            rowInstance = instance;
        }

        public DataRowMetaDefinition(DataRow instance)
        {
            rowType = DataRowInReportTypeEnum.data;
            rowInstance = instance;
        }
    }

}