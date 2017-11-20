namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// General numeric measure
    /// </summary>
    /// <seealso cref="measureDecimal" />
    public class numericMeasure:measureDecimal  
    {
        public numericMeasure(String __name, decimal defaultValue, measureRoleEnum role = measureRoleEnum.numeric) : base(role, measureSystemsEnum.generalNumeric, defaultValue, 1, 0)
        {
            name = __name;
        }
    }
}