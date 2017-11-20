namespace imbSCI.Core.math.range
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Range value for enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="aceCommonTypes.math.rangeValueBase{System.Int32}" />
    public class rangeValueEnum<T> : rangeValueBase<int>, IRangeValue<int> where T : IComparable, IConvertible
    {
        public override void setValueRange(aceRangeConfig config)
        {
            if (config == null)
            {
                isDisabled = true;
                return;
            }
            isDisabled = false;
            min = Convert.ToInt32(config.min);
            max = Convert.ToInt32(config.max);
            range = max - min;
            rule = config.rule;
            checkValue();
        }

        private List<Object> _values = new List<object>();
        /// <summary>
        /// 
        /// </summary>
        /// 
        public List<Object> values
        {
            get { return _values; }
            protected set { _values = value; }
        }

        public T getEnum(Int32 vl)
        {
            foreach (T v in values)
            {
                if (Convert.ToInt32(v) == vl)
                {
                    return v;
                }
            }
            return default(T);
        }

        public T getValue()
        {
            return getEnum(val);
        }

        public rangeValueEnum(numberRangeModifyRule __rule, T start) : base()
        {
            Type t = typeof(T);
            
            if (!t.isEnum())
            {
                throw new ArgumentException("start", "Type must be an Enum");
            }
            

            var vls = Enum.GetValues(t);
            foreach (Object v in vls)
            {
                values.Add(v);
            }

            var ens = t.GetEnumNames().ToList();

            min = 0;
            max = Enumerable.Count<string>(ens);

            range = Enumerable.Count<string>(ens);
            rule = __rule;

            val = Convert.ToInt32(start);
            
        }

      

        //public override T changeValue(T __val, T __delta, string op = "+")
        //{
        //    Int32 vl = Convert.ToInt32(__val);

        //    vl =  vl.rangeChange(Convert.ToInt32(__delta), Convert.ToInt32(max), rule, op);
        //    return getEnum(vl);
        //}

        public override int changeValue(int __val, int __delta, string op = "+")
        {
            return __val.rangeChange(__delta, max, rule, op);
        }
    }

}