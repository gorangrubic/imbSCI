

namespace imbReportingCore.meta.render
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using aceCommonTypes.extensions;
    using aceCommonTypes.core;
    using aceCommonTypes.reporting;
    using aceCommonTypes.reporting.render;
    using render;





    /// <summary>
    /// Static tool box with many rendering units
    /// </summary>
    /// \ingroup report_cm_comp
    public static class metaComposerTools
    {

        

        private static metaComposer<renderHTML> _html = new metaComposer<renderHTML>();
        /// <summary>
        ///
        /// </summary>
        public static metaComposer<renderHTML> html
        {
            get
            {
                return _html;
            }
            set
            {
                _html = value;
            }
        }


        private static metaComposer<renderFlowDocument> _flow = new metaComposer<renderFlowDocument>();
        /// <summary>
        ///
        /// </summary>
        public static metaComposer<renderFlowDocument> flow
        {
            get
            {
                return _flow;
            }
            set
            {
                _flow = value;
            }
        }



        private static metaComposer<renderTableDocument> _table = new metaComposer<renderTableDocument>();
        /// <summary>
        ///
        /// </summary>
        public static metaComposer<renderTableDocument> table
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }


        #region --- markdown ------- meta objects rendering engine for Markdown format
        private static metaComposer<renderMarkdown> _markdown = new metaComposer<renderMarkdown>();
        /// <summary>
        /// meta objects rendering engine for Markdown format
        /// </summary>
        public static metaComposer<renderMarkdown> markdown
        {
            get
            {
                return _markdown;
            }
        }
        #endregion




        #region --- text ------- clean text renderer for meta structure
        private static metaComposer<renderText> _text = new metaComposer<renderText>();
        /// <summary>
        ///  clean text renderer for meta structure
        /// </summary>
        public static metaComposer<renderText> text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        #endregion


    }
}