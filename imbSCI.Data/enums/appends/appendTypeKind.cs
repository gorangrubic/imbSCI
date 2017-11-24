namespace imbSCI.Data.enums.appends
{
    public enum appendTypeKind
    {
        /// <summary>
        /// The none - not for execution
        /// </summary>
        none,
        /// <summary>
        /// The simple: simple string appends and headings
        /// Without prefix
        /// </summary>
        simple,
        ///// <summary>
        ///// The data: DataTable, Pairs, Lists
        ///// </summary>
        //data,
        ///// <summary>
        ///// The structure: add page, add document, add...
        ///// </summary>
        //structure,
        /// <summary>
        /// The style: generate style, variations... <c>s_</c> prefix
        /// </summary>
        style,
        /// <summary>
        /// Starting with <c>c_</c>
        /// The complex: section, line...
        /// The data: DataTable, Pairs, Lists
        /// </summary>
        complex,


        ///// <summary>
        ///// The file
        ///// </summary>
        //file,


        /// <summary>
        /// starting with <c>i_</c> and <c>x_</c>The special and  The structure: add page, add document, add...
        /// </summary>
        special,



        /// <summary>
        /// The other
        /// </summary>
        other,

    }
}