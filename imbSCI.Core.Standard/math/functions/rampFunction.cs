using imbSCI.Core.math.functions.core;
using imbSCI.Core.math.range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions
{

    /// <summary>
    /// Ramp waveform function: starts with <see cref="functionBase.outputRange"/> minimum and ends with maximum value.
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.functions.core.functionBase" />
    public class rampFunction : functionBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="rampFunction"/> class.
        /// </summary>
        public rampFunction():base(numberRangePresetEnum.zeroToOne) {

        }

        /// <summary>
        /// Gets or sets the alpha dimension scale: relevant only when <see cref="GetOutput(int)"/> -- integer input alpha is used
        /// </summary>
        /// <value>
        /// The alpha dimension.
        /// </value>
        public imbNumberScale alphaDimension { get; set; } = new imbNumberScale(numberRangePresetEnum.zeroToOne);

        /// <summary>
        /// Gets the output -- <c>alpha</c> should be 0-1, it is decimal phase position
        /// </summary>
        /// <param name="alpha">Decimal phase position</param>
        /// <returns></returns>
        public override double GetOutput(double alpha = 0)
        {
            return outputRange.getAbsoluteValue(alpha, true);
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public override double GetOutput(int alpha)
        {
            return outputRange.getAbsoluteValue(alphaDimension.getRatioValue(alpha), true);
        }
    }

}