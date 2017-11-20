namespace imbSCI.Data.data
{
    using System;

    /// <summary>
    /// Struktura za flag vrednost
    /// </summary>
    public class byteFlag
    {

        public byteFlag()
        {
            value = 0;
        }


        public byteFlag(String input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (input.Length > 3)
                {
                    String inval = input.Substring(2);
                    value = Byte.Parse(inval, System.Globalization.NumberStyles.HexNumber);
                }
            }
            

        }


        public override string ToString()
        {
            String output = "0x";
            output = output + value.ToString("X2");
            return output;
        }


        #region --- value ------- brojcana vrednost

        private Byte _value = 0;
        /// <summary>
        /// brojcana vrednost
        /// </summary>
        public Byte value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                //OnPropertyChanged("value");
            }
        }
        #endregion
        
    }
}
