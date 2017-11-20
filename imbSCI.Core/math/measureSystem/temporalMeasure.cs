namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// Time measure
    /// </summary>
    /// <seealso cref="measureDecimal" />
    public class temporalMeasure:measureDecimal
    {
        public temporalMeasure(Decimal __degValue):base((measureRoleEnum) measureRoleEnum.duration, measureSystemsEnum.period, __degValue, 1, decadeLevel.none)
        {

        }
    }
}