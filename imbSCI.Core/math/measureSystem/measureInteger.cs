namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.math.measureSystem.enums;
    using imbSCI.Core.extensions.typeworks;

    public abstract class measureInteger : measure<int>
    {
        protected measureInteger() : base()
        {
        }

        protected measureInteger(Enum role, measureSystemsEnum system, int defaultValue, int defaultBaseValue, int levelsFromRoot = 0) : base(role, system, defaultValue, defaultBaseValue, levelsFromRoot)
        {
        }

        //public measureInteger():base()
        public override void convertToUnit(measureSystemUnitEntry targetUnit)
        {
            double fd = info.unit.GetFactorDistance(targetUnit);
            primValue = Convert.ToInt32(Convert.ToDouble(primValue) * fd);
            info.unit = targetUnit;
        }

        public static measureInteger operator +(measureInteger a1, measureInteger a2)
        {
            a1.primValue += a2.primValue;
            return a1;
        }

        public static measureInteger operator -(measureInteger a1, measureInteger a2)
        {
            a1.primValue -= a2.primValue;
            return a1;
        }

        public static measureInteger operator +(measureInteger a1, Int32 a2)
        {
            a1.primValue += a2;
            return a1;
        }

        public static measureInteger operator -(measureInteger a1, Int32 a2)
        {
            a1.primValue -= a2;
            return a1;
        }



        public static measureInteger operator /(measureInteger a1, measureInteger a2)
        {
            a1.primValue = a1.primValue / a2.primValue;
            return a1;
        }

        public static measureInteger operator /(measureInteger a1, Int32 a2)
        {
            a1.primValue = a1.primValue / a2;
            return a1;
        }

        public static measureInteger operator /(measureInteger a1, Object a2)
        {
            a1.primValue = a1.primValue / a2.imbToNumber<Int32>();
            return a1;
        }

        public static measureInteger operator *(measureInteger a1, Object a2)
        {
            a1.primValue = a1.primValue * a2.imbToNumber<Int32>();
            return a1;
        }


        public static measureInteger operator *(measureInteger a1, measureInteger a2)
        {
            a1.primValue = a1.primValue * a2.primValue;
            return a1;
        }

        public static measureInteger operator *(measureInteger a1, Int32 a2)
        {
            a1.primValue = a1.primValue * a2;
            return a1;
        }

    }

}