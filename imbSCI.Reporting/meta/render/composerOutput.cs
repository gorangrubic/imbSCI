namespace imbSCI.Reporting.meta.render
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
    /// Formats to export report into
    /// </summary>
    public enum composerOutput
    {
        /// <summary>
        /// Plain text format using renderText renderer
        /// </summary>
        text,
        /// <summary>
        /// Markdown format using renterMarkdown renderer
        /// </summary>
        markdown,
        /// <summary>
        /// HTML format via Markdown using Markdig HTML rendering
        /// </summary>
        markdownHtml,

        /// <summary>
        /// Direct render of HTML 
        /// </summary>
        imbVelesHtml,

        /// <summary>
        /// Dynamic CSS from template and/or external file
        /// </summary>
        imbVelesCSS,

        /// <summary>
        /// Dynamic javascript from template and with data points
        /// </summary>
        imbVelesJS,

        /// <summary>
        /// HTML format via Markdown using Markdig HTML rendering, then HTML to PDF export
        /// </summary>
        markdownPdf,
        /// <summary>
        /// Excel direct formating via renderer
        /// </summary>
        excel,
        /// <summary>
        /// Excel exporter via EPPlus - for tabular export. Multiple dataTables are exported into one file
        /// </summary>
        excelTablesNested,
        /// <summary>
        /// Excel exporter via EPPlus - separate file in sub folder per each DataTable
        /// </summary>
        excelTablesSeparated,
    }

}