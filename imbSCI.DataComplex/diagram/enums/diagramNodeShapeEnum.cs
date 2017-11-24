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

namespace imbSCI.DataComplex.diagram.enums
{
    /// <summary>
    /// Type of shape that node should be represendet
    /// </summary>
    public enum diagramNodeShapeEnum
    {
        /// <summary>
        /// The normal rectangle
        /// </summary>
        normal,
        /// <summary>
        /// The rounded rectangle
        /// </summary>
        rounded,
        /// <summary>
        /// The circle shaped
        /// </summary>
        circle,
        /// <summary>
        /// The flag to right:    ]
        /// </summary>
        flagToRight,
        /// <summary>
        /// The flag to left: [    
        /// </summary>
        flagToLeft,
        /// <summary>
        /// The rhombus shape
        /// </summary>
        rhombus,
    }

}