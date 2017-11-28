namespace imbSCI.Core.syntax.code
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class codeLineExtensions
    {
        public static Regex _splitSourceCode = new Regex(@"([\w])\r|\s", RegexOptions.Multiline);


        public static Regex _getAlfabetPart = new Regex(@"[A-ZČŠĆŽĐa-zžđščć]{1,}");





        /// <summary>
        /// Tokenizuje ulazni source code - koristi univerzalnu tokenizaciju
        /// </summary>
        /// <param name="code">Izvodni kod koji obradjuje</param>
        /// <param name="removeEmptyTokens">Da li da izbaci prazne tokene?</param>
        /// <returns></returns>
        public static List<string> tokenizeCodeLine(this String code, Boolean removeEmptyTokens)
        {
            List<String> output = new List<string>();
            var tkns = _splitSourceCode.Split(code);

            foreach (var rkn in tkns)
            {
                if (!removeEmptyTokens || !String.IsNullOrEmpty(rkn))
                {
                    output.Add(rkn);
                }
            }
            return output;
        }
    }
}