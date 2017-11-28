namespace imbSCI.Core.syntax.codeSyntax
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public abstract class syntaxDeclarationElementCollection<T>:List<T> where T: class, ISyntaxDeclarationElement
    {




        private ISyntaxDeclarationElement _currentBase; // = "";
        [XmlIgnore]
        /// <summary>
        /// currently selected element
        /// </summary>

        public ISyntaxDeclarationElement currentBase
        {
            get { return _currentBase; }
        }


        protected T _current
        {
            get
            {
                return _currentBase as T;
            }
            set
            {
                _currentBase = value;
            }
           
        }
        [XmlIgnore]
        public T current
        {
            get { return _current as T; }
        }


        ISyntaxDeclarationElement this[String __nameOrAlias]
        {
            get
            {
                return find(__nameOrAlias);
            }
        }


        /// <summary>
        /// Find declaration by name or by alias
        /// </summary>
        /// <param name="nameOrAlias"></param>
        /// <returns></returns>
        public T find(String nameOrAlias)
        {
            foreach (T tmp in this)
            {
                if (tmp.name == nameOrAlias)
                {
                    return tmp;
                }
            }


            foreach (T tmp in this)
            {
                if (tmp.isNameOrAlias(nameOrAlias))
                {
                    return tmp;
                }
            }


            return null;
        }
    }

}