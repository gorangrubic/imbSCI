namespace imbSCI.Data.enums
{
    /// <summary>
    /// Operation on directories to be performed
    /// </summary>
    public enum directoryOperation
    {
        none,
        unknown,
        /// <summary>
        /// The select or build directory on a path
        /// </summary>
        selectOrBuild,
        /// <summary>
        /// Compress into ZIP a directory on a path
        /// </summary>
        compress,
        /// <summary>
        /// Delete directory
        /// </summary>
        delete,
        /// <summary>
        /// Selects only if exists
        /// </summary>
        selectIfExists,
        /// <summary>
        /// Select parent if not root
        /// </summary>
        selectParent,
        /// <summary>
        /// Select device/partition root
        /// </summary>
        selectRoot,
        /// <summary>
        /// Select runtime root
        /// </summary>
        selectRuntimeRoot,
        /// <summary>
        /// Copies directory
        /// </summary>
        copy,
        /// <summary>
        /// Rename directory
        /// </summary>
        rename,
        
    }
}