namespace imbSCI.Core.files.job
{
    using System;
    using System.ComponentModel;
    using imbSCI.Core.extensions.text;
    using imbSCI.Data.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.syntax.data.files;

    /// <summary>
    /// 2017: Polazna klasa za ACE radni projekat / Job. Primenjuje se na ncFileJob ali ima ulogu i u imbVeles projektu.
    /// </summary>
    public abstract class aceFileJobBase : dataBindableBase, IAceFileJobBase
    {

        public aceFileJobBase()
        {
            
        }

        private String _name = "ncJob"; // = new String();
        private fileTargetListSettings _scanFiles = new fileTargetListSettings();
        private Int32 _processTakeSize = 50; // = new Int32();

        /// <summary>
        /// Name for this Job - used for filename and for menu navigation
        /// </summary>
        // [XmlIgnore]
        [Category("ncFileModifyJob")]
        [DisplayName("Job Name")]
        [Description("Name for this Job - used for filename and menu navigation")]
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                // Boolean chg = (_name != value);
                _name = value;
                OnPropertyChanged("name");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Podesavanja skeniranja fajla
        /// </summary>
        // [XmlIgnore]
        [Category("ncFileModifyJob")]
        [DisplayName("NC files")]
        [Description("Podesavanja skeniranja fajla")]
        public fileTargetListSettings scanFiles
        {
            get
            {
                return _scanFiles;
            }
            set
            {
                // Boolean chg = (_scanFiles != value);
                _scanFiles = value;
                OnPropertyChanged("scanFiles");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Number of files to be processed in one processing take; 0 and -1 will set program default
        /// </summary>
        // [XmlIgnore]
        [Category("ncFileModifyJob")]
        [DisplayName("Process take")]
        [Description("Number of files to be processed in one processing take; 0 and -1 will set program default")]
        public Int32 processTakeSize
        {
            get
            {
                return _processTakeSize;
            }
            set
            {
                // Boolean chg = (_processTakeSize != value);
                _processTakeSize = value;
                OnPropertyChanged("processTakeSize");
                // if (chg) {}
            }
        }

        /// <summary>
        /// Generise string izvestaj o trenutnom poslu
        /// </summary>
        /// <returns></returns>
        public virtual String explainJob()
        {
            String output = "";
            output = output.log(String.Format("Job name [{0}] at [{1}]", this.name, this.name.getFilename(".job")));

            String scanOutput = "It will look into path [{0}] for files with extension [{1}]";

            if (scanFiles.doIncludeSubFolders)
            {
                scanOutput += " including all subfolders.";
            }
            else
            {
                scanOutput += " excluding subfolders.";
            }

            output = output.log(String.Format(scanOutput, scanFiles.path, scanFiles.fileExtension));

           // output = output.log(backupTool.explainBackup(scanFiles.backup));
            return output;
        }
    }
}