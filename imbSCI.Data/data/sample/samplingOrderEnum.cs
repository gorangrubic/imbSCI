using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace imbSCI.Data.data.sample
{

    /// <summary>
    /// Sample take order 
    /// </summary>
    public enum samplingOrderEnum
    {
        /// <summary>
        /// The ordinal: from <c>skip</c> to <c>skip</c> + <c>limit</c>
        /// </summary>
        ordinal,
        /// <summary>
        /// The every NTH: ordinal, but every n-th element, including cycling, 
        /// </summary>
        everyNth,

        /// <summary>
        /// The random suffle: random suffle
        /// </summary>
        randomSuffle
    }

}