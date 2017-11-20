namespace imbSCI.Core.math.range
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.interfaces;
    using System;

    public class rangeValueDecimal : rangeValueBase<decimal>, IRangeValue<decimal>
    {
        public rangeValueDecimal(decimal min, decimal max, decimal start, numberRangeModifyRule __rule) : base(min, max, start, __rule)
        {
            range = max - min;
        }

        public override decimal changeValue(decimal __val, decimal __delta, string op = "+")
        {
            return __val.rangeChange(__delta, max, rule, op);
        }

        public override void setValueRange(aceRangeConfig config)
        {
            if (config==null)
            {
                isDisabled = true;
                return;
            }
            isDisabled = false;
            min = Convert.ToDecimal(config.min);
            max = Convert.ToDecimal(config.max);
            range = max - min;
            rule = config.rule;
            checkValue();
        }
    }

}