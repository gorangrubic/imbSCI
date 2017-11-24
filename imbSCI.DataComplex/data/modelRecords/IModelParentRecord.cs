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

    //public interface IModelParentRecord

    public interface IModelParentRecord : IModelStandalone
    {
        IModelStandalone childRecord { get; }

        object childInstance { get; }

        void finishChildRecord();
        
        void recordStart(string __testRunStamp, string __instanceID, params object[] resources);
        void recordFinish(params object[] resources);
    }

    //public interface IModelParentRecord<TChildInstance, TChildRecord>:IModelStandalone
    //{
    //    //instanceWithRecordCollection<TChildInstance, TChildRecord> children { get; }
    //    TChildRecord childRecord { get; }

    //    TChildInstance childInstance { get; }

    //    void finishChildRecord();
    //    void startChildRecord(TChildInstance instance, String __instanceID);
    //    void recordStart(String __testRunStamp, String __instanceID, params Object[] resources);
    //    void recordFinish(params Object[] resources);
    //}

    public interface IModelParentRecord<TInstance, TChildInstance, TChildRecord>:IModelStandaloneRecord<TInstance>, IModelParentRecord
        where TChildInstance : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
        where TChildRecord : modelRecordBase, IModelRecord
    {
        instanceWithRecordCollection<TChildInstance, TChildRecord> children { get; }
        TChildRecord childRecord { get; }
        TChildInstance childInstance { get; }
        TInstance instance { get; }

        void finishChildRecord();
        void startChildRecord(TChildInstance instance, string __instanceID);
        void recordStart(string __testRunStamp, string __instanceID, params object[] resources);
        void recordFinish(params object[] resources);
    }

}