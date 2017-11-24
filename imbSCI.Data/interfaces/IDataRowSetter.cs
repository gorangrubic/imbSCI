using System;
using System.Collections.Generic;
using System.Linq;

using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;
using System.Data;

namespace imbSCI.Data.interfaces
{
    public interface IDataRowSetter
    {

        /// <summary>
        /// Builds the data table shema without any row
        /// </summary>
        /// <param name="onlyValues">if set to <c>true</c> it will create columns only for properties</param>
        /// <returns></returns>
        DataTable buildDataTableShema(Boolean onlyValues);

        /// <summary>
        /// Sets the data row -- non reflection row data set. Only if table has column with same name and only values are copied
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        DataRow setDataRow(DataTable target);

        /// <summary>
        /// Builds the data table vertical.
        /// </summary>
        /// <returns></returns>
        DataTable buildDataTableVertical();

    }
}