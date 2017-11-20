namespace imbSCI.Core.math.measureSystem.enums
{
    using System;

    [Flags]
    public enum measureToStringContent
    {
        value = 1,
        unit = 2,
        name = 4,
        roleLetter = 8,
        equalSign = 16,
        isWord = 32,
        roleName = 64,
        roleSymbol = 128,
        /// <summary>
        /// secondary value used in proportions, counters, indexers, exponents, logarithms and etc
        /// </summary>
        baseValue = 256,
        valueAndUnit = value | unit,
        /// <summary>
        /// The expression: L = 25.5 mm
        /// </summary>
        expression = roleLetter | equalSign | value | unit,
        sentence = name | isWord | value | name,
        fullSentence =  name | roleLetter | isWord | roleSymbol | value | unit


    }

}