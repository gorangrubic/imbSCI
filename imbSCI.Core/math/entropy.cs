// --------------------------------------------------------------------------------------------------------------------
// <copyright file="entropy.cs" company="imbVeles" >
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
namespace imbSCI.Core.math
{
    using System;
    using System.Collections.Generic;

    public static class entropy
    {

        public static Double GetVariance(this IEnumerable<Double> rFreqs)
        {

            throw new NotImplementedException();
        }

        public static Double GetStdDeviation(this IEnumerable<Double> rFreqs)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates entropy, normalizes the output if <c>normalize</c> is <c>true</c>
        /// </summary>
        /// <param name="rFreqs">Unsorted array of relative requencies. Relative requency is calculated as absolute freq. / max. freq. </param>
        /// <param name="eps">The eps.</param>
        /// <param name="normalize">if set to <c>true</c> [normalize].</param>
        /// <returns></returns>
        public static Double GetEntropy(this IEnumerable<Double> rFreqs, double eps = 0.000001, Boolean normalize=true)
        {
            double num1 = 0.0;
            double nl = 0;
            double nlMax = double.MinValue;

            foreach (double num2 in rFreqs)
            {
                nl = Math.Log(num2 + eps);
                if (normalize) nlMax = Math.Max(nl, nlMax);
                num1 += num2 * nl;
            }
            if (normalize) num1 = num1 / nlMax;
            return -num1;
        }
    }
}
