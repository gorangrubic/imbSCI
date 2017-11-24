namespace imbSCI.Core.reporting.render.core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class tagBlockTitleCounter
    {
        public void Clear()
        {
            counter.Clear();
        }


        public Int32 this[Int32 key]
        {
            get
            {
                if (!counter.ContainsKey(key))
                {
                    counter.Add(key, 0);
                }
                return counter[key];
            }
            set
            {
                if (!counter.ContainsKey(key))
                {
                    counter.Add(key, 0);
                }
                counter[key] = value;
            }
        }

        private Dictionary<Int32, Int32> _counter = new Dictionary<int, int>();

        /// <summary> </summary>
        protected Dictionary<Int32, Int32> counter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;

            }
        }

        
    }

}