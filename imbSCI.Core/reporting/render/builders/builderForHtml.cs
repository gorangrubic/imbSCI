// --------------------------------------------------------------------------------------------------------------------
// <copyright file="builderForHtml.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
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
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.reporting.render.builders
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render.config;
    using imbSCI.Core.reporting.render.converters;
    using imbSCI.Core.reporting.render.core;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.appends;
    using imbSCI.Data.enums.fields;
    using imbSCI.Data.enums.reporting;



    public class builderForHtml : imbStringBuilderBase, ITextRender
    {
        public override converterBase converter
        {
            get
            {
                if (_converter == null) _converter = new converterForBootstrap3();
                return _converter;
            }
        }

        public override void prepareBuilder()
        {
            base.prepareBuilder();
            formats = reportOutputSupport.getFormatSupportFor(reportAPI.textBuilder, "index");
            formats.defaultFormat = reportOutputFormatName.textHtml;
            settings.api = reportAPI.textBuilder;
            settings.cursorBehaviour.cursorMode = textCursorMode.scroll;
        }

        /// <summary>
        /// HTML/XML adds <c>q</c> tag, Table aplies <c>smallText</c> style
        /// </summary>
        /// <param name="content">Text content of the quote</param>
        /// <param name="codetypename"></param>
        /// <returns>
        /// OuterXML/String or proper DOM object of container
        /// </returns>
        /// \ingroup_disabled renderapi_append
        public override object AppendCode(String content, String codetypename)
        {
            open(htmlTagName.pre);
            _AppendLine(content);
            close();

            //Append(content, appendType.source, true);
            
            return "";
        }

        public FileInfo savePage(string name, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object addDocument(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameExistingOnOtherDate, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object addPage(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameThis, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public override void AppendImage(string imageSrc, string imageAltText, string imageRef)
        {
            throw new NotImplementedException();
        }

        public override void AppendMath(string mathFormula, string mathFormat = "asciimath")
        {
            throw new NotImplementedException();
        }

        public override void AppendLabel(string content, bool isBreakLine = true, object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public override void AppendPanel(string content, string comp_heading = "", string comp_description = "", object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public void AppendLine()
        {
            throw new NotImplementedException();
        }
    }

}