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
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.enums.fields;
    using imbSCI.Core.math.aggregation;

    /// <summary>
    /// Describes what rows shall be created once <see cref="DataTable"/> is converted to <see cref="DataTableForStatistics"/> output
    /// </summary>
    /// <seealso cref="aceCommonTypes.collection.nested.aceEnumListSet{aceCommonTypes.data.tables.DataRowInReportTypeEnum, aceCommonTypes.data.tables.DataRowMetaDefinition}" />
    public class DataRowMetaDictionary:aceEnumListSet<DataRowInReportTypeEnum, DataRowMetaDefinition>
    {

        public List<DataRowMetaDefinition> allRows = new List<DataRowMetaDefinition>();



        public DataRowMetaDefinition Add(DataRowInReportTypeEnum type, templateFieldDataTable cellSource)
        {
            var output = new DataRowMetaDefinition(type, cellSource);
            Add(type, output);
            
            return output;
        }

        public DataRowMetaDefinition Add(DataRowInReportTypeEnum type, dataPointAggregationType aggregation)
        {
            var output = new DataRowMetaDefinition(type, aggregation);
            Add(type, output);

            return output;
        }

    }

}