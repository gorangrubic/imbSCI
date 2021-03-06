// --------------------------------------------------------------------------------------------------------------------
// <copyright file="weightTableMatch.cs" company="imbVeles" >
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
namespace imbSCI.DataComplex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    public class weightTableMatch<TWeightTableTerm, TSecondTableTerm> 
        where TWeightTableTerm:IWeightTableTerm 
        where TSecondTableTerm:IWeightTableTerm
    {

        public weightTableMatch(TSecondTableTerm keyTerm, TWeightTableTerm __match)
        {
            key = keyTerm;
            match = __match;
        }

        public string ToString()
        {
            string output = "[m:" + match.nominalForm + "]";
            if (subKey != null)
            {
                output +=  "=> [k:" + key.nominalForm + " -> " + subKey.nominalForm + "]";
            } else
            {
                output += "=> [k:" + key.nominalForm + "]";
            }
            return output;
        }


        /// <summary> </summary>
        public TWeightTableTerm match { get; protected set; }


        /// <summary> </summary>
        public TSecondTableTerm key { get; protected set; }


        /// <summary>
        /// 
        /// </summary>
        public IWeightTableTerm subKey { get; set; }
    }

}