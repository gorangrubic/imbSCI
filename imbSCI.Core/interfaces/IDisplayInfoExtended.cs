using imbSCI.Core.attributes;

namespace imbSCI.Core.interfaces
{
    #region imbVeles using

    

    #endregion

    /// <summary>
    /// Prosireni podaci prikaza
    /// </summary>
    [imb(imbAttributeName.collectionPrimaryKey, "displayName")]
    public interface IDisplayInfoExtended : IDisplayInfo
    {
        imbAttributeCollection attributes { get; set; }
    }
}