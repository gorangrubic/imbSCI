namespace imbSCI.Core.syntax.data.files
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using imbSCI.Core.syntax.data.core;
    using imbSCI.Core.syntax.data.files.@base;

    public abstract class textDataSetWithComments<T>:textDataSetBase
    {

        protected Regex paramLine_set = new Regex(@"(.*)[\s]*[=][\s]*(.*)");
        protected Regex paramLine_tab = new Regex(@"(\w*)[\t\s]*(.*)");

        /// <summary>
        /// Obradjuje sve linije
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<T> processLines();


        /// <summary>
        /// Obradjuje jednu liniju
        /// </summary>
        /// <param name="_line"></param>
        /// <param name="i"> </param>
        /// <returns></returns>
        public abstract T processLine(string _line, int i);


        #region --- headerComments ------- Skup komentara na pocetku fajla

        private List<string> _headerComments = new List<string>();
        /// <summary>
        /// Skup komentara na pocetku fajla
        /// </summary>
        public List<string> headerComments
        {
            get
            {
                return _headerComments;
            }
            set
            {
                _headerComments = value;
                OnPropertyChanged("headerComments");
            }
        }
        #endregion

        #region --- loadedParams ------- Bindable property
        private paramPairs _loadedParams;
        /// <summary>
        /// Bindable property
        /// </summary>
        public core.paramPairs loadedParams
        {
            get
            {
                return _loadedParams;
            }
            set
            {
                _loadedParams = value;
                OnPropertyChanged("loadedParams");
            }
        }
        #endregion
        
    }
}