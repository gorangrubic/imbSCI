namespace imbSCI.Data.enums.appends
{
    using System;

    [Flags]
    public enum appendTableOptionFlags
    {
        none = 0,
        topHeadFullWidth = 1,
        topHeadHalfWidth = 2,
        footHalfWidth = 4,
        footFullWidth = 8,
        topHeadAlignmentCenter = 16,
        footAlignmentCenter = 32,
        topHeadAlignmentRight = 64,
        footAlignmentRight = 128,
        topHeadMerged = 256,
        footMearged = 512,

        /// <summary>
        /// Use insert cell/character for pair/values
        /// </summary>
        useBetween = 1024,
        addRowNumberOnLeft = 2048
    }
}