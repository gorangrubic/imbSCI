using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Data;
using imbSCI.Data.collection;
using imbSCI.Data.data;
using imbSCI.Data.interfaces;


namespace imbSCI.Core.reporting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using imbSCI.Core.extensions.data;
    using imbSCI.Data.collection.special;

    /// <summary>
    /// Helper class that contains list of IConsoleControls that have permission to write to console
    /// </summary>
    public class aceLogToConsoleControl : IAceLogToConsoleControl
    {


        private Dictionary<IConsoleControl, String> _prefixRegistar = new Dictionary<IConsoleControl, String> ();
        /// <summary> </summary>
        protected Dictionary<IConsoleControl, String>  prefixRegistar
        {
            get
            {
                return _prefixRegistar;
            }
             set
            {
                _prefixRegistar = value;
            }
        }



        protected circularSelector<ConsoleColor> colorSelector = new circularSelector<ConsoleColor>(ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Gray, ConsoleColor.DarkCyan, ConsoleColor.White);


        private Dictionary<IConsoleControl, ConsoleColor> _colorRegistar = new Dictionary<IConsoleControl, ConsoleColor>();
        /// <summary> </summary>
        protected Dictionary<IConsoleControl, ConsoleColor> colorRegistar
        {
            get
            {
                return _colorRegistar;
            }
            set
            {
                _colorRegistar = value;
            }
        }


       


        /// <summary>
        /// Sets as only output - removes all the rest
        /// </summary>
        /// <param name="loger">The loger.</param>
        public void setAsOnlyOutput(IConsoleControl loger, String prefix = "")
        {
            colorRegistar.Clear();
            prefixRegistar.Clear();
            allowList.Clear();
            setAsOutput(loger, prefix);
        }



        public void setLogFileWriter(String path = null)
        {
            if (_logWritter != null)
            {
                _logWritter.Close();
                logFileWriteOn = false;
            }

            if (path == null)
            {
                if (_logWritter != null)
                {
                    logFileWriteOn = false;
                }
            }
            else
            {
                _logWritter = File.AppendText(path);
                logFileWriteOn = true;
            }
        }

        public Boolean logFileWriteOn { get; set; } = false;

        private TextWriter _logWritter;
        #region imbObject Property <TextWriter> logWritter 
        /// <summary>
        /// imbControl property logWritter tipa TextWriter
        /// </summary>
        public TextWriter logWritter
        {
            get
            {

                if (_logWritter == null)
                {
                    String p = "diagnostic\\log.md";
                   // p.getWritableFile(getWritableFileMode.autoRenameExistingToOldOnce);
                    _logWritter = File.AppendText(p);
                }

                return _logWritter;

            }
            set
            {
                _logWritter = value;
                
            }
        }
        #endregion



        private Object setAsOutputLock = new Object();


        /// <summary>
        /// Sets this loger on allow list
        /// </summary>
        /// <param name="loger">The loger.</param>
        public void setAsOutput(IConsoleControl loger, String prefix = "")
        {
            lock (setAsOutputLock)
            {
                if (!colorRegistar.ContainsKey(loger)) colorRegistar.Add(loger, colorSelector.next());
                if (!allowList.Contains(loger))
                {
                    allowList.Add(loger);
                }
                if (!prefixRegistar.ContainsKey(loger))
                {
                    if (!prefix.isNullOrEmpty())
                    {
                        prefix = prefix.toWidthExact(8, " ") + ": ";
                    }
                    prefixRegistar.Add(loger, prefix);
                }
                loger.VAR_AllowInstanceToOutputToConsole = true;
            }
        }

        /// <summary>
        /// Replaces the output.
        /// </summary>
        /// <param name="oldLoger">The old loger.</param>
        /// <param name="newLoger">The new loger.</param>
        public void replaceOutput(IConsoleControl oldLoger, IConsoleControl newLoger)
        {
            removeFromOutput(oldLoger);
            setAsOutput(newLoger);
        }

        private IConsoleControl lastLogerToWrite = null;


        private Boolean _convertToDos = true;
        /// <summary>
        /// 
        /// </summary>
        public Boolean convertToDos
        {
            get { return _convertToDos; }
            set { _convertToDos = value; }
        }


        private toDosCharactersMode _encodeMode = toDosCharactersMode.toCleanChars;
        /// <summary>
        /// 
        /// </summary>
        public toDosCharactersMode encodeMode
        {
            get { return _encodeMode; }
            set { _encodeMode = value; }
        }


        private List<String> preprocessMessage(String message, IConsoleControl loger)
        {           
            List<String> lines = new List<string>();
            foreach (String line in message.breakLines(false))
            {
                String li = line;
                //if (convertToDos) li = li.toDosCharacters(toDosCharactersMode.toCleanChars);
                if (! String.IsNullOrWhiteSpace(li)) 
                lines.Add(li.ensureStartsWith(prefixRegistar[loger]));
            }
            return lines;
        }


        private Object writeToLogWritterLock = new Object();

        private static Regex reg_highlight = new Regex(@"_([\w\s\.\-\:\,\%]*)_");

        public void writeToConsole(String message, IConsoleControl loger, Boolean breakline, Int32 altColor=-1)
        {
            lock (writeToLogWritterLock)
            {
                if (!checkOutputPermission(loger)) return;

                try
                {

                   
                    if (loger != lastLogerToWrite) Console.WriteLine("--");

                    Console.ForegroundColor = colorRegistar[loger];

                    if (altColor > 0)
                    {
                        Console.ForegroundColor = colorSelector.getAlternative(Console.ForegroundColor, altColor);
                    }

                    if (breakline)
                    {
                        List<String> lines = preprocessMessage(message, loger);

                        foreach (String ln in lines)
                        {

                            writeLine(ln, loger);
                            //Thread.Sleep(1);

                            //if (logFileWriteOn) logWritter.WriteLine(ln);

                        }
                    } else
                    {
                        writeLine(message, loger);

                    }

                    lastLogerToWrite = loger;

                    Console.ForegroundColor = ConsoleColor.White;
                } catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }       
        }

        private void writeLine(String ln, IConsoleControl loger)
        {
            if (reg_highlight.IsMatch(ln))
            {
                var mchs = reg_highlight.Matches(ln);

                var splits = reg_highlight.Split(ln);

                Int32 i = -1;
                foreach (String sp in splits)
                {

                    Console.ForegroundColor = colorRegistar[loger];

                    if (i == 1)
                    {
                        Console.ForegroundColor = colorSelector.getAlternative(Console.ForegroundColor, i);
                    }


                    i = -i;

                    //Thread.Sleep(1);

                    //if (logFileWriteOn) logWritter.WriteLine(ln);


                    

                    if (sp == Enumerable.Last<string>(splits))
                    {
                        Console.WriteLine(sp);
                    } else
                    {
                        Console.Write(sp);
                    }
                }

            }
            else
            {
                Console.WriteLine(ln);
            }

            if (logFileWriteOn) logWritter.Write(ln);
        }


        /// <summary>
        /// TRUE: when <see cref="allowList"/> is empty. Then someone else may print out
        /// </summary>
        /// <value>
        ///   <c>true</c> if [no one on output now]; otherwise, <c>false</c>.
        /// </value>
        public Boolean noOneOnOutputNow
        {
            get
            {
                return !allowList.Any();
            }
        }

        /// <summary>
        /// Checks if this loger has output permission. Checks only the globaly defined list, not members of <see cref="IConsoleControl"/>
        /// </summary>
        /// <param name="loger">The loger.</param>
        /// <returns></returns>
        public Boolean checkOutputPermission(IConsoleControl loger)
        {
            try
            {
                return allowList.Contains(loger);
            } catch (Exception ex)
            {
                Console.WriteLine("Error occured during permission check");
                return true;
            }
        }


        private Object removeFromOutputLock = new Object();


        /// <summary>
        /// Removes this loger from output permission
        /// </summary>
        /// <param name="loger">The loger.</param>
        public void removeFromOutput(IConsoleControl loger)
        {
            //writeToConsole(loger.GetType().Name + ": went off", loger, true);
            lock (removeFromOutputLock)
            {
                if (colorRegistar.ContainsKey(loger)) colorRegistar.Remove(loger); //, colorSelector.next());
                if (allowList.Contains(loger))
                {
                    allowList.Remove(loger);
                    loger.VAR_AllowInstanceToOutputToConsole = false;
                }
            }
        }

        private List<IConsoleControl> _allowList = new List<IConsoleControl>();
        /// <summary> </summary>
        protected List<IConsoleControl> allowList
        {
            get
            {
                return _allowList;
            }
            set
            {
                _allowList = value;
            }
        }

    }

}