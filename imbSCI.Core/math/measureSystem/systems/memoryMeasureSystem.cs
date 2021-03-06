﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="memoryMeasureSystem.cs" company="imbVeles" >
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
namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class memoryMeasureSystem:measureDecadeSystem
    {
        public memoryMeasureSystem():base(measureSystemsEnum.memory)
        {
            AddRole(measureRoleEnum.size, "size", "");
            AddRole(measureRoleEnum.available, "fmem", "");
            AddRole(measureRoleEnum.filesize, "s", "");
            
            AddUnit("b", 0, "byte", "bytes").setFormat("{0:#,###}", "{0:#,###}{1}");
            AddUnit("kb", 1024, "kilobyte", "kilobytes").setFormat("{0:#,###.#}", "{0:#,###.0##}{1}");
            AddUnit("mb", 1048576, "megabyte", "megabytes").setFormat("{0:#,###.#}", "{0:#,###.#}{1}");
            AddUnit("gb", 1073741824, "promile", "primiles").setFormat("{0:#,###.000}", "{0:#,###.000}{1}");

            doFinalSetup();
        }
   
    }
}