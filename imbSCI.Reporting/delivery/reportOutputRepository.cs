namespace imbSCI.Reporting.delivery
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
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render;
    using imbSCI.Core.reporting.render.config;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="resourceDictionaryBase{T}.Object}" />
    public class reportOutputRepository: resourceDictionaryBase<reportOutputUnit>
    {

        public void setOutputUnit(builderSettings settings, object output,string logicalPath, reportElementLevel level)
        {
            var format = settings.forms[level].fileformat;
            string tmp_name = logicalPath.getPathVersion(-1, "\\", true);
            string tmp_path = Path.GetDirectoryName(logicalPath);
            string filename = settings.formats.getFilename(tmp_name, format);
            form = settings.forms[level].form;

            reportOutputUnit tmp = null;
            if (form == reportOutputForm.folder)
            {
                tmp_path = imbSciStringExtensions.add(tmp_path, tmp_name, "\\");
                tmp = new reportOutputUnit(tmp_path, tmp_name, format, form, output, level);
            } else if (form == reportOutputForm.file)
            {

                tmp_path = imbSciStringExtensions.add(tmp_path, filename, "\\");
                tmp = new reportOutputUnit(tmp_path, tmp_name, format, form, output, level);
            } else
            {
              //  tmp = new reportOutputUnit(tmp_path, tmp_name, format, form, output, level);
            }

            Add(logicalPath, tmp);
        }


        public void saveAll(IDocumentRender render)
        {
            foreach (KeyValuePair<string, reportOutputUnit> pair in this)
            {
                var format = pair.Value.fileformat;

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        public string setOutputRootPath(DirectoryInfo __root)
        {
            basePath = __root.FullName;
            return rebuild(name);
        }

        public string rebuild(string __name)
        {
            directoryPath = basePath; 
            directoryPath = imbSciStringExtensions.add(directoryPath, name, "\\");
            return directoryPath;
        }

        protected override reportOutputUnit getDefault()
        {
            return new reportOutputUnit();
        }

        public reportOutputRepository(DirectoryInfo __root, string __name)
        {
            name = __name;
            
            setOutputRootPath(__root);
        }

        /// <summary>
        /// 
        /// </summary>
        public reportOutputForm form { get; set; } = reportOutputForm.unknown;


        /// <summary>
        /// 
        /// </summary>
        public string basePath { get; set; }


        #region --- directoryPath ------- path - directory part 
        private string _directoryPath = "";
        /// <summary>
        /// path - directory part
        /// </summary>
        public string directoryPath
        {
            get
            {
                return _directoryPath;
            }
            set
            {
                _directoryPath = value;
                OnPropertyChanged("directoryPath");
            }
        }
        #endregion

    }

}