// --------------------------------------------------------------------------------------------------------------------
// <copyright file="diagramBuilderForType.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.DataComplex
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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

    /// <summary>
    /// Builds diagram using Type reflection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class diagramBuilderForType<T> where T:new()
    {
        /// <summary>
        /// Limit of depth allowed
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