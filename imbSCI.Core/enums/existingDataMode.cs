namespace imbSCI.Core.enums
{
    /// <summary>
    /// Rule how to handle existing data when append new data collection or single entry 
    /// </summary>
    public enum existingDataMode
    {
        /// <summary>
        /// it will overwrite any existing data in 
        /// </summary>
        overwriteExisting,


        /// <summary>
        /// The overwrites existing only if existing value is null or empty string
        /// </summary>
        overwriteExistingIfEmptyOrNull,
        /// <summary>
        /// it will leave existing entries unchanged
        /// </summary>
        leaveExisting,
        /// <summary>
        /// it will clear  any (other) existing entry or entries and place only specified (one) or (collection). WARNING: beware that in single entry operation it will clear ALL existing data and place only the one specified
        /// </summary>
        clearExisting,

        /// <summary>
        /// it will remove all existing entries that are not matched by new collection
        /// </summary>
        filterAndLeaveExisting,

        /// <summary>
        /// result is key-crossection of existing and new collection - values are from new
        /// </summary>
        filterNewOverwriteExisting,

        /// <summary>
        /// result will be sum of existing and new values
        /// </summary>
        sumWithExisting,
        
    }
}