namespace imbSCI.Core.extensions.text
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Selects proper URLs, email@adresses, #tags.
    /// </summary>
    /// \ingroup_disabled ace_ext_string
    public static class imbStringSelectLists
    {

        //public static IEnumerable<string> LowercaseUsernames(string input, int minCharacters, int maxCharacters)
        //{
        //    var regEx = "^[a-z0-9_-]{3,16}$";
        //    regEx = regEx.Replace("3", minCharacters.ToString());
        //    regEx = regEx.Replace("16", maxCharacters.ToString());
        //    var matches = Regex.Matches(input, regEx, RegexOptions.IgnoreCase);
        //    var matchedStrings = new List<string>();
        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        matchedStrings.Add(matches[i].Value);
        //    }
        //    return matchedStrings;
        //}

        /// <summary>
        /// Matches URLs in string using Regex
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<string> imbGetUrls(this string input)
        {
            var matches = Regex.Matches(input, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)",
                                      RegexOptions.IgnoreCase);
            var matchedStrings = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                matchedStrings.Add(matches[i].Value);
            }
            return matchedStrings;
        }

        /// <summary>
        /// Matches all email addresses in string using Regex
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<string> imbGetEmails(this string input)
        {
            var matches = Regex.Matches(input, @"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})",
                                      RegexOptions.IgnoreCase);
            var matchedStrings = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                matchedStrings.Add(matches[i].Value);
            }
            return matchedStrings;
        }

        /// <summary>
        /// Matches all hashtags in string using Regex
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<string> imbGetHashtags(this string input)
        {
            var matches = Regex.Matches(input, @"(^|[^0-9A-Z&/]+)(#|\uFF03)([0-9A-Z_]*[A-Z_]+[a-z0-9_\\u00c0-\\u00d6\\u00d8-\\u00f6\\u00f8-\\u00ff]*)",
                                      RegexOptions.IgnoreCase);
            var matchedStrings = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                matchedStrings.Add(matches[i].Value);
            }
            return matchedStrings;
        }
    }
}
