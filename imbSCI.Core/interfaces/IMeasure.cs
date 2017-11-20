namespace imbSCI.Core.interfaces
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.math.measureSystem.enums;
    using imbSCI.Core.math.range;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="IMeasure" />
    public interface IMeasure<TValue> : IMeasure where TValue : IComparable
    {
        void setAlarmExact(TValue _alarmValue, Boolean _alarmOn);

        /// <summary>
        /// 
        /// </summary>
        rangeCriteria<TValue> alarmCriteria { get; }

        /// <summary>
        /// 
        /// </summary>
        TValue defValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        rangeValueBase<TValue> valueRange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TValue primValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TValue baseValue { get; set; }

        void setDefaultValue(TValue defaultValue, TValue defaultBaseValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IMeasure" />
    public interface IMeasure:IAceMathMeasure, IMeasureBasic,IValueWithRoleInfo, IValueWithUnitInfo
    {
        measureSystemUnitEntry setCustomUnitEntry();
        measureSystemRoleEntry setCustomRoleEntry(String __letter = "", String __symbol = "", String __name = "");

        measureSystemRoleEntry getRoleEntry(Object input);
        measureSystemUnitEntry getUnitEntry(Object input);

       

        measureInfo info { get; }



        Boolean doUnitOptimization { get; set; }

        /// <summary>
        /// Gets a value indicating whether the current value is plural.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is value plural; otherwise, <c>false</c>.
        /// </value>
        Boolean isValuePlural { get; }

        /// <summary>
        /// TRUE if current value is in alarmant value range
        /// </summary>
        //public virtual Boolean isValueInAlarmRange {
        //    get
        //    {
        //        return alarmCriteria.testCriteria(primValue);
        //    }
        //}


        void convertToOptimalUnitLevel();
        void convertToUnit(measureSystemUnitEntry targetUnit);

        /// <summary>
        /// Returns a string that represents the meassure - according to
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        String ToString();

        /// <summary>
        /// Gets the informational content about this measure
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        List<Object> GetContent(measureToStringContent content);

        String ToString(measureToStringContent content);




    }

}