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
    /// Type of link between nodes
    /// </summary>
    public enum diagramLinkTypeEnum
    {
        /// <summary>
        /// The normal line
        /// </summary>
        normal,
        /// <summary>
        /// The dotted line
        /// </summary>
        dotted,
        /// <summary>
        /// The thick line
        /// </summary>
        thick
    }

}