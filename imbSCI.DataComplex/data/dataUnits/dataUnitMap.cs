namespace imbSCI.DataComplex.data.dataUnits
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
    using imbSCI.Core.math;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.data.dataUnits.core;

    public class dataUnitMap
    {


        /// <summary>
        /// Gets the data unit map.
        /// </summary>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="unitType">Type of the unit.</param>
        /// <returns></returns>
        public static dataUnitMap getDataUnitMap(Type instanceType, Type unitType)
        {
            string token = makeToken(instanceType, unitType);

            if (registry.ContainsKey(token))
            {
                return registry[token];
            }
            else
            {
                return new dataUnitMap(instanceType, unitType);
            }
        }

        protected static string makeToken(Type instanceType, Type unitType)
        {
            return md5.GetMd5Hash(instanceType.Name) + "-" + md5.GetMd5Hash(unitType.Name);
        }


        private static Dictionary<string, dataUnitMap> _registry;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        protected static Dictionary<string, dataUnitMap> registry
        {
            get
            {
                if (_registry == null)
                {
                    _registry = new Dictionary<string, dataUnitMap>();
                }
                return _registry;
            }
        }


        public const string DEFGROUP = "complete";
        public const string SUMGROUP = "summary";

        /// <summary> </summary>
        public dataUnitRowMonitoring monitor { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public settingsEntriesForObject typePropertyDictionary { get; protected set; }

        /// <summary> </summary>
        public Dictionary<string, List<string>> fieldsByNeedle { get; protected set; } = new Dictionary<string, List<string>>();


        /// <summary>
        /// 
        /// </summary>
        public List<settingsPropertyEntryWithContext> columns { get; set; } = new List<settingsPropertyEntryWithContext>();


        protected dataUnitMap(Type instanceType, Type unitType)
        {
            var props = instanceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            typePropertyDictionary = new settingsEntriesForObject(instanceType, false,true);

           

            // fieldsByNeedle.Add(presObj.key, new List<string>());
            monitor = new dataUnitRowMonitoring();


            foreach (KeyValuePair<string, settingsPropertyEntryWithContext> pair in typePropertyDictionary.spes)
            {
                if (pair.Value.pi.isReadWrite())
                {
                    if (!pair.Value.groups.Any())
                    {
                        pair.Value.groups.Add(DEFGROUP);
                    }

                    foreach (string group in pair.Value.groups)
                    {
                        if (!fieldsByNeedle.ContainsKey(group)) fieldsByNeedle.Add(group, new List<string>());
                        fieldsByNeedle[group].Add(pair.Key);

                    }
                    columns.Add(pair.Value);
                    var monF = pair.Value.getMonitoringFunction(instanceType);
                    if (monF != null)
                    {
                        monitor.targets.Add(pair.Key, monF);
                    }
                }
            }

            columns.Sort((x, y) => x.priority.CompareTo(y.priority));
        }
    }

}