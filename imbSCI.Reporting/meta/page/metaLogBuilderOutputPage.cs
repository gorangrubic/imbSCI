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

    public class metaLogBuilderOutputPage : metaCustomizedSimplePage, IMetaComposeAndConstruct
    {
        /// <summary>
        /// 
        /// </summary>
        public ILogBuilder logBuilder { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string instanceID { get; set; }


        public metaLogBuilderOutputPage(string __title, string __description, ILogBuilder __logBuilder, string __instanceID, string filename="log_output"):base(__title, __description)
        {
            logBuilder = __logBuilder;
            name = filename;
            instanceID = __instanceID;
        }

        /// <summary>
        /// Composes the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        /// <returns></returns>
        public override docScript compose(docScript script)
        {
            script.x_scopeIn(this);

            script.AppendHeading(pageTitle);
            script.Append("Log content from: ");
            script.AppendLabel(instanceID, true, "primary");
            script.AppendHorizontalLine();

            script.AppendDirect(logBuilder.ContentToString(true));

           
            script = base.compose(script);

           
            script.x_scopeOut(this);
            return script;
        }





    }

}