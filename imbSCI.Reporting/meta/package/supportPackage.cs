namespace imbSCI.Reporting.meta.package
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.page;
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

    public class supportPackage:metaServicePage
    {

        public override docScript compose(docScript script)
        {
            script = this.checkScript(script);

            script.x_directory(directoryOperation.copy, "reportInclude".add(foldername, "\\"), false);


            script.x_scopeIn(this);

            //script.add(appendType.i_page, docScriptArguments.dsa_name, docScriptArguments.dsa_title,docScriptArguments.dsa_description)
            //    .set(name, pageTitle, pageDescription);

            // script.add(appendType.s_settings).arg(docScriptArguments.dsa_stylerSettings, settings);


            

            script = this.subCompose(script);


            script.x_scopeOut(this);
            return script;
        }

        public supportPackage(string reportIncludeFolder, string description):base(description, "Support package : "+reportIncludeFolder, "about_"+reportIncludeFolder, 10)
        {


        }


        private string _foldername;
        /// <summary> </summary>
        protected string foldername
        {
            get
            {
                return _foldername;
            }
            set
            {
                _foldername = value;
                OnPropertyChanged("foldername");
            }
        }


    }
}