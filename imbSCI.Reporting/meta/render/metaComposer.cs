namespace imbReportingCore.meta.render
{
    using System;
    using System.Linq;
    using aceCommonTypes.primitives;
    using aceCommonTypes.reporting.enums;
    using aceCommonTypes.reporting.render;
    using aceCommonTypes.reporting.style;
    using aceCommonTypes.reporting.style.core;
    using blocks;
    using imbReportingCore.interfaces;
    using imbReportingCore.meta.collection;
    using imbReportingCore.meta.domain;



    /// <summary>
    /// ZA OTPIS Composer provides universal content delivery for metaContentBase elements applied on particular <c>render</c> unit
    /// </summary>
    /// \ingroup report_cm_comp
    public sealed class metaComposer<T>:imbBindable, IMetaComposer where T:ITextRender, new()
    {

        public void setActiveContext(composerContext __context)
        {

            if (context != null)
            {
                context.AppendLine("active context closing...");
            } else
            {

            }

            context = __context;

            if (context == null)
            {
                context.AppendLine("New context attached...");
            }
            else
            {
                context.AppendLine("Context attached...");
            }


        }

        #region --- context ------- active context 
        private composerContext _context;
        /// <summary>
        /// active context
        /// </summary>
        protected composerContext context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
                OnPropertyChanged("context");
            }
        }
        #endregion



        public Object AddPage(String __name)
        {
            if (dR != null)
            {
                return dR.AddPage(__name);
            }
            return null;
        }

        /// <summary>
        /// Appends content in internal repository
        /// </summary>
        /// <param name="input"></param>
        public void AppendContent(IMetaContent input, styleTheme theme=null)
        {
            

            if (input is metaDataTable) { Append((metaDataTable)input); return; }
            if (input is metaCodeBlock) { Append((metaCodeBlock)input); return; }
            if (input is metaFooter) { Append((metaFooter)input); return; }
            if (input is metaHeader) { Append((metaHeader)input); return; }
            if (input is metaNotation) { Append((metaNotation)input); return; }
            if (input is metaKeywords) { Append((metaKeywords)input); return; }
            if (input is metaLinkCollection) { Append((metaLinkCollection)input); return; }
        }

        



        #region --- sb ------- text rendering instance 
        private T _sb = new T();
        /// <summary>
        /// text rendering instance
        /// </summary>
        private T sb
        {
            get
            {
                return _sb;
            }
            set
            {
                _sb = value;
            }
        }

        public ITextRender tR
        {
            get
            {
                return sb as ITextRender;
            }
        }

        public IDocumentRender dR
        {
            get
            {
                return sb as IDocumentRender;
            }
        }
        #endregion

        /// <summary>
        /// Determines whether the specified source has content.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if the specified source has content; otherwise, <c>false</c>.
        /// </returns>
        private Boolean hasContent(IMetaContent source)
        {
            return source.content.Any();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T getBuilder()
        {
            return sb;
        }

        /// <summary>
        /// Returns complete content in string format
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return sb.ToString();
        }


        /// <summary>
        /// It appents internal string array content using proper appendType
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="newLine"></param>
        private void AppendContent(IMetaContent source, appendType type, Boolean newLine = true)
        {
            foreach (String ci in source.content)
            {
                sb.Append(ci, type, newLine);
            }
        }


        internal void Append(metaLinkCollection source)
        {

            sb.Append(source.name, appendType.heading_2, true);
            sb.AppendHorizontalLine();
            foreach(metaLink link in source)
            {
                sb.AppendLink(link.url, link.name, link.description, link.type);
            }
            sb.AppendHorizontalLine();
            sb.Append(source.description, appendType.blockquote, true);
        }




        internal void Append(metaCodeBlock source)
        {
            sb.AppendHorizontalLine();
            sb.Append(source.name, appendType.heading_2, true);

            AppendContent(source, appendType.source, true);

            sb.Append(source.description, appendType.italic, true);

            sb.AppendHorizontalLine();
        }
        internal void Append(metaDataTable source)
        {
            sb.Append(source.name, appendType.heading_1, true);
            sb.AppendTable(source.table);
            sb.Append(source.description, appendType.blockquote, true);

            if (hasContent(source)) sb.AppendHorizontalLine();
            AppendContent(source);
            if (hasContent(source)) sb.AppendHorizontalLine();
        }




        internal void Append(metaHeader source)
        {
            sb.Append(source.name, appendType.heading, true);
            sb.Append(source.description, appendType.blockquote, true);
            if (hasContent(source)) sb.AppendHorizontalLine();
            AppendContent(source);
            if (hasContent(source)) sb.AppendHorizontalLine();
        }
        internal void Append(metaFooter source)
        {
            sb.AppendHorizontalLine();
            sb.Append(source.bottomLine, appendType.heading_2, true);
            AppendContent(source, appendType.blockquote);

        }

        internal void Append(metaKeywords source)
        {
            if (hasContent(source)) sb.Append("Keywords", appendType.bold);
            AppendContent(source, appendType.marked, false);
        }

        internal void Append(metaNotation source)
        {
            sb.AppendHorizontalLine();
            sb.AppendPair("Project", source.name, true, ": ");
            sb.Append(source.description, appendType.italic, true);
            sb.AppendPair("Author", source.author, true, ": ");
            sb.AppendPair("Organization", source.organization, true, ": ");
            sb.AppendLink(source.url, "Project's web page", "");
            sb.AppendPair("Software", source.softwareName, true, ": ");

            if (hasContent(source)) sb.Append("Remarks", appendType.bold);
            AppendContent(source, appendType.blockquote);

            sb.AppendPair("Copyright", source.copyright, true, ": ");
            sb.AppendHorizontalLine();
        } 
    }
}