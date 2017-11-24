namespace imbSCI.Data.interfaces
{
    #region imbVeles using



    #endregion


    /// <summary>
    /// Objekat koji ima jedinstveni ID broj
    /// </summary>
    public interface IObjectWithID
    {
        /// <summary>
        /// Osnovni ID podatak
        /// </summary>
        // [imb(imbAttributeName.collectionPrimaryKey, "id")]
        long id { get; set; }
    }
}