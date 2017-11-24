namespace imbSCI.Reporting.enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// Fields of documentSet structure report
    /// </summary>
    public enum templateFieldContentStructure
    {
        /// <summary>
        /// document count - total number of documents in set
        /// </summary>
        str_documentCount,
        /// <summary>
        ///  page count - total number of pages 
        /// </summary>
        str_pageCount,
        /// <summary>
        /// block count - total number of blocks
        /// </summary>
        str_blockCount,
        /// <summary>
        /// script count - number of script instructions
        /// </summary>
        str_scriptCount,
        /// <summary>
        ///  render name - name of rendering engine
        /// </summary>
        str_renderName,
        /// <summary>
        /// Code Name of theme
        /// </summary>
        str_themeCode,

    }

}