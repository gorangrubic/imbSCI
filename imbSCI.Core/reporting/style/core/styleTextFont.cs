namespace imbSCI.Core.reporting.style.core
{
    using System;
    using System.ComponentModel;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Data.data;
    using imbSCI.Core.extensions.text;
    using System.Drawing;
    using imbSCI.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Font descriptor with some extra data 
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// \ingroup_disabled report_ll_style
    public class styleTextFont : imbBindable
    {
        /// <summary>
        /// Single-font constructor
        /// </summary>
        /// <param name="font"></param>
        public styleTextFont(aceFont font)
        {
            Add(font);
        }



        /// <summary>
        /// Adds the specified font.
        /// </summary>
        /// <param name="font">The font.</param>
        internal void Add(aceFont font)
        {
            if (font == aceFont.none) return;

            fontName = font.ToString().imbTitleCamelOperation(true);
            var newFont = SystemFonts.GetFontByName(fontName);
            if (newFont != null)
            {
                if (drawingFont == null)
                {
                    drawingFont = newFont;
                    family = drawingFont.FontFamily;
                }
                systemFontList.Add(newFont);
            }

            if (_systemFont == null)
            {
                _systemFont = System.Drawing.SystemFonts.CaptionFont;
            }
        }

        /// <summary>
        /// Constructor with multiple fonts load
        /// </summary>
        /// <param name="fontNames"></param>
        public styleTextFont(params aceFont[] fontNames)
        {
            foreach (aceFont font in fontNames)
            {
                Add(font);
            }
        }

        /// <summary>
        /// Returns font family line applicable for CSS and HTML
        /// </summary>
        /// <returns></returns>
        public String getFontFamilyLine()
        {
            String output = "";
            
            foreach (Font font in systemFontList)
            {
                output = imbSciStringExtensions.add(output, font.Name, ",");
            }
            if (imbSciStringExtensions.isNullOrEmptyString(output))
            {
                output = imbSciStringExtensions.add(output, fontName, ",");
            }
            return imbSciStringExtensions.add(output, ";");
        }


        #region --- family ------- Font Family name 
        private FontFamily _family = new FontFamily("Tahoma");
        /// <summary>
        /// Font Family name
        /// </summary>
        public FontFamily family
        {
            get
            {
                return _family;
            }
            set
            {
                _family = value;
                OnPropertyChanged("family");
            }
        }
        #endregion



        #region -----------  systemFontList  -------  [Complete list of system fonts]
        private List<Font> _systemFontList = new List<Font>(); // = new List<Font>();
                                    /// <summary>
                                    /// Complete list of system fonts
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleTextFont")]
        [DisplayName("systemFontList")]
        [Description("Complete list of system fonts")]
        public List<Font> systemFontList
        {
            get
            {
                return _systemFontList;
            }
            set
            {
                // Boolean chg = (_systemFontList != value);
                _systemFontList = value;
                OnPropertyChanged("systemFontList");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  systemFont  -------  [reference to System font]
        private Font _systemFont; // = new Font();
                                    /// <summary>
                                    /// reference to System font
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleTextFont")]
        [DisplayName("systemFont")]
        [Description("reference to System font")]
        public Font drawingFont
        {
            get
            {
               
                return _systemFont;
            }
            set
            {
                // Boolean chg = (_systemFont != value);
                _systemFont = value;
                OnPropertyChanged("systemFont");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  style  -------  [Font style]
        private FontStyle _style = FontStyle.Regular; // = new FontStyle();
                                    /// <summary>
                                    /// Font style
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleTextFont")]
        [DisplayName("style")]
        [Description("Font style")]
        public FontStyle style
        {
            get
            {
                return _style;
            }
            set
            {
                // Boolean chg = (_style != value);
                _style = value;
                OnPropertyChanged("style");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  fontName  -------  [font name - to be used even if systemFont fails]
        private String _fontName = ""; // = new String();
                                    /// <summary>
                                    /// font name - to be used even if systemFont fails
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleTextFont")]
        [DisplayName("fontName")]
        [Description("font name - to be used even if systemFont fails")]
        public String fontName
        {
            get
            {
                return _fontName;
            }
            set
            {
                // Boolean chg = (_fontName != value);
                _fontName = value;
                OnPropertyChanged("fontName");
                // if (chg) {}
            }
        }
        #endregion



    }
}