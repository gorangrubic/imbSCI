using imbSCI.Core.math.range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions.core
{
    public interface IFunctionGenerator
    {

        Double weight { get; set; }

        imbNumberScale outputRange { get; set; } 
        imbNumberScale alphaDimension { get; set; } 

       // imbNumberScale betaDimension { get; set; }

        Double GetOutput(Double alpha=0);

        Double GetOutput(Int32 alpha);
    }


    

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.functions.core.functionBase" />
    public class sineFunction : functionBase
    {
        public Boolean useCosine { get; set; } = false;

        public Int32 offset { get; set; } = 0;

        public override double GetOutput(double alpha = 0)
        {
            Int32 ang = Convert.ToInt32(alpha * 360) + offset;

            if (useCosine) return outputRange.getAbsoluteValue(Math.Cos(ang));
            return outputRange.getAbsoluteValue(Math.Sin(ang));
        }

        public override double GetOutput(int alpha)
        {
            Int32 ang = alpha + offset;

            if (useCosine) return outputRange.getAbsoluteValue(Math.Cos(ang));
            return outputRange.getAbsoluteValue(Math.Sin(ang));
        }
    }


    public class sequenceFunction : functionBase
    {

        public sequenceFunction(Double firstStep=0)
        {
            AddStep(firstStep);
        }

        public void AddStep(Double value)
        {
            steps.Add(value);
         //   alphaDimension.minValue = 0;
          //  alphaDimension.maxValue = steps.Count;
        }

        public List<Double> steps = new List<double>();



        public override double GetOutput(double alpha = 0)
        {
            Int32 i = Convert.ToInt32(steps.Count * alpha);
            
            return outputRange.getAbsoluteValue(steps[i]);
        }

        public override double GetOutput(int alpha)
        {


            return outputRange.getAbsoluteValue(steps[alpha]);
        }
    }



    public class rampFunction : functionBase
    {
        /// <summary>
        /// Gets the output -- <c>alpha</c> should be 0-1
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(double alpha = 0)
        {
            return outputRange.getAbsoluteValue(alpha);
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(int alpha)
        {
            return outputRange.getAbsoluteValue(alphaDimension.getRatioValue(alpha));
        }
    }

    public class noiseFunction : functionBase {

        Random rnd = new Random();

        public noiseFunction()
        {

        }

      
        public override double GetOutput(double alpha = 0)
        {
            return outputRange.getAbsoluteValue(rnd.NextDouble());
        }

        public override double GetOutput(int alpha)
        {
            return GetOutput(0);
        }
    }


    /// <summary>
    /// base of function generator class
    /// </summary>
    public abstract class functionBase:IFunctionGenerator
    {

        /// <summary>
        /// Scale factor, applied when multiply functions are mixed
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public Double weight { get; set; } = 1;

        public imbNumberScale outputRange { get; set; } = new imbNumberScale(0, 1);

        public imbNumberScale alphaDimension { get; set; } = new imbNumberScale(0, 1);
       

        public abstract double GetOutput(double alpha = 0);
        public abstract double GetOutput(int alpha);

        //  public imbNumberScale betaDimension { get; set; } = new imbNumberScale(0, 1);





        ///// <summary>
        ///// Provides value for given inputs
        ///// </summary>
        ///// <param name="alpha">The alpha.</param>
        ///// <param name="betha">The betha.</param>
        ///// <param name="gama">The gama.</param>
        ///// <returns></returns>
        //public abstract Double GetOutput(Double alpha, Double beta = Double.MinValue, Double gama = Double.MinValue);


        //public abstract Double GetOutput(Int32 alpha, Int32 beta = Int32.MinValue);

    }
}
