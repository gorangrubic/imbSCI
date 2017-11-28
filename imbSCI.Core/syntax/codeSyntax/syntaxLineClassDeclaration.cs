namespace imbSCI.Core.syntax.codeSyntax
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Declaration of a line class.
    /// </summary>
    public class syntaxLineClassDeclaration:syntaxDeclarationItemBase, ISyntaxDeclarationElement
    {



        #region --- nameToken ------- Index of token with name 
        private Int32 _nameToken = 0;
        /// <summary>
        /// Index of token with name
        /// </summary>
        public Int32 nameToken
        {
            get
            {
                return _nameToken;
            }
            set
            {
                _nameToken = value;
                OnPropertyChanged("nameToken");
            }
        }
        #endregion


        private Regex regQuery = null;
        

        /// <summary>
        /// Gets REGEX for this line class
        /// </summary>
        /// <returns></returns>
        public Regex getRegex()
        {
            if (regQuery == null)
            {
                regQuery = new Regex(tokenQuery);
            }
            return regQuery;
        }

        #region --- lineType ------- type of line 
        private syntaxBlockLineType _lineType = syntaxBlockLineType.normal;
        /// <summary>
        /// type of line
        /// </summary>
        public syntaxBlockLineType lineType
        {
            get
            {
                return _lineType;
            }
            set
            {
                _lineType = value;
                OnPropertyChanged("lineType");
            }
        }
        #endregion

        public syntaxLineClassDeclaration()
        {

        }

        public syntaxLineClassDeclaration(String __className, String __template, String __tokenQuery)
        {
            name = __className;
            template = __template;
            tokenQuery = __tokenQuery;
        }
        
        #region --- template ------- template for output genetarion 
        private String _template;
        /// <summary>
        /// template for output genetarion. Supports> ~nl for system specific new line sub string
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


        #region --- tokenQuery ------- REGEX query that selects tokens 
        private String _tokenQuery = "";
        /// <summary>
        /// REGEX query that selects tokens
        /// </summary>
        public String tokenQuery
        {
            get
            {
                return _tokenQuery;
            }
            set
            {
                _tokenQuery = value;
                OnPropertyChanged("tokenQuery");
            }
        }
        #endregion

    }


}