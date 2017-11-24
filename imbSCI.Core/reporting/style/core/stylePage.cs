namespace imbSCI.Core.reporting.style.core
{
    using imbSCI.Core.reporting.geometrics;
    using imbSCI.Data.data;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Page style
    /// </summary>
    public class stylePage : imbBindable
    {

        


        #region -----------  maxSize  -------  [max size of the page]
        private styleSize _maxSize = new styleSize();
        /// <summary>
        /// max size of the page
        /// </summary>
        // [XmlIgnore]
        [Category("stylePage")]
        [DisplayName("maxSize")]
        [Description("max size of the page")]
        public styleSize maxSize
        {
            get
            {
                return _maxSize;
            }
            set
            {
                // Boolean chg = (_maxSize != value);
                _maxSize = value;
                OnPropertyChanged("maxSize");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  linePercent  -------  [line height percent]
        private Int32 _linePercent = 100; // = new Int32();
        /// <summary>
        /// line height percent
        /// </summary>
        // [XmlIgnore]
        [Category("stylePage")]
        [DisplayName("linePercent")]
        [Description("line height percent")]
        public Int32 linePercent
        {
            get
            {
                return _linePercent;
            }
            set
            {
                // Boolean chg = (_linePercent != value);
                _linePercent = value;
                OnPropertyChanged("linePercent");
                // if (chg) {}
            }
        }
        #endregion



    


        #region -----------  margins  -------  [margins of page inside documents]
        private fourSideSetting _margins = new fourSideSetting(10, 10);
        /// <summary>
        /// margins of page inside documents
        /// </summary>
        // [XmlIgnore]
        [Category("stylePage")]
        [DisplayName("margins")]
        [Description("margins of page inside documents")]
        public fourSideSetting margins
        {
            get
            {
                return _margins;
            }
            set
            {
                // Boolean chg = (_margins != value);
                _margins = value;
                OnPropertyChanged("margins");
                // if (chg) {}
            }
        }
        #endregion
        
    }
}