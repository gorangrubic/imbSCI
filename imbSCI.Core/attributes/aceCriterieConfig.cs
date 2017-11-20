namespace imbSCI.Core.attributes
{
    using imbSCI.Core.math.range;
    using System;

    public class aceCriterieConfig
    {
        public aceCriterieConfig(IComparable _min, IComparable _max, IComparable _even, rangeCriteriaEnum _mode)
        {
            min = _min;

        }
        public IComparable min;
        public IComparable max;
        public IComparable even;
        public rangeCriteriaEnum mode;
    }

}