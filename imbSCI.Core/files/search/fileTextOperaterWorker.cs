// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileTextOperaterWorker.cs" company="imbVeles" >
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
// Author: Goran Grubi?
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
using System.Text.RegularExpressions;

namespace imbSCI.Core.files.search
{
    public class fileTextOperaterWorker
    {
        private Regex rgex = null;
        private String needle = "";
        private List<String> needles = new List<string>();
        private List<Regex> rgexes = new List<Regex>();
        //private Int32 limitResult = -1;
        //public Int32 ln = 0;

        public fileTextOperaterWorker(IEnumerable<String> __needles, Boolean useRegex = false, RegexOptions regexOptions = RegexOptions.None)
        {
            needles.AddRange(__needles);

            if (useRegex)
            {
                foreach (var nd in __needles)
                {
                    rgex = new Regex(nd, regexOptions);
                    rgexes.Add(rgex);
                }
               
            }
            else
            {

            }
        }

        private Boolean use_rgex
        {
            get
            {
                return (rgex != null) || (rgexes.Any());
            }
        } 

        public fileTextOperaterWorker(String __needle, Boolean useRegex = false, RegexOptions regexOptions = RegexOptions.None)
        {
            needle = __needle;
            if (useRegex) {
                rgex = new Regex(needle, regexOptions);
            } else
            {

            }
        }

        public Boolean evaluate(String line, out String match)
        {
            if (needles.Any())
            {
                if (use_rgex)
                {
                    foreach (Regex rg in rgexes)
                    {
                        if (rg.IsMatch(line))
                        {
                            match = rg.ToString();
                            return true;
                        }
                    }
                }
                else
                {

                    if (line.ContainsAny(needles, out match))
                    {
                        return true; // output.Add(ln, line, false);
                    }
                }
            }
            else { 
                if (use_rgex)
                {
                    if (rgex.IsMatch(line))
                    {
                        match = rgex.ToString();
                        return true; // output.Add(ln, line, false);
                    }
                }
                else
                {
                    if (line.Contains(needle))
                    {
                        match = needle;
                        return true; // output.Add(ln, line, false);
                    }
                }
            }
            match = "";
            return false;
           
        }

        //Regex rgex = null;
        //    

        //    using (var st = File.OpenText(file.FullName))
        //    {
        //        Int32 ln = 0;
        //        while (!st.EndOfStream)
        //        {
        //            String line = st.ReadLine();

        //            
        //        }
        //        st.Close();
        //        st.Dispose();
        //    }

    }

}