namespace imbSCI.Data.enums.appends
{
    /// <summary>
    /// Type of link/object to append
    /// </summary>
    public enum appendLinkType
    {
        unknown,
        /// <summary>
        /// URL
        /// </summary>
        link,
        /// <summary>
        /// IMAGE
        /// </summary>
        image,

        reference,
        referenceLink,
        referenceImage,

        /// <summary>
        /// Internal anchor
        /// </summary>
        anchor,

        /// <summary>
        /// The style link - link to external style source
        /// </summary>
        styleLink,
        /// <summary>
        /// The script link - link to external script source
        /// </summary>
        scriptLink,

        /// <summary>
        /// The script link - link to extrnal script source - to be placed at bottom of page
        /// </summary>
        scriptPostLink,



    }
}