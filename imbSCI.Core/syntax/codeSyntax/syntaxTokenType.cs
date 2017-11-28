namespace imbSCI.Core.syntax.codeSyntax
{
    /// <summary>
    /// Type of token content
    /// </summary>
    public enum syntaxTokenType
    {
        /// <summary>
        /// Prazan token
        /// </summary>
        empty,
        /// <summary>
        /// Nepoznata vrsta tokena
        /// </summary>
        unknown,
        /// <summary>
        /// Clean numeric value like> 5  5.43   -4.76  
        /// </summary>
        numeric,
        /// <summary>
        /// Clean alfabet label like> e-mac  tool    Default 
        /// </summary>
        alfabet,
        /// <summary>
        /// Numeric starting with key letter: b40 X500  X-25.34 ...
        /// </summary>
        keyNumberic,
        /// <summary>
        /// Mixed numeric and alphabet
        /// </summary>
        alfanumeric,

    }

}