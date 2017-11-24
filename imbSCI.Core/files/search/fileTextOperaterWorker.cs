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