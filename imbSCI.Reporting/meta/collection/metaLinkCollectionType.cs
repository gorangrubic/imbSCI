namespace imbSCI.Reporting.meta.collection
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
    /// How this link collection makes url
    /// </summary>
    public enum metaLinkCollectionType
    {
        /// <summary>
        /// It will pass links as they are
        /// </summary>
        unknown,
        /// <summary>
        /// It will ensure that links are with URL shema
        /// </summary>
        externalWeb,
        /// <summary>
        /// It will create relative URL accorting to collection location
        /// </summary>
        relative,
        /// <summary>
        /// It will create absolute URLs according to collection location
        /// </summary>
        absolute
    }
}