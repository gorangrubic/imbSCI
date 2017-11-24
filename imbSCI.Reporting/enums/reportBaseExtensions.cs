namespace imbSCI.Reporting.enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Core.reporting.template;
    using imbSCI.Data.enums.fields;

    public static class reportShortActions
    {
        #region SHORT STRING EXTNSION OPERATORS -----------------------------------------------------------------------------------------|


        /// <summary>
        /// Formats <c>fin</c> parameters into <c>format</c> string
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="fin">The fin.</param>
        /// <returns></returns>
        public static String f(this String format, params Object[] fin)
        {
            String output = String.Format(format, fin.getFlatArray<Object>());
            return output;
        }

        /// <summary>
        /// Adds template parameter placeholder
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string t(this String output, Enum input)
        {
            return output + (stringTemplateTools.PLACEHOLDER_Start + input.ToString() + stringTemplateTools.PLACEHOLDER_End);
        }


        /// <summary>
        /// Adds template parameter placeholder
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string t(this String output, templateFieldBasic input)
        {
            return output + (stringTemplateTools.PLACEHOLDER_Start + input.ToString() + stringTemplateTools.PLACEHOLDER_End);
        }

        /// <summary>
        /// Places in quote \"
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string q(this String output, String input)
        {
            return output.a("\"" + input.ToString() + "\"");
        }



        /// <summary>
        /// Short string concating
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string a(this String output, templateFieldBasic input)
        {
            return output.a(input.ToString());
        }

        /// <summary>
        /// synonim of a() - uses .ToString() on input object
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string o(this String output, Object input)
        {
            return output.a(input.ToString());
        }

        public static object removeStartsWith(string path, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// short string contacting - a from Add
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string a(this String output, String input)
        {

            String separator = " ";

            if (String.IsNullOrEmpty(input))
            {
                return output;
            }
            if (output.Length > 0)
            {
                if (!output.EndsWith(separator) && !input.StartsWith(separator))
                {

                    output += separator;
                }
            }

            output += input;

            return output;
        }

        #endregion  -----------------------------------------------------------------------------------------------------------|

    }



    public enum reportBaseExtensions
    {
        txt,
        html,
        xml,
        log,
        css,
        js,
        /// <summary>
        /// Primenjuje custom ekstenziju u skladu sa izvestajem
        /// </summary>
        custom
    }
}
