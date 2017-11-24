namespace imbSCI.Reporting.meta.document
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

    public class documentPaletteView : metaDocument
    {
        public override metaPage indexPage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override docScript compose(docScript script)
        {
            script.x_scopeIn(this);

            script = baseCompose(script);

            script.x_scopeOut(this);

            return script;

        }
        public override void construct(object[] resources)
        {
            List<object> reslist = resources.getFlatList<object>();

            List<string> baseColors = reslist.getAllOfType<string>();

            foreach (string bc in baseColors)
            {
                metaPalettePage pg = new metaPalettePage(bc);
                pages.Add(pg, this);

            }

            baseConstruct(resources);

        }
    }

}