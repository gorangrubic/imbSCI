namespace imbSCI.Reporting.meta.blocks
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

    /// <summary>
    /// Block of custom docScript instructions to be inserted at block invocation
    /// </summary>
    /// <seealso cref="MetaContainerNestedBase" />
    public class metaDocScriptBlock:MetaContainerNestedBase
    {
        public override void construct(object[] resources)
        {
           // colors = imbSCI.Cores.colors.acePaletteRole.colorA;
            //width = blockWidth.full;

        }


        /// <summary>
        /// instructions to inject
        /// </summary>
        public docScript instructions { get; protected set; } = new docScript("insert");


        public override docScript compose(docScript script)
        {
            if (script == null) script = new docScript(name);

            script.insertSub(instructions, parent);

            return script;
        }
    }

}