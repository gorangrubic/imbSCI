namespace imbSCI.Reporting.resources
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using imbSCI.Reporting.meta.theme;
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
    using imbSCI.Reporting.script;

    /// <summary>
    /// Manager of reporting resources
    /// </summary>
    public static class reportingCoreManager
    {
        /// <summary>
        /// Should it produce verbose log output on Meta report model notifications
        /// </summary>
        public static bool doVerboseLog { get; } = false;


        /// <summary>
        /// Loads <c>BuildAction</c> Content files from two reserved folders. 
        /// </summary>
        /// <remarks>
        /// Targeted file must be set: BuildAction = Content, Copy Local = Always
        /// </remarks>
        /// <param name="rdir">Folder with the file</param>
        /// <param name="foldername">If there is subfolder - name it</param>
        /// <param name="filename">Full filename, including extension</param>
        /// <returns></returns>
        public static string loadReportResourceFile(this reportResourceFolders rdir, string filename, string foldername="")
        {
            string pathFormat = "/{0}/{2}/{1}";
            if (foldername.isNullOrEmpty())
            {
                pathFormat = "{0}{2}/{1}";
            }
            string path = string.Format(pathFormat, rdir.ToString(), filename, foldername);

            Uri uri = new Uri(path, UriKind.Relative);
            //StreamResourceInfo sri = Application.GetResourceStream(uri);
            //StreamReader sReader = new StreamReader(sri.Stream);
            
            string output = "";
            //  output = sReader.ReadToEnd();

            throw new NotImplementedException();

            return output;

        }





        /// <summary>
        /// Prepares this instance.
        /// </summary>
        public static void prepare()
        {
            metaDocumentThemeManager.prepare();
        }
    }
}
