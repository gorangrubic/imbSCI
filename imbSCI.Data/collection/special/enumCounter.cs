// --------------------------------------------------------------------------------------------------------------------
// <copyright file="enumCounter.cs" company="imbVeles" >
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
namespace imbSCI.Data.collection.special
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
//using aceCommonTypes.core.exceptions;

    // using aceCommonTypes.extensions;

    /// <summary>
    /// Brojac enumeracija
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class enumCounter<T>:Dictionary<T, int>
    {
        public enumCounter() : base()
        {
            foreach (T en in Enum.GetValues(typeof (T)))
            {
                this.Add(en, 0);
            }
        }

        public String writeResult(String format = "{0}={2};", String separator=" ")
        {
            String output = "";
            foreach (T en in Keys)
            {
                output = output + String.Format(format, en.ToString(), this[en].ToString()) + separator;
            }
            output = output.TrimEnd(separator.ToCharArray());
            return output;
        }

        /// <summary>
        /// postavlja sve brojace na 0
        /// </summary>
        public void reset()
        {
            foreach (T en in Keys.ToList())
            {
                this[en] = 0;
            }
        }

        public Int32 count(T en)
        {
            
            this[en]++;
            return this[en];
        }
    }
}
