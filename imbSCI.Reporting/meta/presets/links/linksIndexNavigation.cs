namespace imbSCI.Reporting.meta.presets.links
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
    using imbSCI.Reporting.meta.collection;
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

    /// <summary>
    /// Dynamic collection of links for index pages
    /// </summary>
    public class linksIndexNavigation : metaLinkCollection, INavigation
    {
        public linksIndexNavigation()
        {
            type = metaLinkCollectionType.relative;
            name = "Index";
            

        }

        public void rebuild(IMetaContentNested __parent)
        {
            parent = __parent;

            foreach (IMetaContentNested child in __parent)
            {
                AddLink(child, "", child.priority);
            }

            if (parent.parent is metaPage)
            {
                var link = AddLink(parent, "Back to parent", -50);
                //link.name = "Parent page";
            }
        }
    }
}