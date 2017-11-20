namespace imbSCI.Core.math.measurement
{
    using System;
    using imbSCI.Data.interfaces;
    using System.Collections.Generic;
    using imbSCI.Core.interfaces;
    using System.Linq;

    public class measureDisplayGroup: SortedList<Int32, IMeasure>, IObjectWithNameAndDescription
    {

        public IMeasure this[String key]
        {
            get
            {
               IMeasure output = this.Values.First(x => x.name == key);
                return output;
            }
        }

        private String _name;
        /// <summary>
        /// 
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }


        private String _description;
        /// <summary>
        /// 
        /// </summary>
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }


        public measureDisplayGroup(String __name, String __desc)
        {
            name = __name;
            description = __desc;
        }
    }

}