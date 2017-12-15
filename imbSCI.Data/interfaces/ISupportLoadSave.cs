using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data.enums;

namespace imbSCI.Data.interfaces
{


    /// <summary>
    /// Objects that support Load and Save
    /// </summary>
    public interface ISupportLoadSave:IObjectWithName
    {
        /// <summary>
        /// Loads from specified absolute path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        Boolean LoadFrom(String path);

        /// <summary>
        /// Saves to specified absolute path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        Boolean SaveAs(String path, getWritableFileMode mode = getWritableFileMode.newOrExisting);

    }

}