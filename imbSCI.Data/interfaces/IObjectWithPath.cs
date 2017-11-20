namespace imbSCI.Data.interfaces
{
    #region imbVeles using

    using System;

    #endregion



    /// <summary>
    /// Objekat koji ima jedinstveni ID broj
    /// </summary>
    public interface IObjectWithPath:IObjectWithName, IObjectWithParent
    {
        /// <summary>
        /// Putanja objekta
        /// </summary>
        String path { get; }
    }
}