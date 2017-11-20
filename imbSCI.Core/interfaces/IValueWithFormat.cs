namespace imbSCI.Core.interfaces
{
    using System;

    public interface IValueWithFormat
    {
        String formatForValue { get; }
        String formatForValueAndUnit { get; }

    }

}