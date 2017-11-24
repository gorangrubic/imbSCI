namespace imbSCI.Data.enums.reporting
{
    //
    // Summary:
    //     Specifies the HTML styles available to an System.Web.UI.HtmlTextWriter or System.Web.UI.Html32TextWriter
    //     object output stream.

    public enum htmlClassForReport
    {
        none,
        reportHeader,
        reportBlockContainer,
        reportException,
        metaInfo,
        filePath,
        variables,
        member,
        note,
        itemName,
        noteSummaryContainer,
        noteContainer,
        horizontalMenu,
        container,

        linkBlock,
        evenBlock,
        oddBlock,

        /// <summary>
        /// Podrazumevani class za ovaj tip izvestaja
        /// </summary>
        defaultClass,
    }
}