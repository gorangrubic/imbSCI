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

    public abstract class fileDataBaseAttribute :Attribute
    {

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public fileDataPropertyMode formatMode { get; set; } = fileDataPropertyMode.autoTextOrXml;

        /// <summary>
        /// Gets or sets the filename mode.
        /// </summary>
        /// <value>
        /// The filename mode.
        /// </value>
        public fileDataFilenameMode filenameMode { get; set; } = fileDataFilenameMode.customName;

        /// <summary>
        /// Gets or sets the name or property path.
        /// </summary>
        /// <value>
        /// The name or property path.
        /// </value>
        public String nameOrPropertyPath { get; set; } = "";

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public fileDataPropertyOptions options { get; set; } = fileDataPropertyOptions.none;

    } 

}