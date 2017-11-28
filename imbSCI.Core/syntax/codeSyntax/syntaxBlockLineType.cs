namespace imbSCI.Core.syntax.codeSyntax
{
    /// <summary>
    /// Type of blockline
    /// </summary>
    public enum syntaxBlockLineType
    {
        /// <summary>
        /// Primenjuje standardni template
        /// </summary>
        normal,
        /// <summary>
        /// Primenjuje comment template
        /// </summary>
        comment,
        /// <summary>
        /// Predstalja naslovnu liniju
        /// </summary>
        label,
        /// <summary>
        /// Predstavlja custom template liniju
        /// </summary>
        custom,
        /// <summary>
        /// Prestavlja razmak
        /// </summary>
        emptyLine,


        block,

    }

}