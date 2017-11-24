namespace imbSCI.Reporting.includes
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
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
    using imbSCI.Data.collection;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    #endregion

    /// <summary>
    /// imbCollectionMeta namenska kolekcija za  reportIncludeFile
    /// </summary>
    public class reportIncludeFileCollection : aceDictionaryCollection<reportIncludeFile>
    {
        public reportIncludeFileCollection() : base()
        {
        }


        /// <summary>
        /// Dodaje novi fajl 
        /// </summary>
        /// <param name="__path"></param>
        /// <param name="__type"></param>
        public void AddFile(string __path, reportIncludeFileType __type = reportIncludeFileType.unknown)
        {
            if (__type == reportIncludeFileType.unknown)
            {
                __type = __path.getIncludeFileTypeByExtension();
            }

///            Directory.GetCurrentDirectory()

            string dirName = Path.GetDirectoryName(__path);
            //if (imbSciStringExtensions.isNullOrEmpty(dirName))
            //{
            //    __path = outputFolder.resources.ToString();
            //    DirectoryInfo di = new DirectoryInfo(__path);
            //    __path = di.FullName;
            //}

            //if (!Path.IsPathRooted(__path))
            //{
            //  //  __path = Path.Combine(imbCoreManager.runtimePath, __path);
            //}
            bool __lc = false;

            switch (__type)
            {
                case reportIncludeFileType.cssStyle:
                    __lc = true;
                    break;
            }

            reportIncludeFile rf = new reportIncludeFile(__path, __type, __lc);
            Add(rf);
        }


        /// <summary>
        /// Kopira sve fajlove iz kolekcije na datu putanju
        /// </summary>
        /// <param name="outputPath"></param>
        public void prepareIncludes(string outputPath)
        {
            string dirPath = Path.GetDirectoryName(outputPath);
            dirPath = dirPath.ensureEndsWith("\\");
            //DirectoryInfo directory = new DirectoryInfo(outputPath);

            foreach (reportIncludeFile inc in Values)
            {
                if (inc.doLocalCopy)
                {
                    fileOpsBase.copyFile(inc.sourceFilePath, dirPath, inc.filename);
                }


                switch (inc.filetype)
                {
                    case reportIncludeFileType.cssStyle:
                        //fileOpsBase.copyFile(inc.sourceFilePath, dirPath, inc.filename);
                        break;
                    case reportIncludeFileType.emailAttachmentStatic:
                        fileOpsBase.copyFile(inc.sourceFilePath, dirPath, inc.filename);
                        break;
                }


                //logSystem.log(
                //    "Report included file: copy[" + inc.doLocalCopy + "] source[" + inc.sourceFilePath + "] ",
                //    logType.Notification);
            }
        }

        public void addHTMLMetaTags(StringBuilder isb)
        {
            foreach (reportIncludeFile inc in Values)
            {
                switch (inc.filetype)
                {
                    case reportIncludeFileType.cssStyle:
                        string _ins = "<link href=\"" + inc.localOutputPath +
                                      "\" rel=\"stylesheet\" type=\"text/css\"/>";

                        isb.AppendLine(_ins);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}