using imbSCI.Core.math.functions.core;
using imbSCI.Core.math.range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions
{

    /// <summary>
    /// Random noise value generator, within specified <see cref="functionBase.outputRange"/>
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.functions.core.functionBase" />
    public class noiseFunction : functionBase {

        Random rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="noiseFunction"/> class.
        /// </summary>
        public noiseFunction()
        {

        }


        /// <summary>
        /// Gets random value within <see cref="functionBase.outputRange"/>. Alpha input is ignored
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(double alpha = 0)
        {
            return outputRange.getAbsoluteValue(rnd.NextDouble());
        }

        /// <summary>
        /// Gets random value within <see cref="functionBase.outputRange"/>. Alpha input is ignored
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(int alpha)
        {
            return GetOutput(0);
        }
    }

}