namespace imbSCI.Reporting.meta.delivery.items
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
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
    using imbSCI.Data.enums.fields;
    using imbSCI.Reporting.enums;
    using imbSCI.Core.reporting.extensions;
    using aceCommonTypes.extensions.enumworks;

    /// <summary>
    /// Delivers content from file to specified outputpath. Applies context.data to template fields
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.deliveryUnitItem" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.IDeliveryUnitItem" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.items.IDeliveryUnitItemWithTemplate" />
    public class deliveryUnitItemFileOutput : deliveryUnitItem, IDeliveryUnitItem, IDeliveryUnitItemWithTemplate
    {
        /// <summary>
        /// Output template field 
        /// </summary>
        protected templateFieldSubcontent output_datafield { get; set; } = templateFieldSubcontent.none;

        /// <summary>
        /// Gets a value indicating whether this instance is in data field mode.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is data field mode; otherwise, <c>false</c>.
        /// </value>
        public bool isDataFieldMode
        {
            get
            {
                return output_datafield != templateFieldSubcontent.none;
                return (outputpath == null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected deliveryUnitItemContentTemplated templateOutput { get; set; }


        /// <summary>
        /// DataField mode: loads content file and on scopeInOperation applies context data and saves result to output field.
        /// </summary>
        /// <param name="__sourcepath">The sourcepath - relative to reportTheme directory</param>
        /// <param name="__outputfield">The outputfield.</param>
        /// <param name="__location">The location - level to be triggered</param>
        public deliveryUnitItemFileOutput(string __sourcepath, templateFieldSubcontent __outputfield, deliveryUnitItemLocationBase __location, string __title = "", string __description = "") : base(deliveryUnitItemType.contentTemplate)
        {
            location = __location;
            flags = deliveryUnitItemFlags.useTemplate;

            name = "File to data field";
            description = "On level patch - during scopeInOperation loads source path into outputfied after applying context.data";

            if (!__title.isNullOrEmpty()) name = __title;
            if (!__description.isNullOrEmpty()) description = __description;

            sourcepath.setup(__sourcepath);
            output_datafield = __outputfield;
            outputpath = null;
        }

        /// <summary>
        /// Content from file to be exported at output path with optional <see cref="deliveryUnitItemContentTemplated"/> macro template
        /// </summary>
        /// <param name="__sourcepath">The sourcepath - relative to reportTheme directory</param>
        /// <param name="__outputPath">The output path - relative to deliveryInstance directory root. if null then it will not do file output</param>
        /// <param name="__templateOutput">The template output to deliver file output via its macro template (optional)</param>
        public deliveryUnitItemFileOutput(string __sourcepath, string __outputPath, string __title="", string __description="", deliveryUnitItemContentTemplated __templateOutput = null) : base(deliveryUnitItemType.contentTemplate)
        {
            location = deliveryUnitItemLocationBase.globalDeliveryContent;

            flags = deliveryUnitItemFlags.useTemplate;

            templateOutput = __templateOutput;

            name = "Static file content";
            description = "Applies global data";

            if (!__title.isNullOrEmpty()) name = __title;
            if (!__description.isNullOrEmpty()) description = __description;


            if (!__outputPath.isNullOrEmpty())
            {
                outputpath.setup(__outputPath);
            }

            sourcepath.setup(__sourcepath);
        }


        /// <summary>
        /// Prepares the operation.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void prepareOperation(IRenderExecutionContext context)
        {
            base.prepareOperation(context);

            context.data.add(templateFieldBasic.root_relpath, "");

            if (isDataFieldMode)
            {
                context.data.add(output_datafield, "");
                
            }


            if (!isDataFieldMode)
            {
                PropertyCollection pc = new PropertyCollection();
                pc.AppendData(context.data, existingDataMode.overwriteExisting);

                

              //  pc.add(templateFieldBasic.root_relpath, 
                //pc.AppendData(dict[composer.path], existingDataMode.overwriteExisting);

                pc.add(templateFieldBasic.page_title, name);
                pc.add(templateFieldBasic.page_desc, description);

                pc.add(reportOutputDomainEnum.includes, "");
                pc.add(reportOutputDomainEnum.localdirectory, "");
                pc.add(reportOutputDomainEnum.logs, "");

                string filepath = outputpath.toPath(context.directoryRoot.FullName, context.data);
                string dirpath = Path.GetDirectoryName(filepath);
                DirectoryInfo dirinfo = new DirectoryInfo(dirpath);

                string rootrel = dirinfo.getRelativePathToParent(context.directoryRoot).getWebPathBackslashFormat();
                if (rootrel == "/") rootrel = "";

                pc.add(templateFieldBasic.root_relpath, rootrel);


                string output = template.applyToContent(false, pc);

                

                if (templateOutput == null)
                {

                    context.saveFileOutput(output, filepath, context.scope.path, description, name);
                }
                else
                {
                    pc.add(templateFieldSubcontent.main, output);

                    output = templateOutput.template.applyToContent(false, pc);

                    filepath = outputpath.toPathWithExtension(context.directoryRoot.FullName, templateOutput.format.getDefaultExtension());
                    context.saveFileOutput(output, filepath, context.scope.path, description, name);

                    //FileInfo fi = templateOutput.saveOutput(output, context.data, filepath);
                    //context.regFileOutput(fi.FullName, context.scope.path, description, name);
                }
            }
            else
            {
                context.log(name + " :: data field application the item: " + GetType().Name);
            }



        }

        /// <summary>
        /// When scopes the in operation - applies template into context.data [if is in datafield mode]
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="newScope">The new scope.</param>
        public void scopeInOperation(IRenderExecutionContext context, IMetaContentNested newScope)
        {
            if (isDataFieldMode)
            {
                if (!template.isNullOrEmpty())
                {
                    string output = template.applyToContent(false, context.data);

                    context.data.add(output_datafield, output);
                }
            }

           
            
        }

        public void executeScriptInstruction(IRenderExecutionContext context, docScriptInstructionCompiled instruction)
        {

        }

        /// <summary>
        /// Scopes the out operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="oldScope">The old scope.</param>
        public void scopeOutOperation(IRenderExecutionContext context, IMetaContentNested oldScope)
        {

        }

        /// <summary>
        /// inserts empty data field for each composer passed
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="composer">The composer.</param>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public PropertyCollectionDictionary collectOperationStart(IRenderExecutionContext context, IMetaContentNested composer, PropertyCollectionDictionary dict)
        {


            if (isDataFieldMode)
            {
                dict[composer.path].add(output_datafield, "");
            } else
            {

            }

            


            return dict;
        }


        public docScript composeOperationStart(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {

            return script;
        }

        public docScript composeOperationEnd(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {

            return script;
        }

        public override void reportFinishedOperation(IRenderExecutionContext context)
        {

        }

    }
   
}