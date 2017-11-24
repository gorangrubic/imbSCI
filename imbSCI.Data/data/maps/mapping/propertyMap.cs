namespace imbSCI.Data.data.maps.mapping
{
    #region imbVeles using

    using System;
    using imbSCI.Data.interfaces;
    using imbSCI.Data.collection;

    #endregion

    /// <summary>
    /// 2014c> podesavanje mapiranja sa jedne klase na drugu
    /// </summary>
    public class propertyMap : aceCollection<propertyMapEntry>, IObjectWithName
    {
        #region --- name ------- Naziv mapiranja - koristi se kod kesiranja klasa-to-klasa mapiranja

        private String _name;

        /// <summary>
        /// Naziv mapiranja - koristi se kod kesiranja klasa-to-klasa mapiranja
        /// </summary>
        public String name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        #endregion
    }
}