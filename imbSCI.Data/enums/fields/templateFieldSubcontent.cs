namespace imbSCI.Data.enums.fields
{

 

    /// <summary>
    /// HTML blocks 
    /// </summary>
    public enum templateFieldSubcontent
    {

        ///// <summary>
        ///// The none - points to nothing
        ///// </summary>
        //none,

        /// <summary>
        /// The main StringBuilder or content
        /// </summary>
        main,


        /// <summary>
        /// The start of file - the very first lines of the content
        /// </summary>
        startOfFile,

        /// <summary>
        /// The end of file - the very last lines of the content
        /// </summary>
        endOfFile,



        /// <summary>
        /// Page keywords
        /// </summary>
        meta_keywords,
        /// <summary>
        /// Page description
        /// </summary>
        meta_description,

        /// <summary>
        /// Place for heading style links
        /// </summary>
        theme_styles,

        /// <summary>
        /// The theme code headlinks - code links to be included at beginning
        /// </summary>
        theme_code_headlinks,

        /// <summary>
        /// The theme code footlinks - code links to be included at end
        /// </summary>
        theme_code_footlinks,


        /// <summary>
        /// JS (or other) code to include around end or at end of the template
        /// </summary>
        theme_code_ending,






        /// <summary>
        /// Title for HTML title
        /// </summary>
        html_title,
        /// <summary>
        /// Top navigation
        /// </summary>
        html_topnav,

        html_toolbar,
        /// <summary>
        /// Main navigation
        /// </summary>
        html_mainnav,
        /// <summary>
        /// Header content
        /// </summary>
        html_header,
        /// <summary>
        /// Footer content
        /// </summary>
        html_footer,
        /// <summary>
        /// Debug information
        /// </summary>
        html_debug,
        /// <summary>
        /// Main content of the page
        /// </summary>
        html_page_content,

        /// <summary>
        /// Java script to be inserted at end of page
        /// </summary>
        html_js,
       // html_headtag,
        head_includes,
        bottom_includes,
        none,
    }
}