namespace imbSCI.Core.syntax.data.core
{
    using imbSCI.Data.data;
    using System;

    /// <summary>
    /// Objekat sa linijom koda koja zna gde se nalazi
    /// </summary>
    public class line:dataBindableBase
    {

        #region --- number ------- Broj linije na kojoj je pronadjena
        private Int32 _number;
        /// <summary>
        /// Broj linije na kojoj je pronadjena
        /// </summary>
        public Int32 number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged("number");
            }
        }
        #endregion



        #region --- content ------- Sadrzaj linije
        private String _content;
        /// <summary>
        /// Sadrzaj linije
        /// </summary>
        public String content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged("content");
            }
        }
        #endregion
        

        public line(Int32 _n, String __content)
        {
            number = _n;
            content = __content;
        }
    }
}
