﻿namespace imbSCI.Reporting.meta.presets.servicepages
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
    using imbSCI.Core.extensions.enumworks;

    /// <summary>
    /// META structure with general readme.md diagnostic output
    /// </summary>
    /// \ingroup_disabled docServicePage
    public class pagePresetGeneralReadme:metaServicePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="pagePresetGeneralReadme"/> class.
        /// </summary>
        public pagePresetGeneralReadme():base("General purpose ReadMe content describing report folder/page/item", "Read Me - General info", "readme", metaServicePagePosition.atBeginning.ToInt32())
        {
            header.name = "General Readme : Project[".t(templateFieldBasic.sci_projectname) + ("\\@").t(templateFieldBasic.sci_projectpath);
            header.description = "Type: ".t(templateFieldBasic.page_type) + (" - ").t(templateFieldBasic.path_file)+ (" - TPC:").t(templateFieldBasic.self_plc);




            footer.bottomLine = "Autogenerated: ".t(templateFieldBasic.sys_date) + (" ").t(templateFieldBasic.sys_time) + (" - mem.alloc: ").t(templateFieldBasic.sys_mem) +(" - threads: ").t(templateFieldBasic.sys_threads);
            
        }

      
    }

}
