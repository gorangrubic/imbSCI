namespace imbSCI.Core.syntax.data.files
{
    /// <summary>
    /// Nacin na koji uzima test fajl za test run
    /// </summary>
    public enum fileTargetSampleMode
    {
        /// <summary>
        /// Pri test run-u uzima prvi fajl, pri svakom sledecem run-u uzima sledeci sa liste
        /// </summary>
        firstAndNextFile,
        /// <summary>
        /// Pri svakom test runu odabira fajl random patternom
        /// </summary>
        randomFile,
    }
}