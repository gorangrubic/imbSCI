namespace imbSCI.Core.syntax.code
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.syntax.codeSyntax;

    /// <summary>
    /// Gradivni element koda
    /// </summary>
    public class codeSourceElement
    {


        private Dictionary<Int32, codeSourceElement> _subElements = new Dictionary<int, codeSourceElement>(); // = "";
        /// <summary>
        /// Dictionary with sub elements - contained in this source
        /// </summary>
        public Dictionary<Int32, codeSourceElement> subElements
        {
            get { return _subElements; }
        }



        internal List<String> _tokens = new List<string>(); // = "";
                                    /// <summary>
                                    /// Lista tokena
                                    /// </summary>
        public List<String> tokens
        {
            get { return _tokens; }
        }



        internal codeSourceElementType _type = codeSourceElementType.unknown;// = "";
        /// <summary>
        /// type of code source element
        /// </summary>
        public codeSourceElementType type
        {
            get { return _type; }
        }



        internal String _name; // = "";
                                    /// <summary>
                                    /// Bindable property
                                    /// </summary>
        public String name
        {
            get { return _name; }
        }



        internal ISyntaxDeclarationElement _declaration; // = "";
                                    /// <summary>
                                    /// Syntax declaration for this element
                                    /// </summary>
        public ISyntaxDeclarationElement declaration
        {
            get { return _declaration; }
        }



        internal syntaxLineClassDeclaration _lineClass; // = "";
        /// <summary>
        /// Detected line class
        /// </summary>
        public syntaxLineClassDeclaration lineClass
        {
            get { return _lineClass; }
        }



        internal String _source; // = "";
        /// <summary>
        /// Content of the source element
        /// </summary>
        public String source
        {
            get { return _source; }
        }

    }

}