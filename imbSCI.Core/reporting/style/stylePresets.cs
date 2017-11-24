namespace imbSCI.Core.reporting.style
{
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.geometrics;
    using imbSCI.Core.reporting.style.core;

    /// <summary>
    /// 
    /// </summary>
    public static class stylePresets
    {


        #region --- themeCompany ------- Company theme
        private static styleTheme _themeCompany;
        /// <summary>
        /// Company theme
        /// </summary>
        public static styleTheme themeCompany
        {
            get
            {
                if (_themeCompany == null)
                {
                    _themeCompany = new styleTheme(aceBaseColorSetEnum.aceCompany, 16, 10, new fourSideSetting(2), new fourSideSetting(1), enums.aceFont.Impact, enums.aceFont.Helvetica);
                    
                }
                return _themeCompany;
            }
        }
        #endregion


        #region --- themeScience ------- scientific theme
        private static styleTheme _themeScience;
        /// <summary>
        /// scientific theme
        /// </summary>
        public static styleTheme themeScience
        {
            get
            {
                if (_themeScience == null)
                {
                    _themeScience = new styleTheme(aceBaseColorSetEnum.imbScience, 20, 12, new fourSideSetting(4), new fourSideSetting(2), enums.aceFont.Courier, enums.aceFont.Courier);
                }
                return _themeScience;
            }
        }
        #endregion


        #region --- themeBright ------- Theme bright and strong colors
        private static styleTheme _themeBright;
        /// <summary>
        /// Theme bright and strong colors
        /// </summary>
        public static styleTheme themeBright
        {
            get
            {
                if (_themeBright == null)
                {
                    _themeBright = new styleTheme(aceBaseColorSetEnum.aceBrightAndStrong, 18, 11, new fourSideSetting(3), new fourSideSetting(1), enums.aceFont.Georgia, enums.aceFont.Georgia);
                }
                return _themeBright;
            }
        }
        #endregion


        #region --- themeSemantics ------- theme for semantic analysis
        private static styleTheme _themeSemantics;
        /// <summary>
        /// theme for semantic analysis
        /// </summary>
        public static styleTheme themeSemantics
        {
            get
            {
                if (_themeSemantics == null)
                {
                    _themeSemantics = new styleTheme(aceBaseColorSetEnum.imbSemantics, 19, 8, new fourSideSetting(4), new fourSideSetting(1), enums.aceFont.Impact, enums.aceFont.Impact);
                }
                return _themeSemantics;
            }
        }
        #endregion




    }

}