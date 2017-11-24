namespace imbSCI.Reporting.meta.delivery
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using imbSCI.Reporting.meta.delivery.units;
    using imbSCI.Reporting.meta.document;
    using imbSCI.Reporting.meta.documentSet;
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
    using imbSCI.Core.reporting.format;
    using aceCommonTypes.extensions.enumworks;
    using imbSCI.Core.reporting.extensions;
    using imbSCI.Core.files;

    /// <summary>
    /// One element of <see cref="deliveryUnit"/>
    /// </summary>
    /// <seealso cref="metaDocumentSet"/>
    /// <seealso cref="metaDocument"/>
    public abstract class deliveryUnitItem : IObjectWithNameAndDescription  // : IObjectWithNameAndDescription
    {
       

        public void setRelPath(IRenderExecutionContext context)
        {
            string relPath = context.directoryScope.getRelativePathToParent(context.directoryRoot);
            relPath = relPath.getWebPathBackslashFormat();
            if (relPath == "/") relPath = "";

            context.data[templateFieldBasic.root_relpath] = relPath;

        }

        public string getFolderPathForLinkRegistry(IRenderExecutionContext context)
        {
            string folderPath = "";
            //IMetaContent mc = context.scope.parent as IMetaContent;

            //if (mc != null)
            //{
            //    folderPath = mc.path;
            //}
            //else
            //{
                

            //}

            folderPath = context.scope.path;

            context.data.getProperString(folderPath, templateFieldBasic.path_folder, templateFieldBasic.document_path, templateFieldBasic.documentset_path);

            return folderPath;
        }

        /// <summary>
        /// Used just for double include check - normally its null
        /// </summary>
        public FileInfo sourceFileInfo { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public FileInfo output_fileinfo { get; protected set; }


        private string _includeSourceFolder;
        /// <summary>
        /// 
        /// </summary>
        public string includeSourceFolder
        {
            get {
                if (imbSciStringExtensions.isNullOrEmpty(_includeSourceFolder)) _includeSourceFolder = deliveryUnitBuilder.themepath;

                return _includeSourceFolder;

            }
            set { _includeSourceFolder = value; }
        }


        public virtual void prepareOperation(IRenderExecutionContext context)
        {
            string src = sourcepath.toPath(includeSourceFolder, context.data);
            DirectoryInfo dir = context.directoryScope;
            if (location == deliveryUnitItemLocationBase.globalDeliveryResource)
            {
                dir = context.directoryRoot;
            }
            

            if (flags.HasFlag(deliveryUnitItemFlags.useTemplate))
            {
                template = openBase.openFileToString(src, true, false);
            }


            if (flags.HasFlag(deliveryUnitItemFlags.useCopy)) {

                string trg = outputpath.toPath(context.directoryRoot.FullName, context.data);

                output_fileinfo = trg.getWritableFile(getWritableFileMode.overwrite);
                if (sourceFileInfo == null)
                {

                }
                else
                {
                    if (File.Exists(sourceFileInfo.FullName))
                    {
                        File.Copy(sourceFileInfo.FullName, output_fileinfo.FullName, true);

                        context.regFileOutput(output_fileinfo.FullName, output_fileinfo.Extension, description);
                    } else
                    {
                        context.log("File [" + sourceFileInfo.FullName + "] not found.");
                    }

                    //context.saveFileOutput(output, output_fileinfo.FullName, "css", description);
                }
            }

        }

        public virtual void reportFinishedOperation(IRenderExecutionContext context)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public string template { get; set; } = "";


        /// <summary>
        /// 
        /// </summary>
        public string filenameTemplate { get; set; } = "{{{name}}}.{{{ext}}}";

        /// <summary>
        /// Gets the out file path using template
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="content">The content.</param>
        /// <param name="pc">The pc.</param>
        /// <param name="format">The format.</param>
        /// <param name="dir">The dir.</param>
        /// <returns></returns>
        public string getOutFilePath(IRenderExecutionContext context, IMetaContentNested content, PropertyCollection pc, reportOutputFormatName format=reportOutputFormatName.none, DirectoryInfo dir=null)
        {
            if (pc == null) pc = new PropertyCollection();

            if (content == null) content = context.scope as IMetaContentNested;
            if (dir == null) dir = context.directoryScope;

            if (format == reportOutputFormatName.none)
            {
                if (!pc.ContainsKey("ext"))
                {
                    pc.Add("ext", "");
                } else
                {
                    pc["ext"] = "txt";
                }
            } else
            {
                if (!pc.ContainsKey("ext"))
                {
                    pc.Add("ext", format.getFilenameExtension());
                } else
                {
                    pc["ext"] = format.getFilenameExtension();
                }
            }
            if (content != null)
            {
                if (!pc.ContainsKey("name"))
                {
                    pc.Add("name", content.name.getFilename());
                }
                else
                {
                    pc["name"] = content.name.getFilename();
                }
                //pc.Add("name", content.name);
            }

            string path = filenameTemplate.applyToContent(false, pc);

            if (outputpath != null)
            {
                if (!outputpath.directoryPath.isNullOrEmpty())
                {
                    path = outputpath.directoryPath.add(path, "\\");
                }
            }

            path = dir.FullName.add(path, "\\");


            return path;
        }


        /// <summary>
        /// 
        /// </summary>
        protected string runstampRecord { get; set; } = "";


        /// <summary>
        /// Determines whether the specified runstamp is executed.
        /// </summary>
        /// <param name="runstamp">The runstamp.</param>
        /// <param name="writeAsExecuted">if set to <c>true</c> [write as executed].</param>
        /// <returns>
        ///   <c>true</c> if the specified runstamp is executed; otherwise, <c>false</c>.
        /// </returns>
        public bool isExecuted(string runstamp, bool writeAsExecuted=false)
        {
            if (imbSciStringExtensions.isNullOrEmpty(runstampRecord)) runstampRecord = runstamp;
            if (runstampRecord == runstamp)
            {
                return true;
            } else
            {
                if (writeAsExecuted) runstampRecord = runstamp;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<reportElementLevel> levels { get; protected set; } = new List<reportElementLevel>();


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; } = "";


        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; } = "";


        /// <summary>
        /// Initializes a new instance of the <see cref="deliveryUnitItem"/> class.
        /// </summary>
        /// <param name="__itemType">Type of the item.</param>
        protected deliveryUnitItem(deliveryUnitItemType __itemType)
        {
            itemType = __itemType;
            name = GetType().Name + "_" + imbStringGenerators.getRandomString(8);
            description = __itemType.ToString();
        }


        protected void deliveryUnitItemSetup (deliveryUnitItemLocationBase __location,  deliveryUnitItemFlags __flags)
        {
            location = __location;
            flags = __flags;
        }

        protected void setupForTemplatedItem(string __sourcepath)
        {
            sourcepath = new filepath(__sourcepath);
        }

        protected void setupForGeneratedItem(string __outputFilename)
        {
            outputpath = new filepath(__outputFilename);
        }


        /// <summary>
        /// The output file path - relative to deliveryInstance output path: <see cref="imbSCI.Reporting.reporting.render.IRenderExecutionContext.directoryRoot"/>, may include subfolders, filename template and extension 
        /// </summary>
        public filepath outputpath { get; protected set; } = new filepath();


        /// <summary>
        /// The input file/folder path - relative to <see cref="Directory.GetCurrentDirectory"/> 
        /// </summary>
        public filepath sourcepath { get; protected set; } = new filepath();


        /// <summary>
        /// 
        /// </summary>
        public deliveryUnitItemType itemType { get; set; } = deliveryUnitItemType.none;


        /// <summary>
        /// 
        /// </summary>
        public deliveryUnitItemLocationBase location { get; set; } = deliveryUnitItemLocationBase.localResource;


        /// <summary>
        /// 
        /// </summary>
        public deliveryUnitItemFlags flags { get; set; }
    }

}