
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
    /// Collection of linked JavaScripts - to be placed in HEAD tag as links or to be embedded before end of the content
    /// </summary>
    public class linksScripts:metaLinkCollection
    {
        public linksScripts()
        {
            rootRelativePath = "\\_scripts";
        }

        public metaLink AddScript(string filename)
        {
            metaLink link = new metaLink();
            link.type = appendLinkType.reference;
            link.name = filename.ensureEndsWith(".js");
            link.parent = parent;
            link.url = parent.document.path.add(rootRelativePath, "\\").add(link.name, "\\");
            links.Add(link);
            return link;
        }
    }
}