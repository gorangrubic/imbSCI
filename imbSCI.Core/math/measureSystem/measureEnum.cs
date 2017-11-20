namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.enums;

    public class measureEnum<T> : measure<T> where T : IComparable
    {
        public measureEnum():base()
        {
            
        }

        public override IMeasureBasic calculate(IMeasure second, operation op)
        {
            //throw new NotImplementedException();

            return this;
        }

        public override void convertToUnit(measureSystemUnitEntry targetUnit)
        {
            //throw new NotImplementedException();
        }
    }

}