


//using FSharp.Markdown.Pdf;

namespace imbSCI.Core.reporting
{
    using imbSCI.Core.extensions.io;
    using System;
    using System.IO;

    public static class reportOutputQuickTools
    {

        /// <summary>
        /// Saves the markdown content into PDF.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="saveTxtVersionToo">if set to <c>true</c> [save text version too].</param>
        /// <returns></returns>
        public static FileInfo saveMarkdownToPDF(this String content, String filepath, Boolean saveTxtVersionToo=false)
        {
            //filepath = filepath.EnsureEndsWith(".pdf");


            FileInfo fi = null; // filepath.getWritableFile();

            //MarkdownPdf.Transform(content, fi.FullName);


            if (saveTxtVersionToo || true)
            {
                filepath = Path.GetFileNameWithoutExtension(fi.Name) + ".txt";
                fi = filepath.getWritableFile();
                content.saveStringToFile(fi.FullName);
            }

            return fi;
        }

    }

}