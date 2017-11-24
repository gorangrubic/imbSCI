namespace imbSCI.Core.reporting.render.builders
{
    using System.IO;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render.converters;
    using imbSCI.Core.reporting.render.core;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Builder for text output
    /// </summary>
    /// <seealso cref="imbStringBuilderBase" />
    /// <seealso cref="ITextRender" />
    public class builderForText : imbStringBuilderBase, ITextRender
    {
        public override converterBase converter
        {
            get
            {
                if (_converter == null) _converter = new converterForBootstrap3();
                return _converter;
            }
        }
        public builderForText():base()
        {
            prepareBuilder();
        }



        public override void prepareBuilder()
        {
            base.prepareBuilder();
            //settings 
            settings.api = reportAPI.textBuilder;
            settings.cursorBehaviour.cursorMode = textCursorMode.scroll;

            formats = reportOutputSupport.getFormatSupportFor(reportAPI.EEPlus, "table");

            formats.defaultFormat = reportOutputFormatName.textFile;
        }

        public FileInfo savePage(string name, reportOutputFormatName format = reportOutputFormatName.none)
        {
            return saveDocument(name, getWritableFileMode.autoRenameExistingOnOtherDate, format);
        }

        public object addDocument(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameExistingOnOtherDate, reportOutputFormatName format = reportOutputFormatName.none)
        {
            return saveDocument(name, mode, format);
        }

        public object addPage(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameThis, reportOutputFormatName format = reportOutputFormatName.none)
        {
            return saveDocument(name, mode, format);
        }

        public override void AppendImage(string imageSrc, string imageAltText, string imageRef)
        {
            
        }

        public override void AppendMath(string mathFormula, string mathFormat = "asciimath")
        {
            Append(mathFormula, appendType.bypass);
        }

        public override void AppendLabel(string content, bool isBreakLine = true, object comp_style = null)
        {
            Append(content, appendType.bypass);
        }

        public override void AppendPanel(string content, string comp_heading = "", string comp_description = "", object comp_style = null)
        {
            AppendLine(comp_heading);
            AppendLine(content);
            AppendLine(comp_description);
        }

        public void AppendLine()
        {
            throw new System.NotImplementedException();
        }
    }

}