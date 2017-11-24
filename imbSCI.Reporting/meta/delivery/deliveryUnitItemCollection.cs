namespace imbSCI.Reporting.meta.delivery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using imbSCI.Reporting.meta.delivery.items;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Core.reporting.style.enums;

    /// <summary>
    /// Collection of <see cref="deliveryUnitItem"/>s associated to <see cref="deliveryUnit"/> definition
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbSCI.Reporting.meta.delivery.deliveryUnitItem}" />
    /// <seealso cref="IDeliveryUnitItem"/>
    public class deliveryUnitItemCollection:IEnumerable<IDeliveryUnitItem>
    {

        /// <summary>
        /// Determines whether the collection contains item with the same sourcefile path.
        /// </summary>
        /// <param name="sourceFileInfo">The source file information.</param>
        /// <returns>
        ///   <c>true</c> if [contains item from sourcefile] [the specified source file information]; otherwise, <c>false</c>.
        /// </returns>
        public bool containsItemFromSourcefile(FileInfo sourceFileInfo)
        {
            foreach (IDeliveryUnitItem item in this)
            {

                if (item is IDeliverySupportFile)
                {
                    IDeliverySupportFile item_IDeliverySupportFile = (IDeliverySupportFile)item;
                    if (item_IDeliverySupportFile.sourceFileInfo.FullName == sourceFileInfo.FullName)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        /// <summary>
        /// Adds the criteria.
        /// </summary>
        /// <param name="opera">The opera.</param>
        /// <param name="pathMatchRule">The path match rule.</param>
        /// <param name="pathCriteria">The path criteria.</param>
        /// <param name="metaElementTypeToMatch">The meta element type to match.</param>
        /// <param name="level">The level.</param>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public metaContentCriteriaTrigger AddCriteria(metaContentTriggerOperator opera, metaModelTargetEnum pathMatchRule = metaModelTargetEnum.scope, string pathCriteria = null, Type metaElementTypeToMatch = null, reportElementLevel level = reportElementLevel.none, IMetaContentNested element = null) => trigs.AddCriteria(opera, pathMatchRule, pathCriteria, metaElementTypeToMatch, level);

                /// <summary>
        /// Adds the units to be executed if evaluation passes
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void Add(IDeliveryUnitItem unit)
        {
            if (!items.Contains(unit)) items.Add(unit);
        }

        /// <summary>
        /// assigned triggers
        /// </summary>
        protected metaContentCriteriaTriggerCollection trigs { get; set; } = new metaContentCriteriaTriggerCollection();


        /// <summary>
        /// assigned units
        /// </summary>
        protected List<IDeliveryUnitItem> items { get; set; } = new List<IDeliveryUnitItem>();


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IDeliveryUnitItem> GetEnumerator()
        {
            return ((IEnumerable<IDeliveryUnitItem>)items).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IDeliveryUnitItem>)items).GetEnumerator();
        }
    }

}