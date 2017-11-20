namespace imbSCI.Core.attributes
{
    using imbSCI.Core.math.range;
    using System;

    public class aceRangeConfig
    {
        public aceRangeConfig(IComparable _min, IComparable _max, numberRangeModifyRule _rule)
        {
            min = _min;
            max = _max;
            rule = _rule;
        }
        public IComparable min;
        public IComparable max;
        public numberRangeModifyRule rule;
    }

}