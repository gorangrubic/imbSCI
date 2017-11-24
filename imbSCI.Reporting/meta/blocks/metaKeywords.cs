namespace imbSCI.Reporting.meta.blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    using imbSCI.Core.reporting.colors;
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// container for keywords describing this document
    /// </summary>
    /// \ingroup_disabled docBlocks_common
    public class metaKeywords : MetaContainerNestedBase

    {

        public override void construct(object[] resources)
        {
            colors = acePaletteRole.colorA;
            width = blockWidth.full;

        }

        public override docScript compose(docScript script)
        {
            if (script == null) script = new docScript(name);
            script.x_scopeIn(this);

            script.add(appendType.s_palette).arg(colors);

            script.list("Keywords", "", content, 2, true);

            script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);

            script.x_scopeOut(this);
            return script;
        }


        //public string makeText(imbStringBuilder sb = null)
        //{
        //    if (sb == null) sb = new imbStringBuilder();

        //    sb.AppendLine("---");
        //    sb.AppendLine("Keywords");
        //    sb.AppendLine("---");
        //    string kw = "";
        //    content.ForEach(x => kw.Append(x, ";"));
        //    sb.AppendLine(kw);
        //    sb.AppendLine("---");
        //    //sb.prevTabLevel();



        //   // sb.rootTabLevel();

        //    return sb.ToString();
        //}

        //public reportXmlDocument makeXml(reportXmlDocument xmlReport = null)
        //{
        //    if (xmlReport == null) xmlReport = new reportXmlDocument();
        //    return xmlReport;
        //}

        //public reportHtmlDocument makeHtml(reportHtmlDocument htmlReport = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public metaKeywords(params string[] words)
        //{
        //    content.AddRange(words);
        //}

        //public string makeTextTemplate(imbStringBuilder sb = null)
        //{
        //    sb.AppendLine("---");
        //    sb.AppendLine("Keywords");
        //    sb.AppendLine("---");
        //    sb.AppendLine("{{{keywords_content}}}");
        //    //String kw = "";
        //    //content.ForEach(x => kw.Append(x, ";"));
        //    //sb.AppendLine(kw);
        //    sb.AppendLine("---");
        //    //sb.prevTabLevel();
        //    return sb.ToString();
        //}
    }
}