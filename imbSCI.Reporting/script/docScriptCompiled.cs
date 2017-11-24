namespace imbSCI.Reporting.script
{
    using System;
    using System.Collections;
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
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Compiled resion of the script
    /// </summary>
    /// <seealso cref="imbSCI.Cores.primitives.imbBindable" />
    public class docScriptCompiled:imbBindable
    {

        /// <summary>
        /// Adds the specified ins.
        /// </summary>
        /// <param name="ins">The ins.</param>
        /// <returns></returns>
        public docScriptInstructionCompiled compile(docScriptInstruction ins, IRenderExecutionContext log, PropertyCollectionDictionary __indata, PropertyCollection __extraData, docScriptFlags flags)
        {

            docScriptInstructionCompiled instructionCompiled = new docScriptInstructionCompiled(ins, flags);

            try
            {
                PropertyCollectionDictionary indata = __indata;
                PropertyCollection extraData = __extraData;

                if (ins.type == appendType.x_scopeIn)
                {
                    currentDataPath = ins.getProperString(d.dsa_path);
                }
                else if (ins.type == appendType.x_scopeOut)
                {
                    currentDataPath = currentDataPath.getPathVersion(1, "\\", true);
                }




                PropertyCollection dataItem = null;
                if (indata != null)
                {
                    var tmp = indata[currentDataPath];
                    if (tmp is DictionaryEntry)
                    {
                        //DictionaryEntry entry = (DictionaryEntry)tmp;
                        //dataItem = entry.Value as PropertyCollection;
                    }
                    else
                    {
                        dataItem = tmp as PropertyCollection;
                    }


                }


                

                /// Compiling data into template
                instructionCompiled.compileTemplate(dataItem, extraData);

                if (instructionCompiled.isCompileFailed)
                {
                    string msg = scriptInstructions.Count().ToString("D4") + " " + ins.type.ToString() + " failed on: " + instructionCompiled.missingData.toCsvInLine();
                    if (flags.HasFlag(docScriptFlags.ignoreCompilationFails))
                    {
                        log.log(msg);
                    } else
                    {
                        log.compileError(msg, instructionCompiled);
                    }
                    
                    if (flags.HasFlag(docScriptFlags.allowFailedInstructions))
                    {
                        scriptInstructions.Add(instructionCompiled);
                    }
                    scriptInstructionsFailed.Add(instructionCompiled);
                }
                else
                {
                    scriptInstructions.Add(instructionCompiled);

                    if (instructionCompiled.isCompilable)
                    {
                       // log.log("--- compiled Strings(" + instructionCompiled.keyListForStrings.Count + ") and StringCollections(" + instructionCompiled.keyListForStringCollections.Count + ")");
                    }
                }


                missingData.AddRange(instructionCompiled.missingData);
            } catch (Exception ex)
            {

            }
            return instructionCompiled;
        }

        /// <summary>
        /// The script instructions
        /// </summary>
        protected List<docScriptInstructionCompiled> scriptInstructions = new List<docScriptInstructionCompiled>();

        protected List<docScriptInstructionCompiled> scriptInstructionsFailed = new List<docScriptInstructionCompiled>();


        #region --- missingData ------- List of placeholders that were missing data points suring compile process 

        /// <summary>
        /// List of placeholders that were missing data points suring compile process
        /// </summary>
        public List<string> missingData { get; set; } = new List<string>();

        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="docScriptCompiled"/> class.
        /// </summary>
        /// <param name="script">The script.</param>
        public docScriptCompiled(docScript script)
        {
            name = script.name;
            
        }



        #region --- currentDataPath ------- current data path 
        private string _currentDataPath = "";
        /// <summary>
        /// current data path
        /// </summary>
        protected string currentDataPath
        {
            get
            {
                return _currentDataPath;
            }
            set
            {
                _currentDataPath = value;
                OnPropertyChanged("currentDataPath");
            }
        }
        #endregion


        public int Count() => scriptInstructions.Count();

        public int CountFailed() => scriptInstructionsFailed.Count();

        public IEnumerator<docScriptInstructionCompiled> GetEnumerator() => scriptInstructions.GetEnumerator();

        /// <summary>
        /// Name of source documentSet or other kind of source
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }


        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string filename
        {
            get { return name.getCleanFilePath(); }
        }

    }

}