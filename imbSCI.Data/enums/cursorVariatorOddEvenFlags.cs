namespace imbSCI.Data.enums
{
    using System;

    /// <summary>
    /// Describes way of row background changes
    /// </summary>
    [Flags]
    public enum cursorVariatorOddEvenFlags
    {
        none = 0,
        doOddEven =1,
        doMinorOn5 = 2,
        doMinorOn10 = 4,
        doMinorOn20 = 8,
        doMajorOn2Minor = 16,
        doMajorOn5Minor = 32,
        doMajorOn10Minor = 64,
        doMajorOn20Minor = 128,
        
    }
}