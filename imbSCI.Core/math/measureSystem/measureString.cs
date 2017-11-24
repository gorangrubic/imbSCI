namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.core;
    using imbSCI.Core.math.range;
    using imbSCI.Core.enums;
    using imbSCI.Core.interfaces;
    using imbSCI.Data.data;
    using imbSCI.Data.collection.math;
    using imbSCI.Data.primitives;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="measure{TValue}.String}" />
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="IMeasure" />
    public class measureString : measure<string>, ICloneable, IMeasure
    {



        private coordinateXY _formatZone = new coordinateXY();
        /// <summary>
        /// 
        /// </summary>
        public coordinateXY formatZone
        {
            get { return _formatZone; }
            set { _formatZone = value; }
        }

        


        public measureString() : base()
        {
            //valueTypeGroup = valueType.getTypeGroup();
            
           // info = measureSystemManager.getMeasureInfo(roleEnum, unitEnum, measureSystemsEnum.booleans);
           // setDefaultValue(defaultValue, true);

            //strTrue = info.unit.checkValueMap(true).toStringSafe();
            //strFalse = info.unit.checkValueMap(false).toStringSafe();
        }

        /// <summary>
        /// Calculates the specified second.
        /// </summary>
        /// <param name="second">The second.</param>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        public override IMeasureBasic calculate(IMeasure second, operation op)
        {

            if (second is measureString)
            {
                measureString second_measureString = (measureString)second;

                primValue.calculate(op, second_measureString.primValue);
            }

            return this;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void convertToUnit(measureSystemUnitEntry targetUnit)
        {
            //throw new NotImplementedException();
        }

       
    }

}