namespace imbSCI.Core.reporting.render.builders
{
    using System;
    using System.IO;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render.converters;
    using imbSCI.Core.reporting.render.core;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.reporting;

    public class builderForHtml : imbStringBuilderBase, ITextRender
    {
        public override converterBase converter
        {
            get
            {
                if (_converter == null) _converter = new converterForBootstrap3();
                return _converter;
            }
        }

        public override void prepareBuilder()
        {
            base.prepareBuilder();
            formats = reportOutputSupport.getFormatSupportFor(reportAPI.textBuilder, "index");
            formats.defaultFormat = reportOutputFormatName.textHtml;
            settings.api = reportAPI.textBuilder;
            settings.cursorBehaviour.cursorMode = textCursorMode.scroll;
        }

        /// <summary>
        /// HTML/XML adds <c>q</c> tag, Table aplies <c>smallText</c> style
        /// </summary>
        /// <param name="content">Text content of the quote</param>
        /// <param name="codetypename"></param>
        /// <returns>
        /// OuterXML/String or proper DOM object of container
        /// </returns>
        /// \ingroup_disabled renderapi_append
        public override object AppendCode(String content, String codetypename)
        {
            open(htmlTagName.pre);
            _AppendLine(content);
            close();

            //Append(content, appendType.source, true);
            
            return "";
        }

        public FileInfo savePage(string name, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object addDocument(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameExistingOnOtherDate, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object addPage(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameThis, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public override void AppendImage(string imageSrc, string imageAltText, string imageRef)
        {
            throw new NotImplementedException();
        }

        public override void AppendMath(string mathFormula, string mathFormat = "asciimath")
        {
            throw new NotImplementedException();
        }

        public override void AppendLabel(string content, bool isBreakLine = true, object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public override void AppendPanel(string content, string comp_heading = "", string comp_description = "", object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public void AppendLine()
        {
            throw new NotImplementedException();
        }
    }

}