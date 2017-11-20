namespace imbSCI.Core.math.measurement
{
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;

    //public class measureCollection:List<IMeasure>
    //{

    //}


    public class measureCalculationGroups: SortedList<int, SortedList<Int32, IMeasure>>
    {
       // protected SortedList<Int32, SortedList<Int32, IMeasure>> items = new SortedList<int, SortedList<Int32, IMeasure>>();

        public SortedList<Int32, IMeasure> this[Int32 key] {
            get
            {
                SortedList<Int32, SortedList<Int32, IMeasure>> items = this;
               if (!items.ContainsKey(key))
                {
                    items.Add(key, new SortedList<Int32, IMeasure>());
                }
                return items[key];
            }
        }
    }

}