namespace imbSCI.Core.reporting.template
{
    using imbSCI.Data;
    #region imbVeles using

    using System;
    using System.Data;

    #endregion

    /// <summary>
    /// Klasa koja opisuje jedan template
    /// </summary>
    /// \ingroup_disabled report_ll_templates
    public class stringTemplate : stringTemplateDeclaration
    {



        /// <summary>
        /// Applies data from a property collection to its content
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="mContent">Content of the m.</param>
        /// <returns></returns>
        public string applyToContent(PropertyCollection source, String mContent=null)
        {
            if (imbSciStringExtensions.isNullOrEmptyString(mContent)) mContent = template;

             return placeholders.applyToContent(source, mContent);
        }


        /// <summary>
        /// Applies to content.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="mContent">Content of the m.</param>
        /// <returns></returns>
        public string applyToContent(DataTable dt, String mContent = null)
        {
            if (imbSciStringExtensions.isNullOrEmptyString(mContent)) mContent = template;
            return placeholders.applyToContent(dt, template);
        }

        /// <summary>
        /// Removes from content.
        /// </summary>
        /// <param name="mContent">Content of the m.</param>
        /// <returns></returns>
        public string removeFromContent(String mContent = null)
        {
            if (imbSciStringExtensions.isNullOrEmptyString(mContent)) mContent = template;
            return placeholders.removeFromContent(template);
        }

        /// <summary>
        /// Loads the template string.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <returns></returns>
        public int loadTemplateString(string formatString)
        {
            template = formatString;
            return placeholders.loadTemplateString(formatString);
        }

        /// <summary>
        /// Constructor that runs the template code evaluation instantly
        /// </summary>
        /// <param name="templateCode"></param>
        public stringTemplate(string templateCode)
        {
            template = templateCode;
            placeholders.loadTemplateString(template);

        }
       


        #region --- placeholders ------- kolekcija parametara / plejs holdera 
        private reportTemplatePlaceholderCollection _placeholders = new reportTemplatePlaceholderCollection();
        /// <summary>
        /// kolekcija parametara / plejs holdera
        /// </summary>
        public reportTemplatePlaceholderCollection placeholders
        {
            get
            {
                return _placeholders;
            }
            set
            {
                _placeholders = value;
                OnPropertyChanged("placeholders");
            }
        }
        #endregion

    }

}