namespace imbSCI.Core.syntax.codeSyntax
{
    /// <summary>
    /// Deklaracija jednog bloka
    /// </summary>
    public class syntaxBlockDeclaration : syntaxDeclarationItemBase, ISyntaxDeclarationElement
    {
        public syntaxBlockDeclaration()
        {

        }

       

        #region --- role ------- uloga koju ima ovaj blok 
        private syntaxBlockRole _role = syntaxBlockRole.permanent;
        /// <summary>
        /// uloga koju ima ovaj blok
        /// </summary>
        public syntaxBlockRole role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged("role");
            }
        }
        #endregion





        #region --- lines ------- lines defined inside block 
        private syntaxBlockLineDeclarationCollection _lines = new syntaxBlockLineDeclarationCollection();
        /// <summary>
        /// lines defined inside block
        /// </summary>
        public syntaxBlockLineDeclarationCollection lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
                OnPropertyChanged("lines");
            }
        }
        #endregion





        #region --- render ------- Režim renderovanja 
        private syntaxBlockRenderMode _render = syntaxBlockRenderMode.complete;
        /// <summary>
        /// Režim renderovanja
        /// </summary>
        public syntaxBlockRenderMode render
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