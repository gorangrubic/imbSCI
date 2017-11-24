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

    ///// <summary>
    ///// Base data unit for collection representation, ordered optionally
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public abstract class dataUnitCollection<T>:dataUnitBase
    //{

    //    public dataUnitCollection(T instance):base(typeof(T))
    //    {

    //    }

    //}


    public class dataUnitComparativeCollection<T, TCrossItem> : dataUnitBase
    {
        /// <summary>
        /// Instaces of items to cross table with
        /// </summary>
        public List<TCrossItem> crossItems { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public PropertyEntryDictionary crossItemColumns { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public Type crossItemType { get; set; }


        public dataUnitComparativeCollection() : base(typeof(T))
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
                    _complete_Table = new dataUnitPresenter("complete", "Complete comparative table", "Comparative table between " + typeof(T).Name + " and " + typeof(TCrossItem));
                    _complete_Table.setFlags(
                        dataDeliveryPresenterTypeEnum.tableHorizontal,
                        dataDeliverFormatEnum.includeAttachment | dataDeliverFormatEnum.globalAttachment,
                        dataDeliverAttachmentEnum.attachCSV | dataDeliverAttachmentEnum.attachExcel | dataDeliverAttachmentEnum.attachJSON);
                    presenters[nameof(complete_Table)] = _complete_Table;
                }
                return _complete_Table;
            }
        }

    }

}