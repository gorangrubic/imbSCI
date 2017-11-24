namespace imbSCI.DataComplex.data.dataUnits.core
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
    using imbSCI.DataComplex.data.dataUnits.enums;

    /// <summary>
    /// The agregator data units have ability to process an external <see cref="DataTable"/> and to populate their fields according to <see cref="imbSCI.Core.attributes.imbAttributeName.reporting_agregate_function"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="imbReportingCore.data.dataUnits.core.dataUnitBase" />
    public class dataUnitAgregator<T> : dataUnitBase
    {
        public dataUnitAgregator() : base(typeof(T))
        {

        }

        private dataUnitPresenter _complete_Table;
        /// <complete>Defines Table that is showint all properties having "complete" in Category description</complete>
        public override dataUnitPresenter complete_Table
        {
            get
            {
                if (_complete_Table == null)
                {
                    _complete_Table = new dataUnitPresenter("complete", "Complete comparative table", "Comparative table between " );
                    _complete_Table.setFlags(
                        dataDeliveryPresenterTypeEnum.tableVertical,
                        dataDeliverFormatEnum.includeAttachment | dataDeliverFormatEnum.globalAttachment,
                        dataDeliverAttachmentEnum.attachCSV | dataDeliverAttachmentEnum.attachExcel | dataDeliverAttachmentEnum.attachJSON);
                    presenters[nameof(complete_Table)] = _complete_Table;
                }
                return _complete_Table;
            }
        }
    }
}