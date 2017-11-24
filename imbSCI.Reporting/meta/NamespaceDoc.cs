namespace imbSCI.Reporting.meta
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
    /// META structure is abstract DATA representation of report: content and relationship between parts of it. 
    /// </summary>
    /// <remarks>
    /// <para>Logical hierarchy of a META structure</para>
    /// <list type="bullet">
    ///     <listheader>Structure</listheader>
    ///     <item>
    ///         <term>metaDocumentSet</term>
    ///         <description>The main container for single test report. It is related to one science test run, has unique test run stamp.</description>
    ///     </item>
    ///     <item>
    ///         <term>metaDocument</term>
    ///         <description>Describes an output unit (html, pdf, md, xlsx) - it containes pages that may result in separate subfolder (html, md) files or may be as part of it (psf, xlsx) depending on settings and output format.</description>
    ///     </item>
    ///     <item>
    ///         <term>metaDocumentPage</term>
    ///         <description>
    ///             <para>Containes subpages and/or content blocks</para>
    ///         Describes one output onit for particular data source. It may be separate file or part of <c>metaDocument</c>. In web crawler scenario: describes one particular part of the process</description>
    ///     </item>
    ///     <item>
    ///         <term>MetaContentNestedBase classes : IMetaContent</term>
    ///         <description>Content blocks that describe structure of content and hold particular information to be shown.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    [CompilerGenerated]
    internal class NamespaceDoc
    {
    }

}
