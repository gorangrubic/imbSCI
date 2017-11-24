namespace imbSCI.Data.enums.appends
{
    using System;

    #region imbVeles using

    

    #endregion

    /// <summary>
    /// Flagovi - appendTableFlag
    /// </summary>
    [Flags]
    public enum appendTableFlag
    {
        none,

        /// <summary>
        /// da li dodaje ime tabele u ID tabele
        /// </summary>
        addTableNameToID=2,

        /// <summary>
        /// da li dodaje ime tabele u naslov
        /// </summary>
        addTableNameAsTitle=4,

        /// <summary>
        /// Header tekst ide u UPPER
        /// </summary>
        headerToUpper=8,

        /// <summary>
        /// Ubacuje prvi red u tabeli koji sadr�i nazive kolona
        /// </summary>
        insertHeader=16,

        /// <summary>
        /// Drugi red u tabeli sadr�i komentar -- u zavisnosti od implementacije
        /// </summary>
        insertSubHeader=32,

        /// <summary>
        /// Prva kolona u tabeli sadr�i redni broj reda
        /// </summary>
        insertRowNumber=64,

        minorOn5=128,

        majorOn5Minor = 256
    }
}