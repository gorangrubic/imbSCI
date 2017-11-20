namespace imbSCI.Core.data
{
    using System;

    /// <summary>
    /// Zamena za externu biblioteku
    /// </summary>
    public class PropertyItem
    {

        private Type _PropertyType; //= new Type();
        /// <summary> </summary>
        public Type PropertyType
        {
            get
            {
                return _PropertyType;
            }
            protected set
            {
                _PropertyType = value;
            }
        }


        private Object _Value; //= new Object();
        /// <summary> </summary>
        public Object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
               
            }
        }


    }
}