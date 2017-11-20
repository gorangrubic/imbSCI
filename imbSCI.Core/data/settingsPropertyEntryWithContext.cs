namespace imbSCI.Core.data
{
    using imbSCI.Core.collection;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    using System;
    using System.Collections;
    using System.Reflection;

    public class settingsPropertyEntryWithContext:settingsPropertyEntry
    {
        public settingsPropertyEntryWithContext(PropertyInfo __pi, Object __host, PropertyCollectionExtended pce = null) :base(__pi)
        {
            host = __host;
            Object defVal = null;

            if (pi.PropertyType.IsValueType)
            {
                defVal = pi.PropertyType.GetDefaultValue();
            }

            if (host != null)
            {
               
               
                value = host.imbGetPropertySafe(pi, defVal);
            } else
            {
                value = defVal;
            }
            //displayName = __pi.Name;


            //value = pi.imbGetPropertySafe(pi, pi.PropertyType.getInstance());

        }

        public settingsPropertyEntryWithContext(Object __i, IList __host, PropertyCollectionExtended pce = null)
            : base(__host.IndexOf(__i))
        {
            host = __host;
            value = __i;
           // index = __index;

            if (__host is IList)
            {
                IList l = __host as IList;

                Object i = __i;

                String iname = "[" + index.ToString() + "]";
                type = i.GetType();

                displayName = iname;
                description = imbSciStringExtensions.add(iname, "member [" + type.Name + "] of the collection [" + __host.GetType().Name + "]");
                categoryName = "items";

                //pis.Add(iname, null);
                //settingsPropertyEntryWithContext spe = new settingsPropertyEntryWithContext(pro, target);
                //  spes.Add(pro.Name, spe);
            }
           
        }

        #region --- host ------- referenca prema objektu
        private Object _host;
        /// <summary>
        /// referenca prema objektu
        /// </summary>
        public Object host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
                OnPropertyChanged("host");
            }
        }
        #endregion


       

        #region --- value ------- trenutna vrednost
        private Object _value;
        /// <summary>
        /// trenutna vrednost
        /// </summary>
        public Object value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("value");
            }
        }
        #endregion
        
    }
}