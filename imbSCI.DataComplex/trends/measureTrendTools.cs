﻿namespace imbSCI.DataComplex.trends
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

    public static class measureTrendTools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sampleset"></param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpanBySum<T>(this IEnumerable<T> sampleset) where T : IPerformanceTake
        {
            int seconds = (int)(sampleset.Sum(x => x.secondsSinceLastTake) / 60);
            return new TimeSpan(0, 0, seconds);
        }


        /// <summary>
        /// Gets the time span between sampling times of sampleset collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sampleset">The sampleset.</param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan<T>(this IEnumerable<T> sampleset) where T:IPerformanceTake
        {
            DateTime start = sampleset.Min<T, DateTime>(x => x.samplingTime);
            DateTime end = sampleset.Max<T, DateTime>(x => x.samplingTime);
            return end.Subtract(start);
        }


        public static measureTrend GetTrend<T>(this IEnumerable<T> sampleset, Func<T, double> selector, measureTrendTaker trendTaker, TimeSpan span)
        {
            int sC = sampleset.Count();
            int sT = Math.Min(sC, trendTaker.MacroSampleSize);

            var sValues = (from num in sampleset select selector(num));

            //sampleset.Take(sT).GetTimeSpan

            measureTrend trend = new measureTrend(sValues, trendTaker, span);

            return trend;

        }


        public static string GetTrendInline(this measureTrend trend)
        {
            string form = "{0} {1,10}:[_{2,15}_ {3,-14}] ({4,11}) _{5,8}_ ";

            List<string> st = new List<string>();
            st.Add(trend.SampleState.GetStateSymbols());
            st.Add(trend.name.toWidthMaximum(8, ""));

            st.Add(trend.MicroMean.ToString(trend.format));
            
            if (trend.sampledPeriod > 0)
            {
                form += trend.sampledPeriod.ToString("F2") + " min";
            }
            st.Add(trend.unit);

            if (trend.SampleState.HasFlag(measureTrendSampleState.macroMean))
            {
                st.Add(trend.MicroTrend.ToString("P2"));
            } else
            {
                st.Add("~~~~");
            }
            st.Add(trend.Direction.GetTrendDirectionSymbols());

            return string.Format(form, st.ToArray()).toWidthExact(75, " ");

        }

        public static string GetTrendDirectionSymbols(this measureTrendDirection direction)
        {
            // ▲▼▴▾○◦●■□
            string output = "";

            string left = "";
            string right = "";

            if (direction.HasFlag(measureTrendDirection.macroStable))
            {
                left += "-";
                right += "-";
            }



            if (direction.HasFlag(measureTrendDirection.microStable))
            {
                left += "-";
                right += "-";
            }

            if (direction.HasFlag(measureTrendDirection.macroDown)) left += "<-";
            if (direction.HasFlag(measureTrendDirection.microDown)) left += "<<";

            if (direction.HasFlag(measureTrendDirection.microUp)) right += ">>";
            if (direction.HasFlag(measureTrendDirection.macroUp)) right += "->";

            output = left + "" + right;
           
            

            return output;
        }

        public static string GetStateSymbols(this measureTrendSampleState direction)
        {

            if (direction.HasFlag(measureTrendSampleState.macroMean)) return "ok";
            if (direction.HasFlag(measureTrendSampleState.microMean)) return "--";
            if (direction.HasFlag(measureTrendSampleState.spearMean)) return "~~";
            if (direction.HasFlag(measureTrendSampleState.noEnough)) return "no";
            return "-";
            
        }
    }
}