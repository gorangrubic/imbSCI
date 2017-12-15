using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Data.enums.tableReporting
{
    [Flags]
    public enum dataTableIOFlags
    {
        none = 0,

        /// <summary>
        /// The first row column names: the first row contains column names
        /// </summary>
        firstRowColumnNames = 1 <<0,

        useTableNames = 1<<1,


        defaultFlags = firstRowColumnNames | useTableNames,
        noRowWithColumnNames = 4,
    }
}
