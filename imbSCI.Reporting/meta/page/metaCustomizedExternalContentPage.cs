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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.page.metaCustomizedSimplePage" />
    /// <seealso cref="imbSCI.Reporting.interfaces.IMetaComposeAndConstruct" />
    public class metaCustomizedExternalContentPage : metaCustomizedSimplePage, IMetaComposeAndConstruct
    {
        /// <summary>
        /// 
        /// </summary>
        public string introContentPath { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string outroContentPath { get; set; }


        public metaCustomizedExternalContentPage(string __title, string __description, string __introContentPath, string __outroContentPath="") : base(__title, __description)
        {
            name = __title.getFilename();
            introContentPath = __introContentPath;
            outroContentPath = __outroContentPath;
        }

       

        public override void construct(object[] resources)
        {
            AddExternalContent(introContentPath, "", "");

            if (!outroContentPath.isNullOrEmpty()) AddExternalContent(outroContentPath, "", "");

            base.construct(resources);
        }

    }

}