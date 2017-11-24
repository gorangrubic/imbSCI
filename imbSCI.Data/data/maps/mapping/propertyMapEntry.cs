namespace imbSCI.Data.data.maps.mapping
{
    #region imbVeles using

    using System;
    using System.ComponentModel;

    #endregion

    /// <summary>
    /// 2014c> jedan property map unos
    /// </summary>
    
    public class propertyMapEntry : imbBindable
    {
        #region ----------- Boolean [ isActive ] -------  [Da li je aktivirano trenutno mapiranje]

        private Boolean _isActive = false;

        /// <summary>
        /// Da li je aktivirano trenutno mapiranje
        /// </summary>
        [Category("Switches")]
        [DisplayName("isActive")]
        [Description("Da li je aktivirano trenutno mapiranje")]
        public Boolean isActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged("isActive");
            }
        }

        #endregion

        #region --- sourceProperty ------- naziv propertija koji je izvor podatka

        private String _sourceProperty;

        /// <summary>
        /// naziv propertija koji je izvor podatka
        /// </summary>
        public String sourceProperty
        {
            get { return _sourceProperty; }
            set
            {
                _sourceProperty = value;
                OnPropertyChanged("sourceProperty");
            }
        }

        #endregion

        #region --- targetProperty ------- naziv propertija u koji se snima podatak

        private String _targetProperty;

        /// <summary>
        /// naziv propertija u koji se snima podatak
        /// </summary>
        public String targetProperty
        {
            get { return _targetProperty; }
            set
            {
                _targetProperty = value;
                OnPropertyChanged("targetProperty");
            }
        }

        #endregion
    }
}