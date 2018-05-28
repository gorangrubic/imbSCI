using imbSCI.Core.math.functions.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.math.functions
{


    /// <summary>
    /// Macro function containing multiple <see cref="IFunctionGenerator"/>
    /// </summary>
    /// <seealso cref="imbSCI.Core.math.functions.core.functionBase" />
    public class functionArray:functionBase
    {
        /// <summary>
        /// Gets the output produced by contained functions.
        /// </summary>
        /// <param name="alpha">The alpha input - used for as initial input and general alpha</param>
        /// <seealso cref="functionArrayEntry"/>
        /// <seealso cref="functionArrayEntryMode"/>
        /// <seealso cref="items"/>
        /// <returns>Summed result of returned outputs</returns>
        public override double GetOutput(double alpha = 0)
        {
            Double output = 0;
            Double input = alpha;


            foreach (functionArrayEntry entry in items)
            {

                switch (entry.mode)
                {

                    case functionArrayEntryMode.useGeneralAlpha:
                        input = alpha;
                        break;
                    case functionArrayEntryMode.usePrevResultAsAlpha:
                        input = output;
                        break;
                }

                output += entry.function.GetOutput(input) * entry.weight;

            }

            return output;
        }

        /// <summary>
        /// Gets the output produced by contained functions.
        /// </summary>
        /// <param name="alpha">The alpha input - used for as initial input and general alpha</param>
        /// <seealso cref="functionArrayEntry"/>
        /// <seealso cref="functionArrayEntryMode"/>
        /// <seealso cref="items"/>
        /// <returns>Summed result of returned outputs</returns>
        public override double GetOutput(int alpha)
        {

            Double output = 0;
            Int32 input = alpha;


            foreach (functionArrayEntry entry in items)
            {
                
                switch (entry.mode) {

                    case functionArrayEntryMode.useGeneralAlpha:
                        input = alpha;
                        break;
                    case functionArrayEntryMode.usePrevResultAsAlpha:
                        input = Convert.ToInt32(output);
                        break;
                }

                output += entry.function.GetOutput(input) * entry.weight;

            }

            return output;
        }

        /// <summary>
        /// Adds the specified function.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public functionArrayEntry Add(IFunctionGenerator function, Double weight=1, functionArrayEntryMode mode=functionArrayEntryMode.useGeneralAlpha)
        {
            var output = new functionArrayEntry();
            output.function = function;
            output.weight = weight;
            output.mode = mode;

            items.Add(output);

            return output;
        }


        /// <summary>
        /// Contained functions, with their weights and computation mode. The functions are called in the same order as in the list
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<functionArrayEntry> items { get; protected set; } = new List<functionArrayEntry>();

        /// <summary>
        /// Designates how functions are used in <see cref="functionArray"/>
        /// </summary>
        public enum functionArrayEntryMode
        {
            /// <summary>
            /// The function (<see cref="functionBase.GetOutput(double)"/>) will get <see cref="GetOutput(double)"/> general alpha value
            /// </summary>
            useGeneralAlpha,
            /// <summary>
            /// The function will get output from function invoked in previous step. If it is the first in the array, then it gets general alpha
            /// </summary>
            usePrevResultAsAlpha,

        }

        /// <summary>
        /// Holder for a function in the <see cref="functionArray"/>
        /// </summary>
        public class functionArrayEntry
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="functionArrayEntry"/> class.
            /// </summary>
            public functionArrayEntry()
            {

            }

            /// <summary>
            /// Gets or sets the mode.
            /// </summary>
            /// <value>
            /// The mode.
            /// </value>
            public functionArrayEntryMode mode { get; set; } = functionArrayEntryMode.useGeneralAlpha;

            /// <summary>
            /// Scale factor, applied when multiply functions are mixed
            /// </summary>
            /// <value>
            /// The weight.
            /// </value>
            public Double weight { get; set; } = 1;

            /// <summary>
            /// Gets or sets the function.
            /// </summary>
            /// <value>
            /// The function.
            /// </value>
            public IFunctionGenerator function { get; set; } = new sequenceFunction(0);
            
        }

    }
}
