// --------------------------------------------------------------------------------------------------------------------
// <copyright file="diagramLink.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
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
using imbSCI.Graph.Diagram.enums;

namespace imbSCI.Graph.Diagram.core
{
    

    /// <summary>
    /// Model element representing link between two nodes
    /// </summary>
    /// <seealso cref="diagramElementBase" />
    public class diagramLink:diagramElementBase
    {

        internal diagramLink()
        {

        }

        /// <summary>
        /// Link type
        /// </summary>
        public diagramLinkTypeEnum type { get; set; } = diagramLinkTypeEnum.normal;


        private bool _isDoubleDirected = false;
        /// <summary>
        /// If link has arrow on both directions
        /// </summary>
        public bool isDoubleDirected
        {
            get { return (isToDirected && isFromDirected); }
            
        }


        /// <summary>
        /// Should arrow appear next to <see cref="to"/> node
        /// </summary>
        public bool isToDirected { get; set; } = true;


        /// <summary>
        /// Should arrow appear next to <see cref="from"/> node
        /// </summary>
        public bool isFromDirected { get; set; } = false;


        public bool isConnected
        {
            get
            {
                return ((from != null) && (to != null));
            }
        }

        /// <summary>
        /// The node link points from
        /// </summary>
        public diagramNode from { get; internal set; }


        /// <summary>
        /// The node link points to
        /// </summary>
        public diagramNode to { get; internal set; }
    }

}