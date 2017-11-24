namespace imbSCI.Reporting.script
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    using d = docScriptArguments;
    using imbSCI.Core.reporting.extensions;
    using imbSCI.Core.reporting.template;

    /// <summary>
    /// Compiled version of docScriptInstruction with compilation debug information
    /// </summary>
    /// <seealso cref="docScriptInstruction" />
    public class docScriptInstructionCompiled : docScriptInstruction
    {
           

        #region --- missingData ------- List of placeholders that were missing data points suring compile process 

        /// <summary>
        /// List of placeholders that were missing data points suring compile process
        /// </summary>
        public List<string> missingData { get; set; } = new List<string>();

        #endregion



        #region --- keyListForNonStrings ------- list of properties that are not strings 

        /// <summary>
        /// list of properties that are not strings
        /// </summary>
        public List<docScriptArguments> keyListForNonStrings { get; set; } = new List<d>();

        #endregion


        #region --- keyListForStringCollections ------- list of properties with string collection 

        /// <summary>
        /// list of properties with string collection
        /// </summary>
        public List<docScriptArguments> keyListForStringCollections { get; set; } = new List<d>();

        #endregion


        #region --- keyListForStrings ------- List of properties with String type value 

        /// <summary>
        /// List of properties with String type value
        /// </summary>
        public List<docScriptArguments> keyListForStrings { get; set; } = new List<d>();

        #endregion


        #region --- keyListForFailedStrings ------- List of properties that had no required data to finish template compilation 

        /// <summary>
        /// List of properties that had no required data to finish template compilation
        /// </summary>
        public List<docScriptArguments> keyListForFailedStrings { get; set; } = new List<d>();

        #endregion



        /// <summary>
        /// Indicating whether compile did failed on any placeholder or string lines
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is compile failed; otherwise, <c>false</c>.
        /// </value>
        public bool isCompileFailed
        {
            get
            {
                if (missingData.Any()) return true;
                if (keyListForFailedStrings.Any()) return true;
                return false;
            }
        }


        /// <summary>
        /// Indicating if string arguments were detected
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is compilable; otherwise, <c>false</c>.
        /// </value>
        public bool isCompilable
        {
            get
            {
                if (keyListForStrings.Any()) return true;
                if (keyListForStringCollections.Any()) return true;
                return false;
            }
        }


        public docScriptInstructionCompiled(docScriptInstruction __source, docScriptFlags flags) :base(__source.type)
        {
            this.copyInto(__source);
            analyse(flags);
        }


        /// <summary>
        /// Populates keyLists 
        /// </summary>
        /// <exception cref="System.ArgumentNullException">docScriptArgument can't have null value!</exception>
        internal void analyse(docScriptFlags flags)
        {
            foreach (docScriptArguments arg in Keys)
            {
                if (this[arg] == null)
                {
                    if (!flags.HasFlag(docScriptFlags.ignoreArgumentValueNull))
                    {
                        throw new ArgumentNullException(type.toStringSafe().add(arg.ToString(), "->"), "docScriptArgument can't have null value!");
                    } else
                    {
                       // this[arg] = "";
                    }
                }
                if (this[arg] is string)
                {
                    keyListForStrings.Add(arg);
                } else if (this[arg] is IEnumerable<string>)
                {
                    keyListForStringCollections.Add(arg);
                } else
                {
                    keyListForNonStrings.Add(arg);
                }
            }
        }


        /// <summary>
        /// Compiles template arguments using dataSets
        /// </summary>
        /// <param name="dataSets">The data sets to apply</param>
        public void compileTemplate(params PropertyCollection[] dataSets)
        {
            if (dataSets == null)
            {
                return;
            }
            foreach (docScriptArguments arg in keyListForStringCollections)
            {
                IEnumerable<string> lines = this[arg] as IEnumerable<string>;
                List<string> newLines = new List<string>();
                foreach (string line in lines)
                {
                    newLines.Add(applyLine(line, arg, dataSets));
                }
                this[arg] = newLines;    
            }
            foreach (docScriptArguments arg in keyListForStrings)
            { 
                string line = this[arg] as string;
                this[arg] = applyLine(line, arg, dataSets);
                
            }
        }

        /// <summary>
        /// Applies the dataset on the line
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="dataSets">The data sets.</param>
        /// <returns></returns>
        internal string applyLine(string line, docScriptArguments arg, PropertyCollection[] dataSets)
        {
            string cline = line.applyToContent(false, dataSets);
            if (cline.isTemplate())
            {
                keyListForFailedStrings.AddUnique(arg);
                reportTemplatePlaceholderCollection plcs = cline.getPlaceHolders();
                foreach (KeyValuePair<string, reportTemplatePlaceholder> plcp in plcs)
                {
                    missingData.AddUnique(plcp.Key);
                }
            }
            return cline;
        }
    }

}