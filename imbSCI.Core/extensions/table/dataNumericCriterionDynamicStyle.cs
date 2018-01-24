// --------------------------------------------------------------------------------------------------------------------
// <copyright file="dataNumericCriterionDynamicStyle.cs" company="imbVeles" >
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
namespace imbSCI.Core.extensions.table
{
using System;
using System.Linq;
using System.Collections.Generic;
    using imbSCI.Core.math.range;
    using imbSCI.Core.reporting.style;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core;
    using imbSCI.Data.extensions;
    using imbSCI.Data.collection.nested;
    using System.Data;
    using System.Drawing;
    using System.Xml.Serialization;
    using imbSCI.Core.enums;





    public class dataNumericCriterionDynamicStyle<T, TEnum>:dataTableDynamicStyleEntry 
    where T:IComparable
        
    {
        public String columnName { get; set; } = "";

        public TEnum styleKey { get; set; }

        public rangeCriteria<T> criteria { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="dataNumericCriterionDynamicStyle{T, TEnum}"/> class.
        /// </summary>
        /// <param name="_criteria">The criteria.</param>
        /// <param name="key">The key.</param>
        public dataNumericCriterionDynamicStyle(rangeCriteria<T> _criteria, TEnum key, String _columnName)
        {
            criteria = _criteria;
            styleKey = key;
            columnName = _columnName;
        }

        /// <summary>
        /// Evaluates the <see cref="columnName"/> column of the <c>row</c> against <see cref="criteria"/>, if test is positive returns the style associated with <see cref="styleKey"/>
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="table">The table.</param>
        /// <param name="defaultStyle">The default style.</param>
        /// <returns></returns>
        public override dataTableStyleEntry evaluate(DataRow row, DataTable table, dataTableStyleEntry defaultStyle)
        {
            DataTable rowTable = row.Table;

           
            if (!rowTable.Columns.Contains(columnName)) return defaultStyle;

            DataColumn dc = rowTable.Columns[columnName];

            Object vo = row[dc];
            
            T val = vo.imbConvertValueSafeTyped<T>();

            if (criteria.testCriteria(val))
            {
                if (customStyleEntry != null) return customStyleEntry;

                dataTableStyleSet styleSet = table.GetStyleSet();

                return styleSet.GetStyle(styleKey);
            } else
            {
                return defaultStyle;
            }
        }
    }

}