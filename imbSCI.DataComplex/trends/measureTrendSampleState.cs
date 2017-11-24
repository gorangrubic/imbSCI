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
    public enum measureTrendSampleState
    {
        none=0,
        /// <summary>
        /// The no enough: nema minimuma semplova
        /// </summary>
        noEnough=1,
        /// <summary>
        /// The micro mean: dovoljno semplova za mikro mean
        /// </summary>
        microMean=2,
        /// <summary>
        /// The macro mean: dovoljno semplova za full trending
        /// </summary>
        macroMean=4,

        spearMean = 8,
    }
}