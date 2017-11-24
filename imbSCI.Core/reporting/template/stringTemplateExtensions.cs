namespace imbSCI.Core.reporting.template
{
    using imbSCI.Core.extensions.data;
    #region imbVeles using

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Operacije sa stringTemplateExtensions
    /// </summary>
    public static class stringTemplateExtensions
    {
        public static String WILLCARD_NEWLINE = "~nl";


        #region --- willcards ------- collection of template willcards
        private static Dictionary<String, String> _willcards;
        /// <summary>
        /// collection of template willcards
        /// </summary>
        public static Dictionary<String, String> willcards
        {
            get
            {
                if (_willcards == null)
                {
                    _willcards = new Dictionary<String, String>();
                    _willcards.Add("~nl", "\r\n");
                }
                return _willcards;
            }
        }
        #endregion


        /// <summary>
        /// Deploys all template willcards
        /// </summary>
        /// <param name="templateString"></param>
        /// <returns></returns>
        public static String deployTemplateWillcards(this String templateString)
        {
            String output = templateString;

            output = output.Replace(willcards);

            return output;
        }
    }

}
