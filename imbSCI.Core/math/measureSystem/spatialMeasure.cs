namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    public class spatialMeasure:measureDecimal
    {
        public spatialMeasure(Decimal defValue, measureRoleEnum role, decadeLevel level=decadeLevel.none):base(role, measureSystemsEnum.spatial, defValue,1, level)
        {
            //info.unit.
        }
    }
}