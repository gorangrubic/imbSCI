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

    public enum DataRowInReportTypeEnum
    {
        none,
        mergedHeaderTitle,
        mergedHeaderInfo,
        columnCaption,
        columnDescription,
        columnFooterInfo,
        mergedFooterInfo,
        /// <summary>
        /// The merged horizontally: cells with the same value are merged horizontally
        /// </summary>
        mergedHorizontally,
        info,
        data,
        dataAggregate,
        columnInformation,
        mergedCategoryHeader,
    }

}