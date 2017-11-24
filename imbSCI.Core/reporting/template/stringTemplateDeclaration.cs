namespace imbSCI.Core.reporting.template
{
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Proto objekat - sadrzi samo tekstualnu definiciju templatea
    /// </summary>
    public class stringTemplateDeclaration : stringTemplateBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="stringTemplateDeclaration"/> class.
        /// </summary>
        /// <param name="__template">The template.</param>
        public stringTemplateDeclaration(String __template)
        {
            template = __template;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="stringTemplateDeclaration"/> class.
        /// </summary>
        public stringTemplateDeclaration()
        {

        }

        #region --- template ------- template content
        private String _template = "";
        /// <summary>
        /// template content
        /// </summary>
        public String template
        {
            get
            {
                return _template;
            }
            set
            {
                _template = value;
                OnPropertyChanged("template");
            }
        }
        #endregion
    }
}