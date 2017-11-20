namespace imbSCI.Core.attributes
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Reflection;

    #endregion

    public static class imbAttributeProfileEngine
    {
        #region --- attributeCollectionByMemberInfo ------- Kes atributskih kolekcija prema member info-u na koga se odnose

        private static Dictionary<MemberInfo, imbAttributeCollection> _attributeCollectionByMemberInfo;

        /// <summary>
        /// Kes atributskih kolekcija prema member info-u na koga se odnose
        /// </summary>
        internal static Dictionary<MemberInfo, imbAttributeCollection> attributeCollectionByMemberInfo
        {
            get
            {
                if (_attributeCollectionByMemberInfo == null)
                {
                    _attributeCollectionByMemberInfo = new Dictionary<MemberInfo, imbAttributeCollection>();
                }
                return _attributeCollectionByMemberInfo;
            }
        }

        #endregion

        #region --- attributeToPropertyMapsByType ------- Kesirane mape izmedju attributa i propertija nekog tipa

        private static Dictionary<Type, imbAttributeToPropertyMap> _attributeToPropertyMapsByType;

        /// <summary>
        /// Kesirane mape izmedju attributa i propertija nekog tipa
        /// </summary>
        internal static Dictionary<Type, imbAttributeToPropertyMap> attributeToPropertyMapsByType
        {
            get
            {
                if (_attributeToPropertyMapsByType == null)
                {
                    _attributeToPropertyMapsByType = new Dictionary<Type, imbAttributeToPropertyMap>();
                }
                return _attributeToPropertyMapsByType;
            }
        }

        #endregion
    }
}