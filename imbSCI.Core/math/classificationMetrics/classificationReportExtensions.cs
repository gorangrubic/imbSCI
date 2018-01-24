using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.attributes;
using System.ComponentModel;
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

}