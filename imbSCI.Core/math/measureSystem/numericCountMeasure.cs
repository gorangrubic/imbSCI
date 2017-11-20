namespace imbSCI.Core.math.measureSystem
{
    using imbSCI.Core.math.measureSystem.enums;

    public class numericCountMeasure : measureDecimal
    {
        public numericCountMeasure() : base(measureRoleEnum.count, measureSystemsEnum.generalNumeric, 0, 1, 0)
        {
            // name = __name;
            // description = __description;
        }
    }
}