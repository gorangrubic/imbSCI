namespace imbSCI.Reporting.meta.delivery.units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.delivery.items;
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
    using imbSCI.Data.enums.appends;
    using imbSCI.Core.reporting.render.builders;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.style;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.deliveryUnit" />
    public class deliveryUnitMainReport : deliveryUnit
    {
        public deliveryUnitMainReport() : base("Report deliveryInstance")
        {
            
        }





        /// <summary>
        /// Setups this instance.
        /// </summary>
        public override void setup()
        {
            scriptFlags = docScriptFlags.allowFailedInstructions | docScriptFlags.disableGlobalCollection | docScriptFlags.enableLocalCollection | docScriptFlags.ignoreArgumentValueNull | docScriptFlags.ignoreCompilationFails;

            theme = stylePresets.themeSemantics;

            //String cssPath = "".t(templateFieldDeliveryUnit.del_themepath).add("simple\\simple.css", "\\");

            //deliveryUnitItemSupportFile standardCss = new deliveryUnitItemSupportFile(cssPath, "include\\"); // copies file and later includes the file
            //this.Add(standardCss);

            //this.Add(new deliveryUnitItemSupportFile("".t(templateFieldDeliveryUnit.del_themepath).add("simple\\bootstrap.css", "\\"));

            AddThemeSupportFile("simple\\simple.css");
            AddThemeSupportFile("simple\\bootstrap.css");

            //this.AddThemeSupportFile("strap\\strapdown.css");
            //this.AddThemeSupportFile("strap\\strapdown.js"); 
            //this.AddThemeSupportFile("strap\\strapdown-topbar.min.js");

            AddThemeSupportFiles("strapzeta", "*.css");
            AddThemeSupportFile("strapzeta\\bootstrap.min.js");

            AddThemeSupportFile("strapzeta\\strapdown.js").linkType=appendLinkType.scriptPostLink;

            deliveryUnitItemPaletteCSS palletteCss = new deliveryUnitItemPaletteCSS("standard\\standard.css", "include\\"); // templated palette css
            Add(palletteCss);

            //this.AddStandardHtmlItems();
            this.AddJSPluginSupport(jsPluginEnum.D3);           // copies js file
            this.AddJSPluginSupport(jsPluginEnum.JQuery);       // copies jquery


            var renderDirectory = new deliveryUnitDirectoryConstructor(reportElementLevel.documentSet, reportElementLevel.document); // creates directory for documentSets and document
            Add(renderDirectory);


            var renderOutput = new deliveryUnitItemSimpleRenderOutput(new builderForMarkdown(), reportOutputFormatName.textMdFile, renderDirectory.levels);
            renderOutput.levelOfNewFile = reportElementLevel.page;
            renderOutput.levelOfNewPage = reportElementLevel.none;
            renderOutput.levels.AddMultiple(reportElementLevel.documentSet, reportElementLevel.document, reportElementLevel.servicepage, reportElementLevel.page, reportElementLevel.block);

            Add(renderOutput);

            var renderOutputTemplate = new deliveryUnitItemContentTemplated("simple\\simple.html", renderOutput, reportOutputFormatName.htmlViaMD, renderDirectory.levels);
            renderOutputTemplate.filenameSufix = "";
            renderOutputTemplate.levels.AddMultiple(reportElementLevel.servicepage, reportElementLevel.page, reportElementLevel.block);
            Add(renderOutputTemplate);



           // renderOutput.attachIncludeItem(this.items);


            //var renderTableOutput = new deliveryUnitItemSimpleRenderOutput(new builderForTableDocument(), reportOutputFormatName.sheetExcel);
            //renderTableOutput.levels.Add(reportElementLevel.document, reportElementLevel.page, reportElementLevel.block);
            //this.Add(renderTableOutput);



            // this.Add();
        }
    }

}