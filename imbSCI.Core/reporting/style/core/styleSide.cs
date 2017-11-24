namespace imbSCI.Core.reporting.style.core
{
    using System;
    using System.ComponentModel;
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Data.data;

    /// <summary>
    /// One side styling> border, pad/margin, color of the border
    /// </summary>
    public class styleSide:imbBindable
    {
        public styleSide(styleSideDirection __direction)
        {
            direction = __direction;
        }


        #region -----------  direction  -------  [direction of this side]
        private styleSideDirection _direction; // = new styleSideDirection();
                                    /// <summary>
                                    /// direction of this side
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleSide")]
        [DisplayName("direction")]
        [Description("direction of this side")]
        public styleSideDirection direction
        {
            get
            {
                return _direction;
            }
            set
            {
                // Boolean chg = (_direction != value);
                _direction = value;
                OnPropertyChanged("direction");
                // if (chg) {}
            }
        }
        #endregion



        /// <summary>
        /// Setups the specified color role.
        /// </summary>
        /// <param name="__colorRole">The color role. Unknown for no changes</param>
        /// <param name="__thickness">The thickness. -1 for no changes</param>
        /// <param name="__padding">The padding.-1 for no changes</param>
        /// <param name="__margin">The margin.-1 for no changes</param>
        /// <param name="__type">The type. Unknown for no changes</param>
        public void setup(acePaletteRole __colorRole = acePaletteRole.none, Int32 __thickness=-1, Int32 __padding=-1, Int32 __margin = -1, styleBorderType __type=styleBorderType.unknown)
        {
           if (__colorRole != acePaletteRole.none) borderColor = __colorRole;
           if (__thickness > -1) thickness = __thickness;
            if (__padding > -1) padding = __padding;
            //padding = __padding;
            if (__margin > -1) margin = __margin;
            //margin = __margin;
            if (__type != styleBorderType.unknown) type = __type;
            type = __type;
        }

        public object this[styleFourSideParameter param]
        {
            get
            {
                switch (param)
                {
                    case styleFourSideParameter.borderColor:
                        return borderColor;
                        break;
                    case styleFourSideParameter.padding:
                        return padding;
                        break;
                    case styleFourSideParameter.margin:
                        return margin;
                        break;
                    case styleFourSideParameter.thickness:
                        return thickness;
                        break;
                    case styleFourSideParameter.type:
                        return type;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (param)
                {
                    case styleFourSideParameter.borderColor:
                        borderColor = (acePaletteRole)value;
                        break;
                    case styleFourSideParameter.padding:
                        padding = (Int32)value;
                        break;
                    case styleFourSideParameter.margin:
                        margin = (Int32)value;
                        break;
                    case styleFourSideParameter.thickness:
                        thickness = (Int32)value;
                        break;
                    case styleFourSideParameter.type:
                        type = (styleBorderType)value;
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        
        #region -----------  type  -------  [type of border on this side]
        private styleBorderType _type = styleBorderType.none; // = new styleBorderType();
        /// <summary>
        /// type of border on this side
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        // [XmlIgnore]
        [Category("styleBorderSide")]
        [DisplayName("type")]
        [Description("type of border on this side")]
        public styleBorderType type
        {
            get
            {
                return _type;
            }
            set
            {
                // Boolean chg = (_type != value);
                if (value == styleBorderType.unknown) return;
                _type = value;
                OnPropertyChanged("type");
                // if (chg) {}
            }
        }
        #endregion


        #region -----------  borderColor  -------  [Color of the border]
        private acePaletteRole _borderColor = acePaletteRole.none; // = new Color();
                                    /// <summary>
                                    /// Color of the border
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleBorderSide")]
        [DisplayName("borderColor")]
        [Description("Color of the border")]
        public acePaletteRole borderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                // Boolean chg = (_borderColor != value);
                if (value == acePaletteRole.none) return;
                _borderColor = value;
               OnPropertyChanged("borderColor");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  thickness  -------  [thickness of border]
        private Int32 _thickness = 0; // = new Int32();
                                    /// <summary>
                                    /// thickness of border
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleBorderSide")]
        [DisplayName("thickness")]
        [Description("thickness of border")]
        public Int32 thickness
        {
            get
            {
                return _thickness;
            }
            set
            {
                // Boolean chg = (_thickness != value);
                if (value < 0) return;
                _thickness = value;
                OnPropertyChanged("thickness");
                // if (chg) {}
            }
        }
        #endregion


        #region -----------  margin  -------  [ammount of margin]
        private Int32 _margin; // = new Int32();
                                    /// <summary>
                                    /// ammount of margin
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleBorderSide")]
        [DisplayName("margin")]
        [Description("ammount of margin")]
        public Int32 margin
        {
            get
            {
                return _margin;
            }
            set
            {
                // Boolean chg = (_margin != value);
                if (value < 0) return;
                _margin = value;
               OnPropertyChanged("margin");
                // if (chg) {}
            }
        }
        #endregion


        #region -----------  padding  -------  [amount of padding]
        private Int32 _padding; // = new Int32();
                                    /// <summary>
                                    /// amount of padding
                                    /// </summary>
        // [XmlIgnore]
        [Category("styleBorderSide")]
        [DisplayName("padding")]
        [Description("amount of padding")]
        public Int32 padding
        {
            get
            {
                return _padding;
            }
            set
            {
                // Boolean chg = (_padding != value);
                if (value < 0) return;
                _padding = value;
                // if (chg) {}
            }
        }
        #endregion

    }

}