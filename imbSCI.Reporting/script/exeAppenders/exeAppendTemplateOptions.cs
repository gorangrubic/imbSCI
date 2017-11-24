namespace imbSCI.Reporting.script.exeAppenders
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

    [Flags]
    public enum exeAppendTemplateOptions
    {
        sourceIsZip=1,
        /// <summary>
        /// The HTML template: it will process HTML files as templates
        /// </summary>
        htmlTemplate=2,
        /// <summary>
        /// The js template
        /// </summary>
        jsTemplate=4,
        /// <summary>
        /// The json template
        /// </summary>
        jsonTemplate=8,
        /// <summary>
        /// The XML template
        /// </summary>
        xmlTemplate=16,
        /// <summary>
        /// The md template
        /// </summary>
        mdTemplate=32,
        /// <summary>
        /// The CSS template
        /// </summary>
        cssTemplate=64,
        /// <summary>
        /// All template
        /// </summary>
        allTemplate=128,
        
        renderButton = 256,

        renderLink=512,

        renderInfoBox=1024,





    }

}