namespace imbSCI.Reporting.meta.delivery.items
{
    using System;
    using System.Collections.Generic;
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
    using imbSCI.Reporting.enums;
    using aceCommonTypes.extensions.enumworks;
    using imbSCI.Data.enums.fields;
    using imbSCI.Core.reporting.format;

    /// <summary>
    /// Delivers <see cref="imbSCI.Core.interfaces.IAceLogable"/>, <see cref="imbSCI.Reporting.reporting.render.ITextRender"/> or <see cref="System.String"/> content on predefined output path
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.deliveryUnitItem" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.IDeliveryUnitItem" />
    public class deliveryUnitItemLogOutput : deliveryUnitItem, IDeliveryUnitItem
    {
        /// <summary>
        /// 
        /// </summary>
        protected logOutputSpecial specialSource { get; set; }


        /// <summary>
        /// 
        /// </summary>
        protected IAceLogable log { get; set; }


        /// <summary>
        /// 
        /// </summary>
        protected ITextRender logRender { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string logStatic { get; set; } = "";


        protected bool hasRender
        {
            get
            {
                return logRender != null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected deliveryUnitItemContentTemplated templateOutput { get; set; }


        public deliveryUnitItemLogOutput(logOutputSpecial __special, string __outputPath, deliveryUnitItemContentTemplated __templateOutput = null) : base(deliveryUnitItemType.content)
        {
            specialSource = __special;
            templateOutput = __templateOutput;
            setup(null, __outputPath);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="deliveryUnitItemLogOutput"/> class.
        /// </summary>
        /// <param name="__log">The log.</param>
        /// <param name="__outputPath">The output path.</param>
        public deliveryUnitItemLogOutput(IAceLogable __log, string __outputPath, deliveryUnitItemContentTemplated __templateOutput = null) : base(deliveryUnitItemType.content)
        {
            setup(__log, __outputPath);
            templateOutput = __templateOutput;

        }

        public deliveryUnitItemLogOutput(ITextRender __log, string __outputPath, deliveryUnitItemContentTemplated __templateOutput = null) : base(deliveryUnitItemType.content)
        {
            setup(__log, __outputPath);
            templateOutput = __templateOutput;

        }

        protected void setup(object __log, string __outputPath)
        {
            location = deliveryUnitItemLocationBase.globalDeliveryResource;
            flags = deliveryUnitItemFlags.none;

            setLog(__log);
            outputpath.setup(__outputPath);
            name = "Log output";
            description = "Saves log from given object";
        }

        protected void setLog(object __log)
        {
            log = __log as IAceLogable;

            logRender = __log as ITextRender;
            if (__log is string)
            {
                logStatic = __log as string;
            }
        }

        public override void prepareOperation(IRenderExecutionContext context)
        {
            if (specialSource != logOutputSpecial.none)
            {
                if (context.specialLogOuts.ContainsKey(specialSource))
                {
                    setLog(context.specialLogOuts[specialSource]);
                } else
                {
                    //setLog(aceLog.logBuilderRegistry.getLogBuilder(specialSource));
                }
            }

            context.regFileOutput(outputpath.toPath(context.directoryRoot.FullName), reportOutputDomainEnum.logs, description);

            if (templateOutput != null)
            {
                context.regFileOutput(outputpath.toPathWithExtension(context.directoryRoot.FullName, templateOutput.format.getDefaultExtension()), reportOutputDomainEnum.logs, description);
            }

        }

        public override void reportFinishedOperation(IRenderExecutionContext context)
        {

            // setRelPath(context);

            string filepath = outputpath.toPath(context.directoryRoot.FullName, context.data);
            string dirpath = Path.GetDirectoryName(filepath);
            DirectoryInfo dirinfo = new DirectoryInfo(dirpath);

            string rootrel = dirinfo.getRelativePathToParent(context.directoryRoot).getWebPathBackslashFormat();
            if (rootrel == "/") rootrel = "";

            context.data.add(templateFieldBasic.root_relpath, rootrel);

            string spath = outputpath.toPath(context.directoryRoot.FullName);
            string scontent = "";
            if (hasRender)
            {
                scontent = logRender.ContentToString(false, reportOutputFormatName.textMdFile);
            }
            else if (log != null)
            {
                scontent = log.logContent;
            }
            else
            {
                scontent = logStatic;
            }
            context.saveFileOutput(scontent, spath, reportOutputDomainEnum.logs, description);

            // scontent.saveStringToFile(spath, getWritableFileMode.overwrite, Encoding.Unicode);

            if (templateOutput != null)
            {
                string tpath = outputpath.toPathWithExtension(context.directoryRoot.FullName, templateOutput.format.getDefaultExtension());
                FileInfo tfile = templateOutput.saveOutput(context, scontent, context.data, tpath);
                context.regFileOutput(tfile.FullName, reportOutputDomainEnum.logs, description);

            }
        }


        public PropertyCollectionDictionary collectOperationStart(IRenderExecutionContext context, IMetaContentNested composer, PropertyCollectionDictionary dict)
        {



            // throw new NotImplementedException();
            return dict;
        }

        public void scopeInOperation(IRenderExecutionContext context, IMetaContentNested newScope)
        {
            //throw new NotImplementedException();
        }

        public void executeScriptInstruction(IRenderExecutionContext context, docScriptInstructionCompiled instruction)
        {
            //throw new NotImplementedException();
        }

        public void scopeOutOperation(IRenderExecutionContext context, IMetaContentNested oldScope)
        {
            //throw new NotImplementedException();

        }

        public docScript composeOperationStart(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {
            //throw new NotImplementedException();
            return script;
        }

        public docScript composeOperationEnd(IRenderExecutionContext context, IMetaContentNested composer, docScript script)
        {
            return script;
            // throw new NotImplementedException();
        }
    }

}
