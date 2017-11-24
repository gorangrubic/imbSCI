

/// <summary>
/// DataUnits are output sockets mainly designed to work with <see cref="modelRecordBase"/> instances and collections
/// </summary>
namespace imbSCI.DataComplex.data.dataUnits
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
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.data.dataUnits.core;
    using imbSCI.DataComplex.data.dataUnits.enums;

    public static class dataUnitExtensions
    {

        public static int getPreviewRowLimit(this dataDeliveryAcquireEnum acquire) {
            int output = 0;

            var list = acquire.getEnumListFromFlags<dataDeliveryAcquireEnum>();
            foreach (dataDeliveryAcquireEnum li in list)
            {
                switch (li)
                {
                    case dataDeliveryAcquireEnum.collectionLimitShowCase10:
                        output += 10;
                        break;
                    case dataDeliveryAcquireEnum.collectionLimitShowCase25:
                        output += 25;
                        break;
                }
            }

            return output;
        }


        /// <summary>
        /// Gets the monitoring function.
        /// </summary>
        /// <param name="propertyEntry">The property entry.</param>
        /// <param name="instanceType">Type of the instance.</param>
        /// <returns>null if function not found or set to none</returns>
        public static dataUnitRowMonitoringDefinition getMonitoringFunction(this settingsPropertyEntryWithContext propertyEntry, Type instanceType)
        {
            if (!propertyEntry.attributes.ContainsKey(imbAttributeName.reporting_function)) return null;

            monitoringFunctionEnum function = propertyEntry.attributes.getProperEnum<monitoringFunctionEnum>(monitoringFunctionEnum.none, imbAttributeName.reporting_function);
            if (function == monitoringFunctionEnum.none) return null;
            string toWatch = propertyEntry.attributes.getProperString(imbAttributeName.measure_operand);
            var wpi = instanceType.GetProperty(toWatch);
            dataUnitRowMonitoringDefinition output = new dataUnitRowMonitoringDefinition(wpi, propertyEntry.pi, function);

            return output;
        }
    }
}
