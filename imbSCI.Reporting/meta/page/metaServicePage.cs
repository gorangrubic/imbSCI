namespace imbSCI.Reporting.meta.page
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Core.extensions.enumworks;
    using imbSCI.Core.reporting.format;

    /// <summary>
    /// Service Pages are lateral document outputs used for: readme.md, readme.html, index.html, theme.css, theme.js ...
    /// </summary>
    /// <remarks>
    /// Service pages are one-page-document with stand alone Style 
    /// </remarks>
    /// \ingroup_disabled docCore
    /// \ingroup_disabled docPage
    public abstract class metaServicePage : metaPage, IMetaContentNested, IMetaHasHeader, IMetaServicePage
    {
        
        protected metaServicePage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="metaServicePage"/> 
        /// </summary>
        /// <param name="__description">Mapped to both: description of this page and as extra content of <c>header</c></param>
        /// <param name="__title">Display title that is mapped to <c>header.name</c></param>
        /// <param name="__name">Path-safe name to be set to this page. Leave empty to keep default name</param>
        /// <param name="__priority">The position preference of the page</param>
        protected metaServicePage(string __description = "", string __title = "", string __name = "", int __priority=100)
        {
            priority = __priority;
            name = __name;
            header.title = __title;
            header.description = __description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="metaServicePage"/> 
        /// </summary>
        /// <param name="__description">Mapped to both: description of this page and as extra content of <c>header</c></param>
        /// <param name="__title">Display title that is mapped to <c>header.name</c></param>
        /// <param name="__name">Path-safe name to be set to this page. Leave empty to keep default name</param>
        /// <param name="__position">The position preference of the page</param>
        protected metaServicePage(string __description, string __title, string __name = "", metaServicePagePosition __position=metaServicePagePosition.atBeginning)
        {
            position = __position;
            priority = position.ToInt32();
            header.title = __title;
            header.description = __description;
        }


        /// <summary>
        /// 
        /// </summary>
        public metaServicePagePosition position { get; set; } = metaServicePagePosition.unknown;


        private string _filenameBase;
        /// <summary> </summary>
        public string filenameBase
        {
            get
            {
                return _filenameBase;
            }
            set
            {
                _filenameBase = value;
                OnPropertyChanged("filenameBase");
            }
        }



        #region --- fileformat ------- Service page fileformat - it is used to override render settings 
        private reportOutputFormatName _fileformat = reportOutputFormatName.textMdFile;
        /// <summary>
        /// Service page fileformat - it is used to override render settings
        /// </summary>
        public reportOutputFormatName fileformat
        {
            get
            {
                return _fileformat;
            }
            set
            {
                _fileformat = value;
                OnPropertyChanged("fileformat");
            }
        }
        #endregion

    }
}