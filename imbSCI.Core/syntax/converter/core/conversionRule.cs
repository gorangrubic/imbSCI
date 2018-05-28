using imbSCI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace imbSCI.Core.syntax.converter.core
{
    public class conversionRule
    {

        /// <summary>
        /// Processes the line.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public String ProcessLine(String input)
        {
            String output = input;
            if (trim) input = input.Trim(" \t".ToArray());

            if (!startsWith.isNullOrEmpty())
            {
                if (!input.StartsWith(startsWith)) return output;
            }

            if (!endsWith.isNullOrEmpty())
            {
                if (!input.EndsWith(endsWith)) return output;
            }
            if (regex == null)
            {
                output = output.Replace(needle, replacement);
            }
            else
            {
                output = regex.Replace(output, replacement);
            }
            return output;
        }

        public conversionRule()
        {
        }

        public conversionRule SetStart(String input, String _replacement="")
        {
            startsWith = input;
            if (_replacement != "")
            {
                needle = input;
                replacement = _replacement;
            }
            return this;
        }

        public conversionRule SetEnd(String input)
        {
            endsWith = input;
            return this;
        }

        public conversionRule SetReplace(String _needle, String _replacement)
        {
            needle = _needle;
            replacement = _replacement;
            return this;
        }


        public conversionRule SetRegex(String rgx, String _replacement)
        {
            regex = new Regex(rgx);
            replacement = _replacement;
            return this;
        }

        public Boolean trim { get; set; } = true;

        public String startsWith { get; set; } = "";

        public String endsWith { get; set; } = "";

        public String needle { get; set; } = "";

        public String replacement { get; set; }

        public Boolean multiline { get; set; } = false;

        public Regex regex { get; set; }
    }
}
