namespace imbSCI.Data.data.text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Collection of Regex markers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.Dictionary{T, aceCommonTypes.data.text.regexMarker{T}}" />
    public class regexMarkerCollection<T> : Dictionary<T, regexMarker<T>>
    {

        public const String REPLACEMENT_PATTERN = "#";

        public Regex scrambleCut = new Regex("(" + REPLACEMENT_PATTERN + "+)");

        /// <summary>
        /// Generates the replacement string for the specified Regex Match
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public String replacementGenerator(Match m)
        {
            String output = REPLACEMENT_PATTERN;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m.Length; i++)
            {
                sb.Append(output);
            }


            return sb.ToString();
            
        }


        /// <summary>
        /// Adds new marker rule
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(regexMarker<T> item)
        {
            if (item == null) return;

            if (item.marker == null)
            {
                item.marker = defaultMarker;
            }

            Add(item.marker, item);
        }

        /// <summary>
        /// The default marker to be applied to the unmatched parts of the text
        /// </summary>
        public T defaultMarker = default(T);

  
        /// <summary>
        /// Processes the specified text input into <see cref="regexMarkerResultCollection{T}"/>
        /// </summary>
        /// <param name="input">The input text to be parsed</param>
        /// <returns>Collection with matched results</returns>
        public regexMarkerResultCollection<T> process(String input)
        {
            regexMarkerResultCollection<T> output = new regexMarkerResultCollection<T>();
            
            String scrambled = input;
            foreach (regexMarker<T> reg in this.Values)
            {
                if (reg != null)
                {
                    MatchCollection mchs = reg.test.Matches(scrambled);
                    foreach (Match m in mchs)
                    {
                        regexMarkerResult res = new regexMarkerResult(m, reg.marker);
                        output.AddResult(res);
                    }
                    scrambled = reg.test.Replace(scrambled, replacementGenerator);
                }
            }

            String[] rest = scrambleCut.Split(scrambled);

            Int32 index = 0;
            
            regexMarkerResult restResult = null;
            foreach (String rst in rest)
            {
                if (output.byAllocation.ContainsKey(index))
                {
                    index = index + output.byAllocation[index].First().match.Length;
                } else
                {
                    index = output.AddResult(rst, index);
                }
            }
            output.length = index;

            return output;
        }
    }

}