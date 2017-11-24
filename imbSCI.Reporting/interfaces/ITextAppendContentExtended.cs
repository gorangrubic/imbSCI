// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextAppendContentExtended.cs" company="imbVeles" >
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
namespace imbSCI.Reporting.interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
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
    using imbSCI.Core.reporting.render.converters;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.charts.core;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Reporting.script.exeAppenders;

    public interface ITextAppendContentExtended:ITextAppendContent
    {
        /// <summary>
        /// Appends the executable.
        /// </summary>
        /// <param name="exeRunner">The executable runner.</param>
        /// <returns></returns>
        IExeAppend AppendExe(IExeAppend exeRunner);

        /// <summary>
        /// Appends the executable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IExeAppend AppendExe<T>() where T : IExeAppend, new();


        void AppendButton(string caption, string url, bootstrap_color color, bootstrap_size size);

        void AppendChart(chartTypeEnum chartType, chartFeatures features, DataTable data, chartSizeEnum size, chartTypeEnum typesForSeries = chartTypeEnum.none);

        void Attachment(FileInfo file, string caption, bootstrap_color color, bootstrap_size size);

        void Attachment(string content, string filepath, string caption, bootstrap_color color, bootstrap_size size);

        void Attachment(DataTable content, dataTableExportEnum format,  string caption, bootstrap_color color, bootstrap_size size);

        void open(string tag, string title, string description);

        void close();

        void nextTabLevel();

        void prevTabLevel();

        void rootTabLevel();

    }
}