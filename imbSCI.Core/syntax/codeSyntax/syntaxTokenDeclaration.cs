namespace imbSCI.Core.syntax.codeSyntax
{
    using System;

    /// <summary>
    /// Deklaracija jednog tokena
    /// </summary>
    public class syntaxTokenDeclaration : syntaxDeclarationItemBase, ISyntaxDeclarationElement
    {

        public syntaxTokenDeclaration()
        {

        }


        private syntaxTokenType _type = syntaxTokenType.unknown;
        /// <summary>
        /// Vrsta tokena
        /// </summary>
        public syntaxTokenType type
        {
            get
            {
                return _type;
            }
        }

        #region --- typeName ------- Property type name 
        private String _typeName = "String";
        /// <summary>
        /// Property type name
        /// </summary>
        public String typeName
        {
            get
            {
                return _typeName;
            }
            set
            {
                _typeName = value;
                OnPropertyChanged("typeName");
            }
        }
        #endregion


        #region --- valueFormat ------- Formatiranje vrednosti 
        private String _valueFormat = "\"{0}\"";
        /// <summary>
        /// Formatiranje vrednosti
        /// </summary>
        public String valueFormat
        {
            get
            {
                return _valueFormat;
            }
            set
            {
                _valueFormat = value;
                OnPropertyChanged("valueFormat");
            }
        }
        #endregion

    }

}