// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileTextOperater.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files.search
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Text file search and modification
    /// </summary>
    public class fileTextOperater
    {

        private String _filePath ="";
        /// <summary> </summary>
        public String filePath
        {
            get
            {
                return _filePath;
            }
            protected set
            {
                _filePath = value;
                
            }
        }


        private FileInfo _file;
        /// <summary> </summary>
        public FileInfo file
        {
            get
            {
                return _file;
            }
            protected set
            {
                _file = value;
                //OnPropertyChanged("file");
            }
        }




        private fileTextInMemoryBlocks _memMap;
        /// <summary>
        /// 
        /// </summary>
        public fileTextInMemoryBlocks memMap
        {
            get { return _memMap; }
            set { _memMap = value; }
        }



        private Boolean _useMemMap;
        /// <summary>
        /// 
        /// </summary>
        public Boolean useMemMap
        {
            get { return _useMemMap; }
            set { _useMemMap = value; }
        }


        public fileTextOperater(String __filePath, Boolean __useMemMap=true)
        {
            filePath = __filePath;
            file = new FileInfo(__filePath);
            file = filePath.getWritableFile(getWritableFileMode.newOrExisting);
            if (!file.Exists)
            {
                File.WriteAllText(file.FullName, "");
            }
            useMemMap = __useMemMap;
            if (useMemMap)
            {
                memMap = new fileTextInMemoryBlocks(file.FullName);
                
                //MemoryMappedFile.OpenExisting()
                //memMap = MemoryMappedFile.CreateFromFile(file.FullName, FileMode.Open, file.FullName);
            }
        }


        private Int32 _estLinesInFile;
        /// <summary>
        /// 
        /// </summary>
        public Int32 estLinesInFile
        {
            get { return _estLinesInFile; }
            set { _estLinesInFile = value; }
        }


        /// <summary>
        /// Appends the file with lines not already contained in the file, from the specified line list
        /// </summary>
        /// <param name="lineList">The line list.</param>
        /// <param name="altPath">The alt path -- if specified it will create new file and will return operator for it</param>
        public fileTextOperater Append(IEnumerable<String> lineList, String altPath = "")
        {
            String tmpPath = filePath + "bck";


            if (!altPath.isNullOrEmpty())
            {
                tmpPath = altPath;
            }

            FileInfo tmpFile = tmpPath.getWritableFile(getWritableFileMode.overwrite);

            List<String> linesToAppend = lineList.ToList();

            Int32 ln = 0;
            using (var st = File.OpenText(file.FullName))
            {
                var ost = File.AppendText(tmpFile.FullName);

                
                while (!st.EndOfStream)
                {
                    String line = st.ReadLine();

                    if (lineList.Contains(line))
                    {
                        linesToAppend.Remove(line);
                    }
                    ost.WriteLine(line);

                    ln++;
                }

                foreach (String apln in linesToAppend)
                {
                    ost.WriteLine(apln);
                    ln++;
                }

                

                ost.Close();
                ost.Dispose();

                st.Close();
                st.Dispose();
            }

            

            if (altPath.isNullOrEmpty())
            {
                File.Copy(tmpFile.FullName, file.FullName, true);
                File.Delete(tmpFile.FullName);
                estLinesInFile = Math.Max(estLinesInFile, ln);
                return this;
            }
            else
            {
                fileTextOperater op = new fileTextOperater(tmpFile.FullName);
                op.estLinesInFile = ln;
                return op;
            }
        }

        public fileTextLineCollection TakeAll()
        {
            return Take(-1, null, null);
        }


        /// <summary>
        /// Takes the specified number of lines from the file
        /// </summary>
        /// <param name="linesToTake">The lines to take.</param>
        /// <returns></returns>
        public fileTextLineCollection Take(Int32 linesToTake, List<String> shadow, List<String> shadowBuffer=null)
        {
            fileTextLineCollection output = new fileTextLineCollection();

            using (var st = File.OpenText(file.FullName))
            {
                Int32 ln = 0;
                while (!st.EndOfStream)
                {
                    String line = st.ReadLine();
                    if (shadow != null)
                    {
                        if (!shadow.Contains(line))
                        {
                            if (shadowBuffer != null)
                            {
                                if (!String.IsNullOrWhiteSpace(line))
                                {
                                    if (!shadowBuffer.Contains(line)) output.Add(ln, line);
                                }
                            }
                            else
                            {
                                if (!String.IsNullOrWhiteSpace(line))
                                {
                                    output.Add(ln, line);
                                }
                            }
                        }
                    } else
                    {
                        output.Add(ln, line);
                    }

                    if (linesToTake > 0)
                    {
                        if (output.Count() >= linesToTake)
                        {
                            break;
                        }
                    }

                    ln++;
                }
                st.Close();
                st.Dispose();
            }

            return output;
        }


        /// <summary>
        /// Splits source file content into separate results set according to the evaluator result
        /// </summary>
        /// <param name="filepathFormat">The filepath format.</param>
        /// <param name="evaluator">The evaluator. if result is empty then line is not taken from the source list</param>
        /// <param name="autoremove">if set to <c>true</c> it will remove all lines contained in the output <see cref="fileTextSplitResultSet"/></param>
        /// <returns>Parts that are separated from the source content</returns>
        public fileTextSplitResultSet Split(String filepathFormat, lineEvaluator evaluator, Boolean autoremove=false) {

            fileTextSplitResultSet output = new fileTextSplitResultSet(filepathFormat);

            using (var st = File.OpenText(file.FullName))
            {
                Int32 ln = 0;
                while (!st.EndOfStream)
                {
                    String line = st.ReadLine();

                    String result = evaluator(line);
                    if (result == "none") result = "";
                    
                    if (!result.isNullOrEmpty())
                    {
                        output[result].Add(ln, line, true);
                    }

                    ln++;
                }
                st.Close();
                st.Dispose();
            }

            if (autoremove)
            {
                var lns = output.getLineNumbers(true);
                Remove(lns);
            }

            return output;
        }


        /// <summary>
        /// Removes the specified line number list.
        /// </summary>
        /// <param name="lineNumList">The line number list.</param>
        /// <param name="altPath">If specified output is written to the path, original file is not changed</param>
        public fileTextOperater Remove(List<Int32> lineNumList, String altPath = "")
        {
            String tmpPath = filePath + "bck";


            if (!altPath.isNullOrEmpty())
            {
                tmpPath = altPath;
            }

            FileInfo tmpFile = tmpPath.getWritableFile(getWritableFileMode.overwrite);
            Int32 ln = 0;
            Int32 rm = 0;
            using (var st = File.OpenText(file.FullName))
            {
                var ost = File.AppendText(tmpFile.FullName);

                
                while (!st.EndOfStream)
                {
                    String line = st.ReadLine();

                    if (!lineNumList.Contains(ln))
                    {
                        ost.WriteLine(line);
                    }
                    else
                    {
                        rm++;
                    }

                    ln++;
                }

                ost.Close();
                ost.Dispose();

                st.Close();
                st.Dispose();
            }

            memMap = null;

            if (altPath.isNullOrEmpty())
            {
                File.Copy(tmpFile.FullName, file.FullName, true);
                File.Delete(tmpFile.FullName);
                estLinesInFile = ln - rm;
                return this;
            } else
            {
                fileTextOperater op = new fileTextOperater(tmpFile.FullName);
                op.estLinesInFile = ln - rm;
                return op;
            }
        }

        /// <summary>
        /// Removes all lines matching the lineList
        /// </summary>
        /// <param name="lineList">the list of lines to remove</param>
        /// <param name="altPath">If specified output is written to the path, original file is not changed</param>
        public fileTextOperater Remove(List<String> lineList, String altPath = "")
        {
            String tmpPath = filePath + "bck";


            if (!altPath.isNullOrEmpty())
            {
                tmpPath = altPath;
            }

            FileInfo tmpFile = tmpPath.getWritableFile(getWritableFileMode.overwrite);

            Int32 ln = 0;
            Int32 rm = 0;
            using (var st = File.OpenText(file.FullName))
            {
                var ost = File.AppendText(tmpFile.FullName);

               
                while (!st.EndOfStream)
                {
                    String line = st.ReadLine();

                    if (!lineList.Contains(line))
                    {
                        ost.WriteLine(line);
                    } else
                    {
                        rm++;
                    }

                    ln++;
                }

                ost.Close();
                ost.Dispose();

                st.Close();
                st.Dispose();
            }

            memMap = null;

            if (altPath.isNullOrEmpty())
            {
                File.Copy(tmpFile.FullName, file.FullName, true);
                File.Delete(tmpFile.FullName);
                estLinesInFile = ln - rm;
                return this;
            }
            else
            {
                fileTextOperater op = new fileTextOperater(tmpFile.FullName);
                op.estLinesInFile = ln - rm;
                return op;
            }
        }


        public fileTextSearchResult Search(fileTextLineCollection cachedLines, String __needle, Boolean useRegex = false, Int32 limitResult = -1, RegexOptions regexOptions = RegexOptions.None)
        {
            fileTextSearchResult output = new fileTextSearchResult(__needle, file.FullName, useRegex);
            fileTextOperaterWorker eval = new fileTextOperaterWorker(__needle, useRegex, regexOptions);
            
            
            foreach (var lp in cachedLines)
            {
                String match = "";
                if (eval.evaluate(lp.Value, out match))
                {
                    output.Add(lp.Key, lp.Value, false);
                }
            
                if (output.CountThreadSafe > limitResult)
                {
                    output.resultLimitTriggered = true;
                    break;
                }
            }
            return output;
        }

        private fileTextInMemoryBlocks GetTextMap()
        {
            fileTextInMemoryBlocks map = null;
            if (memMap == null)
            {
                map = new fileTextInMemoryBlocks(file.FullName);
            }
            else
            {
                map = memMap;
            }
            return map;
        }


        /// <summary>
        /// Searches lines with specified needle and returns resulting collection
        /// </summary>
        /// <param name="__needle">The needle.</param>
        /// <param name="useRegex">if set to <c>true</c> [use regex].</param>
        /// <returns></returns>
        public fileTextSearchResult Search(String __needle, Boolean useRegex = false, Int32 limitResult=-1, RegexOptions regexOptions = RegexOptions.None)
        {
            fileTextSearchResult output = new fileTextSearchResult(__needle, file.FullName, useRegex);
            fileTextOperaterWorker eval = new fileTextOperaterWorker(__needle, useRegex, regexOptions);
            var map = GetTextMap();

            Boolean limitOn = (limitResult > 0);
            ParallelOptions po = new ParallelOptions();
            
            Parallel.ForEach(map, po, block =>
            {
                Int32 l = block.lineStart;
                String match = "";
                foreach (String line in block)
                {
                    if (eval.evaluate(line, out match))
                    {
                        output.Add(l, line, false);
                    }
                    l++;

                    if (limitOn && (output.CountThreadSafe >= limitResult))
                    {
                        output.resultLimitTriggered = true;
                        break;
                    }
                } 
            });

 
            return output;
        }

        //private void _testLine(String line, fileTextSearchResult output, )


        /// <summary>
        /// Search file with multiple needles
        /// </summary>
        /// <param name="__needles">The needles.</param>
        /// <param name="useRegex">if set to <c>true</c> [use regex].</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns></returns>
        public fileTextSearchResultSet Search(IEnumerable<String> __needles, Boolean useRegex = false, StringComparison comparison=StringComparison.CurrentCultureIgnoreCase, RegexOptions regexOptions = RegexOptions.None, Int32 limitResult = -1)
        {
            fileTextSearchResultSet output = new fileTextSearchResultSet(__needles, file.FullName, useRegex);
            fileTextOperaterWorker eval = new fileTextOperaterWorker(__needles, useRegex, regexOptions);
            var map = GetTextMap();
            Boolean limitOn = (limitResult > 0);

            ParallelOptions po = new ParallelOptions();

            Parallel.ForEach(map, po, block =>
            {
                Int32 l = block.lineStart;
                String match = "";
                foreach (String line in block)
                {
                    if (eval.evaluate(line, out match))
                    {
                        output[match].Add(l, line, false);
                    }
                    l++;

                    if (limitOn && (output.CountThreadSafe >= limitResult))
                    {
                        output.resultLimitTriggered = true;
                        break;
                    }
                }
            });
            
            return output;
        }

        //public FileInfo Replace(fileTextLineCollection replacementLines, String newFilename="")
        //{

        //}

    }

}