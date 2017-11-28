// --------------------------------------------------------------------------------------------------------------------
// <copyright file="linksStylesheets.cs" company="imbVeles" >
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
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Reporting.meta.collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
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
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Collection of linked stylesheets - to be placed in HEAD tag as css link
    /// </summary>
    public class linksStylesheets:metaLinkCollection
    {
        public linksStylesheets()
        {
            rootRelativePath = "\\_styles";
            name = "Style sheets";
            
        }

        /// <summary>
        /// Add CSS file
        /// </summary>
        /// <param name="__filenameWithExtension">just filename of CSS file</param>
        /// <returns>Created link</returns>
        public metaLink AddStyleSheet(string __filenameWithExtension)
        {
            metaLink link = new metaLink();
            link.type = appendLinkType.reference;
            link.name = __filenameWithExtension.ensureEndsWith(".css");

            link.description = "style shet file";
            link.parent = parent;
            link.url = parent.document.path.add(rootRelativePath, "\\");

            links.Add(link);
            return link;

        }
    }
}