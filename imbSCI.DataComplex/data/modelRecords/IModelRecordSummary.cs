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

    public interface IModelRecordSummary<TSideInstance, TSideRecord>:IModelRecordSummary 
         where TSideRecord : modelRecordBase, IModelStandaloneRecord<TSideInstance>
    {
        modelSideRecordSetCollection<TSideInstance, TSideRecord> sideRecordSets { get; }
        void AddSideRecord(TSideRecord __sideRecord);
    }

    public interface IModelRecordSummary:IModelRecord
    {
        /// <summary>
        /// Finishes this summary record
        /// </summary>
        void summaryFinished();
        
    }

}