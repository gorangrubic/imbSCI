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

    /// <summary>
    /// Meta descriptive information container for HEADER 
    /// </summary>
    /// \ingroup_disabled docBlocks_common
    public class metaHeader:MetaContainerNestedBase
    {
        /// <summary>
        /// Performs construction (or upgrade) of DOM with: 
        /// </summary>
        /// <param name="resources"></param>
        /// <remarks>
        /// <para>This method is meant to be called just after constructor and before <c>compose</c> or other application method. </para>
        /// <para>It is not automatically called by constructor for easier prerequirements handling. </para>
        /// <para>Inside the method it is safe to access <c>parent</c>, <c>page</c>, <c>document</c> or any other automatic property.</para>
        /// <para>This method is meant to be called just once: it should remove any existing dynamically created nodes at beginning of execution - in purpose that any subsequent call produces the same result</para>
        /// </remarks>
        public override void construct(object[] resources)
        {
            colors = acePaletteRole.colorB;
            width = blockWidth.full;

        }

        public override docScript compose(docScript script)
        {
            if (script == null) script = new docScript(name);
            script.x_scopeIn(this);


            //script.open("header", title, description);

            //foreach (String cont in content)
            //{
            //    script.AppendLine(cont);
            //}
            //script.close();
          //  script.add(appendType.s_palette).arg(colors);

            script.section(title, description, content);

           // script.add(appendType.c_section, docScriptArguments.dsa_name, docScriptArguments.dsa_content, docScriptArguments.dsa_description, docScriptArguments.dsa_class_attribute, docScriptArguments.dsa_id_attribute).set(name, content, description, "header", "#" + name);

            //script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);

            script.x_scopeOut(this);
            return script;
        }




        #region --- title ------- Title in document header 
        private string _title = "";
        /// <summary>
        /// Title in document header
        /// </summary>
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }
        #endregion



        private string _description = "";
              
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                // Boolean chg = (_description != value);
                _description = value;
                OnPropertyChanged("description");
                // if (chg) {}
            }
        }


        public metaHeader()
        {
            name = "Untitled";
            title = "Header title";
            description = "";
        }




        /// <summary>
        /// Main constructor for header
        /// </summary>
        /// <param name="__title">Title of the document</param>
        /// <param name="__description">Description line</param>
        /// <param name="inputs">Extra content lines -- shown under description</param>
        public metaHeader(string __title, string __description,  params string[] inputs)
        {
            name = __title.imbCodeNameOperation();
            title = __title;
            description = __description;
            content.AddRange(inputs);
        }


        /*
        public string makeTextTemplate(imbStringBuilder sb = null)
        {
            if (sb == null) sb = new imbStringBuilder();

            sb.AppendLine("---");
            sb.AppendLine("{{{header_title}}}");
            sb.AppendLine("{{{header_description}}}");
            sb.AppendLine("---");
            sb.nextTabLevel();
            sb.AppendLine("---");
            content.ForEach(x => sb.AppendLine(x));
            sb.AppendCreationTime(true, "Template creation: ");
            sb.AppendLine("---");

            sb.AppendLine();
            sb.prevTabLevel();

            

            //sb.rootTabLevel();

            return sb.ToString();
        }

        public string makeText(imbStringBuilder sb = null)
        {
            if (sb == null) sb = new imbStringBuilder();

            sb.AppendLine("---");
            sb.AppendLine(name);
            sb.AppendLine(description);
            sb.AppendLine("---");
            sb.nextTabLevel();
            sb.AppendLine("---");
            content.ForEach(x => sb.AppendLine(x));
            sb.AppendCreationTime(true, "Template creation: ");
            sb.AppendLine("---");

            sb.AppendLine();
            sb.prevTabLevel();

            content.ForEach(x => sb.AppendLine(x));

            //sb.rootTabLevel();
            
            return sb.ToString();
        }

        public reportXmlDocument makeXml(reportXmlDocument xmlReport = null)
        {
            if (xmlReport == null) xmlReport = new reportXmlDocument();
            return xmlReport;
        }

        public reportHtmlDocument makeHtml(reportHtmlDocument htmlReport = null)
        {
            throw new NotImplementedException();
        }
        */


    }
}
