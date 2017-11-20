namespace imbSCI.Core.math.measureSystem
{
    using imbSCI.Core.math.measureSystem.enums;

    public class percentMeasure:measureDecimal
    {
        public percentMeasure():base(measureRoleEnum.proportion, measureSystemsEnum.proportion, 0, 100, -1)
        {

        }
    }
}