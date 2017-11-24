namespace imbSCI.Core.reporting.format
{


    /// <summary>
    /// form that one meta item takes during build
    /// </summary>
    public enum reportOutputForm
    {
        /// <summary>
        /// Has no filesystem form
        /// </summary>
        none,
        /// <summary>
        /// The folder
        /// </summary>
        folder,

        /// <summary>
        /// It is part of parent's file
        /// </summary>
        inParentFile,
        /// <summary>
        /// The file
        /// </summary>
        file,
        /// <summary>
        /// The unknown
        /// </summary>
        unknown,
    }

}