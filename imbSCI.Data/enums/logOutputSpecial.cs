namespace imbSCI.Data.enums
{

    /// <summary>
    /// Willmarks for special log output source
    /// </summary>
    public enum logOutputSpecial
    {
        none,

        reportContext,

        aceServices,

        systemMainLog,

        initialLog,

        /// <summary>
        /// Development notes
        /// </summary>
        devNotes,



        /// <summary>
        /// The semantic engine log
        /// </summary>
        semanticEngine,

        /// <summary>
        /// The analytic engine log
        /// </summary>
        analyticEngine,


        /// <summary>
        /// The language engine log. 
        /// </summary>
        languageEngine,


        /// <summary>
        /// The ace subsistem log
        /// </summary>
        aceSubsystem,

        cacheSystem,
        imbSqlEntityCollection,
    }

}