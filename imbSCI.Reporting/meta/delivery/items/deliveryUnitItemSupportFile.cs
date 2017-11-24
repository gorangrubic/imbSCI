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
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Static file copy
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.deliveryUnitItem" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.IDeliveryUnitItem" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.items.IDeliveryUnitItemFromFileSource" />
    public class deliveryUnitItemSupportFile : deliveryUnitItem, IDeliveryUnitItem, IDeliveryUnitItemFromFileSource, IDeliverySupportFile
    {
        /// <summary>
        /// 
        /// </summary>
        public appendLinkType linkType { get; set; } = appendLinkType.scriptLink;


        public deliveryUnitItemSupportFile(string __sourcepath, string __outputfolder) : base(deliveryUnitItemType.supportFile)
        {

            location = deliveryUnitItemLocationBase.globalDeliveryResource;
            flags = deliveryUnitItemFlags.filenameExtensionIsStatic | deliveryUnitItemFlags.linkToPrimaryContent | deliveryUnitItemFlags.filenameIsDataTemplate | deliveryUnitItemFlags.useCopy;
           

            sourcepath.setup(__sourcepath);
            string opath = __outputfolder.add(sourcepath.filenameWithExtension, "\\");

            outputpath.setup(opath);

            switch (sourcepath.extension)
            {
                case ".css":
                    linkType = appendLinkType.styleLink;
                    break;
                case ".js":
                    linkType = appendLinkType.scriptLink;
                    break;
            }
        }

        public PropertyCollectionDictionary collectOperationStart(IRenderExecutionContext context, IMetaContentNested composer, PropertyCollectionDictionary dict)
        {
            return dict;
          //  throw new NotImplementedException();
        }

        public docScript composeOperationEnd(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {
            return script;
           // throw new NotImplementedException();
        }

        public docScript composeOperationStart(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {
            return script;
            //    throw new NotImplementedException();
        }

        public void executeScriptInstruction(IRenderExecutionContext context, docScriptInstructionCompiled instruction)
        {
          //  throw new NotImplementedException();
        }

        public override void prepareOperation(IRenderExecutionContext context)
        {
            base.prepareOperation(context);

            
            




           // String msg = fileOpsBase.copyFile(src, trg, name);

          //  this.prepareOperation(context);
        }

        public void scopeInOperation(IRenderExecutionContext context, IMetaContentNested newScope)
        {
            
        }

        public void scopeOutOperation(IRenderExecutionContext context, IMetaContentNested oldScope)
        {
            
        }

        public void appendToRender(IRenderExecutionContext context, ITextRender __render)
        {
            string pathToFile = getRelativeUrl(context);
            __render.AppendLink(pathToFile, "", "", linkType);
        }

        public string getRelativeUrl(IRenderExecutionContext context, string __relToRoot=null)
        {
            string relJump = __relToRoot;
            if (imbSciStringExtensions.isNullOrEmpty(relJump))
            {
                relJump = context.directoryScope.getRelativePathToParent(context.directoryRoot);
            }

            string relPath = outputpath.toPath("");  //output_fileinfo.FullName.removeStartsWith(context.directoryRoot.FullName);
            relJump = relJump.add(relPath, "");
            relJump = relJump.getWebPathBackslashFormat().Replace(" ", "");
            relJump = relJump.Replace("//", "/");
           // relJump = relJump.Replace("}}}/", "}}}");
            return relJump;
            
        }
    }

}