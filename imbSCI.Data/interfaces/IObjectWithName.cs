namespace imbSCI.Data.interfaces
{
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Objekat koji ima svoje ime - moze biti jedinstveno ali i ne mora
    /// </summary>
    public interface IObjectWithName
    {
        /// <summary>
        /// Ime koje je dodeljeno objektu
        /// </summary>
        String name { get; set; }
    }
}