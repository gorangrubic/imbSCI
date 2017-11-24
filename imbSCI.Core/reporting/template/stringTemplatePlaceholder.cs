namespace imbSCI.Core.reporting.template
{
    using imbSCI.Data.interfaces;
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Parametar - plejsholder
    /// </summary>
    public class stringTemplatePlaceholder : stringTemplateBase, IObjectWithName
    {

        #region --- key ------- string kljuc plejsholdera 
        private String _key = "a";
        /// <summary>
        /// string kljuc plejsholdera
        /// </summary>
        public String name
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged("key");
            }
        }
        #endregion

        public stringTemplatePlaceholder()
        {
         
        }

        public stringTemplatePlaceholder(String __key)
        {
            _key = __key;
        }
    }

}