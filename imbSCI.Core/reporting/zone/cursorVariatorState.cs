namespace imbSCI.Core.reporting.zone
{
    using System;

    //public static class cursorVariatorTools {

    //    public static Int32 

    //}

    /// <summary>
    /// State of coordinates after tested by cursorVariator
    /// </summary>
    public struct cursorVariatorState
    {
        public Boolean isMinor;
        public Boolean isMajor;
        public Boolean isOutside;
        public Boolean isInside;
        public Boolean isLast;
        public Boolean isFirst;
        public Boolean isHeadZone;
        public Boolean isFootZone;
        /// <summary>
        /// Is coordinate inside head zone extended - the zone between headZone and normal rows
        /// </summary>
        public Boolean isHeadZoneExtended;
        public Boolean isFootZoneExtended;
        public Boolean isRightZone;
        public Boolean isLeftZone;
        public Boolean isOdd;
        public Boolean isEven;

        public Int32 x;
        public Int32 y;

        /// <summary>
        /// If TRUE it will use color for layout
        /// </summary>
        public Boolean useLayoutPalette;
        /// <summary>
        /// Applied to select color brightness from pallete
        /// </summary>
        public Int32 useColorIndex;
        /// <summary>
        /// The use inverted - inverts in
        /// </summary>
        public Boolean useInvertedForeground;
    }

}