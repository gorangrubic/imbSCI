// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbStringIsTests.cs" company="imbVeles" >
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
// Author: Goran Grubić
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.extensions.text
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    #endregion

    /// <summary>
    /// Skup testova nad stringom
    /// </summary>
    /// \ingroup_disabled ace_ext_string
    public static class imbStringIsTests
    {


        public static bool IsDate(this string input)
        {
            DateTime dt;
            return (DateTime.TryParse(input, out dt));
        }

        public static Dictionary<string, string> Parameters(
      this Uri self)
        {

            return String.IsNullOrEmpty(self.Query)
              ? new Dictionary<string, string>()
              : self.Query.Substring(1).Split('&').ToDictionary(
                  p => p.Split('=')[0],
                  p => p.Split('=')[1]
              );
        }


        private readonly static Regex domainRegex = new Regex(@"(((?<scheme>http(s)?):\/\/)?([\w-]+?\.\w+)+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\,]*)?)", RegexOptions.Compiled | RegexOptions.Multiline);

        public static string Linkify(this string text, string target = "_self")
        {
            return domainRegex.Replace(
                text,
                match => {
                    var link = match.ToString();
                    var scheme = match.Groups["scheme"].Value == "https" ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;

                    var url = new UriBuilder(link) { Scheme = scheme }.Uri.ToString();

                    return string.Format(@"<a href=""{0}"" target=""{1}"">{2}</a>", url, target, link);
                }
            );
        }

        public static bool IsValidUrl(this string text)
        {
            Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(text);
        }

        /// <summary>
        /// Determines whether the source is proper HTML document having DOCTYPE header or
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if [is proper HTML document] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean isProperHtmlDocument(this String source)
        {
            source = source.ToLower();
            if (source.Contains("<!doctype html")) return true;
            if (source.Contains("<html") && source.Contains("<body")) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Regex select PotentialStreetAndNumber : ([A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}\s+[\w\d\\-]{1,})
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isPotentialStreetAndNumber = new Regex(@"([A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}\s+[\w\d\\-]{1,})", RegexOptions.Compiled);

        /// <summary>
        /// Test if input matches ([A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}\s+[\w\d\\-]{1,})
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isPotentialStreetAndNumber</returns>
        public static Boolean isPotentialStreetAndNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isPotentialStreetAndNumber.IsMatch(input);
        }




        /// <summary>
        /// Regex select PotentialPersonalNamePair : [A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isPotentialPersonalNamePair =
            new Regex(@"[A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}", RegexOptions.Compiled);


        /// <summary>
        /// Regex select IsPotentialCityAndPost : (\b[\d]{5}[\s\n]{1,3}([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}))|(([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}){1}[\s\n]{1,3}[\d]{5}\b)
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isIsPotentialCityAndPost =
            new Regex(
                @"(\b[\d]{5}[\s\n]{1,3}([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}))|(([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}){1}[\s\n]{1,3}[\d]{5}\b)",
                RegexOptions.Compiled);


        /// <summary>
        /// Regex select QuotedSubSentence : ([\""]([A-Za-z\s,;:\-])+[\""])
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isQuotedSubSentence = new Regex(@"([\""]([A-Za-z\s,;:\-])+[\""])",
                                                                    RegexOptions.Compiled);


        /// <summary>
        /// Regex select EnbracedSubSentence : ([\(]([A-Za-z\s,;:\-])+[\)])
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isEnbracedSubSentence = new Regex(@"([\(]([A-Za-z\s,;:\-])+[\)])",
                                                                      RegexOptions.Compiled);


        /// <summary>
        /// Regex select EnumerationSubSentence : \b([\:]{1}([\s]*([A-ZČŠĆŽĐa-zžđščć]{1,3})+([\s]{0,2}([,\;\-]{1}|[\s]{0,1}[\w]{1}[\s]{1}))*){1,})
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isEnumerationSubSentence =
            new Regex(
                @"\b([\:]{1}([\s]*([A-ZČŠĆŽĐa-zžđščć]{1,3})+([\s]{0,2}([,\;\-]{1}|[\s]{0,1}[\w]{1}[\s]{1}))*){1,})",
                RegexOptions.Compiled);


        /// <summary>
        /// Regex select InnerSentence : (,{1}[\s]{1})([\w\d\s]*)(,{1}[\s]{1})
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isInnerSentence = new Regex(@"(,{1}[\s]{1})([\w\d\s]*)(,{1}[\s]{1})",
                                                                RegexOptions.Compiled);


        /// <summary>
        /// Regex select SentenceFragmentCase : ^[a-zžđščć\d\.\-_,:;\(\)]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <remarks>
        /// <para>Kao da predstavlja deo neke recenice -- obavezno pocinje malim slovom</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isSentenceFragmentCase =
            new Regex(@"^[a-zžđščć\d\.\-_,:;\(\)]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$", RegexOptions.Compiled);


        /// <summary>
        /// Regex select LowerCase : ^[a-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isLowerCase = new Regex(@"^[a-zžđščć\s\d\.\-_,:;\(\)]{1,}$", RegexOptions.Compiled);


        /// <summary>
        /// Regex select UpperCase : ^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐ\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isUpperCase = new Regex(@"^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐ\s\d\.\-_,:;\(\)]{1,}$",
                                                            RegexOptions.Compiled);


        /// <summary>
        /// Regex select caseCamel : ([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,})
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_wordcaseCamel = new Regex(@"([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,})", RegexOptions.Compiled);


        /// <summary>
        /// Regex select caseUpper : ([A-ZČŠĆŽĐ]{1,})\b
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_wordcaseUpper = new Regex(@"([A-ZČŠĆŽĐ]{1,})", RegexOptions.Compiled);


        /// <summary>
        /// Regex select caseLower : ([a-zžđščć]{1,})
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_wordcaseLower = new Regex(@"([a-zžđščć]{1,})", RegexOptions.Compiled);


        /// <summary>
        /// Regex select SentenceCase : ^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <remarks>
        /// <para>Pocinje velikim slovom, a ostalo kako god</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isSentenceCase = new Regex(
            @"^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$", RegexOptions.Compiled);


        /// <summary>
        /// Regex select StrictSentenceCase : ^[A-ZČŠĆŽĐ]{1}[a-zžđščć\s\d\-_,\:;]{1,}$
        /// </summary>
        /// <remarks>
        /// <para>Proverava da li je u pitanju pravilan sentence case: prvo slovo je veliko, ostalo su mala slova</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isStrictSentenceCase = new Regex(@"^[A-ZČŠĆŽĐ]{1}[a-zžđščć\s\d\-_,\.:;\(\)]{1,}$",
                                                                     RegexOptions.Compiled);


        /// <summary>
        /// Regex select SymbolicContentOnly : ^[\W\s]+$
        /// </summary>
        /// <remarks>
        /// <para>Iskljucivo simboli u sadrzaju</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isSymbolicContentOnly = new Regex(@"^[\W\s]+$", RegexOptions.Compiled);


        /// <summary>
        /// Regex select Word : [A-ZČŠĆŽĐa-zžđščć]{1,}
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isWord = new Regex(@"[A-ZČŠĆŽĐa-zžđščć]{1,}", RegexOptions.Compiled);


        /// <summary>
        /// Regex select FormatedNumber : ([\d]{1,}[\\\/\:\.\-\|\s]{1,3}){0,5}[\d]{1,}
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isFormatedNumber = new Regex(@"([\d]{1,}[\\\/\:\.\-\|\s]{1,3}){0,5}[\d]{1,}",
                                                                 RegexOptions.Compiled);


        /// <summary>
        /// Regex select Number : [\d]+
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isNumber = new Regex(@"\b([\d]+)\b", RegexOptions.Compiled);


        /// <summary>
        /// Regex select DecimalNumber : [\d]{1,}[\,\.]{1,}[\d]{1,}
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isDecimalNumber = new Regex(@"[\d]{1,}[\,\.]{1,}[\d]{1,}", RegexOptions.Compiled);

        /// <summary>
        /// Regex select OrdinalNumber : [\d]{1,}[\.]{1}
        /// </summary>
        /// <remarks>
        /// <para>For text: example text</para>
        /// <para>Selects: ex</para>
        /// </remarks>
        public static Regex _select_isOrdinalNumber = new Regex(@"[\d]{1,}[\.]{1}", RegexOptions.Compiled);

        /// <summary>
        /// Test if input matches [A-ZČŠĆŽĐ]{1}[a-zžđščć]{2,}[\s]{1,4}[A-ZČŠĆŽĐ]{1}[a-zćšđčž]{2,}
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isPotentialPersonalNamePair</returns>
        public static Boolean isPotentialPersonalNamePair(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isPotentialPersonalNamePair.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches (\b[\d]{5}[\s\n]{1,3}([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}))|(([A-ZČŠĆŽĐ]{1}[a-zžđščć]{1,}|[A-ZČŠĆŽĐ]{2,}){1}[\s\n]{1,3}[\d]{5}\b)
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isIsPotentialCityAndPost</returns>
        public static Boolean isIsPotentialCityAndPost(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isIsPotentialCityAndPost.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ([\""]([A-Za-z\s,;:\-])+[\""])
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isQuotedSubSentence</returns>
        public static Boolean isQuotedSubSentence(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isQuotedSubSentence.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ([\(]([A-Za-z\s,;:\-])+[\)])
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isEnbracedSubSentence</returns>
        public static Boolean isEnbracedSubSentence(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isEnbracedSubSentence.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches \b([\:]{1}([\s]*([A-ZČŠĆŽĐa-zžđščć]{1,3})+([\s]{0,2}([,\;\-]{1}|[\s]{0,1}[\w]{1}[\s]{1}))*){1,})
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isEnumerationSubSentence</returns>
        public static Boolean isEnumerationSubSentence(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isEnumerationSubSentence.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches (,{1}[\s]{1})([\w\d\s]*)(,{1}[\s]{1})
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isInnerSentence</returns>
        public static Boolean isInnerSentence(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isInnerSentence.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[a-zžđščć\d\.\-_,:;\(\)]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isSentenceFragmentCase</returns>
        public static Boolean isSentenceFragmentCase(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isSentenceFragmentCase.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[a-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isLowerCase</returns>
        public static Boolean isLowerCase(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isLowerCase.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐ\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isUpperCase</returns>
        public static Boolean isUpperCase(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isUpperCase.IsMatch(input);
        }

        public static Boolean isWordCaseCamel(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_wordcaseCamel.IsMatch(input);
        }

        public static Boolean isWordCaseUpper(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_wordcaseUpper.IsMatch(input);
        }


        public static Boolean isWordCaseLower(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_wordcaseLower.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[A-ZČŠĆŽĐ]{1}[A-ZČŠĆŽĐa-zžđščć\s\d\.\-_,:;\(\)]{1,}$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isSentenceCase</returns>
        public static Boolean isSentenceCase(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isSentenceCase.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[A-ZČŠĆŽĐ]{1}[a-zžđščć\s\d\-_,\:;]{1,}$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isStrictSentenceCase</returns>
        public static Boolean isStrictSentenceCase(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isStrictSentenceCase.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches ^[\W\s]+$
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isSymbolicContentOnly</returns>
        public static Boolean isSymbolicContentOnly(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isSymbolicContentOnly.IsMatch(input);
        }

        /// <summary>
        /// Test if input matches [A-ZČŠĆŽĐa-zžđščć]{1,}
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isWord</returns>
        public static Boolean isWord(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isWord.IsMatch(input);
        }



        /// <summary>
        /// Regex select OneLetterKeyedNumber : [A-ZČŠĆŽĐa-zžđščć]{1}[\d\.\-]+
        /// </summary>
        /// <remarks>
        /// <para>For text: 2000 1000 2 X-5.00 YN1500</para>
        /// <para>Selects: X-5.00</para>
        /// </remarks>
        public static Regex _select_isOneLetterKeyedNumber = new Regex(@"\b[A-ZČŠĆŽĐa-zžđščć]{1}[\-]?[\d\.]+\b", RegexOptions.Compiled);

        /// <summary>
        /// Proverava da li je prodledjen string u formatu [jedno slovo][- ili nista][broj koji moze biti decimalan]
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isOneLetterKeyedNumber</returns>
        public static Boolean isOneLetterKeyedNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isOneLetterKeyedNumber.IsMatch(input);
        }


        

        /// <summary>
        /// Regex select CleanWord : ([A-ZČŠĆŽĐa-zžđščć]{1,})\b
        /// </summary>
        /// <remarks>
        /// <para>For text: TOOL60101 RC 15 5 5 270 MT01</para>
        /// <para>Selects: RC</para>
        /// </remarks>
        public static Regex _select_isCleanWord = new Regex(@"\b([A-ZČŠĆŽĐa-zžđščć\\p{IsCyrillic}]{1,})\b", RegexOptions.Compiled);

        /// <summary>
        /// Proverava da li je string cista rec ili ima jos nesto u sebi -  ([A-ZČŠĆŽĐa-zžđščć]{1,})\b
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isCleanWord</returns>
        public static Boolean isCleanWord(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isCleanWord.IsMatch(input);
        }


        

        /// <summary>
        /// Test if input matches ([\d]{1,}[\\\/\:\.\-\|\s]{1,3}){0,5}[\d]{1,}
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isFormatedNumber</returns>
        public static Boolean isFormatedNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isFormatedNumber.IsMatch(input);
        }

        /// <summary>
        /// Obican broj - nez decimale i bez negativnog znaka [\d]+
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isNumber</returns>
        public static Boolean isNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isNumber.IsMatch(input);
        }




        /// <summary>
        /// Regex select WordNumber : \b[A-ZČŠĆŽĐa-zžđščć]{2,}[\d\.\-]+\b
        /// </summary>
        /// <remarks>
        /// <para>For text: Y500 YE500  004</para>
        /// <para>Selects: YE500</para>
        /// </remarks>
        public static Regex _select_isWordNumber = new Regex(@"^[A-ZČŠĆŽĐa-zžđščć]{1,}[\d]+$", RegexOptions.Compiled);

        /// <summary>
        /// Da li token pocinje sa jednim ili vise slova a zatim sadrzi brojeve
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isWordNumber</returns>
        public static Boolean isWordNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isWordNumber.IsMatch(input);
        }


        

        /// <summary>
        /// Regex select AlfaNumericWord : [\w\d]+
        /// </summary>
        /// <remarks>
        /// <para>For text: 15YN1500 TOOL60101 RC 15 5 5 270 MT01</para>
        /// <para>Selects: 15YN1500 TOOL60101 RC 15 5 5 270 MT01</para>
        /// </remarks>
        public static Regex _select_isAlfaNumericWord = new Regex(@"[\w\d]+", RegexOptions.Compiled);

        /// <summary>
        /// Vraca TRUE ako je slovna ili brojna vrednost - d  [\w\d]+
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isAlfaNumericWord</returns>
        public static Boolean isAlfaNumericWord(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isAlfaNumericWord.IsMatch(input);
        }


        


        /// <summary>
        /// Regex select IntegerOrDecimalWithSign : [\d\-\.]+
        /// </summary>
        /// <remarks>
        /// <para>For text: -5.00 YN1500</para>
        /// <para>Selects: -5.00</para>
        /// </remarks>
        public static Regex _select_isIntegerOrDecimalWithSign = new Regex(@"^([\-\+]?[\d\.]+)$", RegexOptions.Compiled);

        /// <summary>
        /// proverava da li je u pitanju broj koji moze biti decimalan, moze pocinjati i negaitvnom vrednoscu, a moze biti i obican broj bez decimala
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isIntegerOrDecimalWithSign</returns>
        public static Boolean isIntegerOrDecimalWithSign(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isIntegerOrDecimalWithSign.IsMatch(input);
        }


        

        /// <summary>
        /// Test if input matches [\d]{1,}[\,\.]{1,}[\d]{1,}
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isDecimalNumber</returns>
        public static Boolean isDecimalNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isDecimalNumber.IsMatch(input);
        }

        public static Boolean isMultiline(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return input.Contains(Environment.NewLine);
        }


        /// <summary>
        /// Test if input matches [\d]{1,}[\.]{1}
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>IsMatch against _select_isOrdinalNumber</returns>
        public static Boolean isOrdinalNumber(this String input)
        {
            if (String.IsNullOrEmpty(input)) return false;
            return _select_isOrdinalNumber.IsMatch(input);
        }
    }
}