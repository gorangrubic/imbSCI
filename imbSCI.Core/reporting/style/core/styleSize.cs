namespace imbSCI.Core.reporting.style.core
{
    using System;
    using imbSCI.Core.reporting.zone;

    /// <summary>
    /// Size definition
    /// </summary>
    public class styleSize:textFormatSetupSize
    {
        /// <summary>
        /// It will set heigh to auto and width to 1200px
        /// </summary>
        public styleSize() : base()
        {
            height = -1;
            width = 1200;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="styleSize"/> class.
        /// </summary>
        /// <param name="__width">The width.</param>
        /// <param name="__height">The height.</param>
        public styleSize(Int32 __width, Int32 __height) :base()
        {
            base.height = __height;
            width = __width;

        }
    }
}