namespace imbSCI.Data.enums.reporting
{
    /// <summary>
    /// Uloga koju ima odredjen podatak/tag u izvestaju
    /// </summary>
    public enum reportOutputRoles
    {
        /// <summary>
        /// dodaje se nova linija
        /// </summary>
        appendLine,

        appendPair,
        appendPairItem,
        appendPairValue,

        /// <summary>
        /// Novi odeljak - div
        /// </summary>
        container,

        appendPairContainer,
        appendInline,
        appendLink,
    }
}