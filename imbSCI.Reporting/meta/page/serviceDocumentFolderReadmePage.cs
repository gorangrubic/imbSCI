namespace imbSCI.Reporting.meta.page
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
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
    using imbSCI.Core.reporting.zone;
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.format;

    public class serviceDocumentFolderReadmePage : metaServicePage, IPageFormatSettings
    {
        public serviceDocumentFolderReadmePage(string documentName, string headerTitle, string headerDescription, string footerBottomLine):base(headerDescription, headerTitle, documentName.add("_readme","_"), 100)
        {
            fileformat = reportOutputFormatName.textMdFile;
            filenameBase = "readme";
            basicBlocksFlags = metaPageCommonBlockFlags.pageHeader | metaPageCommonBlockFlags.pageFooter | metaPageCommonBlockFlags.pageNotation | metaPageCommonBlockFlags.pageKeywords;
            
            
        }



        
        public override void construct(object[] resources)
        {
            //List<Object> reslist = resources.getFlatList<Object>();
            settings.zoneLayoutPreset = cursorZoneLayoutPreset.oneFullPage;
            settings.zoneSpatialPreset = cursorZoneSpatialPreset.longTextLog;
            
            settings.mainColor = acePaletteRole.colorA;

            fli = new metaFileInfo();
            blocks.Add(fli, this);

            fli.description = "This folder is created as container of report document {{{document_title}}} ({{{document_path}}})";


            sys = new metaSystemInfo();
            blocks.Add(sys, this);



            blocks.Add(notes, this);
          

            base.construct(resources);



        }

        metaFileInfo fli = null;
        metaSystemInfo sys = null;

        metaNotation notes = new metaNotation();

        public override docScript compose(docScript script)
        {
            script = this.checkScript(script);

            script.x_scopeIn(this);

           // script.x_exportStart(filenameBase, fileformat, reportAPI.imbMarkdown, elementLevelFormPreset.htmlWebSite);

            header.compose(script);

            fli.compose(script);

            sys.compose(script);


            notes.compose(script);

            keywords.compose(script);

            footer.compose(script);

          //  script.x_exportEnd(filenameBase, fileformat);

            script.x_scopeOut(this);

            return script;
        }


    }

}