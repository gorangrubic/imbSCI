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

namespace imbSCI.Core.files.folders
{
    public enum aceFolderType
    {
        /// <summary>
        /// configuration files, external media resources
        /// </summary>
        etc,
        /// <summary>
        /// logs, crash info, backup files
        /// </summary>
        var,
        /// <summary>
        /// script/job/task presets - categorised by folder structure
        /// </summary>
        lib,
        /// <summary>
        /// contins external tools: text editor, html viewer, image viewer etc.
        /// </summary>
        bin,
        /// <summary>
        /// user projects/jobs
        /// </summary>
        usr,


        /// <summary>
        /// temporary files that are safe to be deleted 
        /// </summary>
        tmp,

        
        /// <summary>
        /// root folder
        /// </summary>
        root,

        /// <summary>
        /// folder sa fajlovima koji treba da se obrade
        /// </summary>
        source,

        /// <summary>
        /// folder sa rezultatom - obradjeni 
        /// </summary>
        result,

        /// <summary>
        /// folder sa neobradjenim - jer ne ispunjavaju uslov
        /// </summary>
        notChanged
    }
}