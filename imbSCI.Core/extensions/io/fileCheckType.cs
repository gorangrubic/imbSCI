namespace imbSCI.Core.extensions.io
{
    /// <summary>
    /// Tip provere dostupnosti fajla:
    /// </summary>
    public enum fileCheckType
    {
        /// <summary>
        /// U fajl je moguće upisivati
        /// </summary>
        write,

        /// <summary>
        /// Moguće je čitati podatke iz fajla
        /// </summary>
        read,

        /// <summary>
        /// Fajl postoji - isto što i: File.Exists
        /// </summary>
        exists
    }
}