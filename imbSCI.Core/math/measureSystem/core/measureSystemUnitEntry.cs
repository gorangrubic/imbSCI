namespace imbSCI.Core.math.measureSystem.core
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.math.measureSystem.enums;
    using imbSCI.Core.math.measureSystem.systems;
    using imbSCI.Data;
    using imbSCI.Core.extensions.typeworks;

    /// <summary>
    /// Definition of an unit of <see cref="measureDecadeSystem"/> 
    /// </summary>
    public class measureSystemUnitEntry:ICloneable
    {
        internal measureSystemUnitEntry(String __unit="", String __nameSingular="", String __namePlural = "*")
        {
            unit = __unit;
            _factor = 0;
            nameSingular = __nameSingular;
            if (__namePlural == "*")
            {
                __namePlural = imbSciStringExtensions.add(nameSingular, "s");
            }
            namePlural = __namePlural;
            //system = __system;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="measureSystemUnitEntry"/> class.
        /// </summary>
        /// <param name="__unit">The unit.</param>
        /// <param name="__level">The level.</param>
        /// <param name="__nameSingular">The name singular.</param>
        /// <param name="__rootLevel">The root level.</param>
        /// <param name="__namePlural">The name plural.</param>
        public measureSystemUnitEntry(String __unit, Double __factor, String __nameSingular, measureDecadeSystem __system, String __namePlural="*")
        {
            unit = __unit;
            _factor = __factor;
            nameSingular = __nameSingular;
            if (__namePlural == "*")
            {
                __namePlural = imbSciStringExtensions.add(nameSingular, "s");
            }
            namePlural = __namePlural;
            system = __system;
        }



        private String _unit;
        /// <summary> </summary>
        public String unit
        {
            get
            {
                return _unit;
            }
             set
            {
                _unit = value;
            }
        }


        private String _namePlural;
        /// <summary> </summary>
        public String namePlural
        {
            get
            {
                return _namePlural;
            }
             set
            {
                _namePlural = value;
                //OnPropertyChanged("namePlural");
            }
        }


        private String _nameSingular;
        /// <summary> </summary>
        public String nameSingular
        {
            get
            {
                return _nameSingular;
            }
            set
            {
                _nameSingular = value;
                //OnPropertyChanged("nameSingular");
            }
        }



        /// <summary>
        /// Checks if there is mapped value defined for this value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns></returns>
        public Object checkValueMap(Object val)
        {
            if (hasValueMap)
            {
                if (valueMap.ContainsKey(val))
                {
                    return valueMap[val];
                }
                else
                {
                    return val;
                }
            } else
            {
                return val;
            }
        }



        private Double _factor = 1;
        /// <summary>
        /// 
        /// </summary>
        public Double factor
        {
            get {return _factor; }
            set { _factor = value; }
        }



        /// <summary>
        /// Gets a value indicating whether this instance has any value map entry
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has value map; otherwise, <c>false</c>.
        /// </value>
        public Boolean hasValueMap
        {
            get
            {
                return (valueMap.Count > 0);
            }
        }

        private Dictionary<Object, Object> _valueMap = new Dictionary<Object, Object>();
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Object, Object> valueMap
        {
            get { return _valueMap; }
            protected set { _valueMap = value; }
        }


        public measureSystemUnitEntry setValueMap(Object mapValue, Object mapString)
        {
            valueMap.Add(mapValue, mapString);
            return this;
        }

        public measureSystemUnitEntry setInt32Map(Int32 start, params Object[] mapString)
        {
            Int32 i = start;
            foreach (Object map in mapString)
            {
                valueMap.Add(i, map);
                i++;
            }

            //valueMap.Add(mapValue, mapString);
            return this;
        }

        /// <summary>
        /// Sets formats for <see cref="formatForValue"/> and <see cref="formatForValueAndUnit"/>
        /// </summary>
        /// <param name="__formatForValue">The format for value.</param>
        /// <param name="__formatForValueAndUnit">The format for value and unit.</param>
        public void setFormat(String __formatForValue, String __formatForValueAndUnit = "*")
        {
            formatForValue = __formatForValue;
            formatForValueAndUnit = __formatForValueAndUnit;
            if (formatForValueAndUnit == "*")
            {
                formatForValueAndUnit = imbSciStringExtensions.add(formatForValue, "{1}", " ");
            }
        }

        public object Clone()
        {
            var tmp = new measureSystemUnitEntry(unit, nameSingular, namePlural);
            tmp.setObjectBySource(this);
            return tmp;
        }

        private String _formatForValue = "{0:0,0.##}";
        /// <summary>
        /// String.Format formatting definition applied only on value - expects only one parameter
        /// </summary>
        public String formatForValue
        {
            get { return _formatForValue; }
            set { _formatForValue = value; }
        }


        private String _formatForValueAndUnit = "{0:0,0.##} {1}";
        /// <summary>
        /// String.Format formatting definition applied only on value - expects only one parameter
        /// </summary>
        public String formatForValueAndUnit
        {
            get { return _formatForValueAndUnit; }
            set { _formatForValueAndUnit = value; }
        }


        private measureToStringContent _contentForValueAndUnitOutput = measureToStringContent.value | measureToStringContent.unit;
        /// <summary>
        /// 
        /// </summary>
        public measureToStringContent contentForValueAndUnitOutput
        {
            get { return _contentForValueAndUnitOutput; }
            set { _contentForValueAndUnitOutput = value; }
        }



       



        private Boolean _isUsingBaseValue;
        /// <summary>
        /// 
        /// </summary>
        public Boolean isUsingBaseValue
        {
            get { return _isUsingBaseValue; }
            set { _isUsingBaseValue = value; }
        }



        private measureDecadeSystem _system;
        /// <summary>
        /// 
        /// </summary>
        public measureDecadeSystem system
        {
            get { return _system; }
            set { _system = value; }
        }



    }

}