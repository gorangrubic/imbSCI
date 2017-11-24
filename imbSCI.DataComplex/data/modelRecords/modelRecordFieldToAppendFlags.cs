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

    [Flags]
    public enum modelRecordFieldToAppendFlags
    {
        /// <summary>
        /// The identification: record title, record description, instance classname, <see cref="IModelRecord.state"/>, runstamp, UID, instace-ID, log size...
        /// </summary>
        identification = 1,
        /// <summary>
        /// The model record common data, <see cref="IModelRecord"/> properties: i.e. start time, end time, duration, <see cref="IModelRecord.remarkFlags"/>
        /// </summary>
        modelRecordCommonData = 2,

        /// <summary>
        /// Data from <see cref="imbACE.Core.core.builderForLog.AppendDataFields(imbSCI.Data.collection.PropertyCollectionExtended)"/> : log size statistics and exceptions detected
        /// </summary>
        modelRecordLogData = 4,

        /// <summary>
        /// The model record instance data
        /// </summary>
        modelRecordInstanceData = 8,

        /// <summary>
        /// The common data:
        /// </summary>
        commonData = 16,

        /// <summary>
        /// The algorithm shared: 
        /// </summary>
        algorithmShared = 32,

        algorithmSpecifics = 64,

        algorithmCalculated = 128,
        all = identification|modelRecordCommonData|modelRecordInstanceData|commonData|algorithmShared|algorithmSpecifics|algorithmCalculated,
    }

}