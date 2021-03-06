// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbTreeBuildingFlag.cs" company="imbVeles" >
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
// Project: imbSCI.DataComplex
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using imbSCI.Data;
using imbSCI.Data.collection.nested;
using imbSCI.Data.data;
using imbSCI.Data.enums.reporting;

namespace imbSCI.DataComplex.tree
{
    using System;

    #region imbVeles using

    #endregion

    /// <summary>
    /// Flagovi - imbTreeBuildingFlag
    /// </summary>
    [Flags]
    public enum imbTreeBuildingFlag
    {
        none=0,


        /// <summary>
        /// Da li da gradi centralni registar za svu pod decu -- prilikom registracije ka parentu
        /// </summary>
        buildRootRegisters=1,

        /// <summary>
        /// Da li da gradi lokalne registre za svu pod decu -- prilikom registracije
        /// </summary>
        buildLocalRegisters=2,
    }
}