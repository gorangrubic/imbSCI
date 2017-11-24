namespace imbSCI.DataComplex.extensions.text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.special;

    /// <summary>
    /// Clearing strnigs
    /// </summary>
    /// 
    public static class imbStringCleaners
    {

        private static translationTextTable _unicodeToDos;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static translationTextTable unicodeToDos
        {
            get
            {
                if (_unicodeToDos == null)
                {
                    _unicodeToDos = new translationTextTable();
                    _unicodeToDos.Add("ć", "c");
                    _unicodeToDos.Add("č", "c");
                    _unicodeToDos.Add("ž", "z");
                    _unicodeToDos.Add("đ", "dj");
                    _unicodeToDos.Add("š", "s");
                    _unicodeToDos.Add("Ć", "C");
                    _unicodeToDos.Add("Č", "C");
                    _unicodeToDos.Add("Ž", "Z");
                    _unicodeToDos.Add("Đ", "Dj");
                    _unicodeToDos.Add("Š", "S");
                }
                return _unicodeToDos;
            }
        }


        private static translationTextTable _unicodeToDosX;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static translationTextTable unicodeToDosX
        {
            get
            {
                if (_unicodeToDosX == null)
                {
                    _unicodeToDosX = new translationTextTable();
                    _unicodeToDosX.Add("ć", "cx");
                    _unicodeToDosX.Add("č", "cy");
                    _unicodeToDosX.Add("ž", "zx");
                    _unicodeToDosX.Add("đ", "dx");
                    _unicodeToDosX.Add("š", "sx");
                    _unicodeToDosX.Add("Ć", "CX");
                    _unicodeToDosX.Add("Č", "CY");
                    _unicodeToDosX.Add("Ž", "ZX");
                    _unicodeToDosX.Add("Đ", "DX");
                    _unicodeToDosX.Add("Š", "SX");
                }
                return _unicodeToDosX;
            }
        }

        
        /// <summary>
/// Determines whether it contains ć,ž,š,đ,č -- only small letters
/// </summary>
/// <param name="input">The input.</param>
/// <returns>
///   <c>true</c> if [is non dos chars] [the specified input]; otherwise, <c>false</c>.
/// </returns>
public static bool isNonDosChars(this string input)
        {
            if (input.Contains("ž")) return true;
            if (input.Contains("č")) return true;
            if (input.Contains("š")) return true;
            if (input.Contains("đ")) return true;
            if (input.Contains("ć")) return true;
            return false;
        }

        /// <summary>
        /// Uses precompiled replacement - only small letters
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string toDosCleanDirect(this string input)
        {
            if (imbSciStringExtensions.isNullOrEmpty(input)) return "";

            return input.Replace("ć", "c").Replace("č", "c").Replace("ž", "z").Replace("š", "s").Replace("đ", "dj");
        }

        public static bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }


        public static string toDosCharacters(this string input, toDosCharactersMode mode=toDosCharactersMode.toCleanChars, bool inverse=false)
        {
            switch (mode)
            {
                case toDosCharactersMode.toCleanAndXChars:
                    input = unicodeToDosX.translate(input,inverse);
                    break;
                case toDosCharactersMode.toCleanChars:
                    input = unicodeToDos.translate(input,inverse);
                    break;
            }
            return input;
        }


        /// <summary>
        /// Brise sadržaj od nedozvoljenih karaktera i internog HTML-a
        /// </summary>
        /// <param name="innerHtml"></param>
        /// <returns>String without HTML tags and forbidden characters</returns>
        /// \ingroup_disabled ace_ext_strings
        public static string htmlContentProcess(this string innerHtml)
        {
            string blc = innerHtml;

            blc = blc.StripHTML();

            blc = WebUtility.HtmlDecode(blc); // blc.imbHtmlDecode(blc); // aceCommonTypes.reporting.imbStringReporting.imbHtmlDecode(innerHtml);

            blc = blc.Replace("<!--", "");
            blc = blc.Replace("-->", "");
            blc = blc.Replace("<", "");
            blc = blc.Replace(">", "");
            blc = blc.Replace("\"", "''");


            blc = SecurityElement.Escape(blc);

            return blc;

        }
    }
}
