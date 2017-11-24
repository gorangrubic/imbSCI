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

    public interface IModelRecordSerializable //:ILogSerializable
    {
        string modelClassName { get; set; }
        string modelUID { get; set; }
        string modelInstanceID { get; set; }
        string modelRunStamp { get; set; }
        string modelLogContent { get; set; }
        int modelIndexCurrent { get; set; }
        DateTime modelTimeStart { get; set; }
        DateTime modelTimeFinish { get; set; }

        /// <summary>
        /// Special string note about parameters not available at <see cref="modelRecordBase"/> level
        /// </summary>
        /// <value>
        /// The model note.
        /// </value>
        string modelNote { get; set; }

        modelRecordStateEnum modelState { get; set; }
        modelRecordRemarkFlags modelRemarkFlags { get; set; }

        string modelDataFieldDamp { get; set; }

        //PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data, modelRecordFieldToAppendFlags whatToAppend);

        string modelStartingThread { get; set; }
    }

}