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
    public interface IDataTableBuilder
    {
        
        /// <summary>
        /// Builds the data table comparative.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemsOfSameType">Type of the items of same.</param>
        /// <returns></returns>
        DataTable buildDataTableComparative<T>(IEnumerable<T> itemsOfSameType) where T :IDataTableBuilder;

        /// <summary>
        /// Builds the data table horizontal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemsOfSameType">Type of the items of same.</param>
        /// <returns></returns>
        DataTable buildDataTableHorizontal<T>(IEnumerable<T> itemsOfSameType) where T:IDataTableBuilder;
    }

}