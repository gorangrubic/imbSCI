namespace imbSCI.Core.reporting.colors
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using mColor = System.Windows.Media.Color;
    using gColor = System.Drawing.Color;
    using imbSCI.Data.data;

    #endregion

    /// <summary>
    /// 2013c: LowLevel resurs - GUI framework to store multiple aceColor definitions
    /// </summary>
    public class aceColorLibrary : imbBindable
    {
        #region -----------  collection  -------  [Skup boja prema hexadecimalnoj vrednosti i parametrima modulacije]

        private Dictionary<String, aceColorEntry> _collection = new Dictionary<String, aceColorEntry>();

        /// <summary>
        /// Skup boja prema hexadecimalnoj vrednosti i parametrima modulacije
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorLibrary")]
        [DisplayName("collection")]
        [Description("Skup boja prema hexadecimalnoj vrednosti i parametrima modulacije")]
        public Dictionary<String, aceColorEntry> collection
        {
            get { return _collection; }
            set
            {
                // Boolean chg = (_collection != value);
                _collection = value;
                OnPropertyChanged("collection");
                // if (chg) {}
            }
        }

        #endregion
    }
}