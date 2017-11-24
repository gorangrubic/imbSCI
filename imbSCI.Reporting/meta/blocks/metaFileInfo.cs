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

    public class metaFileInfo: MetaContainerNestedBase
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


            script.c_line();
            script.AppendLine("File: {{{path_file}}}");
            script.AppendLine("Path: {{{path_output}}}");
            script.AppendLine("Format: {{{path_format}}}");
            script.AppendLine("Created: {{{sys_time}}} {{{sys_date}}}");

            if (!description.isNullOrEmpty())
            {
                script.AppendLine("Description:");
                script.AppendLine(description);
            }

            script.c_line();
            script.AppendLine("For parent: {{{parent_type}}}");
            script.AppendLine("Parent path: {{{parent_dir}}}");
            script.AppendLine("Runstamp: {{{test_runstamp}}}");
            script.c_line();

            // script.add(appendType.c_section, docScriptArguments.dsa_name, docScriptArguments.dsa_content, docScriptArguments.dsa_description, docScriptArguments.dsa_class_attribute, docScriptArguments.dsa_id_attribute).set(name, content, description, "header", "#" + name);

            //script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);

            script.x_scopeOut(this);
            return script;
        }


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


        public metaFileInfo()
        {
            name = "fileinfo";
            
            description = "";
        }




     

    }

}