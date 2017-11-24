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
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.DataComplex.diagram
{
    using imbSCI.DataComplex.diagram.enums;
    using imbSCI.DataComplex.diagram.output;

    public static class diagramHelpers
    {
        public static diagramOutputBase getOutputEngine(this diagramOutputEngineEnum engine)
        {
            diagramOutputBase output = null;
            switch (engine)
            {
                case diagramOutputEngineEnum.d3graph:
                    break;
                case diagramOutputEngineEnum.d3nodes:
                    break;
                case diagramOutputEngineEnum.mermaid:
                    output = new diagramMermaidOutput();
                    break;
                default:
                    break;
            }
            return output;
        }
    }

}