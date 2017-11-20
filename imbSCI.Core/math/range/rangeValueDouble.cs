namespace imbSCI.Core.math.range
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.interfaces;
    using System;

    public class rangeValueDouble : rangeValueBase<double>, IRangeValue<double>
    {
        public rangeValueDouble(double min, double max, double start, numberRangeModifyRule __rule) : base(min, max, start, __rule)
        {
            range = max - min;
        }

        public override double changeValue(double __val, double __delta, string op = "+")
        {
            return __val.rangeChange(__delta, max, rule, op);
        }

        public override void setValueRange(aceRangeConfig config)
        {
            if (config == null)
            {
                isDisabled = true;
                return;
            }
            isDisabled = false;
            min = Convert.ToDouble(config.min);
            max = Convert.ToDouble(config.max);
            range = max - min;
            rule = config.rule;
            checkValue();
        }
    }

}