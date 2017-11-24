namespace imbSCI.Data.enums.reporting
{
    /// <summary>
    /// Tip prikljucenog fajla
    /// </summary>
    public enum reportIncludeFileType
    {
        unknown,

        /// <summary>
        /// U pitanju je cssStyle link
        /// </summary>
        cssStyle,

        /// <summary>
        /// spoljni js fajl koji se kopira i poziva
        /// </summary>
        javaScriptFileSource,

        /// <summary>
        /// spoljni js koji se poziva kao link iz meta dela
        /// </summary>
        javaScriptLinkedSource,

        /// <summary>
        /// Koristi se staticni fajl, nista se ne priprema
        /// </summary>
        emailAttachmentStatic,

        /// <summary>
        /// Koristi se stalno isti fajl ali se vrsi rename prema sablonu
        /// </summary>
        emailAttachmentDynamicFileName,

        /// <summary>
        /// Fajlovi koji se salju su u jednom folderu odakle se preuzimaju, preimenuju prema sablonu i salju uz email
        /// </summary>
        emailAttachmentDynamicFileSource,

        /// <summary>
        /// Fajl koji se salje se generise "u letu" 
        /// </summary>
        emailAttachmentGeneratedFile,
    }
}