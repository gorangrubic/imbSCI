namespace imbSCI.Core.syntax.codeSyntax
{
    using System;

    /// <summary>
    /// Declaration of one parameter, instruction, comment, empty line
    /// </summary>
    public class syntaxBlockLineDeclaration:syntaxDeclarationItemBase, ISyntaxDeclarationElement
    {

        internal syntaxBlockLineDeclaration()
        {

        }
       // public class  : syntaxDeclarationItemBase, ISyntaxDeclarationElement




        #region --- className ------- name of lineclass declaration 
        private String _className = "";
        /// <summary>
        /// name of lineclass declaration
        /// </summary>
        public String className
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
                OnPropertyChanged("className");
            }
        }
        #endregion



        private syntaxTokenDeclarationCollection _tokens = new syntaxTokenDeclarationCollection();
        /// <summary>
        /// deklaracija tokena (parametara)
        /// </summary>
        public syntaxTokenDeclarationCollection tokens
        {
            get { return _tokens; }

        }





        #region --- render ------- Type of render template 
        private syntaxBlockLineType _render = syntaxBlockLineType.normal;
        /// <summary>
        /// Type of render template
        /// </summary>
        public syntaxBlockLineType render
        {
            get
            {
                return _render;
            }
            set
            {
                _render = value;
                OnPropertyChanged("render");
            }
        }
        #endregion

    }

}