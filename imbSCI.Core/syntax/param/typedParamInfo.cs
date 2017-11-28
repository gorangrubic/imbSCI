namespace imbSCI.Core.syntax.param
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Struktura koja opisuje parametar - ali ne i njegovu trenutku vrednost
    /// </summary>
    public class typedParamInfo:INotifyPropertyChanged, IGetToSetFromString
    {

        public settingsPropertyEntry sPE { get; set; }

        public typedParamInfo(ParameterInfo paramInfo)
        {
            name = paramInfo.Name;
            type = paramInfo.ParameterType;
            sPE = new settingsPropertyEntry(paramInfo);
            
        }

        /// <summary>
        /// Creates typedParamInfo from string description
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramType">Type of the parameter.</param>
        public typedParamInfo(String paramName, String paramType)
        {
            name = paramName;

            type = paramType.getTypeFromName(typeof(String));
        }

        /// <summary>
        /// Konstruktor na osnovu string deklaracije - koristi setFromString metod
        /// </summary>
        /// <param name="input"></param>
        /// <param name="declaration"></param>
        public typedParamInfo(String input, typedParamDeclarationType declaration) 
        {
            type = typeof(String);
            setFromString(input, declaration);
        }

        /// <summary>
        /// Podrazumevani konstruktor koji postavlja type na string a ime preskace
        /// </summary>
        protected typedParamInfo()
        {
            type = typeof (String);
        }


        /// <summary>
        /// Makes string declaration of the param;
        /// </summary>
        /// <param name="declaration">Declaration format</param>
        public String getToString(typedParamDeclarationType declaration=typedParamDeclarationType.nameDoubleDotType)
        {
            Boolean addCollectionSufix = false;

            String output = "";
            String tName = "";

            if (type != null)
            {
                tName = type.Name;
            } else
            {
                tName = "String";
            }

            switch (declaration)
            {
                case typedParamDeclarationType.nameDoubleDotType:
                    //parts = input.Split(':');
                    output = imbSciStringExtensions.add(name, tName, ":");
                    if (addCollectionSufix) output += ";";
                    break;
            }
            return output;
        }

        /// <summary>
        /// Declares name and value type (class) from string declaration, formated as defined by the declaration
        /// </summary>
        /// <param name="input">String declaration of the param. Example: "numericParam:Int32;textMessage:String"</param>
        /// <param name="declaration">What format is used for string representation</param>
        public void setFromString(String input, typedParamDeclarationType declaration=typedParamDeclarationType.nameDoubleDotType)
        {
            input = input.Trim();
            if (imbSciStringExtensions.isNullOrEmptyString(input))
            {
                return;
            }
            var parts = new String[] {};
            String tName = "String";

            switch (declaration)
            {
                case typedParamDeclarationType.nameDoubleDotType:
                    parts = input.Split(':');
                    name = parts[0].Trim();
                    tName = parts[1].Trim();

                    _type = tName.getTypeFromName();

                    
                    break;
            }
        }


        #region --- name ------- Naziv parametra
        private String _name;
        /// <summary>
        /// Naziv parametra
        /// </summary>
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        #endregion


        #region --- type ------- Tip vrednosti koji se upisuje u parametar
        private Type _type;
        /// <summary>
        /// Tip vrednosti koji se upisuje u parametar
        /// </summary>
        public Type type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("type");
            }
        }
        #endregion
        

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
