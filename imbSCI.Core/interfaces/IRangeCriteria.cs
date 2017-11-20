namespace imbSCI.Core.interfaces
{
    using imbSCI.Core.attributes;
    using System;

    public interface IRangeCriteria
    {
        bool isDisabled { get; set; }
        void setCriteria(aceCriterieConfig config);
        void setCriteria(IComparable even, bool trueIfMore = true);
        void setCriteria(IComparable min, IComparable max, bool trueIfInside = true);
        void setCriteriaExact(IComparable even);
        bool testCriteria(IComparable testValue);
    }
}