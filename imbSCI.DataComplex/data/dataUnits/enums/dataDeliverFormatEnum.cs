namespace imbSCI.DataComplex.data.dataUnits.enums
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

    [Flags]
    public enum dataDeliverFormatEnum
    {
        none = 0,
        includeAttachment = 1,

        wrapInPanel = 2,

        globalAttachment = 4,

        /// <summary>
        /// Attachment will also have limited number of rows
        /// </summary>
        collectionLimitForAttachment = 32,

        onlyShownColumns = 16,

        /// <summary>
        /// When flagen this presenter is source of global attachment
        /// </summary>
        sourceForGlobalAttachment = 32,

        countColumn = 64,

        /// <summary>
        /// At bottom of table/chart it will write name of properties and their descriptions
        /// </summary>
        includeLegend = 128,

        wrapLegendInWell = 256,
        //nameAsLinkToSubpage = 32768,


    }

}