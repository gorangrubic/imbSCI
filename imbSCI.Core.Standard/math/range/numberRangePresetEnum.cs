using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.math.range
{


    /// <summary>
    /// Number scale (range) preset enumeration
    /// </summary>
    public enum numberRangePresetEnum
    {
        /// <summary>
        /// The zero to one: from 0.0 to 1.0
        /// </summary>
        zeroToOne,

        /// <summary>
        /// The balanced half one: from -0.5 to +0.5
        /// </summary>
        balancedHalfOne,
        /// <summary>
        /// The balanced full one: from -1 to +1
        /// </summary>
        balancedFullOne,
    }

}