namespace imbSCI.Core.syntax.data.core
{
    using System;

    [Flags]
    public enum configEntryFlag
    {
        nothing = 0x0,
        ChangableByUser = 0x1,
        UsedInTeco = 0x2,
        UsedInSyncro = 0x4,
        VTVariable = 0x8,
        FloatingPoint = 0x10,
        ReadOnly = 0x20,
        Hidden = 0x40,
        HasToBeDACFromCNC = 0x80,

    }
}