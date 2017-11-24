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

    /// <summary>
        /// Imports content from file or <see cref="imbSCI.Reporting.reporting.render.ITextRender"/> instance
        /// </summary>
        /// <seealso cref="MetaContainerNestedBase" />
        public class metaExternalBlock : MetaContainerNestedBase
    {
        /// <summary>
        /// Name for this instance
        /// </summary>
        public string title { get; set; } = "";

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public string description { get; set; } = "";


        public metaExternalBlock(string __includeFilePath, string __title, string undertitle)
        {
            title = __title;
            description = undertitle;
            includeFilePath = __includeFilePath;
        }

        public metaExternalBlock(ITextRender __includeTextBuilder, string __title, string undertitle)
        {
            title = __title;
            description = undertitle;
            includeTextBuilder = __includeTextBuilder;
        }


        /// <summary>
        /// 
        /// </summary>
        public string includeFilePath { get; set; }


        private ITextRender _includeTextBuilder;
        /// <summary> </summary>
        public ITextRender includeTextBuilder
        {
            get
            {
                return _includeTextBuilder;
            }
            protected set
            {
                _includeTextBuilder = value;
                OnPropertyChanged("includeTextBuilder");
            }
        }


        /// <summary>
        /// Composes a set of <c>docScriptInstruction</c> into supplied <c>docScript</c> instance or created blank new instance with <c>name</c> of this metaContainer
        /// </summary>
        /// <param name="script">The script.</param>
        /// <returns></returns>
        public override docScript compose(docScript script = null)
        {
            

            if (!title.isNullOrEmpty())
            {
                script.AppendHorizontalLine();

                script.open("import", name, "");

                script.AppendComment(description);

                script.AppendHorizontalLine();

            }
            if (!includeFilePath.isNullOrEmpty())
            {
                script.AppendFromFile(includeFilePath);
            }

            if (includeTextBuilder != null)
            {
                script.AppendDirect(includeTextBuilder.ContentToString());
            }
            if (!title.isNullOrEmpty())
            {
                script.close();
            }
            return script;
        }

        public override void construct(object[] resources)
        {
            
        }
    }

}