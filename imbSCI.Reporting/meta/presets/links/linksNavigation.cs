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
    /// Dynamic collection of links to document, root, other pages, next/prev
    /// </summary>
    public class linksNavigation:metaLinkCollection, INavigation
    {
        
        public linksNavigation()
        {
            type = metaLinkCollectionType.relative;
            name = "Navigation";
        }

        /// <summary>
        /// Rebuilds navigation items -- this should be run before rendering the content
        /// </summary>
        /// <param name="__parent"></param>
        public void rebuild(IMetaContentNested __parent)
        {
            parent = __parent;

            if (parent.document != null)
            {
                var link = AddLink(parent.document, "Document page", -25);
            }

            if (parent.root != null)
            {
                var link = AddLink(parent.document, "Report page", -50);
            }

            if (parent.isThisDocument)
            {
                int index = parent.indexOf(__parent);

                if (parent.Count() > index)
                {
                    AddLink(parent[index+1] as IMetaContentNested, "Next page", -10);
                } 

                if (index > 0)
                {
                    AddLink(parent[index - 1] as IMetaContentNested, "Prev page", -5);
                }
                
            }
            
            if (parent is metaPage)
            {
                var link = AddLink(parent, "Back to parent", -15);
                //link.name = "Parent page";
            }
        }
    }
}