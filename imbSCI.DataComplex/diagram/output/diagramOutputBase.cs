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

namespace imbSCI.DataComplex.diagram.output
{
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.render;
    using imbSCI.DataComplex.diagram.core;

    public abstract class diagramOutputBase
    {
        public abstract string getOutput(diagramModel model, acePaletteProvider colorProvider);

        public abstract string getOutputNodesDeclaration(diagramModel model);

        public abstract string getOutputLinksDeclaration(diagramModel model);

        public abstract string getOutputStyleDeclaration(diagramModel model, acePaletteProvider colorProvider);



        public abstract void render(diagramModel model, ITextRender render);

        //public abstract String getLinkType(diagramLinkTypeEnum type);

        public abstract string getNodeDeclaration(diagramNode node);

        public abstract string getLinkDeclaration(diagramLink link);

        //public abstract String get

    }

}