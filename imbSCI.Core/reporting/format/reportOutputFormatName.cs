namespace imbSCI.Core.reporting.format
{

    /// <summary>
    /// Format u kome se generise izvestaj
    /// </summary>
    public enum reportOutputFormatName
    {
        

        /// <summary>
        /// koristi obican text format
        /// </summary>
        textFile,

        textMdFile,

        /// <summary>
        /// log file
        /// </summary>
        textLog,

        textHtml,
        textXml,

        /// <summary>
        /// The ser XML - object serialization result
        /// </summary>
        serXml,

        htmlViaMD,
        /// <summary>
        /// The sheet excel - single file, xlsx
        /// </summary>
        sheetExcel,
        /// <summary>
        /// The sheet CSV - collection of - if worksheet containes more than one worksheet
        /// </summary>
        sheetCsv,
        
        sheetHtml,
        sheetPDF,
        /// <summary>
        /// The sheet XML - workbook xml
        /// </summary>
        sheetXML,

        docRTF,
        docHTML,
        docPDF,

        docJPG,
        docTIFF,
        docPNG,

        rdf,

        owl,


        json,

        /// <summary>
        /// Koristi HTML format i default browser 
        /// </summary>
        htmlReport,


        /// <summary>
        /// Text file describing a folder
        /// </summary>
        folderReadme,
        xml,

        /// <summary>
        /// obican text za email
        /// </summary>
        emailPlainText,

        /// <summary>
        /// HTML format za email
        /// </summary>
        emailHTML,

        Excel,
        Calc,
        csv,


        none,
        markdown,
        textCss,
        docXAML,
        unknown,
        Word,
        Writter,
    }

}