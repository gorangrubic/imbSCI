namespace imbSCI.Core.reporting.format
{
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Data.data;
    using System.Drawing;

    /// <summary>
    /// Describes formatring of an page
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="cursorZoneExecutionSettings"/> 
    public class pageFormat:imbBindable
    {

        private acePaletteRole _mainColor = acePaletteRole.colorA;
        /// <summary>
        /// Sets color of tab and backgrouns
        /// </summary>
        public acePaletteRole mainColor
        {
            get { return _mainColor; }
            set { _mainColor = value; }
        }


        private Color _tabHeadColor = Color.White;
        /// <summary> </summary>
        public Color tabHeadColor
        {
            get
            {
                return _tabHeadColor;
            }
            set
            {
                _tabHeadColor = value;
                OnPropertyChanged("tabHeadColor");
            }
        }



        #region --- zoneSpatialPreset ------- Preset with padding, margin and other spatial configuration applicable on a page 
        private cursorZoneSpatialPreset _zoneSpatialPreset = cursorZoneSpatialPreset.sheetNormal;
        /// <summary>
        /// Preset with padding, margin and other spatial configuration applicable on a page
        /// </summary>
        public cursorZoneSpatialPreset zoneSpatialPreset
        {
            get
            {
                return _zoneSpatialPreset;
            }
            set
            {
                _zoneSpatialPreset = value;
                OnPropertyChanged("zoneSpatialPreset");
            }
        }


        #endregion


        #region --- zoneLayoutPreset ------- Preset to be applied once new page is started 
        private cursorZoneLayoutPreset _zoneLayoutPreset = cursorZoneLayoutPreset.twoColumn;
        /// <summary>
        /// Preset to be applied once new page is started
        /// </summary>
        public cursorZoneLayoutPreset zoneLayoutPreset
        {
            get
            {
                return _zoneLayoutPreset;
            }
            set
            {
                _zoneLayoutPreset = value;
                OnPropertyChanged("zoneLayoutPreset");
            }
        }
        #endregion
    }

}