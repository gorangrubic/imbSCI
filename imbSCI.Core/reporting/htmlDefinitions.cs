namespace imbSCI.Core.reporting
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;

    #endregion

    //public enum htmlTagForm
    //{
    //    openFormat,
    //    closeFormat,
    //}

    /// <summary>
    /// Definicije i konstante vezane za HTML
    /// </summary>
    public static class htmlDefinitions
    {
        //#region --- htmlTags ------- static and autoinitiated object
        //private static imbCollectionNestedEnumToString<htmlTagForm, htmlTagName> _htmlTags;
        ///// <summary>
        ///// static and autoinitiated object
        ///// </summary>
        //public static imbCollectionNestedEnumToString<htmlTagForm, htmlTagName> htmlTags
        //{
        //    get
        //    {
        //        if (_htmlTags == null)
        //        {
        //            _htmlTags = new imbCollectionNestedEnumToString<htmlTagForm, htmlTagName>(true);

        //        }
        //        return _htmlTags;
        //    }
        //}
        //#endregion


        public static String HTMLTag_Script = "script";
        public static String HTMLTag_Style = "style";
        public static String HTMLTag_Meta = "meta";

        public static Char[] HTMLMeta_keywordsSepparators = new char[] {' ', ',', ';'};

        public static List<String> HTMLTags_metaTags = new List<string>(new String[] {"title", "meta"});
        public static List<String> HTMLTags_linkTags = new List<string>(new String[] {"a", "link"});

        public static List<String> HTMLTags_headingTags =
            new List<string>(new String[]
                                 {"h1", "h2", "h3", "h4", "h5", "h6", "th", "title", "caption", "label", "figcaption"});

        public static List<String> HTMLTags_highlightTags =
            new List<string>(new String[] {"em", "strong", "b", "u", "big", "i", "mark", "tt"});

        public static List<String> HTMLTags_textSemanticTags =
            new List<string>(new String[]
                                 {
                                     "dfn", "code", "samp", "time", "kbd", "var", "abbr", "acronym", "hr", "wbr", "cite",
                                     "q", "samp", "s", "sub", "sup"
                                 });

        public static List<String> HTMLTags_listStructureTags = new List<string>(new String[] {"ol", "ul", "menu", "dl"});
        public static List<String> HTMLTags_listItemTags = new List<string>(new String[] {"li", "dt", "dd"});
        public static List<String> HTMLTags_tableStructureTags = new List<string>(new String[] {"table", "tbody"});

        public static List<String> HTMLTags_tableItemTags =
            new List<string>(new String[] {"tr", "td", "th", "thead", "tfoot", "colgroup", "col"});

        public static List<String> HTMLTags_blockStructureTags = new List<string>(new String[] {"div", "span", "p"});

        public static List<String> HTMLTags_semanticStructureTags =
            new List<string>(new String[]
                                 {
                                     "article", "header", "footer", "section", "blockquote", "main", "details", "summary",
                                     "address", "figure", "aside", "nav"
                                 });

        internal static List<String> _HTMLTags_allStructureTags = null;

        public static List<String> HTMLTags_frameStructureTags = new List<string>(new String[] {"iframe", "frameset"});

        public static List<String> HTMLTags_scriptAndMetaTags =
            new List<string>(new String[] {"style", "script", "meta", "link", "base", "title", "noscript"});

        public static List<String> HTMLTags_imageTags = new List<string>(new String[] {"img", "canvas"});

        public static List<String> HTMLTags_multimediaTags =
            new List<string>(new String[] {"video", "audio", "embed", "object", "track", "applet"});

        public static List<String> HTMLTags_formInputTags =
            new List<string>(new String[]
                                 {"form", "input", "textarea", "select", "keygen", "datalist", "fieldset", "button"});

        public static List<String> HTMLTags_interfaceTags =
            new List<string>(new String[] {"button", "progress", "meter", "command"});

        public static List<String> HTMLTags_allStructureTags
        {
            get
            {
                if (_HTMLTags_allStructureTags == null)
                {
                    List<String> output = new List<string>();
                    output.AddRange(HTMLTags_listStructureTags);
                    output.AddRange(HTMLTags_tableStructureTags);
                    output.AddRange(HTMLTags_blockStructureTags);
                    output.AddRange(HTMLTags_semanticStructureTags);
                    _HTMLTags_allStructureTags = output;
                }
                return _HTMLTags_allStructureTags;
            }
        }
    }
}