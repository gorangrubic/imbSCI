namespace imbSCI.Core.attributes
{
    using imbSCI.Core.extensions.typeworks;
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    public class imbAttributeCollection : PropertyCollection //Dictionary<imbAttributeName, imbAttribute>
    {
        public imbAttribute this[Object key]
        {
            get
            {
                imbAttribute att = (imbAttribute) base[key];
                return att;
            }
            set
            {
                base[key] = value;
            }
        }

        /// <summary>
        /// dodaje novi attribut u kolekciju
        /// </summary>
        /// <param name="newAttribute"></param>
        public void AddNewAttribute(imbAttribute newAttribute)
        {
            if (ContainsKey(newAttribute.nameEnum))
            {
                this[newAttribute.nameEnum] = newAttribute;
            }
            else
            {
                Add(newAttribute.nameEnum, newAttribute);
            }
        }

        public imbAttribute getAttribute(imbAttributeName name)
        {
            if (ContainsKey(name))
            {
                return (imbAttribute)this[name];
            }
            else
            {
                return null;
            }
        }

        public void setMessage<T>(imbAttributeName name, T defValue, out T target)
        {
            if (ContainsKey(name))
            {
                target = this[name].imbConvertValueSafeTyped<T>();
            } else
            {
                target = defValue;
            }
        }

        public Object getMessageObj(imbAttributeName name, Object output = null)
        {
            if (ContainsKey(name))
            {
                return this[name].getMessage();
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// Bezbedno preuzimanje poruke
        /// </summary>
        /// <param name="name"></param>
        /// <param name="output">Podrazumevani output</param>
        /// <returns></returns>
        public T getMessage<T>(imbAttributeName name, T output = default(T))
        {
            if (ContainsKey(name))
            {
                return this[name].imbConvertValueSafeTyped<T>();
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// Bezbedno preuzimanje poruke
        /// </summary>
        /// <param name="name"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public String getMessage(imbAttributeName name, String output = "")
        {
            if (ContainsKey(name))
            {
                
                return this[name].getMessage().ToString();
            }
            else
            {
                return output;
            }
        }

        #region --- selfDeclaredAttributes ------- Attributi koje je samostalno deklarisao tip

        private Dictionary<imbAttributeName, imbAttribute> _selfDeclaredAttributes =
            new Dictionary<imbAttributeName, imbAttribute>();

        /// <summary>
        /// Attributi koje je samostalno deklarisao tip
        /// </summary>
        public Dictionary<imbAttributeName, imbAttribute> selfDeclaredAttributes
        {
            get { return _selfDeclaredAttributes; }
            set { _selfDeclaredAttributes = value; }
        }

        #endregion
    }
}