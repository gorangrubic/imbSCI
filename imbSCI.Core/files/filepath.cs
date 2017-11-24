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


namespace imbSCI.Core.files
{
    using imbSCI.Core.reporting.extensions;
    using System.Data;
    using System.IO;

    /// <summary>
    /// Information about filepath
    /// </summary>
    public class filepath
    {
        public filepath(String path="")
        {
            setup(path);
        }

        public String toPath(String rootpath="")
        {
            String output = rootpath;

            output = output.add(directoryPath.add(filename.add(extension, "."), "\\"), "\\");
            return output;
        }

        public String toPathWithExtension(String rootpath = "", String customExtension="")
        {
            String output = rootpath;
            if (customExtension.isNullOrEmpty()) customExtension = extension;

            output = output.add(directoryPath.add(filename.add(customExtension, "."), "\\"), "\\");
            return output;
        }

        /// <summary>
        /// Returns the path with data applied
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public String toPath(String rootPath, PropertyCollection data)
        {
            String output = ""; // directoryPath.ensureStartsWith(rootPath);

          output = output.add(directoryPath.add(filename.add(extension, "."), "\\"), "\\");
            output = output.applyToContent(false, data);

            output = output.ensureStartsWith(imbSciStringExtensions.ensureEndsWith(rootPath, "\\"));

            return output;
        }

        public void setup(String path)
        {
            if (path.isNullOrEmpty())
            {
                return;
            }

            isRooted = Path.IsPathRooted(path);
            
            filename = Path.GetFileNameWithoutExtension(path);
            extension = Path.GetExtension(path);
            directoryPath = Path.GetDirectoryName(path);
        }


        private Boolean _isRooted;
        /// <summary>
        /// 
        /// </summary>
        public Boolean isRooted
        {
            get { return _isRooted; }
            protected set { _isRooted = value; }
        }


        private filepathflags _flags;
        /// <summary>
        /// 
        /// </summary>
        public filepathflags flags
        {
            get { return _flags; }
            protected set { _flags = value; }
        }



        private String _filename;
        /// <summary>
        /// 
        /// </summary>
        public String filename
        {
            get { return _filename; }
            protected set { _filename = value; }
        }

        public String filenameWithExtension
        {
            get
            {
                return filename.add(extension, ".");
            }
        }


        private String _extension;
        /// <summary>
        /// 
        /// </summary>
        public String extension
        {
            get { return _extension; }
            protected set { _extension = value; }
        }


        private String _directoryPath;
        /// <summary>
        /// 
        /// </summary>
        public String directoryPath
        {
            get { return _directoryPath; }
            protected set { _directoryPath = value; }
        }



    }
}
