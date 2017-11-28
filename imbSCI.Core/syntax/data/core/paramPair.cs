namespace imbSCI.Core.syntax.data.core
{
    using imbSCI.Data.data;
    using System;

    public class paramPair : dataBindableBase
    {

        #region --- isComment ------- Da li je u pitanju komentar
        private Boolean _isComment;
        /// <summary>
        /// Da li je u pitanju komentar
        /// </summary>
        public Boolean isComment
        {
            get
            {
                return _isComment;
            }
            set
            {
                _isComment = value;
                OnPropertyChanged("isComment");
            }
        }
        #endregion
        

        #region --- name ------- ime parametra
        private String _name;
        /// <summary>
        /// ime parametra
        /// </summary>
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        #endregion


        #region --- value ------- vrednost parametra
        private String _value;
        /// <summary>
        /// vrednost parametra
        /// </summary>
        public String value
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


        #region --- config ------- Config meta definicija
        private configEntry _config;
        /// <summary>
        /// Config meta definicija
        /// </summary>
        public configEntry config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
                OnPropertyChanged("config");
            }
        }
        #endregion
        
        
    }
}
