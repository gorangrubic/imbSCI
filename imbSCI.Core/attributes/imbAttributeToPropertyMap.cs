namespace imbSCI.Core.attributes
{
    using imbSCI.Core.extensions.typeworks;
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Reflection;

    #endregion

    /// <summary>
    /// Sadrzi podatke o mapiranju Attribute To Property
    /// </summary>
    public class imbAttributeToPropertyMap : Dictionary<PropertyInfo, imbAttributeName>
    {
        #region --- targetType ------- Tip za mapiranje 

        private Type _targetType;

        /// <summary>
        /// Tip za mapiranje
        /// </summary>
        public Type targetType
        {
            get { return _targetType; }
            set { _targetType = value; }
        }

        #endregion

        public imbAttributeToPropertyMap(Type __targetType)
        {
            PropertyInfo[] pi = new PropertyInfo[] {};
            targetType = __targetType;

            pi = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                if (p.CanWrite)
                {
                    imbAttributeCollection attributes = imbAttributeTools.getImbAttributeDictionary(p);
                    if (attributes.ContainsKey(imbAttributeName.metaValueFromAttribute))
                    {
                        imbAttribute att = attributes[imbAttributeName.metaValueFromAttribute];
                        Add(p, (imbAttributeName) att.objMsg);
                    }
                }
            }
        }

        public void writeToObject(Object target, imbAttributeCollection attributes, Boolean onlyDeclared = false,
                                  Boolean avoidOverwrite = false)
        {
            foreach (KeyValuePair<PropertyInfo, imbAttributeName> pair in this)
            {
                Boolean go = true;
                if (avoidOverwrite)
                {
                    if (pair.Key.GetValue(target, null) != null) go = false;
                }
                if (onlyDeclared)
                {
                    go = (pair.Key.DeclaringType == targetType);
                }

                if (go)
                {
                    if (attributes.ContainsKey(pair.Value))
                    {
                        target.imbSetPropertyConvertSafe(pair.Key, attributes[pair.Value].getMessage());
                        //pair.Key.SetValue(target, attributes[pair.Value].getMessage(), null);
                    }
                }
            }
        }
    }
}