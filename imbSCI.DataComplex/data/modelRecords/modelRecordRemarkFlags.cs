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
    /// Pointing to important events and/or facts of this record
    /// </summary>
    [Flags]
    public enum modelRecordRemarkFlags
    {
        /// <summary>
        /// Irregular operation: the algorithm this record is following had minor irregularities during operation
        /// </summary>
        irregularOperation,
        /// <summary>
        /// Broken: one or more major errors occoured during operation of this algorithm
        /// </summary>
        broken,
        /// <summary>
        /// Significant: result this algorithm achieved is significant
        /// </summary>
        significant,
        /// <summary>
        /// Insteresting: algorithm log should be examined by researched 
        /// </summary>
        insteresting,

        /// <summary>
        /// The algorithm failed on the evaluation criteria
        /// </summary>
        testCriteriaFail,
        /// <summary>
        /// The algorithm passed the evaluation criteria
        /// </summary>
        testCriteriaPass,

    }

}