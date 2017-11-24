namespace imbSCI.Core.reporting
{
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting.render;
    using System;

    public interface ILogBuilder:ILogable, IAceLogable, ITextRender
    {
        ILogBuilder logStartPhase(String title, String message);
        ILogBuilder logEndPhase();

        /// <summary>
        /// Sets the alternative color mode for console output. Use set exact to set exactly the value for alternative color, otherwise it works in Toggle mode.
        /// </summary>
        /// <param name="altChange">The alt change.</param>
        /// <param name="setExact">if set to <c>true</c> [set exact].</param>
        void consoleAltColorToggle(Boolean setExact = false, Int32 altChange = -1);

        /// <summary>
        /// Appends the exception.
        /// </summary>
        /// <param name="title">The title - main message about exception</param>
        /// <param name="ex">Exception thrown</param>
        /// <param name="exceptionLevel">The exception level: used when nested exceptions are thrown</param>
       // void AppendException(String title, Exception ex, Int32 exceptionLevel = 0);

        void save();
    }

}