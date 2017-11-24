namespace imbSCI.Data.enums.appends
{
    using System;

    [Flags]
    public enum appendTableColumnOptionFlags
    {
        none = 0,
        /// <summary>
        /// Use basic numeric format - with thousant separator
        /// </summary>
        useBasicNumericFormat = 1,
        /// <summary>
        /// Use currency format - with decimal places
        /// </summary>
        useCurrencyFormat = 2,
        /// <summary>
        /// Use currency negative red format
        /// </summary>
        useCurrencyNegativeRedFormat = 4,
        /// <summary>
        /// The use col desc for head
        /// </summary>
        useColDescForHead = 8,
        useColTypeForFoot = 16,
        useFormatForType = 32,
        wrapTextContent = 64,
        useSecondColor = 128,
        useThirdColor = 256

    }
}