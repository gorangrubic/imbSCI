namespace imbSCI.Data.interfaces
{
    #region imbVeles using

    using System;

    #endregion

    public interface IObjectWithParent
    {
        /// <summary>
        /// Referenca prema parent objektu
        /// </summary>
        Object parent { get; }
    }
}