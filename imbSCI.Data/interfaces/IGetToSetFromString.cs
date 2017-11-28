namespace imbSCI.Data.interfaces
{
    using imbSCI.Data.enums;
    using System;

    /// <summary>
    /// Data description classes having serialization capability over customizable declaration syntax
    /// </summary>
    public interface IGetToSetFromString
    {
        /// <summary>
        /// Makes string declaration of the param;
        /// </summary>
        /// <param name="declaration">Declaration format</param>
        String getToString(typedParamDeclarationType declaration = typedParamDeclarationType.nameDoubleDotType);

        /// <summary>
        /// Declares name and value type (class) from string declaration, formated as defined by the declaration
        /// </summary>
        /// <param name="input">String declaration of the param. Example: "numericParam:Int32;textMessage:String"</param>
        /// <param name="declaration">What format is used for string representation</param>
        void setFromString(String input, typedParamDeclarationType declaration = typedParamDeclarationType.nameDoubleDotType);
    }
}
