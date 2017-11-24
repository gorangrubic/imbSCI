namespace imbSCI.Data.interfaces
{
    using System;

    /// <summary>
    /// Classes that support autosave registration
    /// </summary>
    public interface IAutosaveEnabled
    {
        /// <summary>
        /// Gets a value indicating whether the instance should be registered for autosave call on application close
        /// </summary>
        /// <value>
        /// <c>true</c> if [variable register for autosave]; otherwise, <c>false</c>.
        /// </value>
        Boolean VAR_RegisterForAutosave { get; }
        /// <summary>
        /// Gets the variable filename prefix to be used
        /// </summary>
        /// <value>
        /// The variable filename prefix.
        /// </value>
        String VAR_FilenamePrefix { get; }


        /// <summary>
        /// The root base of filename (without extension) for autosave. 
        /// </summary>
        /// <remarks>
        /// This should be an abstract property in abstract base classes
        /// </remarks>
        /// <value>
        /// The variable filename base.
        /// </value>
        String VAR_FilenameBase { get; }



        /// <summary>
        /// Gets the variable filename extension.
        /// </summary>
        /// <value>
        /// The variable filename extension.
        /// </value>
        String VAR_FilenameExtension { get; }

        /// <summary>
        /// Gets the variable folder path for autosave.
        /// </summary>
        /// <value>
        /// Path (from app. root) to store the record on autosave. Also used as default on regular save call.
        /// </value>
        String VAR_FolderPathForAutosave { get; }

        /// <summary>
        /// Gets the content of the log.
        /// </summary>
        /// <value>
        /// The content of the log.
        /// </value>
        String logContent { get; }
    }
}