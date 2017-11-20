namespace imbSCI.Core.math.range
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.interfaces;
    using System;

    public class rangeValueInt32 : rangeValueBase<int>, IRangeValue<int>
    {
        public rangeValueInt32(int min, int max, int start, numberRangeModifyRule __rule) : base(min, max, start, __rule)
        {
            range = max - min;
        }

        public override int changeValue(int __val, int __delta, string op = "+")
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
            min = Convert.ToInt32(config.min);
            max = Convert.ToInt32(config.max);
            range = max - min;
            rule = config.rule;
            checkValue();
        }
    }

}