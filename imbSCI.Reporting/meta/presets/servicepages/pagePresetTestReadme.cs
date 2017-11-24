namespace imbSCI.Reporting.meta.presets.servicepages
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
    using imbSCI.Data.enums.fields;
    using imbSCI.Reporting.enums;

    /// <summary>
    /// Readme file for one research sample item (i.e. for webSiteProfile www.koplas.co.rs)
    /// </summary>
    /// \ingroup_disabled docServicePage
    public class pagePresetTestReadme : pagePresetGeneralReadme
    {
        public pagePresetTestReadme()
        {
            header.name = "Test report [".t(templateFieldBasic.test_caption) + (" [").t(templateFieldBasic.test_runstamp)+ "]";
            header.description = "Description: ".t(templateFieldBasic.test_description) + " - Status: ".t(templateFieldBasic.test_status);

            content.Add("Test start: ".t(templateFieldBasic.test_runstart));
            content.Add("Test running time: ".t(templateFieldBasic.test_runtime));
            content.Add("Test version: ".t(templateFieldBasic.test_versionCount));

            content.Add("Report path: ".t(templateFieldBasic.parent_dir));
            content.Add("Report index path: ".t(templateFieldBasic.parent_index));
            content.Add("Application root: ".t(templateFieldBasic.sys_path));
        }
    }
}