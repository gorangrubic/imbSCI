namespace imbSCI.Core.reporting.render.contentControl
{
    using imbSCI.Data.data;
    using imbSCI.Data.enums.fields;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    /// Main and subcontent controller - a helper class for <c>ITextRender</c>, <c>IDocumentRender</c>, <c>IRender</c>
    /// </summary>
    /// <seealso cref="imbReportingBindable" />
    public class stringBuilderControler : imbBindable
    {
        public stringBuilderControler()
        {
            switchToActive(templateFieldSubcontent.main);
        }

        ///// <summary>
        ///// Compiles subcontents with the main content or with the specified template.
        ///// </summary>
        ///// <param name="template">The template string. If empty it will use the <c>main</c> content as template</param>
        ///// <param name="log">Optional logger</param>
        ///// <param name="secondary">The secondary dataset - if specified it will run secondary <c>applyToContent</c> call against compiled content. Useful if <c>subcontent</c> contains template placeholders unmatched during prior <c>compile</c> call</param>
        ///// <returns>Compiled content where placeholders are replaced with subcontents and optionally with <c>secondary</c> dataset</returns>
        //public String compile(String template = "", ILogable log = null, PropertyCollection secondary = null)
        //{
        //    String output = "";
        //    Boolean useMain = false;
        //    if (template.isNullOrEmpty())
        //    {
        //        template = this[templateFieldSubcontent.main].ToString();
        //    } else
        //    {
        //        useMain = true;
        //    }

        //    PropertyCollection dataset = getDataset(useMain);

        //    if (dataset.Count == 0)
        //    {
        //        return template;
        //    }

        //    template = template.applyToContent(false, dataset);

        //    if (secondary != null)
        //    {
        //        template = template.applyToContent(false, secondary);
        //    }

            
        //    return template;
        //}
                

        /// <summary>
        /// Retrieves all subcontents and optionaly the main subcontent - as PropertyCollection
        /// </summary>
        /// <returns>Key: <see cref="imbSCI.Data.enums.fields.templateFieldSubcontent"/> / Value: <see cref="StringBuilder"/> </returns>
        public PropertyCollection getDataset(Boolean includeMain=false)
        {
            PropertyCollection output = new PropertyCollection();

            foreach (KeyValuePair<templateFieldSubcontent, StringBuilder> de in registry)
            {
                if (de.Key != templateFieldSubcontent.main)
                {
                    output.Add(de.Key, de.Value.ToString());
                } else
                {
                    if (includeMain)
                    {
                        output.Add(de.Key, de.Value.ToString());
                    }
                }
            }

            return output;
        }


        public void switchToActive(templateFieldSubcontent subfield)
        {
            if (!registry.ContainsKey(subfield))
            {
                registry.Add(subfield, new StringBuilder());
            }
            active = subfield;
        }

        private templateFieldSubcontent _active = templateFieldSubcontent.main;
        /// <summary>
        /// Determinates the active StringBuilder
        /// </summary>
        protected templateFieldSubcontent active
        {
            get { return _active; }
            set { _active = value; }
        }

        /// <summary>
        /// Gets the active StringBuilder - equeal to <c>this[active]</c>
        /// </summary>
        /// <value>
        /// Equeal to <c>this[active]</c>
        /// </value>
        public StringBuilder sb
        {
            get
            {
                return registry[active];
            }
        }

        public void Clear()
        {
            registry.Clear();
            switchToActive(templateFieldSubcontent.main);
        }

        /// <summary>
        /// Gets the <see cref="System.Text.StringBuilder" /> under the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.Text.StringBuilder" />.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        internal StringBuilder this[templateFieldSubcontent key]
        {
            get
            {
                if (!registry.ContainsKey(key))
                {
                    registry.Add(key, new StringBuilder());
                }
                return registry[key] as StringBuilder;
            }
        }


        private Dictionary<templateFieldSubcontent, StringBuilder> _registry = new Dictionary<templateFieldSubcontent, StringBuilder>();
        /// <summary>
        /// Container for string builders
        /// </summary>
        protected Dictionary<templateFieldSubcontent, StringBuilder> registry
        {
            get { return _registry; }
            set { _registry = value; }
        }


    }
}
