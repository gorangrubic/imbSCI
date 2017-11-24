namespace imbSCI.Reporting.meta.blocks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    /// wrapper koji prikazuje content
    /// </summary>
    /// \ingroup_disabled docBlocks_common
    public class metaCodeBlock : MetaContainerNestedBase
    {



        public override docScript compose(docScript script)
        {
            if (script == null) script = new docScript(name);
            script.x_scopeIn(this);

            //script.open("code", title, desc);
            
            //script.add(appendType.s_palette).arg(colors);

            script.code(title, description, content, codetypename);

          //  script.add(appendType.c_section, docScriptArguments.dsa_name, docScriptArguments.dsa_content, docScriptArguments.dsa_description, docScriptArguments.dsa_class_attribute, docScriptArguments.dsa_id_attribute).set(name, content, description, "codeblock", "#"+name);
           
           // script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);
            
            script.x_scopeOut(this);
            return script;

        }

        public override void construct(object[] resources)
        {
            colors = acePaletteRole.colorC;
            width = blockWidth.full;

        }


        /// <summary>
        /// 
        /// </summary>
        public string codetypename { get; set; } = "html";


        private string _title = "";

        /// <summary> </summary>
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



        #region -----------  description  -------  [Content for footer]
        private string _description = ""; // = new String();
                                    /// <summary>
                                    /// Content for footer
                                    /// </summary>
        // [XmlIgnore]
        [Category("metaCodeBlock")]
        [DisplayName("description")]
        [Description("Content for footer")]
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
        #endregion

        /// <summary>
        /// Code block -- containes custom code that may have template params
        /// </summary>
        /// <param name="__name">What whould be writen at head of the block? leave empty to hide head</param>
        /// <param name="__description">What would be written as footer of the block? leave empty to hide footer </param>
        /// <param name="__url">What link to put at bottom of footer? no link if empty</param>
        /// <param name="__code"></param>
        public metaCodeBlock(string __name, string __description, IEnumerable<string> __code)
        {
            content.AddRange(__code);
            name = __name;
            title = __name;
            description = __description;
            
        }

       
        
    }
}