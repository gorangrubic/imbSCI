namespace imbSCI.Data.data.maps.datamap
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion


    public class propertyValuePairs : propertyValuePairsBase<object>, IValuePairs
        //imbCollectionMeta<Object>, IValuePairs //Dictionary<string, object>, IValuePairs
    {
        #region --- origin ------- kako je instancirana kolekcija - sta je bio izvor strukture

        private propertyValuePairsOrigin _origin = propertyValuePairsOrigin.unknown;

        /// <summary>
        /// kako je instancirana kolekcija - sta je bio izvor strukture 
        /// </summary>
        public propertyValuePairsOrigin origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                OnPropertyChanged("origin");
            }
        }

        #endregion

        public propertyValuePairs()
        {
        }

        public propertyValuePairs(IEnumerable<String> fields)
        {
            foreach (var p in fields)
            {
                Add(p, "");
            }
            origin = propertyValuePairsOrigin.stringFields;
        }

        public propertyValuePairs(IEnumerable<KeyValuePair<string, object>> source)
        {
            foreach (var p in source)
            {
                Add(p.Key, p.Value);
            }
            origin = propertyValuePairsOrigin.keyValuePairStringObject;
        }

        public propertyValuePairs(IEnumerable<PropertyInfo> fields)
        {
            foreach (var p in fields)
            {
                
                Add(p.Name, null);
            }
            origin = propertyValuePairsOrigin.imbPropertyInfos;
        }

        public propertyValuePairs(IEnumerable<PropertyInfo> fields, Object source)
        {
            foreach (var p in fields)
            {
                Add(p.Name, null);
            }
            getValues(source);
            origin = propertyValuePairsOrigin.imbPropertyInfosWithSource;
        }

        ///bool ContainsKey(string name);
        /// 
        /// 
        /// <summary>
        /// Vraca pairs koji predstavljaju rezultat operacije nad skupom
        /// </summary>
        /// <remarks>
        /// Vraca vrednosti is second-a
        /// </remarks>
        /// <param name="second"></param>
        /// <param name="cst"></param>
        /// <returns></returns>
        public IValuePairs getCrossSection(IValuePairs second, crossSectionType cst)
        {
            return IValuePairsExtension.getCrossSection(this, second, cst);
        }


        // <summary>
        /// Vraca sve vrednosti iz niza
        /// </summary>
        /// <returns></returns>
        public List<Object> getValues()
        {
            return Enumerable.ToList<object>(Values);
        }

        IList<string> IValuePairs.Keys
        {
            get { return Keys as IList<string>; }
        }

    }
}