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
    using imbSCI.Core.math;

    /// <summary>
    /// Trend instance
    /// </summary>
    public class measureTrend
    {


        public measureTrend(IEnumerable<double> samples, measureTrendTaker __trendTaker, TimeSpan __timePeriod)
        {

            sampledPeriod = __timePeriod.TotalMinutes;

            trendTaker = __trendTaker;
            deploySample(samples);
        }


        public measureTrend(IEnumerable<double> samples, string __name, string __unit, int __macroSampleSize, double __zeroMargin, int __microSampleSize=-1, int __spearSampleSize=-1)
        {
            trendTaker = new measureTrendTaker(__name, __unit, __macroSampleSize, __microSampleSize, __spearSampleSize, __zeroMargin);
            deploySample(samples);
        }


        public double sampledPeriod { get; set; } = 0;

        public string name
        {
            get
            {
                return trendTaker.name;
            }
        }

        public string format
        {
            get
            {
                return trendTaker.format;
            }
        }

        public string unit
        {
            get
            {
                return trendTaker.unit;
            }
        }

        public int sampleSize { get; set; } = 0;

        public double sPeriod { get; set; }

        protected void deploySample(IEnumerable<double> samples)
        {
            SampleState = trendTaker.GetSampleState(samples.Count());
            sampleSize = samples.Count();
            sPeriod = sampledPeriod.GetRatio(sampleSize);



            if (SampleState.HasFlag(measureTrendSampleState.macroMean))
            {
                var smp = samples.Take(trendTaker.MacroSampleSize);
               // Double smpMinutes = 0;

               

                // smpMinutes = sPeriod * smp.Count();

               

                
                if (trendTaker.IsTimeAverage)
                {
                    
                    MacroMean = smp.Sum().GetRatio((sPeriod * trendTaker.MacroSampleSize)); //(sum.GetRatio(smp.Count())) / sPeriod;
                    MacroMin = smp.Min() / sPeriod;
                    MacroMax = smp.Max() / sPeriod;
                } else
                {
                    MacroMean = smp.Average();
                    MacroMin = smp.Min();
                    MacroMax = smp.Max();
                }
                
                

            } 
            if (SampleState.HasFlag(measureTrendSampleState.microMean))
            {
                if (trendTaker.IsTimeAverage)
                {
                    MicroMean = samples.Take(trendTaker.MicroSampleSize).Sum().GetRatio((sPeriod * trendTaker.MicroSampleSize));
                }
                else
                {
                    MicroMean = samples.Take(trendTaker.MicroSampleSize).Average();
                }

                
            }
            if (SampleState.HasFlag(measureTrendSampleState.spearMean))
            {
                if (trendTaker.IsTimeAverage)
                {
                    SpearMean = samples.Take(trendTaker.SpearSampleSize).Sum().GetRatio((sPeriod * trendTaker.SpearSampleSize));
                }
                else
                {
                    SpearMean = samples.Take(trendTaker.SpearSampleSize).Average();
                }

               
            }

            if (SampleState.HasFlag(measureTrendSampleState.microMean))
            {
                MicroTrend = (MicroMean - SpearMean).GetRatio(MicroMean);

                Trend = MicroTrend - MicroMean;

            }

            if (SampleState.HasFlag(measureTrendSampleState.macroMean))
            {
                MacroTrend = (MacroMean - MicroMean).GetRatio(MacroMean);

                Trend = MacroTrend - MicroTrend;


            }

            measureTrendDirection __direction = measureTrendDirection.ready;

            if (Math.Abs(MicroTrend) <= trendTaker.ZeroMargin)
            {
                __direction |= measureTrendDirection.microStable;
            } else
            {
                if (MicroTrend > 0)
                {
                    __direction |= measureTrendDirection.microUp;
                } else
                {
                    __direction |= measureTrendDirection.microDown;
                }
            }


            if (Math.Abs(MacroTrend) <= trendTaker.ZeroMargin)
            {
                __direction |= measureTrendDirection.macroStable;
            }
            else
            {
                if (MicroTrend > 0)
                {
                    __direction |= measureTrendDirection.macroUp;
                }
                else
                {
                    __direction |= measureTrendDirection.macroDown;
                }
            }

            Direction = __direction;
            
            
            
            


        }

        protected measureTrendTaker trendTaker { get; set; }


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("MacroMean")]
        [imb(imbAttributeName.measure_letter, "M_i")]
        [imb(imbAttributeName.measure_setUnit, "")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MacroMean { get; set; } = default(double);



        /// <summary> Lowest value in the macro set </summary>
        [Category("Ratio")]
        [DisplayName("MacroMin")]
        [imb(imbAttributeName.measure_letter, "M_min")]
        [imb(imbAttributeName.measure_setUnit, "")]
        [Description("Lowest value in the macro set")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MacroMin { get; set; } = default(double);



        /// <summary> Highest value in the macro set </summary>
        [Category("Ratio")]
        [DisplayName("MacroMax")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Highest value in the macro set")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MacroMax { get; set; } = default(double);



        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("MicroMean")]
        [imb(imbAttributeName.measure_letter, "m_i")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MicroMean { get; set; } = default(double);


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("SpearMean")]
        [imb(imbAttributeName.measure_letter, "s_i)")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double SpearMean { get; set; } = default(double);


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("MicroTrend")]
        [imb(imbAttributeName.measure_letter, "mTr = s_i / m_i")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MicroTrend { get; set; } = default(double);


        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("MacroTrend")]
        [imb(imbAttributeName.measure_letter, "MTr = m_i / M_i")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double MacroTrend { get; set; } = default(double);



        /// <summary> Ratio </summary>
        [Category("Ratio")]
        [DisplayName("Trend")]
        [imb(imbAttributeName.measure_letter, "Tr = mTr - MTr")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public double Trend { get; set; } = default(double);



        /// <summary> Current trend direction </summary>
        [Category("Label")]
        [DisplayName("Direction")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Current trend direction")] // [imb(imbAttributeName.reporting_escapeoff)]
        public measureTrendDirection Direction { get; set; } = default(measureTrendDirection);



        /// <summary> Sample status </summary>
        [Category("Label")]
        [DisplayName("SampleState")]
        [imb(imbAttributeName.measure_letter, "")]
        [imb(imbAttributeName.measure_setUnit, "-")]
        [Description("Sample status")] // [imb(imbAttributeName.reporting_escapeoff)]
        public measureTrendSampleState SampleState { get; set; } = default(measureTrendSampleState);




    }
}