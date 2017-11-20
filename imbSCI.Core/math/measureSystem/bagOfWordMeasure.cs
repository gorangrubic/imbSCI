namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.enums;

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <seealso cref="aceCommonTypes.math.measureSystem.core.measure{aceCommonTypes.primitives.bagOfWords}" />
    ///// <seealso cref="System.ICloneable" />
    //public class bagOfWordMeasure : measure<bagOfWords>, ICloneable, IMeasure
    //{
       
    //    public override IMeasureBasic calculate(IMeasure second, operation op)
    //    {

    //        if (second is IMeasure)
    //        {
    //            IMeasure second_IMeasure = (IMeasure)second;
    //            second_IMeasure.convertToUnit(info.unit);


    //            primValue.calculate(second.getValue<Object>(), op);

    //        }

    //        return this;
    //    }


    //    /// <summary>
    //    /// Creates a new object that is a copy of the current instance.
    //    /// </summary>
    //    /// <returns>
    //    /// A new object that is a copy of this instance.
    //    /// </returns>
    //    public object Clone()
    //    {
    //        bagOfWordMeasure output = this.MemberwiseClone() as bagOfWordMeasure;
            
    //        output.primValue = primValue.Clone() as bagOfWords;

    //        return output;
    //    }

    //    public override void convertToUnit(measureSystemUnitEntry targetUnit)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}