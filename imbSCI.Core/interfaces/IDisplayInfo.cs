namespace imbSCI.Core.interfaces
{
    using imbSCI.Core.attributes;
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Osnovni podaci za prikaz
    /// </summary>
    public interface IDisplayInfo
    {
        [imb(imbAttributeName.collectionPrimaryKey)]
        String displayName { get; set; }

        String menuIcon { get; set; }

        String description { get; set; }
    }


   

}