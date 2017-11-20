namespace imbSCI.Core.collection
{
    using System;

    /// <summary>
    /// Column/data aspect of the PropertyEntry
    /// </summary>
    [Flags]
    public enum PropertyEntryColumn
    {
        none=0,
        /// <summary>
        /// Original version of entry key
        /// </summary>
        entry_key=8192,
        /// <summary>
        /// Display version of entry name
        /// </summary>
        entry_name=1,
        /// <summary>
        /// Asociated entry description
        /// </summary>
        entry_description=2,

        /// <summary>
        /// Display version of entry value - formatted but without unit
        /// </summary>
        entry_value=4,

        /// <summary>
        /// Display version of entry value, formatted with unit
        /// </summary>
        entry_valueAndUnit=8,

        /// <summary>
        /// Measure role letter
        /// </summary>
        role_letter=16,
        /// <summary>
        /// Measure symbol
        /// </summary>
        role_symbol=32,
        /// <summary>
        /// Measure role name
        /// </summary>
        role_name=64,

        entry_unit=128,


        entry_unitname=256,


        entry_importance=512,

        autocount_idcolumn = 1024,
        valueType = 2048,
        property_description = 8193,
    }

}