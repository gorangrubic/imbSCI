namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.enums;

    public interface IValueWithImportanceInfo
    {
        Boolean isValueInAlarmRange { get; }
        dataPointImportance relevance { get; set; }
    }

}