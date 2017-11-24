namespace imbSCI.Core.enums
{
    using System;

    [Flags]
    public enum cursorVariatorHeadFootFlags
    {
        none = 0,
        doHeadZone = 1,
        doHeadZoneBig = 2,
        doHeadExtenedZone = 4,
        doFootZone = 8,
        doFootZoneBig = 16,
        doFootExtendedZone = 32,
        doLeftZone = 64,
        doRightZone = 128,
        addTableNameHeader = 256,
        addTableDescFooter = 512,
        addRowNumberOnMinor = 1024,
        addRowNumberOnMajor = 2028,
        addColumnDescForFoot = 4056,
        addColumnTypeForFoot = 8112,
        

    }
}