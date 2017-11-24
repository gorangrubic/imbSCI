namespace imbSCI.DataComplex.trends
{
    using System;
    using System.Collections.Generic;
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

    [Flags]
    public enum measureTrendDirection
    {
        none=0,
        ready = 1,
        macroUp =2,
        microUp=4,
        macroDown=8,
        microDown=16,
        macroStable = 32,
        microStable = 64,

        doubleStable = macroStable | microStable,

        /// <summary>
        /// The double up: Macro and Micro Trends are positive
        /// </summary>
        doubleUp = macroUp | microUp,
        up = macroStable | microUp,
        upDown=macroUp | microDown,
        down = macroStable | microDown,

        doubleDown = macroDown | microDown,
        downUp = macroDown | microUp,
        stable = macroStable | microStable,
        
    }
}