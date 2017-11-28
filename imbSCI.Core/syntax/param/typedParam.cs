namespace imbSCI.Core.syntax.param
{
    using System;
    using System.ComponentModel;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;

    /// <summary>
    /// Parametar sa dodeljenom vrednoscu
    /// </summary>
    public class typedParam:INotifyPropertyChanged
    {

        public typedParam()
        {
        }

        public typedParam(typedParamInfo __info, String input)
        {
            _info = __info;

            input = input.Trim('\"');
            _value = input.imbConvertValueSafe(info.type);

        }

        public void setValue(String valueString)
        {
            _value = valueString.imbConvertValueSafe(info.type);
        }

        /// <summary>
        /// Gets the string representation of the parameter.
        /// </summary>
        /// <param name="declaration">if set to <c>true</c> it adds the Type declaration.</param>
        /// <param name="addDotComma">if set to <c>true</c> it adds dot comma character at the end.</param>
        /// <returns></returns>
        public String getString(Boolean declaration, Boolean addDotComma=false, Boolean explicitForm=true)
        {
            String output = "";
            if (explicitForm) output = info.name + "=";
            if (value != null)
            {
                if (info.type.isText())
                {
                    output += "\"" + value.toStringSafe() + "\"";
                } else
                {
                    output += value.toStringSafe();
                }
            }
            if (declaration)
            {
                output += info.type.Name;
            }
            if (addDotComma) output += ";";
            return output;
        }

        /// <summary>
        /// Dodeljena vrednost - obradjen 
        /// </summary>
        private Object _value;
        /// <summary>
        /// Dodeljena vrednost - obradjen 
        /// </summary>
        public Object value
        {
            get
            {
                return _value;
            }
        }
        

         public void setValueDirect(Object val)
        {
            _value = val;
        }

        /// <summary>
        /// info
        /// </summary>
        private typedParamInfo _info;
        /// <summary>
        /// info
        /// </summary>
        public typedParamInfo info
        {
            get
            {
                return _info;
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}