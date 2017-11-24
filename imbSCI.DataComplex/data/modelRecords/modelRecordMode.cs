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
    /// Enumeration used by model execution records
    /// </summary>
    [Flags]
    public enum modelRecordMode
    {
        none = 0,
        single = 1,
        multi = 2,
        starter = 4,
        singleStarter = single | starter,
        multiStarter= multi | starter,
        nonStarter=8,

        particularScope = 16,
        summaryScope = 32,
        

        obligationInverseOption = 64,
        /// <summary>
        /// The obligation related to RecordStart operation
        /// </summary>
        obligationOnStart = 512,
        /// <summary>
        /// The obligation related to RecordInit operation
        /// </summary>
        obligationOnInit = 1024,
        /// <summary>
        /// The obligation related to RecordFinish operation
        /// </summary>
        obligationOnFinish = 2048,

        obligationDataSet = 128,
        obligationInitBeforeStart = 4096,

        obligationStartBeforeInit = 8192,

        obligationStartBeforeFinish = 16384, 

        obligationPropertyList = 32768,
        obligationBuildSummaryStatistics = 65536,
        callDataSetBuildOnFinish = 131072,



        // particular = particularScope | singleStarter | obligationDataSet,
        // summary = summaryScope | multiStarter,
        // special = globalScope | nonStarter,

    }
}