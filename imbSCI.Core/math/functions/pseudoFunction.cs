using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.math.functions.core;
using imbSCI.Core.math.range;
using System.Text;

namespace imbSCI.Core.math.functions
{

    /// <summary>
    /// Returns predefined fixed value
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.functions.core.functionBase" />
    public class pseudoFunction : functionBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="pseudoFunction"/> class.
        /// </summary>
        public pseudoFunction():base(numberRangePresetEnum.zeroToOne)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="pseudoFunction"/> class.
        /// </summary>
        /// <param name="outputValue">The output value.</param>
        public pseudoFunction(Double outputValue):base(numberRangePresetEnum.zeroToOne)
        {
            output = outputValue;
        }

        public Double output { get; set; } = 0;

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(double alpha = 0)
        {
            return output;
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(int alpha)
        {
            return output;
        }
    }

}