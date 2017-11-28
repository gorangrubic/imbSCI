namespace imbSCI.Core.syntax.codeSyntax
{
    using System;

    public class syntaxTypeName
    {
        public syntaxTypeName()
        {

        }

        public syntaxTypeName(String __name, String __fullname)
        {
            name = __name;
            fullname = __fullname;
        }

        #region --- name ------- short type name 
        private String _name;
        /// <summary>
        /// short type name
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
              
            }
        }
        #endregion



        #region --- fullname ------- full path type name 
        private String _fullname;
        /// <summary>
        /// full path type name
        /// </summary>
        public String fullname
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
              
            }
        }
        #endregion

    }
}