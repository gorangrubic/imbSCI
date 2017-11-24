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

    [AttributeUsage(AttributeTargets.Class)]
    public class fileStructureAttribute : fileDataBaseAttribute
    {

        /// <summary>
        /// Defining <see cref="fileDataStructureDescriptor"/> that uses propertyValue as folder name 
        /// </summary>
        /// <param name="__nameOrPath">The name or path.</param>
        /// <param name="__mode">The mode.</param>
        /// <param name="__filenameMode">The filename mode.</param>
        /// <param name="__options">The options.</param>
        public fileStructureAttribute(String __nameOrPath, fileStructureMode __mode=fileStructureMode.subdirectory,
            fileDataFilenameMode __filenameMode = fileDataFilenameMode.propertyValue,
            fileDataPropertyOptions __options = fileDataPropertyOptions.none)
        {

            nameOrPropertyPath = __nameOrPath;
            mode = __mode;
            filenameMode = __filenameMode;
            options = __options;


        }

        public fileStructureMode mode { get; set; } = fileStructureMode.subdirectory;



    }

}