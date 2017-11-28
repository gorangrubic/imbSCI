namespace imbSCI.Core.syntax.codeSyntax
{
    using System;

    public class syntaxRenderUnit
    {

        public syntaxRenderUnit()
        {

        }

        public syntaxRenderUnit(String __name, syntaxBlockRenderMode __mode)
        {
            _elementName = __name;
            _mode = __mode;
        }


        private String _elementName; // = "";
        /// <summary>
        /// Name of block or line to be rendered
        /// </summary>
        public String elementName
        {
            get { return _elementName; }
        }


        private syntaxBlockRenderMode _mode; // = "";
        /// <summary>
        /// Way to render element
        /// </summary>
        public syntaxBlockRenderMode mode
        {
            get { return _mode; }
        }


    }

}