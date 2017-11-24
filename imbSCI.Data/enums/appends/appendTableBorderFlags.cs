namespace imbSCI.Data.enums.appends
{
    using System;

    /// <summary>
    /// Describes a way to apply borders to cells
    /// </summary>
    [Flags]
    public enum appendTableBorderFlags
    {
        none = 0,
        addOuterBorder = 1,
        addHeadAndFooterBorder = 2,
        addHeadExtendedBorder = 4,
        addFootExtendedBorder = 8,
        addHeadBorderDouble = 16,
        addFootBorderDouble = 32,
        addBorderOnTopAndBottom = 64,
        addLeftZoneBorder = 128,
        addRightZoneBorder = 256,
    }
}