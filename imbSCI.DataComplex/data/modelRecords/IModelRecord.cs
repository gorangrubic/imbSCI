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
    /// Data model objects -- with records of <see cref="imbFramework.tests.testDefinition"/> execution
    /// </summary>
    public interface IModelRecord: IAppendDataFieldsExtended, IAutosaveEnabled, ILogable, IConsoleControl //, ILogSerializableProvider<IModelRecordSerializable>
    {
       // void initiate(String __instanceID, String __testRunStamp);
        string UID { get; }
        string instanceID { get; }
        string testRunStamp { get; }
        string logContent { get; }
        int childIndexCurrent { get; }
        DateTime timeStart { get; }
        DateTime timeFinish { get; }
        ILogBuilder logBuilder { get; }

        modelRecordStateEnum state { get; }
        modelRecordRemarkFlags remarkFlags { get; set; }
        PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data, modelRecordFieldToAppendFlags whatToAppend);
        
        string startingThread { get; }
    }
}
