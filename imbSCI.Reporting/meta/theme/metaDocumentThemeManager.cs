
namespace imbSCI.Reporting.meta.theme
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
    using imbSCI.Core.reporting.style.enums;

    /// <summary>
    /// Maganer for document themes
    /// </summary>
    public static class metaDocumentThemeManager
    {
        /// <summary>
        /// nepotreban metod - moze odmah da se poziva preset[]
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static metaDocumentTheme getTheme(string name)
        {
            return preset[name];
        }

        /// <summary>
        /// Called on startup
        /// </summary>
        internal static void prepare()
        {
            preset.makeStandardTheme("standard", "#143436", "#232323", "#FF9900", aceFont.Helvetica, aceFont.Impact);
        }

        #region --- themes ------- static and autoinitiated object

        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static metaDocumentThemeCollection preset { get; } = new metaDocumentThemeCollection();

        #endregion

    }
}