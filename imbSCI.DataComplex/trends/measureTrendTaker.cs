// --------------------------------------------------------------------------------------------------------------------
// <copyright file="measureTrendTaker.cs" company="imbVeles" >
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
namespace imbSCI.DataComplex.trends
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

    public class measureTrendTaker
    {

        public bool IsTimeAverage { get; set; } = false;

        public bool IsCumulative { get; set; } = false;


        public measureTrendTaker()
        {

        }

        public measureTrendTaker(string __name, string __unit, int __macroSampleSize, int __microSampleSize=-1, int __spearSampleSize=-1, double __zeroMargin=-1)
        {
            name = __name;
            unit = __unit;
            MacroSampleSize = __macroSampleSize;
            if (__microSampleSize == -1) __microSampleSize = __macroSampleSize / 2;
            if (__spearSampleSize == -1) __spearSampleSize = __microSampleSize / 2;
            if (__zeroMargin == -1) __zeroMargin = 0.05;
            MicroSampleSize = __microSampleSize;
            SpearSampleSize = __spearSampleSize;
            ZeroMargin = __zeroMargin;
        }

        public measureTrendSampleState GetSampleState(int sampleSize)
        {
            if (sampleSize >= MacroSampleSize) return measureTrendSampleState.macroMean | measureTrendSampleState.microMean | measureTrendSampleState.spearMean;
            if (sampleSize >= MicroSampleSize) return measureTrendSampleState.microMean | measureTrendSampleState.spearMean;
            if (sampleSize >= SpearSampleSize) return measureTrendSampleState.spearMean;
            return measureTrendSampleState.noEnough;
        }

        public string name { get; set; } = "Trend";
        public string format { get; set; } = "F4";
        public string unit { get; set; } = "n";


        /// <summary> Number of samples to take for macro mean </summary>
        [Category("Count")]
        [DisplayName("MacroSampleSize")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of samples to take for macro mean")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public int MacroSampleSize { get; set; } = 8;


        /// <summary> Number of samples to take for micro mean </summary>
        [Category("Count")]
        [DisplayName("MicroSampleSize")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of samples to take for micro mean")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public int MicroSampleSize { get; set; } = 4;



        /// <summary> Number of samples to take for spear mean </summary>
        [Category("Count")]
        [DisplayName("SpearSampleSize")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of samples to take for spear mean")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public int SpearSampleSize { get; set; } = 2;



        /// <summary> Zero-centered margin defining trend ingorance range </summary>
        [Category("Ratio")]
        [DisplayName("ZeroMargin")]
        [imb(imbAttributeName.measure_letter, "+/- d")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Zero-centered margin defining trend ingorance range")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double ZeroMargin { get; set; } = 0.05;




    }
}