namespace imbSCI.Reporting.meta.presets.servicepages
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
    using imbSCI.Data.enums.fields;
    using imbSCI.Reporting.enums;

    /// <summary>
    /// Page with report for test sub item (i.e. inner web page)
    /// </summary>
    /// \ingroup_disabled docServicePage
    public class pagePresetTestSubItemIndex : metaPage
    {
        public pagePresetTestSubItemIndex()
        {

            header.name = "Solution test session report: p[".t(templateFieldBasic.path_output) + ("]:[runstamp:").t(templateFieldBasic.test_runstamp) + ("]");
            string tmp = "App.start start[{0}] - runs[{1}] - threads[{2}] - memory alloc:[{3}] - test status:[{4}]";

            header.description = "";
        }

       
    }
}