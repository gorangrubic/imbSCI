namespace imbSCI.Core.reporting.zone
{

    public enum cursorZoneSpatialPreset
    {
        /// <summary>
        /// The sheet normal: t=1, wc=12, hc=120, sp=160px
        /// </summary>
        sheetNormal,

        /// <summary>
        /// 20x20px cell dimension
        /// </summary>
        sheetSquareCell,

        /// <summary>
        /// The text page - t=8, wc=100, hc=60, sp=10
        /// </summary>
        textPage,

        /// <summary>
        /// The console - wc85 x hc43, t=4
        /// </summary>
        console,

        /// <summary>
        /// The wide console - wc=160, hc=78
        /// </summary>
        wideConsole,

        /// <summary>
        /// The a4 on font size 10pt
        /// </summary>
        a4OnFont10pt,
        longTextLog,
    }

}