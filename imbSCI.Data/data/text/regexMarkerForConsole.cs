namespace imbSCI.Data.data.text
{
    using System;
    using imbSCI.Data.enums;

    /// <summary>
    /// Regex marker applied to parse some markdown-like annotation in the text message to be displayed at Console Application output 
    /// </summary>
    /// <seealso cref="aceCommonTypes.data.text.regexMarker{aceCommonTypes.data.text.consoleStyleMarkerEnum}" />
    public class regexMarkerForConsole:regexMarker<consoleStyleMarkerEnum>
    {
        /// <summary>
        /// Gets or sets the foreground color to be attached to the token matching the <see cref="regexMarker{T}.test"/>
        /// </summary>
        /// <value>
        /// The foreground.
        /// </value>
        public ConsoleColor foreground { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Gets or sets the background color attached to the token matching the <see cref="regexMarker{T}.test"/>
        /// </summary>
        /// <value>
        /// The background.
        /// </value>
        public ConsoleColor background { get; set; } = ConsoleColor.DarkGray;

        /// <summary>
        /// Initializes a new instance of the <see cref="regexMarkerForConsole"/> parser rule
        /// </summary>
        /// <param name="regex">The regex test for tokens</param>
        /// <param name="__m">The style marker it represents</param>
        /// <param name="fore">The foreground color, <see cref="foreground"/></param>
        /// <param name="back">The background color, <see cref="background"/>.</param>
        public regexMarkerForConsole(string regex, consoleStyleMarkerEnum __m, ConsoleColor fore, ConsoleColor back) : base(regex, __m)
        {
            foreground = fore;
            background = back;
        } 
    }

}