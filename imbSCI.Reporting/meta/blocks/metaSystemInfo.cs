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
    using imbSCI.Data.enums.fields;

    public class metaSystemInfo : MetaContainerNestedBase
    {
        //public override IMetaContentNested SearchForChild(string needle)
        //{
        //    needle = CleanNeedle(needle);
        //    if (this.name == needle) return this;
        //    return null;
        //}


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


            script.heading("System status", 3, false);
            
            script.AppendPair("Memory allocated", templateFieldBasic.sys_mem, ": ", true);
            script.AppendPair("Free Physical memory", templateFieldBasic.sys_memphysical, ": ", true);
            script.AppendPair("Free Virtual memory", templateFieldBasic.sys_memvirtual, ": ", true);
            script.AppendPair("Free space in paging file", templateFieldBasic.sys_pagefile, ": ", true);
            script.AppendPair("Threads", templateFieldBasic.sys_threads, ": ", true);
            script.AppendPair("Start time", templateFieldBasic.sys_start, ": ", true);
            script.AppendPair("Time since start", templateFieldBasic.sys_runtime, ": ", true);
            script.AppendPair("Start path", templateFieldBasic.sys_path, ": ", true);
            script.AppendPair("OS name", templateFieldBasic.sys_osname, ": ", true);
            script.AppendPair("OS version", templateFieldBasic.sys_osversion, ": ", true);
            script.AppendPair("Bits", templateFieldBasic.sys_cputype, ": ", true);
            

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


        public metaSystemInfo()
        {
            name = "systeminfo";

            description = "";
        }


    }

}