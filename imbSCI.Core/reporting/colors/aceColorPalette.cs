// --------------------------------------------------------------------------------------------------------------------
// <copyright file="aceColorPalette.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubić
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.reporting.colors
{
    #region imbVeles using

    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Xml.Serialization;
// using System.Drawing;
    //using System.
    //using System.Media;
    using mColor = System.Windows.Media.Color;
    using gColor = System.Drawing.Color;


    using colorBrush = System.Windows.Media.SolidColorBrush;
    using gGradient = System.Drawing.Drawing2D.LinearGradientBrush;
    using imbSCI.Data.collection.special;
    using imbSCI.Core.extensions.enumworks;
    using imbSCI.Data.enums.fields;
    using imbSCI.Data;
    using imbSCI.Data.collection;
    using System.Windows.Media;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.extensions.text;

    //using aceCommonTypes.colors;
    #endregion

    /// <summary>
    /// Klasa koja pravi set pozadina i boja za tekst na osnovu osnovne boje
    /// </summary>
    /// \ingroup_disabled report_ll
    //[XmlInclude(typeof (System.Windows.Media.MatrixTransform)), XmlInclude(typeof (System.Windows.Media.GradientStop))]
    public class aceColorPalette : imbBindable, IHasDescribeMethod, IAppendDataFields
    {



        /// <summary>
        /// Gets the color wheel.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public colorWhellForContent getColorWheel()
        {
            
            colorWhellForContent output = new colorWhellForContent(bgColors[acePaletteVariationRole.even.ToInt32()].toHexColor(), bgColors[acePaletteVariationRole.odd.ToInt32()].toHexColor(), bgColors[acePaletteVariationRole.important.ToInt32()].toHexColor());
            output.header = bgColors[acePaletteVariationRole.header.ToInt32()].toHexColor();
            output.footer = bgColors[acePaletteVariationRole.important.ToInt32()].toHexColor();
            output.heading = bgColors[acePaletteVariationRole.heading.ToInt32()].toHexColor();
            return output;
        }

        #region -----------  name  -------  [Human name]
        private String _name = "A"; // = new String();
                                    /// <summary>
                                    /// Human name
                                    /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("name")]
        [Description("Human name")]
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                // Boolean chg = (_name != value);
                _name = value;
                OnPropertyChanged("name");
                // if (chg) {}
            }
        }
        #endregion

        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        public PropertyCollection AppendDataFields(PropertyCollection data = null)
        {
            if (data == null) data = new PropertyCollection();
            data[templateFieldStyling.color_base] = baseColor.toHexColor();
            data[templateFieldStyling.color_name] = name;
            data[templateFieldStyling.color_path] = path;

            for (int i = 0; i < 5; i++)
            {
                data[imbSciStringExtensions.add("color_foreground", i.ToString(), "")] = colorsFore[i].toHexColor();
                data[imbSciStringExtensions.add("color_background", i.ToString(), "")] = colorsBottom[i].toHexColor();
                data[imbSciStringExtensions.add("color_top", i.ToString(), "")] = colorsOnTop[i].toHexColor();

            }


            return data;
        }


        /// <summary>
        /// Gets the CSS definition for this color pallete
        /// </summary>
        /// <returns></returns>
        public String getCSS(String __name)
        {

            String output = "";

            //colorsOnTop = new aceCollectionLimitSafe<Color>();
            //colorsBottom = new aceCollectionLimitSafe<Color>();
            //colorsFore = new aceCollectionLimitSafe<Color>();

            Int32 cc = colorsOnTop.Count;

            for (int i = 0; i < cc; i++)
            {
                output = output + imbSciStringExtensions.add(__name, i.ToString(), "_") + " {" + Environment.NewLine;

                output += "color: " + colorsFore[i].toHexColor(true) + ";" + Environment.NewLine;
                output += "background-color:" + colorsBottom[i].toHexColor(true) + ";" + Environment.NewLine;

                output = output + "}" + Environment.NewLine + Environment.NewLine;
            }
            
            return output;
        }


        #region --- path ------- jedinstvena id putanja

        private String _path;

        /// <summary>
        /// jedinstvena id putanja
        /// </summary>
        public String path
        {
            get
            {
                //if (String.IsNullOrEmpty(_path))
                //{
                //   // _path = aceColorPaletteManager.makePath(hexColor, _vDelta, _sDelta )
                //}
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }

        #endregion

        #region --- gDelta ------- Bindable property

        private float _gDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public float gDelta
        {
            get { return _gDelta; }
            set
            {
                _gDelta = value;
                OnPropertyChanged("gDelta");
            }
        }

        #endregion

        #region --- hDelta ------- Bindable property

        private Int32 _hDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public Int32 hDelta
        {
            get { return _hDelta; }
            set
            {
                _hDelta = value;
                OnPropertyChanged("hDelta");
            }
        }

        #endregion

        #region --- sDelta ------- Bindable property

        private float _sDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public float sDelta
        {
            get { return _sDelta; }
            set
            {
                _sDelta = value;
                OnPropertyChanged("sDelta");
            }
        }

        #endregion

        #region --- vDelta ------- Bindable property

        private float _vDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public float vDelta
        {
            get { return _vDelta; }
            set
            {
                _vDelta = value;
                OnPropertyChanged("vDelta");
            }
        }

        #endregion

        #region --- ccount ------- Bindable property

        private Int32 _ccount = 8;

        /// <summary>
        /// Bindable property
        /// </summary>
        public Int32 ccount
        {
            get { return _ccount; }
            set
            {
                _ccount = value;
                OnPropertyChanged("ccount");
            }
        }

        #endregion

        #region --- foreSnap ------- Bindable property

        private Boolean _foreSnap;

        /// <summary>
        /// Bindable property
        /// </summary>
        public Boolean foreSnap
        {
            get { return _foreSnap; }
            set
            {
                _foreSnap = value;
                OnPropertyChanged("foreSnap");
            }
        }

        #endregion

        #region -----------  hexColor  -------  [Hexa decimalna vrednost boje]

        private String _hexColor; // = new String();

        /// <summary>
        /// Hexa decimalna vrednost boje
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("hexColor")]
        [Description("Hexa decimalna vrednost boje")]
        public String hexColor
        {
            get { return _hexColor; }
            set
            {
                // Boolean chg = (_hexColor != value);
                _hexColor = value;
                OnPropertyChanged("hexColor");
                // if (chg) {}
            }
        }

        #endregion

        #region --- iconKey ------- Preporučena ikonica

        private String _iconKey;

        /// <summary>
        /// Preporučena ikonica - takodje preuzima je i sa imbAttribute-a > menuItem
        /// </summary>
        public String iconKey
        {
            get { return _iconKey; }
            set
            {
                _iconKey = value;
                OnPropertyChanged("iconKey");
            }
        }

        #endregion

        #region --- baseColor ------- Osnovna boja od koje je počela paleta

        private Color _baseColor;

        /// <summary>
        /// Osnovna boja od koje je počela paleta
        /// </summary>
        // [XmlIgnore]
        public Color baseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                OnPropertyChanged("baseColor");
            }
        }

        #endregion

        //private float _gDelta = 0.1F;
        //private Int32 _hDelta = 0;
        //private float _sDelta = 0.1F;
        //private float _vDelta = 0.2F;
        //private Int32 _ccount = 5;
        //private Boolean _foreSnap = false;
        //  private String _hexColor = "#FF3300";

        // [XmlIgnore]
        // public ObservableCollection<Color> colorsOnTop = new ObservableCollection<Color>();
        // [XmlIgnore]
        public const Int32 minCount = 5;

        #region --- disabled ------- Boja za ugasen objekat

        private LinearGradientBrush _disabled;

        /// <summary>
        /// Bindable property
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush disabled
        {
            get { return _disabled; }
            set
            {
                _disabled = value;
                OnPropertyChanged("disabled");
            }
        }

        #endregion

        /// public ObservableCollection<Color> colorsBottom = new ObservableCollection<Color>();
        // [XmlIgnore]
        // public ObservableCollection<Color> colorsFore = new ObservableCollection<Color>();
        // [XmlIgnore]
        //public ObservableCollection<LinearGradientBrush> backgrounds = new ObservableCollection<LinearGradientBrush>();
        // [XmlIgnore]
        //public ObservableCollection<SolidColorBrush> underLines = new ObservableCollection<SolidColorBrush>();
        // [XmlIgnore]
        //public ObservableCollection<SolidColorBrush> foregrounds = new ObservableCollection<SolidColorBrush>();

        #region -----------  foregrounds  -------  [solid brushevi za ispisivanje teksta]
        private aceCollectionLimitSafe<SolidColorBrush> _foregrounds = new aceCollectionLimitSafe<SolidColorBrush>();

        /// <summary>
        /// blanko konstruktor
        /// </summary>
        public aceColorPalette()
        {
        }


        #region --- fgColors ------- foreground colors in Drawing namespace 
        private aceCollectionLimitSafe<gColor> _tpColors = new aceCollectionLimitSafe<gColor>();
        /// <summary>
        /// On top of background
        /// </summary>
        public aceCollectionLimitSafe<gColor> tpColors
        {
            get
            {
                return _tpColors;
            }
            set
            {
                _tpColors = value;
                OnPropertyChanged("tpColors");
            }
        }
        #endregion

        #region --- bgColors ------- Background colors in Drawing namespace 
        private aceCollectionLimitSafe<gColor> _bgColors = new aceCollectionLimitSafe<gColor>();
        /// <summary>
        /// Background colors in Drawing namespace
        /// </summary>
        public aceCollectionLimitSafe<gColor> bgColors
        {
            get
            {
                return _bgColors;
            }
            set
            {
                _bgColors = value;
                OnPropertyChanged("bgColors");
            }
        }
        #endregion


        #region --- fgColors ------- foreground colors in Drawing namespace 
        private aceCollectionLimitSafe<gColor> _fgColors = new aceCollectionLimitSafe<gColor>();
        /// <summary>
        /// foreground colors in Drawing namespace
        /// </summary>
        public aceCollectionLimitSafe<gColor> fgColors
        {
            get
            {
                return _fgColors;
            }
            set
            {
                _fgColors = value;
                OnPropertyChanged("fgColors");
            }
        }
        #endregion




        /// <summary>
        /// Generiše paletu boja, pozadina i dodatnih brusheva
        /// </summary>
        /// <param name="hexBaseColor">HTML/Hexadecimalni format boja. npr: #FFCC00</param>
        /// <param name="gradientDelta">Kolika je razlika između gornjeg i donjeg kraja gradijenta, ~0.1</param>
        /// <param name="hDelta">Promena boje HUE</param>
        /// <param name="sDelta">Promena saturacije </param>
        /// <param name="vDelta">Promena svetline</param>
        /// <param name="colorCount">Koliko boja da generiše (min. 5)</param>
        /// <param name="foreColorSnap">Da li da koristi crnu i belu umesto obojenih foreground-a</param>
        public aceColorPalette(String hexBaseColor, float gradientDelta = 0.1F, Int32 hDelta = 0, float sDelta = 0.05F,
                            float vDelta = 0.05F, Int32 colorCount = 8, Boolean foreColorSnap = true,
                            String __path = null)
        {
            if (String.IsNullOrEmpty(__path))
                __path = aceColorConverts.makePath(hexBaseColor, vDelta, sDelta, hDelta, foreColorSnap);

            createPalette(hexBaseColor, gradientDelta, hDelta, sDelta, vDelta, colorCount, foreColorSnap, __path);
        }

        public aceCollectionLimitSafe<System.Drawing.SolidBrush> fgBrushes = new aceCollectionLimitSafe<System.Drawing.SolidBrush>();
        public aceCollectionLimitSafe<System.Drawing.SolidBrush> tpBrushes = new aceCollectionLimitSafe<System.Drawing.SolidBrush>();
        public aceCollectionLimitSafe<System.Drawing.Drawing2D.LinearGradientBrush> bgBrushes = new aceCollectionLimitSafe<System.Drawing.Drawing2D.LinearGradientBrush>();



        /// <summary>
        /// solid brushevi za ispisivanje teksta
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("foregrounds")]
        [Description("solid brushevi za ispisivanje teksta")]
        public aceCollectionLimitSafe<SolidColorBrush> foregrounds
        {
            get { return _foregrounds; }
            set
            {
                // Boolean chg = (_foregrounds != value);
                _foregrounds = value;
                OnPropertyChanged("foregrounds");
                // if (chg) {}
            }
        }

        #endregion

        /// <summary>
        /// Top colors colorsOnTop[0] (Color)
        /// </summary>
        [XmlIgnore]
        public Color colorsOnTop0
        {
            get { return colorsOnTop[0]; }
        }

        /// <summary>
        /// Top colors colorsOnTop[1] (Color)
        /// </summary>
        [XmlIgnore]
        public Color colorsOnTop1
        {
            get { return colorsOnTop[1]; }
        }

        /// <summary>
        /// Top colors colorsOnTop[2] (Color)
        /// </summary>
        [XmlIgnore]
        public Color colorsOnTop2
        {
            get { return colorsOnTop[2]; }
        }

        /// <summary>
        /// Top colors colorsOnTop[3] (Color)
        /// </summary>
        [XmlIgnore]
        public Color colorsOnTop3
        {
            get { return colorsOnTop[3]; }
        }

        /// <summary>
        /// Top colors colorsOnTop[4] (Color)
        /// </summary>
        [XmlIgnore]
        public Color colorsOnTop4
        {
            get { return colorsOnTop[4]; }
        }


        /// <summary>
        /// 1 pozadina
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush bg0
        {
            get { return backgrounds[0]; }
        }

        /// <summary>
        /// 2 pozadina
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush bg1
        {
            get { return backgrounds[1]; }
        }

        /// <summary>
        /// 3 pozadina
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush bg2
        {
            get { return backgrounds[2]; }
        }

        /// <summary>
        /// 4 pozadina
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush bg3
        {
            get { return backgrounds[3]; }
        }

        /// <summary>
        /// 5 pozadina
        /// </summary>
        [XmlIgnore]
        public LinearGradientBrush bg4
        {
            get { return backgrounds[4]; }
        }


        /// <summary>
        /// Boja za slova foregrounds[0] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush foregrounds0
        {
            get { return foregrounds[0]; }
        }

        /// <summary>
        /// Boja za slova foregrounds[1] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush foregrounds1
        {
            get { return foregrounds[1]; }
        }

        /// <summary>
        /// Boja za slova foregrounds[2] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush foregrounds2
        {
            get { return foregrounds[2]; }
        }

        /// <summary>
        /// Boja za slova foregrounds[3] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush foregrounds3
        {
            get { return foregrounds[3]; }
        }

        /// <summary>
        /// Boja za slova foregrounds[4] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush foregrounds4
        {
            get { return foregrounds[4]; }
        }


        /// <summary>
        /// Podvucene linije underLines[0] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush underLines0
        {
            get { return underLines[0]; }
        }

        /// <summary>
        /// Podvucene linije underLines[1] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush underLines1
        {
            get { return underLines[1]; }
        }

        /// <summary>
        /// Podvucene linije underLines[2] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush underLines2
        {
            get { return underLines[2]; }
        }

        /// <summary>
        /// Podvucene linije underLines[3] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush underLines3
        {
            get { return underLines[3]; }
        }

        /// <summary>
        /// Podvucene linije underLines[4] (SolidColorBrush)
        /// </summary>
        [XmlIgnore]
        public SolidColorBrush underLines4
        {
            get { return underLines[4]; }
        }

        #region --- customKeyId ------- custom key id

        private String _customKeyId;

        /// <summary>
        /// custom key id
        /// </summary>
        public String customKeyId
        {
            get { return _customKeyId; }
            set
            {
                _customKeyId = value;
                OnPropertyChanged("customKeyId");
            }
        }

        #endregion

        #region -----------  underLines  -------  [Solid color brushevi za podvlacenje itema]

        private aceCollectionLimitSafe<SolidColorBrush> _underLines = new aceCollectionLimitSafe<SolidColorBrush>();

        /// <summary>
        /// Solid color brushevi za podvlacenje itema
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("underLines")]
        [Description("Solid color brushevi za podvlacenje itema")]
        public aceCollectionLimitSafe<SolidColorBrush> underLines
        {
            get { return _underLines; }
            set
            {
                // Boolean chg = (_underLines != value);
                _underLines = value;
                OnPropertyChanged("underLines");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  backgrounds  -------  [Gradient brushovi za pozadinu]

        private aceCollectionLimitSafe<LinearGradientBrush> _backgrounds = new aceCollectionLimitSafe<LinearGradientBrush>();

        /// <summary>
        /// Gradient brushovi za pozadinu
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("backgrounds")]
        [Description("Gradient brushovi za pozadinu")]
        public aceCollectionLimitSafe<LinearGradientBrush> backgrounds
        {
            get { return _backgrounds; }
            set
            {
                // Boolean chg = (_backgrounds != value);
                _backgrounds = value;
                OnPropertyChanged("backgrounds");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  colorsFore  -------  [Boje za foreground]

        private aceCollectionLimitSafe<Color> _colorsFore = new aceCollectionLimitSafe<Color>();

        /// <summary>
        /// Boje za foreground
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("colorsFore")]
        [Description("Boje za foreground")]
        public aceCollectionLimitSafe<Color> colorsFore
        {
            get { return _colorsFore; }
            set
            {
                // Boolean chg = (_colorsFore != value);
                _colorsFore = value;
                OnPropertyChanged("colorsFore");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  colorsBottom  -------  [Boje za donju stranu gradient brusha]

        private aceCollectionLimitSafe<Color> _colorsBottom = new aceCollectionLimitSafe<Color>();

        /// <summary>
        /// Boje za donju stranu gradient brusha
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("colorsBottom")]
        [Description("Boje za donju stranu gradient brusha")]
        public aceCollectionLimitSafe<Color> colorsBottom
        {
            get { return _colorsBottom; }
            set
            {
                // Boolean chg = (_colorsBottom != value);
                _colorsBottom = value;
                OnPropertyChanged("colorsBottom");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  colorsOnTop  -------  [Boje za gornju stranu gradient brusha]

        private aceCollectionLimitSafe<Color> _colorsOnTop = new aceCollectionLimitSafe<Color>();

        /// <summary>
        /// Boje za gornju stranu gradient brusha
        /// </summary>
        // [XmlIgnore]
        [Category("aceColorPalette")]
        [DisplayName("colorsOnTop")]
        [Description("Boje za gornju stranu gradient brusha")]
        public aceCollectionLimitSafe<Color> colorsOnTop
        {
            get { return _colorsOnTop; }
            set
            {
                // Boolean chg = (_colorsOnTop != value);
                _colorsOnTop = value;
                OnPropertyChanged("colorsOnTop");
                // if (chg) {}
            }
        }

        #endregion

        /// <summary>
        /// Prazni sve kolekcije
        /// </summary>
        public void clearCollections()
        {
            colorsOnTop = new aceCollectionLimitSafe<Color>();
            colorsBottom = new aceCollectionLimitSafe<Color>();
            colorsFore = new aceCollectionLimitSafe<Color>();

            backgrounds = new aceCollectionLimitSafe<LinearGradientBrush>();
            underLines = new aceCollectionLimitSafe<SolidColorBrush>();
            foregrounds = new aceCollectionLimitSafe<SolidColorBrush>();

            
        }

        /// <summary>
        /// (re)Generiše paletu boja - koristi postojeca podesavanja
        /// </summary>
        /// <param name="hexBaseColor">HTML/Hexadecimalni format boja. npr: #FFCC00</param>
        public void createPalette(String hexBaseColor)
        {
            createPalette(hexBaseColor, _gDelta, _hDelta, _sDelta, _vDelta, _ccount, _foreSnap);
        }

        /// <summary>
        /// Generiše paletu boja, pozadina i dodatnih brusheva
        /// </summary>
        /// <param name="hexBaseColor">HTML/Hexadecimalni format boja. npr: #FFCC00</param>
        /// <param name="gradientDelta">Kolika je razlika između gornjeg i donjeg kraja gradijenta, ~0.1</param>
        /// <param name="hDelta">Promena boje HUE</param>
        /// <param name="sDelta">Promena saturacije </param>
        /// <param name="vDelta">Promena svetline</param>
        /// <param name="colorCount">Koliko boja da generiše (min. 5)</param>
        /// <param name="foreColorSnap">Da li da koristi crnu i belu umesto obojenih foreground-a</param>
        public void createPalette(String hexBaseColor, float __gradientDelta, Int32 __hDelta, float __sDelta,
                                  float __vDelta, Int32 __colorCount = 8, Boolean __foreColorSnap = false,
                                  String __path = "")
        {
            clearCollections();

            gDelta = __gradientDelta;
            hDelta = __hDelta;
            sDelta = __sDelta;
            vDelta = __vDelta;
            ccount = __colorCount;
            _foreSnap = __foreColorSnap;
            _hexColor = hexBaseColor;

            if (String.IsNullOrEmpty(__path))
                __path = aceColorConverts.makePath(hexBaseColor, vDelta, sDelta, hDelta, __foreColorSnap);
            if (!String.IsNullOrEmpty(__path)) path = __path;


            //baseColor = aceColorConverts.fromHexColor(hexBaseColor);
            baseColor = aceColorPaletteManager.getColor(hexBaseColor);

            if (ccount < minCount) ccount = minCount;

            Int32 a;
            for (a = 0; a < ccount; a++)
            {
                float vd = (vDelta*a);
                float sd = (sDelta*a);
                Int32 hd = (hDelta*a);

                var tmpTop = aceColorPaletteManager.getColor(hexBaseColor, vd, sd, hd);
                tpColors.Add(aceColorConverts.toDrawingColor(tmpTop));
                tpBrushes.Add(new System.Drawing.SolidBrush(tpColors[a]));
                colorsOnTop.Add(tmpTop);

                var tmpBg = aceColorPaletteManager.getColor(hexBaseColor, (vd - gDelta), (sd - (gDelta * 2)), hd);
                bgColors.Add(aceColorConverts.toDrawingColor(tmpBg));
                colorsBottom.Add(tmpBg);

                //aceColorConverts.getBrighter(vd, baseColor, sd, hd);
                
                    //aceColorConverts.getBrighter((vd - gradientDelta), baseColor, (sd - (gradientDelta * 2)), hd));

               
                backgrounds.Add(new LinearGradientBrush(colorsOnTop[a], colorsBottom[a], 90));

                gGradient bgGrad = new gGradient(new System.Drawing.PointF(0, 0), new System.Drawing.PointF(50, 50), aceColorConverts.toDrawingColor(colorsOnTop[a]), aceColorConverts.toDrawingColor(colorsBottom[a]));
                bgBrushes.Add(bgGrad);

                


                var tmpFg = aceColorPaletteManager.getColor(hexBaseColor, (vd - gDelta), (sd - (gDelta * 2)), hd, true, __foreColorSnap);
                fgColors.Add(aceColorConverts.toDrawingColor(tmpFg));
                fgBrushes.Add(new System.Drawing.SolidBrush(fgColors[a]));
                colorsFore.Add(tmpFg);

          
                
                underLines.Add(new colorBrush(colorsOnTop[a]));
                foregrounds.Add(new colorBrush(colorsFore[a]));
            }

            Color ds = aceColorPaletteManager.getColor(hexBaseColor, -0.4F, -0.2F, 0);
            Color ds2 = aceColorPaletteManager.getColor(hexBaseColor, -0.3F, -0.1F, 90);

            disabled = new LinearGradientBrush(ds, ds2, 90);
        }

        #region Implementation of IHasDescribeMethod

        public string describe(int tabInsert)
        {
            return describe((string) "\t".Repeat(tabInsert));
        }

        public string statusLine
        {
            get
            {
                return label + String.Format(
                    " OnTop({0}) OnBottom({1}) Backgrounds({2}) ForeColors({3}) Underlines({4}) Foregrounds({5}) ",
                    colorsOnTop.Count, colorsBottom.Count, backgrounds.Count, colorsFore.Count, underLines.Count,
                    foregrounds.Count);
            }
        }

        public string label
        {
            get { return customKeyId + " pallete based on [" + hexColor + "] variations count: " + ccount.ToString(); }
        }

        public string describe(string __prefix = null)
        {
            return __prefix + " " + hexColor + " Color count: (" + colorsOnTop.Count + ")";
        }

        #endregion
    }
}