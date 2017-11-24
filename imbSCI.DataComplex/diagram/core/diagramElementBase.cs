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
    /// <summary>
    /// Base class for all elements within <see cref="diagramModel" />
    /// </summary>
    /// <seealso cref="IObjectWithName" />
    public abstract class diagramElementBase:IObjectWithName, IObjectWithNameAndDescription
    {
        /// <summary>
        /// UID name of this diagram element - for Links no need to be unique
        /// </summary>
        public string name { get; set; } = "";


        /// <summary>
        /// Human-readable description text to appear inside or above diagram element
        /// </summary>
        public string description { get; set; } = "";


        /// <summary>
        /// Associated color role - good idea to be sinchronized with: <see cref="imbSCI.Core.reporting.colors.acePaletteRole"/>
        /// </summary>
        public int color { get; set; } = 1;


        /// <summary>
        /// Associated importance level - good idea to be sinchronized with: <see cref="imbSCI.Core.reporting.colors.acePaletteVariationRole"/>
        /// </summary>
        public int importance { get; set; } = 0;


        /// <summary>
        /// Object that is logicaly related to this diagram element
        /// </summary>
        public IObjectWithName relatedObject { get; set; } = null;


        /// <summary>
        /// Reference to <see cref="diagramModel"/> that contains this element
        /// </summary>
        public diagramModel parent { get; set; }
    }

}