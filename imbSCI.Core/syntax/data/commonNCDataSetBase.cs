namespace imbSCI.Core.syntax.data
{
    using System;
    using System.Linq;
    using imbSCI.Core.syntax.data.core;
    using imbSCI.Core.syntax.data.files;

    public abstract class commonNCDataSetBase : textDataSetWithComments<paramPair>
    {
       
        /// <summary>
        /// Obradjuje jednu liniju
        /// </summary>
        /// <param name="_line"></param>
        /// <param name="i"> </param>
        /// <returns></returns>
        public override paramPair processLine(string _line, int i)
        {
            paramPair output = new paramPair();
            _line = _line.Trim();

            var lne = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (lne.Length == 0)
            {
                if (!String.IsNullOrEmpty(_line))
                {
                    lne = new string[] { _line };
                }
            }

            if (lne.Any())
            {
                var lnCommand = lne[0].Trim().ToUpper();
                output.name = lnCommand;
                output.value = "";
                for (int li = 1; li < lne.Length; li++)
                {
                    output.value += " " + lne[li];
                }
            }

            return output;
        }
    }
}