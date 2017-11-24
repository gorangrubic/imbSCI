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
    using imbSCI.Core.reporting.style;
    using imbSCI.Data.enums.fields;
    using imbSCI.Core.reporting.render.builders;
    using imbSCI.Core.reporting.format;

    public class deliveryUnitCompactReport : deliveryUnit
    {
        public deliveryUnitCompactReport() : base("Compact report delivery")
        {
        }

        public override void setup()
        {
            scriptFlags = docScriptFlags.allowFailedInstructions | docScriptFlags.enableLocalCollection | docScriptFlags.ignoreArgumentValueNull | docScriptFlags.ignoreCompilationFails | docScriptFlags.useDataDictionaryForLocalData;

            theme = stylePresets.themeSemantics;

            AddThemeSupportFiles("velestrap", "bootmark.min.js", "include\\", true);

            AddThemeSupportFiles("velestrap", "*.css", "include\\", false);
            AddThemeSupportFiles("velestrap", "*.js", "include\\", false);

            var footer_delivery = AddItem(new deliveryUnitItemFileOutput("compact\\footer.md", templateFieldSubcontent.html_footer, deliveryUnitItemLocationBase.localResource, "Page footer", "Include at end of page"));

            var renderDirectory = new deliveryUnitDirectoryConstructor(reportElementLevel.documentSet, reportElementLevel.document); // creates directory for documentSets and document
            Add(renderDirectory);


            var renderOutput = new deliveryUnitItemSimpleRenderOutput(new builderForMarkdown(),
                reportOutputFormatName.textMdFile, renderDirectory.levels);

            renderOutput.levelOfNewFile = reportElementLevel.page;
            renderOutput.levelOfNewPage = reportElementLevel.none;
            renderOutput.levels.AddMulti(reportElementLevel.documentSet, reportElementLevel.document, reportElementLevel.servicepage, reportElementLevel.page, reportElementLevel.block);

            Add(renderOutput);

            var renderOutputTemplate = new deliveryUnitItemContentTemplated("compact\\index.html", renderOutput, reportOutputFormatName.textHtml, renderDirectory.levels);
            renderOutputTemplate.filenameSufix = "";
            renderOutputTemplate.levels.AddMulti(reportElementLevel.documentSet, reportElementLevel.document, reportElementLevel.servicepage, reportElementLevel.page);
            Add(renderOutputTemplate);

            //var indexdeliver = AddItem(new deliveryUnitItemFileOutput("veles_report\\index.md", "index.html", "Report home", "Introduction page of the report", renderOutputTemplate));

            AddReportIncludeFiles("docs", renderOutputTemplate, "*.md", false);

            



            /*
            var logOutA = AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.reportContext, "logs\\reporting.md", renderOutputTemplate));

            var logOutB = AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.systemMainLog, "logs\\system.md", renderOutputTemplate));

            var logOutC = AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.aceCommonServices, "logs\\execution.md", renderOutputTemplate));

            var logOutD = AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.initialLog, "logs\\init.md", renderOutputTemplate));
            */
            /*
            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.devNotes, "logs\\devnotes.md", renderOutputTemplate));
            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.aceCommonServices, "logs\\ace_common_services.md", renderOutputTemplate));
            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.aceSubsystem, "logs\\ace_subsystem.md", renderOutputTemplate));

            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.analyticEngine, "logs\\analytic_engine.md", renderOutputTemplate));
            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.languageEngine, "logs\\language_engine.md", renderOutputTemplate));
            AddItem(new deliveryUnitItemLogOutput(imbSCI.Cores.enums.logOutputSpecial.semanticEngine, "logs\\semantic_engine.md", renderOutputTemplate));

    */


        }
    }

}