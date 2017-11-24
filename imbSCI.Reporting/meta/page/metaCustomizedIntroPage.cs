namespace imbSCI.Reporting.meta.page
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.interfaces;
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

    public class metaCustomizedIntroPage : metaCustomizedSimplePage, IMetaComposeAndConstruct
    {
        /// <summary>
        /// 
        /// </summary>
        public string introContentPath { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string outroContentPath { get; set; }


        public metaCustomizedIntroPage(string __title, string __description, string __introContentPath, string __outroContentPath) : base(__title, __description)
        {
            name = "index";
            introContentPath = __introContentPath;
            outroContentPath = __outroContentPath;
        }

        /// <summary>
        /// Composes the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        /// <returns></returns>
        public override docScript compose(docScript script)
        {
            script.x_scopeIn(this);

            if (!introContentPath.isNullOrEmpty())
            {
                script.AppendFromFile(introContentPath);
            }
            script = base.compose(script);

            if (!outroContentPath.isNullOrEmpty())
            {
                script.AppendFromFile(outroContentPath);
            }

            script.x_scopeOut(this);
            return script;
        }
        
    }


}
