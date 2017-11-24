namespace imbSCI.Core.reporting
{
    #region imbVeles using

    using imbSCI.Core.reporting.format;
    using imbSCI.Data.enums.reporting;

    #endregion

    /// <summary>
    /// Definicija stila za izvestaj
    /// </summary>
    public class reportOutputFormatTags
    {
        public htmlTagName divTag = htmlTagName.none;
        public htmlTagName headTag = htmlTagName.none;
        public htmlTagName inlineBoldTag = htmlTagName.none;
        public htmlTagName inlineTag = htmlTagName.none;
        public htmlTagName lineTag = htmlTagName.none;
        public htmlTagName preTag = htmlTagName.none;

        public reportOutputFormatTags(reportOutputFormatName format = reportOutputFormatName.none)
        {
            if (format == reportOutputFormatName.none) format = reportOutputFormatName.htmlReport; //imbCoreApplicationSettings.ReportReportFormat;
            switch (format)
            {
                case reportOutputFormatName.textFile:

                    break;
                case reportOutputFormatName.htmlReport:
                    headTag = htmlTagName.h3;
                    lineTag = htmlTagName.p;
                    inlineTag = htmlTagName.span;
                    inlineBoldTag = htmlTagName.span;
                    preTag = htmlTagName.pre;
                    divTag = htmlTagName.div;
                    break;
            }
        }
    }
}