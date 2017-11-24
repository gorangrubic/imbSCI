namespace imbSCI.Reporting.meta.blocks
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
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Attached file
    /// </summary>
    /// <seealso cref="MetaContainerNestedBase" />
    public class metaAttachmentBlock : MetaContainerNestedBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string includeFilePath { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string filename { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string caption { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string templateNeedle { get; set; }


        #region ----------- Boolean [ isDataTemplate ] -------  []
        private bool _isDataTemplate = false;
        /// <summary>
        /// 
        /// </summary>

        public bool isDataTemplate
        {
            get { return _isDataTemplate; }
            set { _isDataTemplate = value; OnPropertyChanged("isDataTemplate"); }
        }
        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="metaAttachmentBlock"/> class.
        /// </summary>
        /// <param name="__includeFilePath">The include file path.</param>
        /// <param name="__filename">The filename.</param>
        /// <param name="__caption">The caption.</param>
        /// <param name="__description">The description.</param>
        /// <param name="__templateNeedle">The template needle.</param>
        /// <param name="__isDataTemplate">if set to <c>true</c> [is data template].</param>
        public metaAttachmentBlock(string __includeFilePath, string __filename, string __caption, string __description, string __templateNeedle="", bool __isDataTemplate=false)
        {
            includeFilePath = __includeFilePath;
            filename = __filename;
            caption = __caption;
            description = __description;
            templateNeedle = __templateNeedle;
            isDataTemplate = __isDataTemplate;
        }

        public override docScript compose(docScript script = null)
        {

            if (templateNeedle.isNullOrEmpty())
            {   
                script.AppendFile(includeFilePath, filename, isDataTemplate);
            } else
            {
                script.AppendFileTemplated(includeFilePath, templateNeedle, filename, isDataTemplate, false);
            }
            if (!caption.isNullOrEmpty())
            {

                script.AppendHeading(caption, 4);

                script.AppendLine(description);

                script.AppendLink(filename, filename, description, appendLinkType.link);
            }
            
            return script;
        }

        public override void construct(object[] resources)
        {

        }

        //public override IMetaContentNested SearchForChild(string needle)
        //{
        //    throw new NotImplementedException();
        //}
    }

}