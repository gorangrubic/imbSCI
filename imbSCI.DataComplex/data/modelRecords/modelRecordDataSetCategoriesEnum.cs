namespace imbSCI.DataComplex.data.modelRecords
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

    public enum modelRecordDataSetCategoriesEnum
    {
        /// <summary>
        /// The master record
        /// </summary>
        [imb(imbAttributeName.menuCommandTitle, "Record execution")]
        [imb(imbAttributeName.menuHelp, "Basic information about the recorded session")]
        master_record,
        
        [imb(imbAttributeName.menuCommandTitle, "Record log info")]
        [imb(imbAttributeName.menuHelp,"Information on logged content of this record")]
        master_log_info,
    }
}