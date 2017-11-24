namespace imbSCI.Reporting.meta.blocks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
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
    /// Block for displaying list of values/
    /// </summary>
    /// <seealso cref="MetaContainerNestedBase" />
    public class metaListViewer : MetaContainerNestedBase
    {
      


        public override void construct(object[] resources)
        {
            List<object> reslist = resources.getFlatList<object>();

            colors = acePaletteRole.colorA;
            width = blockWidth.full;

            List<object> list = reslist.getFirstOfType<List<object>>(false, null);

            variables = list;

            description = "Item count: " + list.Count;
            name = "List";

            doHorizontal = list.getAndRemoveIfExists(docScriptArguments.dsa_isHorizontal);

            //var wdth = dpair.getAndRemoveProperField(docScriptArguments.dsa_);
        }


        #region --- pairSettings ------- Settings of variable pair display
        private PropertyCollection _pairSettings;
        /// <summary>
        /// Settings of variable pair display
        /// </summary>
        public PropertyCollection pairSettings
        {
            get
            {
                return _pairSettings;
            }
            set
            {
                _pairSettings = value;
                OnPropertyChanged("pairSettings");
            }
        }
        #endregion


        public override docScript compose(docScript script)
        {
            if (script == null) script = new docScript(name);
            script.x_scopeIn(this);

            script.add(appendType.s_palette).arg(colors);


            script.add(appendType.heading_2, name).arg(docScriptArguments.dsa_doMerge, true);

            script.add(appendType.c_data).arg(docScriptArguments.dsa_dataPairs, variables).arg(docScriptArguments.dsa_separator, "").hr().arg(docScriptArguments.dsa_title, name).arg(docScriptArguments.dsa_description, description).arg(docScriptArguments.dsa_id_attribute, "pair_" + name);

            script.add(appendType.italic, description).arg(docScriptArguments.dsa_doMerge, true);

            //;


            //script.add(appendType.c_section, docScriptArguments.dsa_name, docScriptArguments.dsa_content, docScriptArguments.dsa_description, docScriptArguments.dsa_class_attribute, docScriptArguments.dsa_id_attribute).set(name, content, description, "header", "#" + name);

            script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);

            script.x_scopeOut(this);

            return script;
        }

        #region -----------  variables  -------  [Variables to show]
        private List<object> _variables; // = new PropertyCollection();
        /// <summary>
        /// Variables to show
        /// </summary>
        // [XmlIgnore]
        [Category("metaVariablePairs")]
        [DisplayName("variables")]
        [Description("Variables to show")]
        public List<object> variables
        {
            get
            {
                return _variables;
            }
            set
            {
                // Boolean chg = (_variables != value);
                _variables = value;
                OnPropertyChanged("variables");
                // if (chg) {}
            }
        }
        #endregion


        #region -----------  description  -------  [Description of variable pairs]
        private string _description; // = new String();
        /// <summary>
        /// Description of variable pairs
        /// </summary>
        // [XmlIgnore]
        [Category("metaVariablePairs")]
        [DisplayName("description")]
        [Description("Description of variable pairs")]
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


        #region ----------- Boolean [ doHorizontal ] -------  [Render variables into horizontal table]
        private bool _doHorizontal = false;
        /// <summary>
        /// Render variables into horizontal table
        /// </summary>
        [Category("Switches")]
        [DisplayName("doHorizontal")]
        [Description("Render variables into horizontal table")]
        public bool doHorizontal
        {
            get { return _doHorizontal; }
            set { _doHorizontal = value; OnPropertyChanged("doHorizontal"); }
        }
        #endregion

    }
}