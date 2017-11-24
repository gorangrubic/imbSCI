namespace imbSCI.Reporting.script.exeAppenders
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

    /// <summary>
    /// ToolKit that supports <c>exeAppend</c> library
    /// </summary>
    public static class exeAppendContentExtensions
    {
        /// <summary>
        /// Gets the search pattern.
        /// </summary>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        public static List<string> getExtensionList(this exeAppendTemplateOptions flags)
        {
            List<string> output = new List<string>();
            List<exeAppendTemplateOptions> flgs = flags.getEnumListFromFlags<exeAppendTemplateOptions>();
            foreach (exeAppendTemplateOptions tl in flgs)
            {
                if (tl.ToString().EndsWith("Template"))
                {
                    string include = tl.ToString().removeEndsWith("Template");
                    output.Add(include);
                }
            }

            return output;
        }

        /// <summary>
        /// Gets the search pattern.
        /// </summary>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        public static string getSearchPattern(this exeAppendTemplateOptions flags)
        {
            string output = "";
            List<exeAppendTemplateOptions> flgs = flags.getEnumListFromFlags<exeAppendTemplateOptions>();
            foreach (exeAppendTemplateOptions tl in flgs)
            {
                if (tl.ToString().EndsWith("Template"))
                {
                    string include = tl.ToString().removeEndsWith("Template").add("*", ".");
                    output = output.add(include, "|");
                }
            }
            
            return output;
        }

        /// <summary>
        /// Directories the copy.
        /// </summary>
        /// <param name="sourceDirName">Name of the source dir.</param>
        /// <param name="destDirName">Name of the dest dir.</param>
        /// <param name="copySubDirs">if set to <c>true</c> [copy sub dirs].</param>
        /// <exception cref="DirectoryNotFoundException">Source directory does not exist or could not be found: "
        ///                     + sourceDirName</exception>
        public static void DirectoryCopy(this string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    subdir.FullName.DirectoryCopy(temppath, copySubDirs);
                }
            }
        }
    }

}