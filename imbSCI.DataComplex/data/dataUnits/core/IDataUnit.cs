namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
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
    using imbSCI.DataComplex.data.dataUnits.enums;

    public interface IDataUnit
    {
        dataUnitPresenter globalAttachmentProvider { get; }
        dataUnitPresenter globalAttachmentTable { get; }
        dataUnitPresenterDictionary presenters { get; }
        dataUnitPresenter complete_Table { get; }
        dataDeliveryAcquireEnum dataAcquireFlags { get; set; }
        dataUnitMap map { get; }
        void dataImportComplete();
        DataTable buildCustomDataTable(IEnumerable instance_items, dataUnitPresenter presenter, bool isPreviewTable);

    }

}