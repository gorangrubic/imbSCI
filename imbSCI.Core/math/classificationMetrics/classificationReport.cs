// --------------------------------------------------------------------------------------------------------------------
// <copyright file="classificationReport.cs" company="imbVeles" >
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
using imbSCI.Core.attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.classificationMetrics
{



    /// <summary>
    /// Extension methods for <see cref="IClassificationReport"/>
    /// </summary>
    public static class classificationReportExtensions
    {


        /// <summary>
        /// Adds the values from specified <c>metrics</c> object
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="metrics">The metrics.</param>
        /// <param name="method">The method of ratios computation (F1, Precision, Recall)</param>
        public static void AddValues(this IClassificationReport a, classificationEvalMetricSet metrics, classificationMetricComputation method)
        {
            a.Precision += metrics.GetPrecision(method);
            a.Recall += metrics.GetRecall(method);
            a.F1measure += metrics.GetPrecision(method);

            foreach (var p in metrics)
            {
                a.Correct += p.Value.correct;
                a.Wrong += p.Value.wrong;
                a.Targets += p.Value.correct + p.Value.wrong;
            }

        }


        /// <summary>
        /// Adds the values from specified <c>source</c>
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="source">The source.</param>
        public static void AddValues(this IClassificationReport a, IClassificationReport source)
        {
            a.Precision += source.Precision;
            a.Recall += source.Recall;
            a.F1measure += source.F1measure;
            a.Correct += source.Correct;
            a.Targets += source.Targets;
            a.Wrong += source.Wrong;
        }

        /// <summary>
        /// Divides the values stored in the report
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="OnlyRatios">if set to <c>true</c> [only ratios].</param>
        public static void DivideValues(this IClassificationReport a,Double divisor, Boolean OnlyRatios = true)
        {
            
            a.Precision = a.Precision.GetRatio(divisor);
            a.Recall = a.Recall.GetRatio(divisor);
            a.F1measure = a.F1measure.GetRatio(divisor);
            if (!OnlyRatios)
            {
                a.Correct = a.Correct.GetRatio(divisor);
                a.Targets = a.Targets.GetRatio(divisor);
                a.Wrong = a.Wrong.GetRatio(divisor);
            }
        }

        //public static DocumentSetCaseCollectionReport GetAverage(IEnumerable<DocumentSetCaseCollectionReport> input)
        //{
        //    DocumentSetCaseCollectionReport output = null;
        //    DocumentSetCaseCollectionReport first = null;
        //    Int32 c = 0;
        //    foreach (var i in input)
        //    {
        //        if (first == null)
        //        {
        //            first = i;
        //            output = new DocumentSetCaseCollectionReport(first.Classifier + "_" + "")
        //            output.Classifier = first.Classifier;
        //            output.kFoldCase = output.Classifier + " (mean)";
        //        }
        //        output.AddValues(i);
        //        c++;
        //    }
        //    output.DivideValues(c);

        //    return output;
        //}

    }


    /// <summary>
    /// Interface to classification report objects
    /// </summary>
    public interface IClassificationReport
    {
        String Name { get; set; }
        String Classifier { get; set; }
        Double Correct { get; set; }
        Double Wrong { get; set; }
        Double Targets { get; set; }
        Double Precision { get; set; }
        Double Recall { get; set; }
        Double F1measure { get; set; }
        classificationEvalMetricSet GetSetMetrics(classificationEvalMetricSet _metrics = null);

    }

    /// <summary>
    /// Base class for classification reporting
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.classificationMetrics.IClassificationReport" />
    public class classificationReport:IClassificationReport
    {

        public classificationReport()
        {

        }

        public classificationReport(String caseName)
        {
            Name = caseName;
        }
       

        private classificationEvalMetricSet metrics;

        /// <summary>
        /// Sets (if specified <c>_metrics</c> is not null) and Gets (earlier or just set) metrics object. Makes no change to report content, just stores the metrics temporarrly
        /// </summary>
        /// <param name="_metrics">The metrics.</param>
        /// <returns></returns>
        public classificationEvalMetricSet GetSetMetrics(classificationEvalMetricSet _metrics = null)
        {
            if (_metrics != null) metrics = _metrics;
            return metrics;
        }

        /// <summary> the title attached to this k-fold evaluation case instance </summary>
        [Category("Label")]
        [DisplayName("Name")] //[imb(imbAttributeName.measure_letter, "")]
        [Description("the title attached to this case instance")]
        [imb(imbAttributeName.reporting_columnWidth, "50")]
        public String Name { get; set; } = default(String);



        /// <summary> Name of post classifier </summary>
        [Category("Label")]
        [DisplayName("Classifier")] //[imb(imbAttributeName.measure_letter, "")]
        [Description("Name of post classifier")] // [imb(imbAttributeName.reporting_escapeoff)]
        public String Classifier { get; set; } = default(String);





        /// <summary> Correct classifications </summary>
        [Category("Evaluation")]
        [DisplayName("Correct")]
        [imb(imbAttributeName.measure_letter, "E_c")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Correct classifications")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public Double Correct { get; set; } = 0;


        /// <summary> Wrong </summary>
        [Category("Count")]
        [DisplayName("Wrong")]
        [imb(imbAttributeName.measure_letter, "E_w")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Wrong classification count")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public Double Wrong { get; set; } = default(Int32);




        /// <summary> Number of web sites designated for model evaluation </summary>
        [Category("Evaluation")]
        [DisplayName("Targets")]
        [imb(imbAttributeName.measure_letter, "W_n")]
        [imb(imbAttributeName.measure_setUnit, "n")]
        [Description("Number of web sites designated for model evaluation")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public Double Targets { get; set; } = default(Int32);


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("Precision")]
        [imb(imbAttributeName.measure_letter, "P")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        [Description("Rate of correctly classified cases in all evaluated")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public Double Precision { get; set; } = default(Double);


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("Recall")]
        [imb(imbAttributeName.measure_letter, "R")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        [Description("Rate of correctly classified web sites in total number of web sites of the class")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public Double Recall { get; set; } = default(Double);



        /// <summary> F1 measure - harmonic mean of precision and recall </summary>
        [Category("Ratio")]
        [DisplayName("F1measure")]
        [imb(imbAttributeName.measure_letter, "F1")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [imb(imbAttributeName.reporting_valueformat, "F5")]
        [Description("F1 measure - harmonic mean of precision and recall")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public Double F1measure { get; set; } = default(Double);


    }
}
