namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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
    using imbSCI.DataComplex.special;

    /// <summary>
    /// 
    /// </summary>
    public class dataUnitRowMonitoringDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        public instanceCountCollection<int> freqCount { get; set; }


        public dataUnitRowMonitoringDefinition(PropertyInfo __toWatch, PropertyInfo __toStore, monitoringFunctionEnum __function)
        {
            pi_toWatch = __toWatch;
            pi_toStore = __toStore;
            function = __function;
        }

        public void prepare()
        {
            storedResult = 0;
            newResult = 0;
            storedValue = 0;
            newValue = 0;

        }

        /// <summary>
        /// Reads the value and resolves
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public int readValueAndResolveInt32(object instance, bool saveToProperty=true)
        {
            int output = 0;
            storedValue = newValue;

            newValue = Convert.ToInt32(pi_toWatch.GetValue(instance, null));

            switch (function)
            {
                case monitoringFunctionEnum.stability:
                    if ((storedValue == newValue) && (newValue > 0))
                    {
                        output = storedResult + 1;
                    } else
                    {
                        output = 0;
                    }
                    break;
                case monitoringFunctionEnum.change:
                    output = storedValue - newValue;
                    break;
                case monitoringFunctionEnum.minFreq:
                    freqCount.AddInstance(newValue, "readValueAndResolveInt32() at dataUnitRowMonitoringDefinition");
                    newValue = freqCount[newValue];
                    output = Math.Min(storedResult, newValue);
                    break;
                case monitoringFunctionEnum.maxFreq:
                    freqCount.AddInstance(newValue, "readValueAndResolveInt32() at dataUnitRowMonitoringDefinition");
                    newValue = freqCount[newValue];
                    output = Math.Max(storedResult, newValue);
                    break;
                case monitoringFunctionEnum.summary:
                
                    output = storedResult + newValue;
                    break;
                case monitoringFunctionEnum.min:
                    output = Math.Min(storedResult, newValue);
                    break;
                case monitoringFunctionEnum.max:
                    output = Math.Max(storedResult, newValue);
                    break;
                case monitoringFunctionEnum.final:
                    output = newValue;
                    break;
            }
            newResult = output;
            storedResult = output;

            if (saveToProperty)
            {
                instance.imbSetPropertySafe(pi_toStore, storedResult, true);
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        public int newValue { get; set; }


        /// <summary> Last value</summary>
        public int storedValue { get; protected set; }


        /// <summary>
        /// 
        /// </summary>
        public int storedResult { get; set; } = 0;


        /// <summary>
        /// 
        /// </summary>
        public int newResult { get; set; }


        /// <summary> </summary>
        public PropertyInfo pi_toWatch { get; protected set; }


        /// <summary> </summary>
        public PropertyInfo pi_toStore { get; protected set; }

        /// <summary> </summary>
        public monitoringFunctionEnum function { get; protected set; } = monitoringFunctionEnum.none;
    }

}