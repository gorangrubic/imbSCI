﻿using System;
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
    /// Direction of flowchart diagram
    /// </summary>
    public enum diagramDirectionEnum
    {
        /// <summary>
        /// Top to Bottom
        /// </summary>
        TB,
        /// <summary>
        /// Bottom to top
        /// </summary>
        BT,
        /// <summary>
        /// Right to left
        /// </summary>
        RL,
        /// <summary>
        /// The lr
        /// </summary>
        LR,
        /// <summary>
        /// Same as <see cref="TB"/>
        /// </summary>
        TD,
    }
}