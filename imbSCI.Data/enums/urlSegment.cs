
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace imbSCI.Data.enums
{
    /// <summary>
    /// Segment URL-a koji treba da se izdvoji
    /// </summary>
    public enum urlSegment
    {
        getQParamName,
        getQParamValue,
        getQParamSegment,
        getFileName,
        getPathBeforeFileName,
        getFileExtension,
        getFileNameOnly
    }
}