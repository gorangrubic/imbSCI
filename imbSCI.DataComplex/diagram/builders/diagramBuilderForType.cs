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

namespace imbSCI.DataComplex.diagram.builders
{
    using imbSCI.DataComplex.diagram.core;
    using imbSCI.DataComplex.diagram.enums;

    public abstract class diagramBuilderForType<T> where T:new()
    {
        /// <summary>
        /// 
        /// </summary>
        public int childDepthLimit { get; set; } = 5;


        public abstract diagramModel buildModel(diagramModel output, T source);

        public abstract diagramNode buildNode(diagramModel model, T source);

       

        public virtual string getLinkDescription(diagramLink child, string defDescription = "")
        {
            return defDescription;
        }

        public virtual int getColor(diagramNode child, int defColor = 1)
        {
            return defColor;
        }

        public virtual diagramLinkTypeEnum getLinkTypeEnum(diagramNode child, diagramLinkTypeEnum defType = diagramLinkTypeEnum.normal)
        {
            return defType;
        }

        public virtual diagramNodeShapeEnum getShapeTypeEnum(T child, diagramNodeShapeEnum defType = diagramNodeShapeEnum.normal)
        {
            return defType;
        }
    }

}