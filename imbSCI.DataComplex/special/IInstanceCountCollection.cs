namespace imbSCI.DataComplex.special
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

    /// <summary>
    /// Interface to statistical results
    /// </summary>
    public interface IInstanceCountCollection
    {
        int TotalScore { get; }
        double avgFreq { get; }
        
        double diversityRatio { get; }
        int Count { get; }
    }
}