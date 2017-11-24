namespace imbSCI.Reporting.meta.presets.links
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
    /// Categories of Scientific references
    /// </summary>
    public enum linksSciReferenceDomain
    {
        /// <summary>
        /// The articles partially or completly applied into imbVeles
        /// </summary>
        applied,
        /// <summary>
        /// The articles referenced in my articles/thesis
        /// </summary>
        citation,
        /// <summary>
        /// Not direclty referenced but related topics
        /// </summary>
        related,
        /// <summary>
        /// Overview and summary articles about relevant fields
        /// </summary>
        introductive,
    }
}