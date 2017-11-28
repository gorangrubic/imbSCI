
using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Data;
using imbSCI.Data.collection;
using imbSCI.Data.data;
using imbSCI.Data.interfaces;


namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.reporting;

    public interface IAceLogToConsoleControl
    {
        /// <summary>
        /// Sets as only output - removes all the rest
        /// </summary>
        /// <param name="loger">The loger.</param>
        void setAsOnlyOutput(IConsoleControl loger, String prefix = "");

        void setLogFileWriter(String path = null);

        /// <summary>
        /// Sets this loger on allow list
        /// </summary>
        /// <param name="loger">The loger.</param>
        void setAsOutput(IConsoleControl loger, String prefix = "");

        /// <summary>
        /// Replaces the output.
        /// </summary>
        /// <param name="oldLoger">The old loger.</param>
        /// <param name="newLoger">The new loger.</param>
        void replaceOutput(IConsoleControl oldLoger, IConsoleControl newLoger);

        /// <summary>
        /// 
        /// </summary>
        Boolean convertToDos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        toDosCharactersMode encodeMode { get; set; }

        /// <summary>
        /// TRUE: when <see cref="allowList"/> is empty. Then someone else may print out
        /// </summary>
        /// <value>
        ///   <c>true</c> if [no one on output now]; otherwise, <c>false</c>.
        /// </value>
        Boolean noOneOnOutputNow { get; }

        void writeToConsole(String message, IConsoleControl loger, Boolean breakline, Int32 altColor=-1);

        /// <summary>
        /// Checks if this loger has output permission. Checks only the globaly defined list, not members of <see cref="IConsoleControl"/>
        /// </summary>
        /// <param name="loger">The loger.</param>
        /// <returns></returns>
        Boolean checkOutputPermission(IConsoleControl loger);

        /// <summary>
        /// Removes this loger from output permission
        /// </summary>
        /// <param name="loger">The loger.</param>
        void removeFromOutput(IConsoleControl loger);
    }

}