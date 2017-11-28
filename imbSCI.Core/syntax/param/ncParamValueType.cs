namespace imbSCI.Core.syntax.param
{
    public enum ncParamValueType
    {
        /// <summary>
        /// Parametar je prazan - sigurno je neka greska
        /// </summary>
        empty,
        /// <summary>
        /// Numericka vrednost
        /// </summary>
        numeric,
        /// <summary>
        /// oznaka
        /// </summary>
        label,
        /// <summary>
        /// greska
        /// </summary>
        error,
    }
}