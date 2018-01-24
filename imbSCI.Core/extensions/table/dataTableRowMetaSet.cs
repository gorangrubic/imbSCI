// --------------------------------------------------------------------------------------------------------------------
// <copyright file="dataTableRowMetaSet.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.extensions.table
{
    using imbSCI.Core.reporting.style;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Data.collection.nested;
    using System.Data;
    using System.Drawing;
    using System.Xml.Serialization;


    public class dataTableRowMetaSet:dataTableMetaSet
    {
        public dataTableRowMetaSet()
        {

        }


        /// <summary>
        /// Sets the specified style by rows indexes. The row index is interpreted by index in source table (not reporting version of the table -- i.e. heading rows are not counted, only data)
        /// </summary>
        /// <param name="style">The style.</param>
        /// <param name="rowIndexes">The row indexes.</param>
        /// <returns>Rule that was created</returns>
        public dataRowIndexDynamicStyle<DataRowInReportTypeEnum> SetStyleForRows(DataRowInReportTypeEnum style, params Int32[] rowIndexes)
        {
            var indexC = new dataRowIndexDynamicStyle<DataRowInReportTypeEnum>(style, rowIndexes);
            indexC.indexFromSourceTable = true;
            units.Add(indexC);
            return indexC;
        }

        /// <summary>
        /// Sets the style for rows with value.
        /// </summary>
        /// <typeparam name="TValueType">The type of the value type.</typeparam>
        /// <param name="style">The style.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="rowIndexes">The row indexes.</param>
        /// <returns></returns>
        public dataValueMatchCriterionDynamicStyle<TValueType, DataRowInReportTypeEnum> SetStyleForRowsWithValue<TValueType>(DataRowInReportTypeEnum style, String columnName, params TValueType[] rowIndexes) where TValueType:IComparable
        {
            var indexC = new dataValueMatchCriterionDynamicStyle<TValueType, DataRowInReportTypeEnum>(rowIndexes,  style, columnName);
            
            units.Add(indexC);
            return indexC;
        }

        /// <summary>
        /// Evaluates the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="table">The table.</param>
        /// <param name="defaultStyle">The default style.</param>
        /// <returns></returns>
        public dataTableStyleEntry evaluate(DataRow row, DataTable table, dataTableStyleEntry defaultStyle)
        {
            dataTableStyleEntry output = defaultStyle;
            foreach (var unit in units)
            {
                output = unit.evaluate(row, table, output);
                if (output != defaultStyle)
                {
                    return output;
                }
            }

            foreach (var item in items)
            {
                output = item(row, table, output);
                if (output != defaultStyle)
                {
                    return output;
                }
            }
            return output;
        }



        private List<rowMetaEvaluation> _items = new List<rowMetaEvaluation>();
        /// <summary> </summary>
        [XmlIgnore]
        public List<rowMetaEvaluation> items
        {
            get
            {
                return _items;
            }
            protected set
            {
                _items = value;
            }
        }

    }

}