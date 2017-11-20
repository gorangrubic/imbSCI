namespace imbSCI.Core.math.range
{
    /// <summary>
    /// Na koji način menjam boju
    /// </summary>
    public enum numberRangeModifyRule
    {
        /// <summary>
        /// Dodaje prosledjene vrednosti i ako dođu do maksimuma onda ih ostavi na maksimumu (ne važi za HUE)
        /// </summary>
        clipToMax,

        /// <summary>
        /// Ako dođu do maksimuma vrati ih na početak
        /// </summary>
        loop,

        /// <summary>
        /// Postavlja prosleđene vrednosti, bez obzira na trenutne vrednosti
        /// </summary>
        set,


        /// <summary>
        /// Prosleđuje staru vrednost
        /// </summary>
        bypass,

        /// <summary>
        /// Množi sa delta
        /// </summary>
        multiply,

        /// <summary>
        /// Deli sa delta
        /// </summary>
        divide,

        /// <summary>
        /// Returns value from limit for amount it was passing the limit
        /// </summary>
        bounce,
    }
}