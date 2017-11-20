namespace imbSCI.Core.interfaces
{
    #region imbVeles using

    using System;

    #endregion

    public interface IDisplayInfoComplete : IDisplayInfoExtended
    {
        String baseColor { get; set; }

        //aceColorPalette palete { get; set; }

        Boolean isHidden { get; set; }
    }
}