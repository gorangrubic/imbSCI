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

namespace imbSCI.Core.files.fileDataStructure
{

    public enum fileDataFilenameMode
    {
        /// <summary>
        /// The custom name: custom filename prefix is specified
        /// </summary>
        customName,
        /// <summary>
        /// The property name: property name is used
        /// </summary>
        memberInfoName,

        /// <summary>
        /// Value of a String property specified trough customName
        /// </summary>
        propertyValue,

    }

}