using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using aceCommonTypes.colors;
using aceCommonTypes.extensions;
using aceCommonTypes.reporting;
using aceCommonTypes.reporting.render;
using imbReportingCore.interfaces;
using imbReportingCore.meta.document;
using imbReportingCore.meta.render;
using imbReportingCore.meta.theme;

namespace imbReportingCore.meta.render
{
    using aceCommonTypes.reporting.enums;
    using aceCommonTypes.reporting.render.core;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbStringBuilderBase" />
    public class composerContext:imbStringBuilderBase
    {

        /// <summary>
        /// ZA OTPIS Initializes a new instance of the <see cref="composerContext"/> class.
        /// </summary>
        /// <param name="__documentSet">The document set.</param>
        /// <param name="__theme">The theme.</param>
        /// <param name="__tasks">The tasks.</param>
        public composerContext(metaDocumentSet __documentSet, metaDocumentTheme __theme, IMetaComposer __composer, composerOutput __output, params composerPostTask[] __tasks)
        {
            AppendLine("Composer Context initiated");
            
            documentSet = __documentSet;
            theme = __theme;
            tasks = __tasks.getFlatList<composerPostTask>();
            composer = __composer;

            AppendLine("documentSet: " + __documentSet.name + " (" + __documentSet.GetType().Name + ")");
            Append("Theme: " + theme.name + " ", appendType.bypass, false);

            foreach (KeyValuePair<acePaletteRole, aceColorPalette> pair in theme.basicStyle.palletes)
            {
                Append("| " + pair.Key.ToString() + " > " + pair.Value.hexColor + " |", appendType.bypass, false);
            }
            AppendLine("Composer: " + __composer.GetType().Name + " (" + __composer.tR.GetType().Name + ")");

            AppendLine("Primary output: " + __output.ToString() + "");

            AppendLine("Postprocess task: " + __output.ToString() + tasks.toCsvInLine(","));

            
            select(__documentSet);
        }


        #region --- repositorium ------- Collection with all output files-documents stored by path rooted in documentSet 
        private composerRepositorium _repositorium = new composerRepositorium();
        /// <summary>
        /// Collection with all output files-documents stored by path rooted in documentSet
        /// </summary>
        public composerRepositorium repositorium
        {
            get
            {
                return _repositorium;
            }
            set
            {
                _repositorium = value;
                OnPropertyChanged("repositorium");
            }
        }
        #endregion

        public void select(IMetaContent __current)
        {

        }


        #region --- current ------- Currently selected meta content object 
        private IMetaContent _current;
        /// <summary>
        /// Currently selected meta content object
        /// </summary>
        public IMetaContent current
        {
            get
            {
                return _current;
            }
            set
            {
                if (value == null)
                {
                    AppendLine("Current meta content: supplied value is *null* - no change made");
                    return;
                }
                if (_current != value)
                {
                    if (_current != null)
                    {
                        AppendLine("Current meta content: from _[" + _current.name + "]_ to _[" + value.name + "]_");
                    } else
                    {
                        AppendLine("Current meta content: first deploy from *[null]* to _[" + value.name + "]_");
                    }
                } else
                {
                    AppendLine("Current meta content: no change, _value_ suplied is same as the current _[" + value.name + "]_");
                }
                _current = value;
                OnPropertyChanged("current");
            }
        }
        #endregion




        private IMetaComposer _composer;
        /// <summary>
        /// 
        /// </summary>
        public IMetaComposer composer
        {
            get { return _composer; }
            set { _composer = value; }
        }



        #region --- theme ------- Theme to use for the document 
        private metaDocumentTheme _theme;
        /// <summary>
        /// Theme to use for the document
        /// </summary>
        public metaDocumentTheme theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
                OnPropertyChanged("theme");
            }
        }
        #endregion


        #region --- documentSet ------- r
        private metaDocumentSet _documentSet;
        /// <summary>
        /// Reference to a document set to be exported
        /// </summary>
        public metaDocumentSet documentSet
        {
            get
            {
                return _documentSet;
            }
            set
            {
                _documentSet = value;
                OnPropertyChanged("documentSet");
            }
        }
        #endregion



        private composerGlobalData _data = new composerGlobalData();
        /// <summary>
        /// dynamic data collection to be applied over template tags
        /// </summary>
        // [XmlIgnore]
        [Category("metaExporterContext")]
        [DisplayName("data")]
        [Description("dynamic data collection to be applied over template tags")]
        public composerGlobalData data
        {
            get
            {
                return _data;
            }
            protected set
            {
                // Boolean chg = (_data != value);
                _data = value;
                OnPropertyChanged("data");
                // if (chg) {}
            }
        }


        #region -----------  tasks  -------  [Post processing tasks]
        private List<composerPostTask> _tasks = new List<composerPostTask>();
        /// <summary>
        /// Post processing tasks
        /// </summary>
        // [XmlIgnore]
        [Category("metaExporterSettings")]
        [DisplayName("tasks")]
        [Description("Post processing tasks")]
        public List<composerPostTask> tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                // Boolean chg = (_tasks != value);
                _tasks = value;
                OnPropertyChanged("tasks");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  resourcesPath  -------  [Path of resources folder - location to search for included images, css, js and other files]
        private String _resourcesPath = "\\resources";
        /// <summary>
        /// Path of resources folder - location to search for included images, css, js and other files
        /// </summary>
        // [XmlIgnore]
        [Category("metaDocumentTheme")]
        [DisplayName("resourcesPath")]
        [Description("Path of resources folder - location to search for included images, css, js and other files")]
        public String resourcesPath
        {
            get
            {
                return _resourcesPath;
            }
            set
            {
                // Boolean chg = (_resourcesPath != value);
                _resourcesPath = value;
                OnPropertyChanged("resourcesPath");
                // if (chg) {}
            }
        }
        #endregion


        #region -----------  outputPath  -------  [Path where report export starts]
        private String _outputPath = "\\reports";
        /// <summary>
        /// Path where report export starts
        /// </summary>
        // [XmlIgnore]
        [Category("metaExporterSettings")]
        [DisplayName("outputPath")]
        [Description("Path where report export starts")]
        public String outputPath
        {
            get
            {
                return _outputPath;
            }
            set
            {
                // Boolean chg = (_outputPath != value);
                _outputPath = value;
                OnPropertyChanged("outputPath");
                // if (chg) {}
            }
        }
        #endregion




        private Boolean _isComplete; // = new Boolean();
        /// <summary>
        /// Is export job completed
        /// </summary>
        // [XmlIgnore]
        [Category("metaExporterLog")]
        [DisplayName("isComplete")]
        [Description("Is export job completed")]
        public Boolean isComplete
        {
            get
            {
                return _isComplete;
            }
            set
            {
                // Boolean chg = (_isComplete != value);
                _isComplete = value;
                OnPropertyChanged("isComplete");
                // if (chg) {}
            }
        }

    }
}
