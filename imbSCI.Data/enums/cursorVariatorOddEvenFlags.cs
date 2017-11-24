// --------------------------------------------------------------------------------------------------------------------
// <copyright file="cursorVariatorOddEvenFlags.cs" company="imbVeles" >
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
// Project: imbSCI.Data
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Data.enums
{
    using System;

    /// <summary>
    /// Describes way of row background changes
    /// </summary>
    [Flags]
    public enum cursorVariatorOddEvenFlags
    {
        none = 0,
        doOddEven =1,
        doMinorOn5 = 2,
        doMinorOn10 = 4,
        doMinorOn20 = 8,
        doMajorOn2Minor = 16,
        doMajorOn5Minor = 32,
        doMajorOn10Minor = 64,
        doMajorOn20Minor = 128,
        
    }
}