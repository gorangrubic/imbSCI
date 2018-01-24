using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.text;
using imbSCI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace imbSCI.Core.files.folders
{

    public static class folderNodeFileDescriptorTools
    {
        public static String FileDescriptionFormat { get; set; } = "[{0,-50}] {1}";

        public static folderNodeFileDescriptor GetFileDescription(this folderNode folder, String filename, String fileDescription)
        {
            if (fileDescription.isNullOrEmpty())
            {
                String fileClean = Path.GetFileNameWithoutExtension(filename);
                String fileTitle = fileClean.imbTitleCamelOperation(true);

                String ext = Path.GetExtension(filename).Trim('.').ToLower();



                switch (ext)
                {
                    case "json":
                        fileDescription = "JSON Serialized Data Object";
                        break;
                    case "xml":
                        fileDescription = "XML Serialized Data Object";
                        if (filename.ContainsAny(new String[] { "setup", "Setup", "config", "Config", "settings", "Settings" }))
                        {
                            fileTitle = fileClean.imbTitleCamelOperation(true);
                            fileDescription = "Serialized configuration [" + fileTitle + "] object";
                        }

                        break;
                    case "txt":
                        fileDescription = "Plain text file";
                        if (filename.StartsWith("ci_"))
                        {
                            fileClean = fileClean.removeStartsWith("ci_");
                            fileTitle = fileClean.imbTitleCamelOperation(true);
                            fileDescription = "Column / Fields meta information for data table [" + fileTitle + "] export";
                        }
                        if (fileClean == "note")
                        {
                            fileDescription = "Relevant notes on [" + folder.caption + "] in markdown/text format";
                        }
                        if (fileClean.Contains("error"))
                        {
                            fileDescription = "Error record(s)";
                        }
                        if (filename == "directory_readme.txt")
                        {
                            fileDescription = "Description of directory content (this file)";
                        }
                        break;
                    case "csv":
                        fileDescription = "Comma Separated Value data dump";
                        if (filename.StartsWith("dc_"))
                        {
                            fileClean = fileClean.removeStartsWith("dc_");
                            fileTitle = fileClean.imbTitleCamelOperation(true);
                            fileDescription = "Clean data CSV version of data table [" + fileTitle + "] export";
                        }
                        break;
                    case "xls":
                    case "xlsx":
                        fileDescription = "Excel spreadsheet";
                        if (filename.StartsWith("dt_"))
                        {
                            fileClean = fileClean.removeStartsWith("dt_");
                            fileTitle = fileClean.imbTitleCamelOperation(true);
                            fileDescription = "Excel spreadsheet report on [" + fileTitle + "] data table";
                        }
                        break;
                    case "md":
                        fileDescription = "Markdown document";
                        break;
                    case "bin":
                        fileDescription = "Binary Serialized Data Object";
                        break;
                    case "dgml":
                        fileDescription = "Serialized graph in Directed-Graph Markup Language format";
                        break;
                    case "html":
                        fileDescription = "HTML Document";
                        break;
                    case "log":
                        fileDescription = "Log output plain text file";
                        break;
                    default:
                        fileDescription = ext.ToUpper() + " file";
                        break;
                }

                

            }
            fileDescription = String.Format(FileDescriptionFormat, filename, fileDescription);

            var desc =  new folderNodeFileDescriptor();
            desc.filename = filename;
            desc.description = fileDescription;
            return desc;
        }
    }

    public class folderNodeFileDescriptor
    {
        public folderNodeFileDescriptor()
        {

        }

        public String filename { get; set; }

        public String description { get; set; }
    }
}
