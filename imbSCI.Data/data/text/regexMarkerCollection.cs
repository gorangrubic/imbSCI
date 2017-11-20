namespace imbSCI.Data.data.text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Collection of Regex run markers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.Dictionary{T, aceCommonTypes.data.text.regexMarker{T}}" />
    public class regexMarkerCollection<T> : Dictionary<T, regexMarker<T>>
    {
        public Regex scrambleCut = new Regex("(#+)");

        public String replaceGenerator(Match m)
        {
            String output = "#";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m.Length; i++)
            {
                sb.Append(output);
            }


            return sb.ToString();
            
        }


        public void Add(regexMarker<T> item)
        {
            if (item == null) return;

            if (item.marker == null)
            {
                item.marker = defaultMarker;
            }

            Add(item.marker, item);
        }

        public T defaultMarker = default(T);

        public Regex splitter { get; set; }
        public String splitterExpression { get; set; } = "";


        /// <summary>
        /// Processes the specified text input into regexMarkerREsultCollection
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
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
                    scrambled = reg.test.Replace(scrambled, replaceGenerator);
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