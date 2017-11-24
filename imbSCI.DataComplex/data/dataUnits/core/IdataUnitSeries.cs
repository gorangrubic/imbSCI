namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
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

    public interface IdataUnitSeries
    {
        IDataUnitSeriesEntry lastDataPair { get; }

        /// <complete>Defines Table that is showint all properties having "complete" in Category description</complete>
        dataUnitPresenter complete_Table { get; }

        /// <summary> </summary>
        dataUnitMap map { get; }

        /// <summary> </summary>
        int lastIteration { get; }

        DataTable GetTableWith(dataUnitPresenter presenter, bool isPreview = false);
        void dataImportComplete();

        ////  IDataUnitSeriesEntry lastDataPair { get; }

        /// <summary>
        /// Builds the custom data table.
        /// </summary>
        /// <param name="instance_items">The instance items.</param>
        /// <param name="presenter">The presenter.</param>
        /// <param name="isPreviewTable">if set to <c>true</c> [is preview table].</param>
        /// <returns></returns>
        DataTable buildCustomDataTable(IEnumerable instance_items, dataUnitPresenter presenter, bool isPreviewTable);

        /// <summary>
        /// Builds the data table shema.
        /// </summary>
        /// <param name="presenter">The presenter.</param>
        /// <returns></returns>
        DataTable buildDataTableShema(dataUnitPresenter presenter=null);

        event PropertyChangedEventHandler PropertyChanged;

        IDataUnitSeriesEntry lastEntry { get; }
        IDataUnitSeriesEntry currentEntry { get; }
    }
}