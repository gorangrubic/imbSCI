namespace imbSCI.Core.reporting.zone
{
    using System;

    /// <summary>
    /// Zone setup for spacing and sizing
    /// </summary>
    /// <seealso cref="textFormatSetupBase" />
    public class cursorZoneSpatialSettings: textFormatSetupBase
    {

        
        

        private Int32 _spatialUnit = 160;
        /// <summary>
        /// Gets or sets the spatial unit (width): width of one Cell Unit
        /// </summary>
        /// <value>
        /// The spatial unit.
        /// </value>
        public Int32 spatialUnit
        {
            get { return _spatialUnit; }
            set { _spatialUnit = value; }
        }


        


        private float _spatialUnitRatioYPerX = 0.2F;

        /// <summary>
        /// Gets or sets the spatial unit ratio y per x.
        /// </summary>
        /// <value>
        /// The spatial unit ratio y per x.
        /// </value>
        public float spatialUnitRatioYPerX
        {
            get { return _spatialUnitRatioYPerX; }
            set { _spatialUnitRatioYPerX = value; }
        }



        #region --- spatialUnitMarginRatio ------- ratio to calculate margin spacing unit from standard spatial unit 
        private float _spatialUnitMarginRatio = 0.5F;
        /// <summary>
        /// ratio to calculate margin spacing unit from standard spatial unit
        /// </summary>
        public float spatialUnitMarginRatio
        {
            get
            {
                return _spatialUnitMarginRatio;
            }
            set
            {
                _spatialUnitMarginRatio = value;
                OnPropertyChanged("spatialUnitMarginRatio");
            }
        }
        #endregion


        #region --- spatialUnitPaddingRatio ------- ratio to calculate padding spacing unit from standard spatial unit 
        private float _spatialUnitPaddingRatio = 0.25F;
        /// <summary>
        /// ratio to calculate padding spacing unit from standard spatial unit
        /// </summary>
        public float spatialUnitPaddingRatio
        {
            get
            {
                return _spatialUnitPaddingRatio;
            }
            set
            {
                _spatialUnitPaddingRatio = value;
                OnPropertyChanged("spatialUnitPaddingRatio");
            }
        }
        #endregion






        private Int32 _spatialUnitHeight = -1;
        /// <summary>
        /// 
        /// </summary>
        public Int32 spatialUnitHeight
        {
            get
            {

                if (_spatialUnitHeight < 0) _spatialUnitHeight = Convert.ToInt32(spatialUnit * spatialUnitRatioYPerX);
                return _spatialUnitHeight;
            }
            set
            {
                _spatialUnitHeight = value;
            }
        }


        #region --- spatialUnitMargin ------- recalculated margin spatial unit, based on ratio 
        private Int32 _spatialUnitMargin = -1;
        /// <summary>
        /// recalculated margin spatial unit, based on ratio
        /// </summary>
        public Int32 spatialUnitMargin
        {
            get
            {
                if (_spatialUnitMargin < -1) _spatialUnitMargin = Convert.ToInt32(spatialUnit * spatialUnitMarginRatio);
                return _spatialUnitMargin;
            }
            set
            {
                _spatialUnitMargin = value;
                OnPropertyChanged("spatialUnitMargin");
            }
        }
        #endregion


        #region --- spatialUnitPadding ------- recalculated padding unit 
        private Int32 _spatialUnitPadding = -1;
        /// <summary>
        /// recalculated padding unit
        /// </summary>
        public Int32 spatialUnitPadding
        {
            get
            {
                if (_spatialUnitPadding < -1) _spatialUnitPadding = Convert.ToInt32(spatialUnit * spatialUnitPaddingRatio);
                return _spatialUnitPadding;
            }
            set
            {
                _spatialUnitPadding = value;
                OnPropertyChanged("spatialUnitPadding");
            }
        }
        #endregion





        private Int32 _tabPerCellUnit = 1;


        /// <summary>
        /// Number of cell units per one tab
        /// </summary>
        public Int32 tabPerCellUnit
        {
            get { return _tabPerCellUnit; }
            set { _tabPerCellUnit = value; }
        }

        
      

        public cursorZoneSpatialSettings(Int32 width, Int32 marginLR, Int32 paddingLR) : base(width, marginLR, paddingLR)
        {

        }
        public cursorZoneSpatialSettings():base()
        {

        }

        public cursorZoneSpatialSettings(Int32 __width, Int32 __height, Int32 __leftRightMargin, Int32 __topBottomMargin, Int32 __leftRightPadding, Int32 __topBottomPadding) : base(__width, __height, __leftRightMargin, __topBottomMargin, __leftRightPadding, __topBottomPadding)
        {

        }
    }
}
