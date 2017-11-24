namespace imbSCI.Core.reporting.format
{
    
    using imbSCI.Core.reporting.render.builders;

    /// <summary>
    /// Reporting API enumeration
    /// </summary>
    public enum reportAPI
    {
        /// <summary>
        /// The imb reporting - API for <see cref="imbSCI.Core.Builders.render.builders.builderForFlowDocument"/>  
        /// </summary>
        imbReporting,

        /// <summary>
        /// The text builder - API for <see cref="builderForText"/>, <see cref="imbACE.Core.core.builderForLog"/>, 
        /// <see cref="builderForMarkdown"/>, <see cref="builderForHtml"/>
        /// </summary>
        textBuilder,

        /// <summary>
        /// <see cref="imbSCI.Core.Builders.render.builders.builderForTableDocument"/>
        /// </summary>
        EEPlus,
        imbXmlHtml,
        imbMarkdown,
        imbFlowDocument,
        imbSerialization,
        imbDiagnostics,
    }
}