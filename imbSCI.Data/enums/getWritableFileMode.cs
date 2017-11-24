namespace imbSCI.Data.enums
{
    /// <summary>
    /// Mode of getWritableFile extension
    /// </summary>
    public enum getWritableFileMode
    {
        /// <summary>
        /// The none - the function is disabled
        /// </summary>
        none,
        /// <summary>
        /// The unknown - it will not affect any existing preference
        /// </summary>
        unknown,
        /// <summary>
        /// It will create new file if no existing detected, or get existing 
        /// </summary>
        newOrExisting,
        /// <summary>
        /// It will not create new file if no existing detected
        /// </summary>
        existing,
        /// <summary>
        /// It will delete any existing file and provide newly created
        /// </summary>
        overwrite,
        /// <summary>
        /// It will automatically modify path with _Counter sufix so the new file has unique filename
        /// </summary>
        autoRenameThis,

        /// <summary>
        /// The automatic rename the existing file if it was created on another date
        /// </summary>
        autoRenameExistingOnOtherDate,

        /// <summary>
        /// It will rename any existing file with sufix _old
        /// </summary>
        autoRenameExistingToOld,
        /// <summary>
        /// It will rename any existing file with sufix _backup
        /// </summary>
        autoRenameExistingToBack,

        /// <summary>
        /// It will just append existing file - partial implementation
        /// </summary>
        appendFile,
        autoRenameExistingToNextPage,

        /// <summary>
        /// It will allow just one backup of an existing file by adding just "_old" sufix, without making new filename unique
        /// </summary>
        autoRenameExistingToOldOnce,
    }

}