namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.enums;

    public interface IMeasureBasic: IObjectWithNameAndDescription, IValueWithFormat, IValueWithImportanceInfo, IValueWithToString, IValueComparable, IObjectWithMetaModelNameAndGroup, IComparable
    {
        string GetFormatedValue();
        string GetFormatedValueAndUnit();

        IRangeValue valueRange { get; }

        IRangeCriteria alarmCriteria { get; }


        TC getValue<TC>();

        IMeasureBasic calculate(IMeasure second, operation op);

        measureOperandList calculateTasks { get; }

        /// <summary>
        /// If true it will use alarm range to fire alarm
        /// </summary>
        Boolean isAlarmTurnedOn { get; set; }

        bool isValueInAlarmRange { get; }


        /// <summary>
        /// Gets the format for value or value-and-unit if forValueAndUnit is TRUE.
        /// </summary>
        /// <param name="forValueAndUnit">if set to <c>true</c> returns format for value and unit.</param>
        /// <returns>Format string</returns>
        String GetFormatForValue(Boolean forValueAndUnit = false);

        /// <summary>
        /// TRUE if current value is same as default value specified with constructor 
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is value default; otherwise, <c>false</c>.
        /// </value>
        Boolean isValueDefault { get; }
    }

}