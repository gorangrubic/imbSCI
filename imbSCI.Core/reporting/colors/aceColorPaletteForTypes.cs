namespace imbSCI.Core.reporting.colors
{
    using imbSCI.Data.data;
    #region imbVeles using

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Part of GUI framework
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public class aceColorPaletteForTypes : imbBindable
    {
        #region -----------  defaultPalette  -------  [Podrazumevana paleta za null itd]

        private aceColorPalette _defaultPalette; // = new aceColorPalette();

        /// <summary>
        /// Podrazumevana paleta za null itd
        /// </summary>
        public aceColorPalette defaultPalette
        {
            get
            {
                if (_defaultPalette == null)
                {
                    if (collection.ContainsKey("defaultPalete"))
                    {
                        _defaultPalette = collection["defaultPalete"];
                    }
                    else
                    {
                        _defaultPalette = new aceColorPalette("#F2F2F2", 0.1F, 0, 0.05F, 0.05F, 5, true, "defaultPalete");
                        collection.Add("defaultPalete", _defaultPalette);
                    }
                }
                return _defaultPalette;
            }
            set { _defaultPalette = value; }
        }

        #endregion

        #region -----------  paletteForType  -------  [Recnik paleta za zadati tip]

        private Dictionary<String,aceColorPalette> _collection = new Dictionary<String, aceColorPalette>();

        /// <summary>
        /// Recnik paleta za zadati tip
        /// </summary>
        // [XmlIgnore]
        public Dictionary<String, aceColorPalette> collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        #endregion
    }
}