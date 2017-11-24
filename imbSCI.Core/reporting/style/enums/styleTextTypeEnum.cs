// --------------------------------------------------------------------------------------------------------------------
// <copyright file="styleTextTypeEnum.cs" company="imbVeles" >
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
namespace imbSCI.Core.reporting.style.enums
{
    /// <summary>
    /// Compressed subset of appendType
    /// </summary>
    public enum styleTextTypeEnum
    {
        none,
        regular,
        bold,
        heading_1, // heading
        heading_2,
        heading_3,
        heading_4,
        heading_5,
        heading_6,
        italic, // quote
        marked,
        squareQuote,
        quotation,
        striketrough,
        blockquote,
        math,
        monospace,
        source, // source

    }

}