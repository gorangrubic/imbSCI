namespace imbSCI.Core.reporting.zone
{
    using System;

    public static class cursorDimConversions
    {

        


        /// <summary>
        /// Converts width in mm into EEPlus Excel column witdh parameter
        /// </summary>
        /// <param name="mmWidth">desired width in mm</param>
        /// <returns></returns>
        public static Int32 toExcelWidth(this Int32 mmWidth)
        {
            return mmWidth / 2;
        }
    }
}
