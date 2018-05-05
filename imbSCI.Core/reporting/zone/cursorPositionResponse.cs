using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.reporting.zone
{
    using imbSCI.Data.interfaces;
    using System.ComponentModel;


    /// <summary>
    /// Result enumeration when asking <see cref="cursorZone"/> to determine where the <see cref="cursor"/> is currently
    /// </summary>
    public enum cursorPositionResponse
    {
        atBeginning,
        somewhereWithin,
        atEnd,

    }

}