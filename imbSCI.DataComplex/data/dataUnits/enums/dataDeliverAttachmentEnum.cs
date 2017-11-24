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
    public enum dataDeliverAttachmentEnum
    {
       
        none = 0,
        /// <summary>
        /// It will create side-page in report, with all data shown
        /// </summary>
        attachSidePage = 4,

        attachHtml = 8,

        attachXml = 16,

        attachExcel = 32,

        attachCSV = 64,

        attachJSON = 128,

        attachText = 256,

        attachMD = 512,

    }

}