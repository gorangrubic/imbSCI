namespace imbSCI.Core.syntax.data.files
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using imbSCI.Core.syntax.data.core;

    /// <summary>
    /// Podrzava ucitavanje> bat, e-mac.mch, t-punch.cfg 
    /// </summary>
    public class standardParamDataSet : textDataSetWithComments<paramPair>
    {
        public override bool afterLoad()
        {
           // throw new NotImplementedException();
            return true;
        }

        public override bool processToObject(object _target)
        {
            throw new NotImplementedException();
        }

        public override bool processToDictionary()
        {
            throw new NotImplementedException();
        }

        public override bool beforeSave()
        {
          //  throw new NotImplementedException();
            return true;
        }

        public override bool save(string _path = "")
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<paramPair> processLines()
        {
            paramPairs output = new paramPairs();
            int i = 0;  
            foreach (String ln in lines)
            {
                paramPair oln = processLine(ln, i);
                output.Add(oln);
                i++;
            }
            loadedParams = output;
            return output;
        }



      

        public override core.paramPair processLine(string _line, int i)
        {
            if (String.IsNullOrEmpty(_line)) return null;
            _line = _line.Trim();
            if (String.IsNullOrEmpty(_line)) return null;

            paramPair output = new paramPair();

            if (_line.StartsWith("#"))
            {
                output.isComment = true;
                output.name = "#" + i.ToString("D3");
                output.value = _line.Trim('#');
                return output;
            }

            if (paramLine_set.IsMatch(_line))
            {
                Match mc = paramLine_set.Match(_line);
                output.name = mc.Groups[1].Value.Trim();
                if (output.name.StartsWith("set "))
                {
                    output.name = output.name.Substring(3).Trim();
                }
                output.value = mc.Groups[2].Value.Trim();
                return output;
            }

            if (paramLine_tab.IsMatch(_line))
            {
                Match mc = paramLine_tab.Match(_line);
                output.name = mc.Groups[1].Value.Trim();
                output.value = mc.Groups[2].Value.Trim();
                return output;
            }

            

            return output;
        }
    }
}
