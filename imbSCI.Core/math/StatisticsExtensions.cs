// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsExtensions.cs" company="imbVeles" >
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
namespace imbSCI.Core.math
{
    using MathNet.Numerics.Statistics;

    /// <summary>
    /// Entropy, and some wrappers to <see cref="MathNet.Numerics"/>
    /// </summary>
    public static class StatisticsExtensions
    {

        /// <summary>
        /// Gets the statistics - <see cref="MathNet.Numerics.Statistics"/>
        /// </summary>
        /// <param name="rFreqs">The r freqs.</param>
        /// <param name="increasedAccuricy">if set to <c>true</c> [increased accuricy].</param>
        /// <returns></returns>
        public static DescriptiveStatistics GetStatistics(this IEnumerable<Double> rFreqs, Boolean increasedAccuricy=false)
        {
            if (!rFreqs.Any()) return new DescriptiveStatistics(new Double[] { }, false);
            return new DescriptiveStatistics(rFreqs, increasedAccuricy);
        }


        /// <summary>
        /// Gets the variance.
        /// </summary>
        /// <param name="rFreqs">The r freqs.</param>
        /// <param name="isSample">if set to <c>true</c> [is sample].</param>
        /// <returns></returns>
        public static Double GetVariance(this IEnumerable<Double> rFreqs, Boolean isSample = false)
        {
            if (!rFreqs.Any()) return 0;
            if (!isSample)
            {
                return rFreqs.PopulationVariance();
            }
            return rFreqs.Variance();
        }

        /// <summary>
        /// Gets the standard deviation - just a wrapper <see cref="MathNet.Numerics.Statistics"/>
        /// </summary>
        /// <param name="rFreqs">The r freqs.</param>
        /// <param name="isSample">if set to <c>true</c> [population].</param>
        /// <returns></returns>
        public static Double GetStdDeviation(this IEnumerable<Double> rFreqs, Boolean isSample= true)
        {
            if (!rFreqs.Any()) return 0;
            if (!isSample)
            {
                return rFreqs.PopulationStandardDeviation();
            }
            return rFreqs.StandardDeviation();
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
            if (!rFreqs.Any()) return 0;
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