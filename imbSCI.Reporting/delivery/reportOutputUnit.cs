namespace imbSCI.Reporting.delivery
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
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// One unit of output
    /// </summary>
    /// <seealso cref="imbSCI.Core.reporting.format.reportElementFormSet" />
    public class reportOutputUnit: reportElementFormSet
    {
        public reportOutputUnit()
        {
            

        }

        public reportOutputUnit(string __path, string __name, reportOutputFormatName __format, reportOutputForm __form, object __output, reportElementLevel __level)
        {
            path = __path;
            name = __name;
            fileformat = __format;
            form = __form;
           // builder = __builder;
            output = __output;
            level = __level;

        }


        public void saveOutput()
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }


        #region --- path ------- Logical level path - used for search and data binding 
        private string _path;
        /// <summary>
        /// Logical level path - used for search and data binding
        /// </summary>
        public string path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }
        #endregion


        #region --- directoryPath ------- path - directory part 
        private string _directoryRelativePath = "";
        /// <summary>
        /// path - directory part
        /// </summary>
        public string directoryRelativePath
        {
            get
            {
                return _directoryRelativePath;
            }
            set
            {
                _directoryRelativePath = value;
                OnPropertyChanged("directoryRelativePath");
            }
        }
        #endregion


        #region --- filenamePath ------- path part - with filename 
        private string _filenamePath;
        /// <summary>
        /// path part - with filename
        /// </summary>
        public string filenamePath
        {
            get
            {
                return _filenamePath;
            }
            set
            {
                _filenamePath = value;
                OnPropertyChanged("filenamePath");
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public reportOutputFormatName fileformat { get; set; } = reportOutputFormatName.unknown;


        #region --- level ------- level 
        private reportElementLevel _level;
        /// <summary>
        /// level
        /// </summary>
        public reportElementLevel level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                OnPropertyChanged("level");
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public reportOutputForm form { get; set; } = reportOutputForm.unknown;

        //private IDocumentRender _builder;
        ///// <summary>
        ///// reference to builder
        ///// </summary>
        //public IDocumentRender builder
        //{
        //    get { return _builder; }
        //    set { _builder = value; }
        //}



        #region --- output ------- typed output made by IRender instance 
        private object _output;
        /// <summary>
        /// typed output made by IRender instance
        /// </summary>
        public object output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                OnPropertyChanged("output");
            }
        }
        #endregion

    }

}