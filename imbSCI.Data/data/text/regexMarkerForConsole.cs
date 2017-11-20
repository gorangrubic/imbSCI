namespace imbSCI.Data.data.text
{
    using System;

    /// <summary>
    /// Regex marker applied for Console
    /// </summary>
    /// <seealso cref="aceCommonTypes.data.text.regexMarker{aceCommonTypes.data.text.consoleStyleMarkerEnum}" />
    public class regexMarkerForConsole:regexMarker<consoleStyleMarkerEnum>
    {
        public regexMarkerForConsole(string regex, consoleStyleMarkerEnum __m, ConsoleColor fore, ConsoleColor back) : base(regex, __m)
        {
            foreground = fore;
            background = back;
        } 
    }

}