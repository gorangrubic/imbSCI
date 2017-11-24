namespace imbSCI.Reporting.meta.delivery.units
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using imbSCI.Core.reporting.extensions;
    using imbSCI.Reporting.enums;

    /// <summary>
    /// 
    /// </summary>
    public static class deliveryUnitBuilder
    {
        /// <summary>
        /// Prepares the operation file source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="item">The item.</param>
        public static void prepareOperationFileSource(this IDeliveryUnitItemFromFileSource item, IRenderExecutionContext context)
        {
            string outPath = item.outputpath.toPath(context.directoryRoot.FullName, context.data);
            string inPath = item.sourcepath.toPath("", context.data);

            fileOpsBase.copyFile(inPath, outPath, item.name);
        }

        /// <summary>
        /// Loads the template, applies <see cref="imbSCI.Reporting.reporting.render.IRenderExecutionContext.data"/> and saves into output path
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public static void loadFileAndSaveTemplate(this IDeliveryUnitItemFromFileSource item, IRenderExecutionContext context)
        {
            string outPath = item.outputpath.toPath(context.directoryRoot.FullName, context.data);
            string inPath = item.sourcepath.toPath("", context.data);

            string content = openBase.openFileToString(inPath, true, false);
            string contentOutput = content.applyToContent(false, context.data);

            contentOutput.saveStringToFile(outPath,getWritableFileMode.overwrite);

        }

        //public static String path(this IMetaContent composer, deliveryUnitItemLocationBase location)
        //{
        //    switch (item.location)
        //    {
        //        case deliveryUnitItemLocationBase.localResource:
        //        case deliveryUnitItemLocationBase.externalWebResource:
        //            itemByLevel[reportElementLevel.page].Add(item);
        //            break;
        //        case deliveryUnitItemLocationBase.globalDeliveryResource:
        //            return composer.getPathToParent(composer.root);
        //            break;
        //        case deliveryUnitItemLocationBase.globalDocumentResource:
        //            itemByLevel[reportElementLevel.document].Add(item);
        //            break;
        //        case deliveryUnitItemLocationBase.globalDocumentSetResource:
        //            return composer.elementLevel;
        //            break;
        //        case deliveryUnitItemLocationBase.unknown:

        //            break;
        //    }
        //}

        /// <summary>
        /// Adds a set of <see cref="deliveryUnitItem"/>s for the standard HTML report
        /// </summary>
        /// <param name="unit">The unit.</param>
        public static void AddStandardHtmlItems(this deliveryUnit unit)
        {
          //  String cssPath = templateFieldDeliveryUnit.del_themepath.ToString().add("standard\\standard.css", "\\");

          //  deliveryUnitItemSupportFile standardCss = new deliveryUnitItemSupportFile(cssPath, "include\\");
          //  deliveryUnitItemPaletteCSS palletteCss = new deliveryUnitItemPaletteCSS();
          ////  deliveryUnitItemContentTemplated pageTemplate = new deliveryUnitItemContentTemplated("\\standard\\standard.html");

          //  unit.Add(standardCss);
          //  unit.Add(palletteCss);
          //  //unit.Add(pageTemplate);

        }

        public static void AddJSPluginSupport(this deliveryUnit unit, jsPluginEnum plugin)
        {

            deliveryUnitItemSupportFile js = null;

            string includePath = "".t(templateFieldDeliveryUnit.del_includepath); //ToString(); //.add("standard\\standard.css", "\\");
            string outputPath = "include\\";
            FileInfo fi = null;
            string in_path = "";
            switch (plugin)
            {
                case jsPluginEnum.bibliography:
                   // js = new deliveryUnitItemSupportFile(includepath.add("d3.js", "\\"), outputPath);
                    break;
                case jsPluginEnum.D3:
                    in_path = includepath.add("d3.js", "\\");
                    fi = new FileInfo(in_path);

                    js = new deliveryUnitItemSupportFile(fi.FullName, outputPath);
                    unit.Add(js, fi);
                    break;
                case jsPluginEnum.JQuery:
                    in_path = includepath.add("jquery.js", "\\");
                    fi = new FileInfo(in_path);
                    js = new deliveryUnitItemSupportFile(fi.FullName, outputPath);
                    unit.Add(js, fi);
                    break;
                case jsPluginEnum.ontologyViewer:
                   // js = new deliveryUnitItemSupportFile(includepath.add("d3.js", "\\"), outputPath);
                    break;
                case jsPluginEnum.strapdown:
                    //unit.Add(new deliveryUnitItemSupportFile(includepath.add("strapdown.js", "\\"), outputPath));
                    //unit.Add(new deliveryUnitItemSupportFile(includepath.add("strapdown.css", "\\"), outputPath));
                    //unit.Add(new deliveryUnitItemSupportFile(includepath.add("strapdown-topbar.min.js", "\\"), outputPath));
                    break;
                case jsPluginEnum.visualRDF:
                   // js = new deliveryUnitItemSupportFile(includepath.add("d3.js", "\\"), outputPath);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        ///
        /// </summary>
        public static string themepath { get; set; } = "reportTheme";


        /// <summary>
        ///
        /// </summary>
        public static string includepath { get; set; } = "reportInclude";
    }

}