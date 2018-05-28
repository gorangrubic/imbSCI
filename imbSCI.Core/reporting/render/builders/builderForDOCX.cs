using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.reporting.render.builders
{
    using System.Collections;
    using System.Data;
    using System.IO;
    using Xceed.Words.NET;

    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render.config;
    using imbSCI.Core.reporting.render.converters;
    using imbSCI.Core.reporting.render.core;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.appends;
    using imbSCI.Data.enums.fields;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data;
    using System.Xml;

    public class builderForDOCX : ITextRender
    {
        public builderForDOCX()
        {
            textDocument = DocX.Create("Untitled.docx", DocumentTypes.Document);
        }

        public DocX textDocument { get; set; }

        public XmlNode Add(XmlNode content)
        {
            //textDocument.Content.Add(content);
            //lastContent = content;
            return content;
        }

        public XmlNode lastContent { get; set; }


        public converterBase converter => throw new NotImplementedException();

        public long lastLength => throw new NotImplementedException();

        public long Length => throw new NotImplementedException();

        public IList content => throw new NotImplementedException();

        public cursor c => throw new NotImplementedException();

        public cursorZone zone => throw new NotImplementedException();

        public builderSettings settings => throw new NotImplementedException();

        public string linePrefix { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DirectoryInfo directoryScope { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string tabInsert => throw new NotImplementedException();

        public int tabLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object addDocument(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameExistingOnOtherDate, reportOutputFormatName format = reportOutputFormatName.none)
        {
            textDocument = DocX.Create(name.ensureEndsWith(".docx"), DocumentTypes.Document);
            return textDocument;
        }

        public object addPage(string name, bool scopeToNew = true, getWritableFileMode mode = getWritableFileMode.autoRenameThis, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public void Append(string content, appendType type = appendType.none, bool breakLine = false)
        {
            throw new NotImplementedException();
        }

        public object AppendCite(string content)
        {
            throw new NotImplementedException();
        }

        public object AppendCode(string content)
        {
            throw new NotImplementedException();
        }

        public object AppendCode(string content, string codetypename)
        {
            throw new NotImplementedException();
        }

        public object AppendComment(string content)
        {
            throw new NotImplementedException();
        }

        public void AppendDirect(string content)
        {
            throw new NotImplementedException();
        }

        public void AppendFile(string sourcepath, string outputpath, bool isDataTemplate = false)
        {
            throw new NotImplementedException();
        }

        public object AppendFrame(string content, int width, int height, string title = "", string footnote = "", IEnumerable<string> paragraphs = null)
        {
            throw new NotImplementedException();
        }

        public void AppendFromFile(string sourcepath, templateFieldSubcontent datakey = templateFieldSubcontent.none, bool isLocalSource = false)
        {
            throw new NotImplementedException();
        }

        public object AppendFunction(string functionCode, bool breakLine = false)
        {
            throw new NotImplementedException();
        }

        public object AppendHeading(string content, int level = 1)
        {
            return null;
        }

        public void AppendHorizontalLine()
        {
            throw new NotImplementedException();
        }

        public void AppendImage(string imageSrc, string imageAltText, string imageRef)
        {
            throw new NotImplementedException();
        }

        public void AppendLabel(string content, bool isBreakLine = true, object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public void AppendLine()
        {
            throw new NotImplementedException();
        }

        public void AppendLine(string content)
        {
            Paragraph p = textDocument.InsertParagraph(content);
        }

        public void AppendLink(string url, string name, string caption = "", appendLinkType linkType = appendLinkType.link)
        {
            throw new NotImplementedException();
        }

        public void AppendList(IEnumerable<object> content, bool isOrderedList = false)
        {
            throw new NotImplementedException();
        }

        public void AppendMath(string mathFormula, string mathFormat = "asciimath")
        {
            throw new NotImplementedException();
        }

        public void AppendPair(string key, object value, bool breakLine = true, string between = " = ")
        {
            throw new NotImplementedException();
        }

        public object AppendPairs(PropertyCollection data, bool isHorizontal = false, string between = "")
        {
            throw new NotImplementedException();
        }

        public void AppendPanel(string content, string comp_heading = "", string comp_description = "", object comp_style = null)
        {
            throw new NotImplementedException();
        }

        public object AppendParagraph(string content, bool fullWidth = false)
        {
            throw new NotImplementedException();
        }

        public void AppendPlaceholder(object fieldName, bool breakLine = false)
        {
            throw new NotImplementedException();
        }

        public object AppendQuote(string content)
        {
            throw new NotImplementedException();
        }

        public object AppendSection(string content, string title, string footnote = null, IEnumerable<string> paragraphs = null)
        {
            throw new NotImplementedException();
        }

        public void AppendTable(DataTable table, bool doThrowException = true)
        {
            throw new NotImplementedException();
        }

        public void AppendToFile(string outputpath, string content)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public tagBlock close(string tag = "none")
        {
            throw new NotImplementedException();
        }

        public void closeAll()
        {
            throw new NotImplementedException();
        }

        public void consoleAltColorToggle(bool setExact = false, int altChange = -1)
        {
            throw new NotImplementedException();
        }

        public string ContentToString(bool doFlush = false, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public string GetContent(long fromLength = long.MinValue, long toLength = long.MinValue)
        {
            throw new NotImplementedException();
        }

        public PropertyCollection getContentBlocks(bool includeMain, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object getDocument()
        {
            throw new NotImplementedException();
        }

        public string getLastLine(bool removeIt = false)
        {
            throw new NotImplementedException();
        }

        public FileInfo loadDocument(string filepath, string name = "", reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public object loadPage(string filepath, string name = "", reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public void nextTabLevel()
        {
            throw new NotImplementedException();
        }

        public tagBlock open(string tag, string title = "", string description = "")
        {
            throw new NotImplementedException();
        }

        public void prevTabLevel()
        {
            throw new NotImplementedException();
        }

        public void rootTabLevel()
        {
            throw new NotImplementedException();
        }

        public void saveDocument(FileInfo fi)
        {
            throw new NotImplementedException();
        }

        public FileInfo saveDocument(string name, getWritableFileMode mode, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public FileInfo savePage(string name, reportOutputFormatName format = reportOutputFormatName.none)
        {
            throw new NotImplementedException();
        }

        public string SubcontentClose()
        {
            throw new NotImplementedException();
        }

        public void SubcontentStart(templateFieldSubcontent key, bool cleanPriorContent = false)
        {
            throw new NotImplementedException();
        }
    }

}