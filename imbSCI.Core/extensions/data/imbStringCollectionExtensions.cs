namespace imbSCI.Core.extensions.data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    using imbSCI.Data;

    /// \ingroup_disabled ace_ext_string
    /// \ingroup_disabled ace_ext_collections
    public static class imbStringCollectionExtensions
    {
        [Flags]
        public enum buildDataTableOptions
        {
            addCounterColumn=1,
            extractPrefix=2,
            extractExceptions=4,

        }

        /// <summary>
        /// Builds the data table from string lines
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="options">The options.</param>
        /// <param name="dataTable">The data table - name</param>
        /// <returns></returns>
        public static DataTable buildDataTable(this IEnumerable<String> lines,buildDataTableOptions options, String dataTable )
        {
            DataTable output = new DataTable(dataTable);
            List<DataColumn> columnList = new List<DataColumn>();

            if (options.HasFlag(buildDataTableOptions.addCounterColumn))
            {
                DataColumn dcId = output.Columns.Add("#", typeof(Int32));
                dcId.AutoIncrement = true;
                dcId.AutoIncrementSeed = 1;
                
            }
            DataColumn dcExceptions = null;
            if (options.HasFlag(buildDataTableOptions.extractExceptions))
            {
                dcExceptions = output.Columns.Add("Exceptions");
                
            }

            DataColumn dc = output.Columns.Add("Content");

            foreach (String ln in lines)
            {
                var dr = output.NewRow();
                if (options.HasFlag(buildDataTableOptions.extractExceptions))
                    {
                        //List<logContentExceptionsFlags> logExceptions = ln.getEnumsDetectedInString<logContentExceptionsFlags>();
                        //dr[dcExceptions] = logExceptions.Join(',');
                        
                    }

                dr[dc] = ln;
                output.Rows.Add(dr);
            }

            return output;
        }


        /// <summary>
        /// Determines whether the specified target contains any of needles
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="needles">The needles.</param>
        /// <returns>
        ///   <c>true</c> if the specified target contains any of needle; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean ContainsAny(this String target, IEnumerable<String> needles, Boolean trimNeedleWhitespace=true)
        {

            foreach (String needle in needles)
            {
                String nd = needle;
                if (trimNeedleWhitespace) nd = needle.Trim();
                if (target.Contains(nd))
                {
                    return true;
                }
            }
            return false;
        }

        
        public static Boolean ContainsAny(this String target, IEnumerable<String> needles, out String match, Boolean trimNeedleWhitespace = true)
        {

            foreach (String needle in needles)
            {
                String nd = needle;
                if (trimNeedleWhitespace) nd = needle.Trim();
                if (target.Contains(nd))
                {
                    match = nd;
                    return true;
                }
            }
            match = "";
            return false;
        }

        public static Boolean ContainsAll(this String target, params String[] needles)
        {
            Boolean output = true;
            foreach (String needle in needles)
            {
                String nd = needle;
                if (!target.Contains(nd))
                {
                    return false;
                }
            }
            return true;
        }


        public static Boolean ContainsAll(this String target, IEnumerable<String> needles, Boolean trimNeedleWhitespace = true)
        {
            Boolean output = true;
            foreach (String needle in needles)
            {
                String nd = needle;
                if (trimNeedleWhitespace) nd = needle.Trim();
                if (!target.Contains(nd))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Adds the <c>value</c> into <see cref="IDictionary"/> under first valid key specified with <c>first</c> and <c>orThese</c> parameters. Returns key value that was finally applied.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="first">The first.</param>
        /// <param name="value">The value.</param>
        /// <param name="orThese">The or these.</param>
        /// <returns></returns>
        /// <exception cref="aceCommonTypes.core.exceptions.aceGeneralException">None of these argument is value - null - AddFirstOr(first, ... orThese others)</exception>
        public static String AddFirstOr<T>(this IDictionary<String, T> target, String first, T value, params String[] orThese)
        {
            List<String> candidates = new List<String>();
             // orThese.getFlatList<String>();
            if (!first.isNullOrEmpty())
            {
                candidates.Add(first);
            }
            candidates.AddRange(orThese);

            foreach (String these in candidates)
            {
                if (!these.isNullOrEmpty())
                {
                    if (!target.ContainsKey(these))
                    {
                        target.Add(these, value);
                        return these;
                    }
                }
            }

            return "";
            //throw new ArgumentOutOfRangeException(nameof( new aceGeneralException("None of these argument is value", null, orThese, "or(first, ... orThese others)");
        }




        /**
         * \ingroup_disabled ace_ext_collections
         * */
        public static void AddSeveral(this IList list, params String[] items)
        {
            foreach (String st in items)
            {
                list.Add(st);
            }
        }


        /// <summary>
        /// Gets the total length of all strings in collection
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="items">The items.</param>
        /// <returns>Sum of Length for all strings</returns>
        public static Int32 getTotalLength(this IEnumerable<String> list, params String[] items)
        {
            Int32 len = 0;
            foreach (String st in items)
            {
                len += st.Length;
            }
            return len;
        }



        /// <summary>
        /// Replaces all Keys with corresponding Values
        /// </summary>
        /// <param name="input"></param>
        /// <param name="willcards"></param>
        /// <returns></returns>
        public static String Replace(this String input, Dictionary<String, String> willcards)
        {
            String output = input;
            foreach (var wc in willcards)
            {
                output = output.Replace(wc.Key, wc.Value);
                
            }
            return output;
        }





        /// <summary>
        /// Inserts new line in String IList collection
        /// </summary>
        /// <param name="output">output to accept new line</param>
        /// <param name="newline">content of the new line</param>
        /// <returns></returns>
        public static IList<String> insertNewLineInOutput(this IList<String> output, String newline)
        {
            if (newline.Length > 0)
            {
                if (newline.StartsWith(" ") && !newline.StartsWith("  "))
                {
                    newline = newline.TrimStart(" ".ToArray());
                }
                output.Add(newline);
            }
            return output;
        }

        /// <summary>
        /// Filter out empty or null entries -  Vraca listu iz koje su izbaceni null i "" stringovi
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// \ingroup_disabled ace_ext_strings
        public static List<String> removeEmptyOrNull(this IEnumerable<String> input)
        {
            List<String> _tkns = new List<string>();
            foreach (String tk in input)
            {
                if (!String.IsNullOrEmpty(tk))
                {
                    _tkns.Add(tk);
                }
            }
            return _tkns;
        }


        public static void removeRange(this IList<String> input, IEnumerable<String> remove)
        {
            
            foreach (String tk in remove)
            {
                input.Remove(tk);   
            }
            
        }
    }
}
