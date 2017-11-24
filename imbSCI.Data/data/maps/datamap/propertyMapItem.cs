namespace imbSCI.Data.data.maps.datamap
{
    #region imbVeles using

    using System;
    using System.Reflection;
    using System.Text;
    using imbSCI.Data.data.maps.mapping;
    using System.Xml.Serialization;

    #endregion

    /// <summary>
    /// 2014c> Collection item: evaluationMapItem, part of evaluationMapItemCollection
    /// </summary>

    public class propertyMapItem : imbBindable, IImbMapItem
    {
        private string _path;

        public propertyMapItem()
        {
        }

        public propertyMapItem(String __name)
        {
            name = __name;
            path = __name;
        }

        #region -----------  name  -------  [Naziv ]

        private String _name; // = new String();

        /// <summary>
        /// cela putanja - onako kako je prosledjeno prilikom definisanja
        /// </summary>
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// ujedno i naziv propertija 
        /// </summary>
        public String name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        #endregion

        #region IImbMapItem Members

        /// <summary>
        /// Da li je map itemu dodeljeno pi
        /// </summary>
        public Boolean isActivated
        {
            get { return (pi != null); }
        }

        #endregion

        #region --- pi ------- property info

        private PropertyInfo _pi;

        /// <summary>
        /// property info
        /// </summary>
        [XmlIgnore]
        public PropertyInfo pi
        {
            get { return _pi; }
            set
            {
                _pi = value;
                OnPropertyChanged("pi");
            }
        }


        /// <summary>
        /// Dijagnosticki ispis naziva ovog mapiranog itema
        /// </summary>
        /// <returns></returns>
        public string getMapItemLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name);
            if (pi == null)
            {
                sb.Append(" - not connected");
            }
            else
            {
                sb.Append(name);// + " (" + pi.")");
            }

            return sb.ToString();
        }

        #endregion
    }
}