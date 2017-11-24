namespace imbSCI.Core.reporting.zone
{
    /// <summary>
    /// Role that a zone may have inside another zone
    /// </summary>
    public enum cursorZoneRole
    {
        /// <summary>
        /// The parent zone for all zones
        /// </summary>
        master,
        /// <summary>
        /// The header - top most section with given height
        /// </summary>
        header,
        /// <summary>
        /// The footer - bottom most section with given height
        /// </summary>
        footer,
        /// <summary>
        /// The section - horizontal division of a zone where height is defined as part of parent zone
        /// </summary>
        section,
        /// <summary>
        /// The column - vertical division of a zone where width is defined as part of parent zone
        /// </summary>
        column,
        
    }

}