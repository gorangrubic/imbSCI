namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;
    using imbSCI.Core.math.range;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.enums;

    public class memory : measureDecimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="memory"/> class.
        /// </summary>
        /// <param name="defaultValue">The default value.</param>
        public memory(decimal defaultValue = 0) : base(measureRoleEnum.size, measureSystemsEnum.memory, defaultValue)
        {

        }

        /// <summary>
        /// Calculates the specified second.
        /// </summary>
        /// <param name="second">The second.</param>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        public IMeasureBasic calculate(IMeasure second, operation op)
        {

            if (second is IMeasure)
            {
                IMeasure second_IMeasure = (IMeasure)second;
                second_IMeasure.convertToUnit(info.unit);

                primValue = primValue.calculate(op, second.getValue<Decimal>());

            }

            return this;
        }
    }
}