
namespace imbSCI.Reporting.meta.collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
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
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Collection of linked stylesheets - to be placed in HEAD tag as css link
    /// </summary>
    public class linksStylesheets:metaLinkCollection
    {
        public linksStylesheets()
        {
            rootRelativePath = "\\_styles";
            name = "Style sheets";
            
        }

        /// <summary>
        /// Add CSS file
        /// </summary>
        /// <param name="__filenameWithExtension">just filename of CSS file</param>
        /// <returns>Created link</returns>
        public metaLink AddStyleSheet(string __filenameWithExtension)
        {
            metaLink link = new metaLink();
            link.type = appendLinkType.reference;
            link.name = __filenameWithExtension.ensureEndsWith(".css");

            link.description = "style shet file";
            link.parent = parent;
            link.url = parent.document.path.add(rootRelativePath, "\\");

            links.Add(link);
            return link;

        }
    }
}