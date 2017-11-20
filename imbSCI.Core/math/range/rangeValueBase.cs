namespace imbSCI.Core.math.range
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Value limited within range
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="rangeCriteria{T}" />
    public abstract class rangeValueBase<T>:rangeCriteria<T>, IRangeValue, ICloneable where T : IComparable
    {
        public abstract void setValueRange(aceRangeConfig config);
        

        private T _range;
        /// <summary>
        /// Value total range
        /// </summary>
        public T range
        {
            get { return _range; }
            protected set { _range = value; }
        }


        private T _val;
        /// <summary>
        /// Current value - auto checked
        /// </summary>
        public T val
        {
            get { return _val; }
            set {

                _val = checkValue(value);
                
            }
        }

        //  public abstract T getRange(T __min, T __max);

        public void checkValue()
        {
            _val = checkValue(_val);
        }

        public void setValue(Object input) 
        {
            val = (T)input;
        }

        public Object getValue() 
        {
            return val;
        }

        /// <summary>
        /// Forces value inside the range if not <see cref="rangeCriteria{T}.isDisabled"/> set <c>True</c>
        /// </summary>
        /// <param name="__val">The value to test against the range</param>
        /// <returns></returns>
        public T checkValue(T __val)
        {
            if (isDisabled) return __val;

            T output = __val;
            Int32 i = 0;
            Int32 il = 100;
            while (isBelowMin(output))
            {
                i++;
                output = changeValue(output, range, "+");
                if (i > il) break;
            }

            i = 0;
            while (isOverOrOnMax(output))
            {
                i++;
                output = changeValue(output, range, "-");
                if (i > il) break;
            }

            return output;
        }

        public abstract T changeValue(T __val, T __delta, String op="+");

        public object Clone()
        {
            List<Object> settings = new List<object>();
            settings.AddRange(new Object[] { min, max, val, rule });
            Object clv = GetType().getInstance(settings.ToArray());
            return clv;
        }

        private numberRangeModifyRule _rule = numberRangeModifyRule.clipToMax;
        /// <summary>
        /// 
        /// </summary>
        public numberRangeModifyRule rule
        {
            get { return _rule; }
            set { _rule = value; }
        }

        protected rangeValueBase()
        {
        }

        protected rangeValueBase(T min, T max, T start, numberRangeModifyRule __rule)
        {
            rule = __rule;
            setCriteria(min, max, false);
            //range = getRange(min, max);
            val = start;
        }
    }

}