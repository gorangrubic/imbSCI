
namespace imbSCI.Reporting.meta.theme
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Core.reporting.geometrics;
    using imbSCI.Core.reporting.colors;

    /// <summary>
    /// Collection of document theme
    /// </summary>
    public class metaDocumentThemeCollection:ObservableCollection<metaDocumentTheme>
    {
        
        public metaDocumentTheme this[string key]
        {
            get
            {
                if (this.Any(x => x.name == key))
                {
                    return this.First(x => x.name == key);
                } else
                {
                    throw new NotImplementedException(string.Format("Theme {0} never created!", key));
                }
                
            }
        }

        /// <summary>
        /// Creation of new theme
        /// </summary>
        /// <param name="name"></param>
        /// <param name="baseColorA"></param>
        /// <param name="baseColorB"></param>
        /// <param name="baseColorC"></param>
        /// <param name="pageFontName"></param>
        /// <param name="headingFontName"></param>
        /// <returns></returns>
        public metaDocumentTheme makeStandardTheme(string name, string baseColorA, string baseColorB, string baseColorC, aceFont pageFontName, aceFont headingFontName)
        {
            styleTheme stil = new styleTheme(aceBaseColorSetEnum.aceBrightAndStrong, 28, 12, new fourSideSetting(4), new fourSideSetting(2), pageFontName, headingFontName);
            metaDocumentTheme theme=null; //= new metaDocumentTheme(name, stil);
           // Add(theme);
            return theme;
        }


        
           
    }
}