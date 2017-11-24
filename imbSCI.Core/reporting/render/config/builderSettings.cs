namespace imbSCI.Core.reporting.render.config
{
    using System;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.appends;
    using System.Collections.Generic;

    /// <summary>
    /// Define way build process is performed
    /// </summary>
    public class builderSettings:imbBindable
    {
        public builderSettings()
        {
            foreach (appendType ap in Enum.GetValues(typeof(appendType)))
            {
                supportedAppends.Add(ap);
            }
            
            //supportedAppends.Add(appendType.)
        }

        
        protected reportOutputSupport _formats; // = new reportOutputSupport();

        /// <summary>
        /// Gets the output support definition for this report kind
        /// </summary>
        /// <value>
        /// The object containing output support info
        /// </value>
        /// \ingroup_disabled renderapi_service
        public reportOutputSupport formats
        {
            get
            {
                return _formats;
            }
            set
            {
                _formats = value;
            }
        }
        

        #region --- api ------- this builder is part of what api 
        private reportAPI _api;
        /// <summary>
        /// this builder is part of what api
        /// </summary>
        public reportAPI api
        {
            get
            {
                return _api;
            }
            set
            {
                _api = value;
                OnPropertyChanged("api");
            }
        }
        #endregion


        #region --- cursorBehaviour ------- way cursor and zone behaves 
        private cursorZoneExecutionSettings _cursorBehaviour = new cursorZoneExecutionSettings();
        /// <summary>
        /// way cursor and zone behaves
        /// </summary>
        public cursorZoneExecutionSettings cursorBehaviour
        {
            get
            {
                return _cursorBehaviour;
            }
            set
            {
                _cursorBehaviour = value;
                OnPropertyChanged("cursorBehaviour");
            }
        }
        #endregion



        private List<appendType> _supportedAppends = new List<appendType>();
        /// <summary>
        /// 
        /// </summary>
        public List<appendType> supportedAppends
        {
            get { return _supportedAppends; }
            set { _supportedAppends = value; }
        }



        #region --- forms ------- Bindable property 
        private reportOutputFormat _forms = new reportOutputFormat(elementLevelFormPreset.none);
        /// <summary>
        /// Bindable property
        /// </summary>
        public reportOutputFormat forms
        {
            get
            {
                return _forms;
            }
            set
            {
                _forms = value;
                OnPropertyChanged("forms");
            }
        }
        #endregion

    }
}
