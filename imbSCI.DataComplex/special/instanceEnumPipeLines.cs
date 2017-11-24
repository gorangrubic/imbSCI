namespace imbSCI.DataComplex.special
{
    using System;
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
    using imbSCI.Data.collection.nested;
    using imbSCI.DataComplex.extensions.data;
    using imbSCI.Core.extensions.table;

    /// <summary>
    /// Pipe-chain of instance counters with sourceID locking mechanism.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <seealso cref="aceEnumDictionary{TEnum,TObject}.primitives.instanceCountPipeLine{T}}" />
    public class instanceEnumPipeLines<T, TEnum>: aceEnumDictionary<TEnum, instanceCountPipeLine<T>> where T:class
    {
        /// <summary> </summary>
        public bool propagationPaused { get; protected set; } = false;

        public bool HasAnyRecordAtAll
        {
            get
            {

                foreach (instanceCountPipeLine<T> ot in this.Values)
                {
                    if (ot.HasAnyRecord) return true;
                }
                return false;
            }
        }

        public void FlushAndLock(instanceEnumPipeLines<T, TEnum> completeEnumPipe, string sourceID)
        {
            HoldOn();

            foreach (instanceCountPipeLine<T> ot in this.Values)
            {
                ot.Add(ot.self, sourceID);
            }

            FlushAndLock(sourceID);
        }


        /// <summary>
        /// Sets pipe-line to pause
        /// </summary>
        public void HoldOn()
        {
            propagationPaused = true;
            foreach (instanceCountPipeLine<T> ot in this.Values)
            {
                ot.HoldOn();
            }
        }

        public void FlushAndLock(string sourceID)
        {
            propagationPaused = false;
            foreach (instanceCountPipeLine<T> ot in this.Values)
            {
                ot.FlushAndLock(sourceID);
            }
        }

        /// <summary>
        /// Builds the data table with statistics 
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public DataTable buildDataTable(string tableName)
        {
            TEnum keyOfTheFirst = (TEnum) this.Keys.imbGetItemAt(0, false);

            settingsMemberInfoEntry key_mie = new settingsMemberInfoEntry(typeof(TEnum));
            settingsMemberInfoEntry value_mie = new settingsMemberInfoEntry(typeof(T));


            instanceCountPipeLine<T> ot = this[keyOfTheFirst];
            if (ot == null)
            {

            }

            var o = ot.self;

            foreach (KeyValuePair<TEnum, instanceCountPipeLine<T>> oti in this)
            {
                ot = oti.Value;
                ot.self.reCalculate(instanceCountCollection<T>.preCalculateTasks.all);
                
            }


            DataTable output = this.BuildDataTableHorDictionary("self", key_mie.displayName,PropertyEntryColumn.property_description | PropertyEntryColumn.role_letter | PropertyEntryColumn.role_symbol,
                new string[] { nameof(o.Count), nameof(o.avgFreq), nameof(o.minFreq), nameof(o.maxFreq), nameof(o.medianFreq), nameof(o.varianceFreq), nameof(o.entropyFreq) });
            /*
            buildDataTable(tableName,
            imbDataTableExtensions.buildDataTableOptions.doInsertAutocountColumn|imbDataTableExtensions.buildDataTableOptions.doOnlyWithDisplayName|imbDataTableExtensions.buildDataTableOptions.doInsertItemTitleColumn, globalMeasureUnitDictionary.stats);
            */
            output.Title(tableName);
            return output;
        }

        /// <summary> </summary>
        public instanceEnumPipeLines<T,TEnum> parents { get; protected set; }


        /// <summary>
        /// Connects the complete counter socket to specified parent
        /// </summary>
        /// <param name="__parents">The parents.</param>
        /// <returns></returns>
        public int connectParents(instanceEnumPipeLines<T, TEnum> __parents)
        {
            int c = 0;
            parents = __parents;
            foreach (TEnum key in parents.Keys)
            {
                this[key].parent = parents[key];
                c++;
            }
            return c;
        }
    }

}