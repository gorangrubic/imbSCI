// --------------------------------------------------------------------------------------------------------------------
// <copyright file="styleSurfaceColor.cs" company="imbVeles" >
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
using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.reporting.style.core
{
    using System.ComponentModel;
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Data.enums.appends;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.reporting.geometrics;
    using System.Drawing;

    public class styleSurfaceColor
    {
        public styleFillType FillType { get; set; } = styleFillType.Solid;

        public Double Tint { get; set; } = 1;

        public Color Color { get; set; } = Color.Gray;

       // public Color ColorAlt { get; set; } = Color.Snow;

        public styleSurfaceColor()
        {

        }


        //style.Style.Font.Name = styleSet.fontName;
            
        //    style.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    style.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
        //    style.Style.Fill.BackgroundColor.Tint = new decimal (0.8);
        //    style.Style.Font.Bold = false;
        //    style.Style.Font.Size = 10;
    }

}