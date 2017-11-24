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
    /// Report on sub items - testing web site sub pages 
    /// </summary>
    /// \ingroup_disabled docServicePage
    public class pagePresetTestItemSubitemsReadme : pagePresetGeneralReadme
    {
        public pagePresetTestItemSubitemsReadme()
        {
            header.name = "Readme on : Test Item report asset [".t(templateFieldBasic.page_id) + (" part of ").t(templateFieldBasic.parent_type);
            header.description = "Type: ".t(templateFieldBasic.page_type)+ (" - ").t(templateFieldBasic.path_file)+ (" - ").t(templateFieldBasic.page_id)+ (" of ").t(templateFieldBasic.page_number);

            content.Add("Item name: ".t(templateFieldBasic.page_name));
            content.Add("Item description: ".t(templateFieldBasic.page_title));
            content.Add("Parent directory path: ".t(templateFieldBasic.parent_dir));
            content.Add("Parent index path: ".t(templateFieldBasic.parent_index));
            content.Add("Parent type: ".t(templateFieldBasic.parent_type));
        }

    }
}