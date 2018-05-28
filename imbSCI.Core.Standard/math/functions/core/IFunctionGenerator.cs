using imbSCI.Core.math.range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions.core
{

    /// <summary>
    /// Interface for function classes, used for procedural generation of [whatever]s :)
    /// </summary>
    public interface IFunctionGenerator
    {
        /// <summary>
        /// Output scalling range adjusts function output before returning final result from <see cref="GetOutput(double)"/> and <see cref="GetOutput(int)"/> methods
        /// </summary>
        /// <value>
        /// The output range.
        /// </value>
        imbNumberScale outputRange { get; set; }



        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        Double GetOutput(Double alpha=0);

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        Double GetOutput(Int32 alpha);
    }

}