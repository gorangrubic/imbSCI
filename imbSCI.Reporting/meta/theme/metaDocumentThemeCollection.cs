// --------------------------------------------------------------------------------------------------------------------
// <copyright file="metaDocumentThemeCollection.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Reporting
// Author: Goran Grubić
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------

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