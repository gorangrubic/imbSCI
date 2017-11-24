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
    using imbSCI.Core.reporting.extensions;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;

    /// <summary>
    /// exeAppend unit for content delivery, injection, transformation and link creation
    /// </summary>
    /// <seealso cref="exeAppendBase" />
    /// <seealso cref="IExeAppend" />
    public class exeAppendTemplatedBundle:exeAppendBase, IExeAppend
    {
        public enum targetOperaton
        {
            deployInFolder,
            deployInArchive,
            deployInDocument,
        }


        private targetOperaton _operation = targetOperaton.deployInFolder;
        /// <summary> </summary>
        public targetOperaton operation
        {
            get
            {
                return _operation;
            }
            protected set
            {
                _operation = value;
                OnPropertyChanged("operation");
            }
        }


        private string _targetExtension = "";
        /// <summary> </summary>
        public string targetExtension
        {
            get
            {
                return _targetExtension;
            }
            protected set
            {
                _targetExtension = value;
                OnPropertyChanged("targetExtension");
            }
        }


        /// <summary>
        /// The static data main
        /// </summary>
        public const string STATIC_DATA_MAIN = "main";
        /// <summary>
        /// The static data second
        /// </summary>
        public const string STATIC_DATA_SECOND = "second";

        /// <summary>
        /// Initializes a new instance of the <see cref="exeAppendTemplatedBundle"/> class.
        /// </summary>
        /// <param name="targetpath">The targetpath.</param>
        /// <param name="pce">The pce.</param>
        public exeAppendTemplatedBundle(string targetpath, PropertyCollectionExtended pce)
        {
            if (targetpath.Contains("{{{"))
            {
                targetpath = targetpath.applyToContent(false, pce).getCleanFilepath();
            }

            staticData.Add(STATIC_DATA_MAIN, pce);

            if (Path.GetFileName(targetpath).isNullOrEmpty())
            {
                // it is directory
                target = Directory.CreateDirectory(targetpath);
                operation = targetOperaton.deployInFolder;
               
            } else 
            {
                targetExtension = Path.GetExtension(targetpath).Trim('.');
                switch (targetExtension)
                {
                    case "zip":
                        operation = targetOperaton.deployInArchive;
                        break;
                    case "odt":
                        operation = targetOperaton.deployInDocument;
                        break;
                    
                }
                target = Directory.CreateDirectory(Path.GetDirectoryName(targetpath));
                FileInfo fi = targetpath.getWritableFile(getWritableFileMode.overwrite);


                targetFilename = fi.FullName.removeStartsWith(target.FullName);
                
            }
            
        }


        private string _targetFilename = "";
        /// <summary> </summary>
        protected string targetFilename
        {
            get
            {
                return _targetFilename;
            }
            set
            {
                _targetFilename = value;
                OnPropertyChanged("targetFilename");
            }
        }


        private DirectoryInfo _target;
        /// <summary>Target for content deployment</summary>
        protected DirectoryInfo target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                OnPropertyChanged("target");
            }
        }


        private List<exeAppendTemplateBundleItem> _items = new List<exeAppendTemplateBundleItem>();
        /// <summary> </summary>
        protected List<exeAppendTemplateBundleItem> items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("items");
            }
        }




        public exeAppendTemplateBundleItem Add(exeAppendTemplateOptions __options, string __filePath, PropertyCollectionExtended __data)
        {
            var tmp = new exeAppendTemplateBundleItem(__options, __filePath, __data);

            items.Add(tmp);
            return tmp;
        }



        public override IExeAppend execute(IRenderExecutionContext context, ITextRender render)
        {
            

            foreach (exeAppendTemplateBundleItem item in items)
            {
                List<string> files = item.getFromSource(context, render, target, targetFilename);
                item.setToTarget(files, context, operation, target, targetFilename);
            }

            return this;
        }
    }

}