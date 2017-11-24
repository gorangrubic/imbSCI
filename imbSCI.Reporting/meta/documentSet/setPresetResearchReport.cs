﻿namespace imbSCI.Reporting.meta.documentSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.page;
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
    /// Complete report on scientific test
    /// </summary>
    /// <remarks>
    ///     <list type="bullet">
    ///         <listheader>Report contains</listheader>
    ///         <item>Sampled collection report</item>
    ///         <item>Test workflow info</item>
    ///         <item>Used resources</item>
    ///     </list>
    /// </remarks>
    /// \ingroup_disabled docDocumentSet
    public class setPresetResearchReport:metaDocumentSet
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public setPresetResearchReport()
        {

        }

        public override metaPage indexPage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override docScript compose(docScript script)
        {
            throw new NotImplementedException();
        }

        public override void construct(object[] resources)
        {
            throw new NotImplementedException();
        }
    }
}