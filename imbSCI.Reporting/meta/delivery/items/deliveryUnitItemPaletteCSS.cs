namespace imbSCI.Reporting.meta.delivery.items
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
    using imbSCI.Core.reporting.extensions;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.deliveryUnitItem" />
    public class deliveryUnitItemPaletteCSS : deliveryUnitItemSupportFile, IDeliveryUnitItem, IDeliveryUnitItemFromFileSource, IDeliverySupportFile
    {

      

        /// <summary>
        /// Initializes a new instance of the <see cref="deliveryUnitItemPaletteCSS"/> class.
        /// </summary>
        /// <param name="opath">The opath.</param>
        public deliveryUnitItemPaletteCSS(string __sourcepath, string __outputfolder) : base(__sourcepath,  __outputfolder)
        {
            location = deliveryUnitItemLocationBase.globalDeliveryResource;
            flags = deliveryUnitItemFlags.filenameExtensionIsStatic | deliveryUnitItemFlags.linkToPrimaryContent | deliveryUnitItemFlags.filenameIsDataTemplate | deliveryUnitItemFlags.useTemplate;            
        }




        public override void prepareOperation(IRenderExecutionContext context)
        {
            string output_path = outputpath.toPath(context.directoryRoot.FullName, context.data);

            var pc = context.theme.AppendDataFields(context.data);

            base.prepareOperation(context);
            
            string output = template.applyToContent(false, context.data);
            
            output_fileinfo = output_path.getWritableFile(getWritableFileMode.overwrite);

            //output.saveStringToFile(output_fileinfo.FullName, getWritableFileMode.overwrite); // = output.saveStringToFile(output_path, imbSCI.Cores.enums.getWritableFileMode.overwrite);

            context.saveFileOutput(output, output_fileinfo.FullName, "css", description);
           
        }


        /*

        public void composeOperationEnd(IRenderExecutionContext context, IMetaContent composer)
        {
          //  throw new NotImplementedException();
        }

        public void composeOperationStart(IRenderExecutionContext context, IMetaContent composer)
        {
            //throw new NotImplementedException();
        }

        public void scopeInOperation(IRenderExecutionContext context, IMetaContentNested newScope)
        {
            //throw new NotImplementedException();
        }

        public void scopeOutOperation(IRenderExecutionContext context, IMetaContentNested oldScope)
        {
           // throw new NotImplementedException();
        }

        public PropertyCollectionDictionary collectOperationStart(IRenderExecutionContext context, IMetaContent composer, PropertyCollectionDictionary dict)
        {
            throw new NotImplementedException();
        }

        public void executeScriptInstruction(IRenderExecutionContext context, docScriptInstructionCompiled instruction)
        {
            throw new NotImplementedException();
        }

        public docScript composeOperationStart(IRenderExecutionContext context, IMetaContent composer, docScript script)
        {
            throw new NotImplementedException();
        }

        public docScript composeOperationEnd(IRenderExecutionContext context, IMetaContent composer, docScript script)
        {
            throw new NotImplementedException();
        }
        */
    }

}