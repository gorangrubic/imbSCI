namespace imbSCI.Data.enums.fields
{
    /// <summary>
    /// Template field names - Web Page profiling report
    /// </summary>
    public enum templateFieldWebPageReport
    {
        /// <summary>
        /// Summary textt on webRequest
        /// </summary>
        code_webRequest,
        /// <summary>
        /// Loaded source HTML
        /// </summary>
        code_sourceHTML,
        /// <summary>
        /// Extracted text of source
        /// </summary>
        code_sourceTEXT,
        /// <summary>
        /// Extracted markdown text of source
        /// </summary>
        code_sourceMarkdown,
        /// <summary>
        /// Normalized HTML source code - after loading 
        /// </summary>
        code_sourceHTML_norm,

        /// <summary>
        /// Web structure metrics
        /// </summary>
        web_structureMetrics,

        /// <summary>
        /// XML structure tree
        /// </summary>
        web_pageStructureTree,

        /// <summary>
        /// Optimised page structure tree
        /// </summary>
        web_pageStructureTreeOpt,

        /// <summary>
        /// Extracted template tree
        /// </summary>
        web_pageTemplateTree,

        /// <summary>
        /// Extracted template text
        /// </summary>
        web_pageTemplateTextContent,

        /// <summary>
        /// XML output of tokenized page structure
        /// </summary>
        web_pageStructureTokenized,
        /// <summary>
        /// Report on directly extracted information about company
        /// </summary>
        web_pageDirectExtraction,
        /// <summary>
        /// Report on semanticaly extracted information
        /// </summary>
        web_pageSemanticExtraction,

        /// <summary>
        /// Export of extracted knowledge
        /// </summary>
        csp_extractedKnowledge,
        /// <summary>
        /// ... after loading NBS data
        /// </summary>
        csp_enrichNBS,
        /// <summary>
        /// ... after processing APR data
        /// </summary>
        csp_enrichAPR,
        /// <summary>
        /// ... after processing CRM data
        /// </summary>
        csp_enrichCRM,

        /// <summary>
        /// RDF of Company Semantic Profile
        /// </summary>
        csp_complete,

        /// <summary>
        /// Current main imbVeles log content
        /// </summary>
        log_systemLog,

        /// <summary>
        /// Log of parent workflow
        /// </summary>
        log_workflowLog,


        /// <summary>
        /// Izveštaj o izboru unutrašnjih linkva za analizu templejta
        /// </summary>
        web_linkSelection,
        /// <summary>
        /// Izvestaj o detektovanom templejtu
        /// </summary>
        web_template,

        /// <summary>
        /// Report on web type classification 
        /// </summary>
        web_classification,

        /// <summary>
        /// Report on key pages detection
        /// </summary>
        web_keypages,



    }
}