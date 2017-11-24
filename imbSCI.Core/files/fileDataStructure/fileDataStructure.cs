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
    using imbSCI.Core.files.folders;
    using System.Xml.Serialization;

    public abstract class fileDataStructure
    {




        /// <summary>
        /// Parent folder or it's own folder
        /// </summary>
        /// <value>
        /// The folder.
        /// </value>
        [XmlIgnore]
        public folderNode folder { get; set; }



        /// <summary>
        /// Called when object is loaded
        /// </summary>
        public abstract void OnLoaded();

        /// <summary>
        /// Called when before saving the data structure
        /// </summary>
        public abstract void OnBeforeSave();


    }

}