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

namespace imbSCI.DataComplex.diagram.core
{
    using imbSCI.DataComplex.diagram.enums;

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