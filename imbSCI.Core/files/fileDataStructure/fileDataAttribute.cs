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

    [AttributeUsage(AttributeTargets.Property)]
    public class fileDataAttribute : fileDataBaseAttribute
    {








        /// <summary>
        /// Initializes a new instance of the <see cref="fileDataAttribute"/> class.
        /// </summary>
        /// <param name="__customName">Custom filename prefix (without extension)</param>
        /// <param name="__formatMode">Mode of serialization</param>
        /// <param name="__options">Special options</param>
        public fileDataAttribute(String __customName, 
            fileDataPropertyMode __formatMode=fileDataPropertyMode.autoTextOrXml, fileDataPropertyOptions __options = fileDataPropertyOptions.none)
        {
            nameOrPropertyPath = __customName;
            filenameMode = fileDataFilenameMode.customName;
            formatMode = __formatMode;
            options = __options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="fileDataAttribute"/> class.
        /// </summary>
        /// <param name="__filename">The filename mode</param>
        /// <param name="__mode">Mode of serialization</param>
        /// <param name="__options">Special options</param>
        public fileDataAttribute(fileDataFilenameMode __filename = fileDataFilenameMode.memberInfoName, 
            fileDataPropertyMode __mode = fileDataPropertyMode.autoTextOrXml,
            fileDataPropertyOptions __options = fileDataPropertyOptions.none)
        {
            filenameMode = __filename;
            formatMode = __mode;
            options = __options;
        }
    }

}