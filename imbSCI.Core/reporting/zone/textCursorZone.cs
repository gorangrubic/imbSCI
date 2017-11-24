namespace imbSCI.Core.reporting.zone
{
    /// <summary>
    /// Zona kretanja kursora
    /// </summary>
    public enum textCursorZone
    {
        
        /// <summary>
        /// Zona ogranicena padding + margin
        /// </summary>
        innerZone,
        /// <summary>
        /// Zona ogranicena marginom
        /// </summary>
        innerBoxedZone,
        /// <summary>
        /// Zona celog prikaza
        /// </summary>
        outterZone,
        /// <summary>
        /// zona nije zadata - ovo ne bi smelo da ostane drugo kao vrednost
        /// </summary>
        unknownZone,
    }
}