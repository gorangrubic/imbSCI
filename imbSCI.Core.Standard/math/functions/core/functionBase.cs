using imbSCI.Core.math.range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions.core
{



    /// <summary>
    /// Base of function generator class
    /// </summary>
    public abstract class functionBase:IFunctionGenerator
    {

        protected functionBase()
        {
        }

        protected functionBase(numberRangePresetEnum preset)
        {
            outputRange = new imbNumberScale(preset);
        }


        /// <summary>
        /// Gets or sets the output range.
        /// </summary>
        /// <value>
        /// The output range.
        /// </value>
        public imbNumberScale outputRange { get; set; } = new imbNumberScale(0, 1);

        ///// <summary>
        ///// Gets or sets the alpha dimension.
        ///// </summary>
        ///// <value>
        ///// The alpha dimension.
        ///// </value>
        //public imbNumberScale alphaDimension { get; set; } = new imbNumberScale(0, 1);


        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public abstract double GetOutput(double alpha = 0);

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public abstract double GetOutput(int alpha);

       

    }
}
