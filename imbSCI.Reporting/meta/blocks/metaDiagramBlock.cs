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
    using imbSCI.DataComplex.diagram;
    using imbSCI.DataComplex.diagram.enums;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    public class metaDiagramBlock : MetaContainerNestedBase
    {
        /// <summary>
        /// 
        /// </summary>
        public diagramModel diagram { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public diagramOutputEngineEnum engine { get; set; }


        public metaDiagramBlock(diagramModel __diagram, diagramOutputEngineEnum __engine)
        {
            diagram = __diagram;
        }

        public override docScript compose(docScript script = null)
        {
            script.open("diagram", diagram.name, diagram.description);

            if (diagram != null)
            {
                script.AppendDiagram(diagram, engine);
            }

            script.close();
            return script;
        }

        public override void construct(object[] resources)
        {
            
            
        }
    }

}