namespace imbSCI.Reporting.meta.page
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
    using imbSCI.Core.reporting.format;

    public class serviceDocScriptLog:metaServicePage
    {
        public serviceDocScriptLog(string __title, string __description = "")
        {
            priority = 200;
            name = __title.imbCodeNameOperation();
            header.title = __title;
            header.description = __description;
            pageTitle = __title;
            pageDescription = __description;

            filenameBase = name;
            fileformat = reportOutputFormatName.textMdFile;

        }

        /// <summary>
        /// 
        /// </summary>
        public docScript log { get; set; } = new docScript("docScript log");


        public override docScript compose(docScript script)
        {
            script.x_scopeIn(this);

            script.insertSub(log);

            script.x_scopeOut(this);

            return script;
        }
    }

}