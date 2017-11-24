namespace imbSCI.Reporting.includes
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    #endregion

    /// <summary>
    /// Tip include fajla
    /// </summary>
    [imb(imbAttributeName.collectionPrimaryKey, "name")]
    public class reportIncludeFile : imbReportingBindable
    {
        public reportIncludeFile()
        {
        }

        public reportIncludeFile(string _sourcePath, reportIncludeFileType __fileType = reportIncludeFileType.cssStyle,
                                 bool __doLocalCopy = true)
        {
            sourceFilePath = _sourcePath;
            name = Path.GetFileNameWithoutExtension(_sourcePath);
            extension = Path.GetExtension(_sourcePath);
            filetype = __fileType;
            doLocalCopy = __doLocalCopy;
            filename = name + extension;

            localOutputPath = filename;
        }

        #region --- extension ------- ekstenzija

        private string _extension;

        /// <summary>
        /// ekstenzija
        /// </summary>
        public string extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                OnPropertyChanged("extension");
            }
        }

        #endregion

        #region -----------  name  -------  [file name izlaznog fajla - ekstenzija ostaje ista kao ulazna]

        private string _name; // = new String();

        /// <summary>
        /// file name izlaznog fajla - ekstenzija ostaje ista kao ulazna
        /// </summary>
        // [XmlIgnore]
        [Category("reportIncludeFile")]
        [DisplayName("name")]
        [Description("file name izlaznog fajla (bez ekstenzije) - ekstenzija ostaje ista kao ulazna")]
        public string name
        {
            get { return _name; }
            set
            {
                // Boolean chg = (_name != value);
                _name = value;
                OnPropertyChanged("name");
                // if (chg) {}
            }
        }

        #endregion

        #region --- filename ------- ime fajla zajedno sa ekstenzijom

        private string _filename;

        /// <summary>
        /// ime fajla zajedno sa ekstenzijom
        /// </summary>
        public string filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnPropertyChanged("filename");
            }
        }

        #endregion

        #region --- localOutputPath ------- lokalna putanja u izlaznom folderu, sve sa filename.extension na kraju

        private string _localOutputPath;

        /// <summary>
        /// lokalna putanja u izlaznom folderu, sve sa filename.extension na kraju
        /// </summary>
        public string localOutputPath
        {
            get { return _localOutputPath; }
            set
            {
                _localOutputPath = value;
                OnPropertyChanged("localOutputPath");
            }
        }

        #endregion

        #region -----------  sourceFilePath  -------  [putanja ka fajlu koji treba da se ubaci pored izvestaja]

        private string _sourceFilePath; // = new String();

        /// <summary>
        /// putanja ka fajlu koji treba da se ubaci pored izvestaja
        /// </summary>
        // [XmlIgnore]
        [Category("reportIncludeFile")]
        [DisplayName("sourceFilePath")]
        [Description("putanja ka fajlu koji treba da se ubaci pored izvestaja")]
        public string sourceFilePath
        {
            get { return _sourceFilePath; }
            set
            {
                // Boolean chg = (_sourceFilePath != value);
                _sourceFilePath = value;
                OnPropertyChanged("sourceFilePath");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  filetype  -------  [Tip fajla koji treba da se ubaci]

        private reportIncludeFileType _filetype; // = new reportIncludeFileType();

        /// <summary>
        /// Tip fajla koji treba da se ubaci
        /// </summary>
        // [XmlIgnore]
        [Category("reportIncludeFile")]
        [DisplayName("filetype")]
        [Description("Tip fajla koji treba da se ubaci")]
        public reportIncludeFileType filetype
        {
            get { return _filetype; }
            set
            {
                // Boolean chg = (_filetype != value);
                _filetype = value;
                OnPropertyChanged("filetype");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  doLocalCopy  -------  [Da li treba da napravi lokalnu kopiju fajla koji se ubacuje]

        private bool _doLocalCopy; // = new Boolean();

        /// <summary>
        /// Da li treba da napravi lokalnu kopiju fajla koji se ubacuje
        /// </summary>
        // [XmlIgnore]
        [Category("reportIncludeFile")]
        [DisplayName("doLocalCopy")]
        [Description("Da li treba da napravi lokalnu kopiju fajla koji se ubacuje")]
        public bool doLocalCopy
        {
            get { return _doLocalCopy; }
            set
            {
                // Boolean chg = (_doLocalCopy != value);
                _doLocalCopy = value;
                OnPropertyChanged("doLocalCopy");
                // if (chg) {}
            }
        }

        #endregion
    }
}