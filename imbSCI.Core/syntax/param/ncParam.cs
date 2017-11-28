namespace imbSCI.Core.syntax.param
{
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using imbSCI.Data.data;
    using imbSCI.Core.extensions.text;

    /// <summary>
    /// Opisuje jednu instancu NC parametra koja ima svoj format, svoje mesto u liniji i mozda svoje slovo 
    /// </summary>
    public class ncParam:dataBindableBase
    {

        /// <summary>
        /// Vraca String vrednost parametra
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String output = "";
            if (!String.IsNullOrEmpty(key))
            {
                output += key;
            }
           
            switch (valueType)
            {
                default:
                    output += strValue;
                    break;
                case ncParamValueType.label:
                    output += strValue;
                    break;
                case ncParamValueType.numeric:
                    output += decValue.ToString(format);
                    break;
                case ncParamValueType.error:
                    output += "!" + strValue + "!";
                    break;
            }
            if (output=="")
            {
                
            }
            return output;
        }

        

        /// <summary>
        /// Podesava parametar uz pomoc ulaznog stringa. Pokretati pre ubacivanja u kolekciju - da bi parametar bio dostupan preko string kljuca
        /// </summary>
        /// <param name="inputString">Moze imati space na pocetku i na kraju. Moze biti brojni ili string</param>
        /// <param name="__index">Redni broj parametra, ostaviti -1 ako ne treba da modifikuje indeks</param>
        public void setFromString(String inputString, Int32 __index=-1)
        {
            originalSourceCode = inputString;

            if (__index > -1) index = __index;

            if (String.IsNullOrEmpty(inputString))
            {
                valueType = ncParamValueType.empty;
                strValue = "";
                decValue = 0;
                return;
            }




            inputString = inputString.Trim();

            String parStr = Regex.Replace(inputString, "[^0-9.]", ""); // ako je parStr empty or null onda je label u pitanju

            if (String.IsNullOrEmpty(parStr))
            {
                strValue = parStr;
                valueType = ncParamValueType.label;
                return;
            }


            String parLet = inputString.Replace(parStr, "");

            Boolean isNegativeSign = parLet.Contains("-");

            parLet = parLet.Replace("-", "").Trim();

            if (parLet.Length>0)
            {
                if (parLet.Length == 1)
                {
                    key = parLet;
                    valueType = ncParamValueType.numeric;
                }
                if (parLet.Length > 1)
                {
                    valueType = ncParamValueType.label;
                    strValue = inputString;
                }
            } else
            {
                valueType = ncParamValueType.numeric;
            }

            if (valueType == ncParamValueType.numeric)
            {
                if (Decimal.TryParse(parStr, out _decValue))
                {
                    if (isNegativeSign)
                    {
                        decValue = -decValue;
                    }

                    format = parStr.getFormatFromExample(0);
                } else
                {
                    strValue = "Failed to Parse [" + parStr + "] to Decimal value. parLet was: ["+parLet+"]";
                    valueType = ncParamValueType.error;
                }
            }
        }


        #region --- index ------- Indeks u kolekciji

        private Int32 _index = -1;
        /// <summary>
        /// Indeks u kolekciji
        /// </summary>
        public Int32 index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged("index");
            }
        }
        #endregion
        

        #region --- key ------- Pronadjen kljuc
        private String _key = "";
        /// <summary>
        /// Pronadjen kljuc
        /// </summary>
        public String key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged("key");
            }
        }
        #endregion



        #region --- valueType ------- tip nc param value

        private ncParamValueType _valueType = ncParamValueType.label;
        /// <summary>
        /// tip nc param value
        /// </summary>
        internal ncParamValueType valueType
        {
            get
            {
                return _valueType;
            }
            set
            {
                _valueType = value;
                OnPropertyChanged("valueType");
            }
        }
        #endregion
        


        #region --- strValue ------- smestanje string vrednosti
        private String _strValue = "";
        /// <summary>
        /// smestanje string vrednosti
        /// </summary>
        internal String strValue
        {
            get
            {
                return _strValue;
            }
            set
            {
                _strValue = value;
                OnPropertyChanged("strValue");
            }
        }
        #endregion


        #region --- decValue ------- smestanje decimalne vrednosti
        private Decimal _decValue;
        /// <summary>
        /// smestanje decimalne vrednosti
        /// </summary>
        internal Decimal decValue
        {
            get
            {
                return _decValue;
            }
            set
            {
                _decValue = value;
                OnPropertyChanged("decValue");
            }
        }
        #endregion


        #region --- originalSourceCode ------- izvodni kod

        private String _originalSourceCode = "";
        /// <summary>
        /// izvodni kod
        /// </summary>
        protected String originalSourceCode
        {
            get
            {
                return _originalSourceCode;
            }
            set
            {
                _originalSourceCode = value;
                OnPropertyChanged("originalSourceCode");
            }
        }
        #endregion
        
        

        #region -----------  format  -------  [Format kojim je bio zapisan parametar]
        private String _format = "#";// = new String();
        /// <summary>
        /// Format kojim je bio zapisan parametar
        /// </summary>
        // [XmlIgnore]
        [Category("ncParam")]
        [DisplayName("format")]
        [Description("Format kojim je bio zapisan parametar")]
        internal String format
        {
            get
            {
                return _format;
            }
            set
            {
                // Boolean chg = (_format != value);
                _format = value;
                OnPropertyChanged("format");
                // if (chg) {}
            }
        }
        #endregion
        

    }
}
