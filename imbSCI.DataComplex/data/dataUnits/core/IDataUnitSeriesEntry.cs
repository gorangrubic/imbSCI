namespace imbSCI.DataComplex.data.dataUnits.core
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

    public interface IDataUnitSeriesEntry
    {
        int iteration { get; set; }
        DateTime rowCreated { get; }
        /// <summary>
        /// Time in minutes since last entry created
        /// </summary>
        /// <value>
        /// The since last minimum.
        /// </value>
        double sinceLastMin { get; }
    }

}