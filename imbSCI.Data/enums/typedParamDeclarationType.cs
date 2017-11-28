namespace imbSCI.Data.enums
{
    public enum typedParamDeclarationType
    {
        /// <summary>
        /// Parametar deklarisan: paramname:typename --> name:String --- koristi se ; kada se navodi u nizu> count:Int32;name:String;
        /// </summary>
        nameDoubleDotType,

        /// <summary>
        /// -n[Job name]
        /// </summary>
        cmdOperationBracketsStyle,

        /// <summary>
        /// -n job:String
        /// </summary>
        cmdOperationNoBracketsStyle,
    }
}