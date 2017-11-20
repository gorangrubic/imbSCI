namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.enums;

    public class instanceMeasure<T> : measure<T> where T : class, IComparable, new()
    {
        public override IMeasureBasic calculate(IMeasure second, operation op)
        {
            
            switch (op)
            {
                case operation.none:
                    primValue = null;
                    break;
                case operation.assign:
                case operation.plus:
                    primValue = second.getValue<T>();
                    break;
                case operation.minus:
                    T vl = second.getValue<T>();
                    if (primValue == vl) primValue = null;
                    break;
                
                default:
                    break;
            }
            return this;
               
        }

        public override void convertToUnit(measureSystemUnitEntry targetUnit)
        {
           // throw new NotImplementedException();
        }
    }

}