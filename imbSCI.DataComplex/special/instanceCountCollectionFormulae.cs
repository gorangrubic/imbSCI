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
    /// Supported comparison modes
    /// </summary>
    public enum instanceCountCollectionFormulae
    {

        keyCount,
        /// <summary>
        /// sum of all frequencies
        /// </summary>
        totalScore,
        /// <summary>
        /// [Total score] / [word count]
        /// </summary>
        avgFrequency,
        /// <summary>
        /// 1 - [Total score] divided by [average score square]
        /// </summary>
        significance,
    }
}