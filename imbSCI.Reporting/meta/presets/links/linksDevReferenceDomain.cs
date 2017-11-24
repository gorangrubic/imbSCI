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
    /// DevReferenceDomain - categories of development help
    /// </summary>
    public enum linksDevReferenceDomain
    {
        /// <summary>
        /// General .NET development
        /// </summary>
        standard,
        /// <summary>
        /// Semantic technologies and APIs
        /// </summary>
        semantic,
        /// <summary>
        /// Natural Language Processing
        /// </summary>
        nlp,
        /// <summary>
        /// Report generation
        /// </summary>
        reporting,
        /// <summary>
        /// XML and XPath
        /// </summary>
        xml,
        /// <summary>
        /// web technologies: php, mysql, html, css, java
        /// </summary>
        web,


    }
}