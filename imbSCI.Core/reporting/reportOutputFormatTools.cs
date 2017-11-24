namespace imbSCI.Core.reporting
{
    #region imbVeles using

    using System;
    using System.IO;
    using imbSCI.Core.reporting.format;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.enums;

    #endregion



    public static class reportOutputFormatTools
    {

        public static reportIncludeFileType getIncludeFileTypeByExtension(this String filename)
        {
            String ext = Path.GetExtension(filename);
            ext = ext.ToLower();
            ext = ext.Trim('.');
            switch (ext)
            {
                case "css":
                    return reportIncludeFileType.cssStyle;
                    break;
                default:
                    return reportIncludeFileType.unknown;
                    break;
            }
        }

        public static externalTool getDefaultApplication(this reportOutputFormatName outputFormat)
        {
            switch (outputFormat)
            {
                case reportOutputFormatName.htmlReport:
                    return externalTool.firefox;
                    break;
                default:
                    return externalTool.notepadpp;
                    break;
            }
        }

        

        /// <summary>
        /// proverava da li je prosledjen tag defaultTag -- tj. ako jeste vraca podrazumevani tag prema datoj ulozi
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public static htmlTagName checkForDefaultTag(this htmlTagName tag,
                                                     reportOutputRoles role = reportOutputRoles.appendLine)
        {
            if (tag == htmlTagName.defaultTag)
            {
                Object tg = defaultTags[reportOutputFormatName.htmlReport][role];
                if (tg is htmlTagName)
                {
                    tag = (htmlTagName) tg;
                }
            }
            return tag;
        }

        #region --- defaultTags ------- static and autoinitiated object

        private static imbCollectionNestedEnum<reportOutputFormatName, reportOutputRoles, Object> _defaultTags;

        /// <summary>
        /// Kolekcija podrazumevanih tagova za dat oblik izvestavanja
        /// </summary>
        private static imbCollectionNestedEnum<reportOutputFormatName, reportOutputRoles, Object> defaultTags
        {
            get
            {
                if (_defaultTags == null)
                {
                    _defaultTags = new imbCollectionNestedEnum<reportOutputFormatName, reportOutputRoles, Object>();

                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendLine] = htmlTagName.p;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendLink] = htmlTagName.a;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendInline] = htmlTagName.p;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendPair] = htmlTagName.span;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendPairContainer] = htmlTagName.p;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendPairItem] = htmlTagName.span;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.appendPairValue] = htmlTagName.span;
                    _defaultTags[reportOutputFormatName.htmlReport][reportOutputRoles.container] = htmlTagName.div;
                }
                return _defaultTags;
            }
        }

        #endregion

        /*

        #region --- defaultIncludeExtensions ------- lista ekstenzija prema rip

        private static Dictionary<reportIncludeFileType, String> _defaultIncludeExtensions =
            new Dictionary<reportIncludeFileType, string>();
        /// <summary>
        /// lista ekstenzija prema rip
        /// </summary>
        public static Dictionary<reportIncludeFileType, String> defaultIncludeExtensions
        {
            get
            {
                if (_defaultIncludeExtensions == null)
                {
                    _defaultIncludeExtensions = new Dictionary<reportIncludeFileType, String>();
                    _defaultIncludeExtensions.Add(reportIncludeFileType.cssStyle, ".css"
                }
                return _defaultIncludeExtensions;
            }
        }
        #endregion
        */
    }
}