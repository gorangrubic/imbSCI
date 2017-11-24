namespace imbSCI.Reporting.meta.delivery
{
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
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// Execution flags
    /// </summary>
    [Flags]
    public enum deliveryUnitItemFlags
    {

        none = 0,

        /// <summary>
        /// The item is contained in an archive file
        /// </summary>
        zippedSource = 1,

        /// <summary>
        /// Output filenames are data templates that should be preprocessed before used
        /// </summary>
        filenameIsDataTemplate = 2,


        /// <summary>
        /// It will prevend deliveryUnit to change any predefined filename extension
        /// </summary>
        filenameExtensionIsStatic = 4,



        /// <summary>
        /// It will create proper link within primary content. i.e. for CSS file it will include style tag in head part of HTML output
        /// </summary>
        linkToPrimaryContent = 8,


        useTemplate = 16,

        useCopy = 32,

        deployTemplateOnPrepare = 64,

    }

}