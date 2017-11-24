namespace imbSCI.Core.reporting
{

    #region imbVeles using

    

    #endregion

    /// <summary>
    /// Flagovi - appendBreakFlag
    /// </summary>
    public enum appendBreakFlag
    {
        none,

        /// <summary>
        /// Pocinje novu liniju, ili novi red ako je u pitanju spreadsheet dokument
        /// </summary>
        breakLine,

        breakPage,

        breakSection,
    }
}