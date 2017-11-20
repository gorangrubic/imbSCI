namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.math.range;
    using imbSCI.Core.attributes;

    public interface IRangeValue<T>: IRangeValue where T:IComparable
    {
        T range { get; }
        T val { get; }
        T checkValue(T __val);
        T changeValue(T __val, T __delta, String op = "+");
    }

    public interface IRangeValue: IRangeCriteria
    {
        void checkValue();
        void setValueRange(aceRangeConfig config);

        void setValue(Object input);

        Object getValue();

        numberRangeModifyRule rule { get; set; }
    }

}