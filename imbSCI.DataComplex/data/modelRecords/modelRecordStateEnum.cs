namespace imbSCI.DataComplex.data.modelRecords
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
    /// State of the record
    /// </summary>
    public enum modelRecordStateEnum
    {
        /// <summary>
        /// Not started: the record is still unactive, waiting for <see cref="modelRecordParentBase.recordStart"/> call
        /// </summary>
        notStarted,

        /// <summary>
        /// Started: the record is running.
        /// </summary>
        started,

        /// <summary>
        /// Finished: the record is closed on this algorithm. 
        /// </summary>
        finished,

        initiated,
    }

}