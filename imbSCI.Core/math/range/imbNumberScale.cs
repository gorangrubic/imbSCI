// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbNumberScale.cs" company="imbVeles" >
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
// Author: Goran Grubić
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------

#region USING



#endregion

namespace imbSCI.Core.math.range
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Matematički alat koji radi sa min-max skalom
    /// konvertuje apsolutni i relativni (ratio) broj
    /// </summary>
    public class imbNumberScale
    {
        /// <summary>
        /// Maksimalna vrednost u skali
        /// </summary>
        public Double maxValue = 100;

        /// <summary>
        /// Minimalna vrednost u skali
        /// </summary>
        public Double minValue = 0;

        /// <summary>
        /// Konstruktor koji postavlja min i max
        /// </summary>
        /// <param name="_min"></param>
        /// <param name="_max"></param>
        public imbNumberScale(Double _min, Double _max)
        {
            minValue = Math.Min(_min, _max);
            maxValue = Math.Max(_min, _max);
        }

        /// <summary>
        /// Konstruktor koji postavlja min i max ali iz Liste 
        /// pri čemu je 0 član min a 1 član max
        /// </summary>
        /// <param name="input"></param>
        public imbNumberScale(List<Double> input)
        {
            if (input.Count > 1)
            {
                minValue = input[0];
                maxValue = input[1];
            }
        }

        /// <summary>
        /// Vraća apsolutni broj za zadati racio
        /// koristeći postavljeni min-max raspon
        /// </summary>
        /// <param name="ratio">koeficijent na osnovu kojeg se dobija absolutni broj</param>
        /// <returns></returns>
        public Double getAbsoluteValue(Double ratio)
        {
            Double range = maxValue - minValue;
            Double output = minValue + (ratio*range);
            return output;
        }

        /// <summary>
        /// Vraća koeficijent na osnovu ranije definisanog raspona
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Double getRatioValue(Double input)
        {
            Double over = input - minValue;
            Double ratio = over/maxValue;
            return ratio;
        }
    }
}