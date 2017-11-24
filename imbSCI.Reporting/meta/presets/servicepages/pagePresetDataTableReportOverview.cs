namespace imbSCI.Reporting.meta.presets.servicepages
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    using imbSCI.Data.enums.fields;

    /// <summary>
    /// Overview page for DataTableReport overview -- it uses path mechanism to reach page
    /// </summary>
    public class pagePresetDataTableReportOverview:metaPage
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyCollectionList dataset { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="pagePresetDataTableReportOverview"/> class.
        /// </summary>
        public pagePresetDataTableReportOverview(string headerTitle, string headerDescription, string footerBottomLine)
        {
            name = "dbDumpOverview";

            pageTitle = headerTitle;
            pageDescription = headerDescription;

            basicBlocksFlags = metaPageCommonBlockFlags.pageHeader | metaPageCommonBlockFlags.pageFooter | metaPageCommonBlockFlags.pageNavigation | metaPageCommonBlockFlags.pageNotation | metaPageCommonBlockFlags.pageKeywords;

            footer.bottomLine = footerBottomLine;

        }

        public override void construct(object[] resources)
        {
            List<object> reslist = resources.getFlatList<object>(typeof(PropertyCollectionList), typeof(PropertyCollection));

            PropertyCollectionList directAccessDataList = reslist.Pop<PropertyCollectionList>();

            dataset = directAccessDataList;

            base.construct(resources);
        }

        public virtual docScript compose(docScript script)
        {
            script = this.checkScript(script);


            script.x_scopeIn(this);


            header.compose(script);

            navigation.compose(script);

            script.AppendLine();

            foreach (PropertyCollection pc in dataset)
            {
                script.c_line();

                string tablename = pc.getAndRemoveProperString(templateFieldDataTable.data_tablename);
                string desc = pc.getAndRemoveProperString(templateFieldDataTable.data_tabledesc);
                script.pairs(tablename, desc, pc, "", 2, false);

                script.AppendLine();

            }

            footer.compose(script);

            
                
           
            //script.add(appendType.i_page, docScriptArguments.dsa_name, docScriptArguments.dsa_title,docScriptArguments.dsa_description)
            //    .set(name, pageTitle, pageDescription);

            // script.add(appendType.s_settings).arg(docScriptArguments.dsa_stylerSettings, settings);


///            script.add(appendType.s_palette).arg(acePaletteRole.colorDefault);

           // script = this.subCompose(script);


            script.x_scopeOut(this);

            return script;
        }



    }

}