using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.extensions.table
{
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.math.aggregation;
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.lowLevelApi;
    using imbSCI.Core.reporting.render.config;
    using imbSCI.Data;
    using imbSCI.Data.enums.fields;
    using System.Data;


    public static class dataTableTools
    {
        public static Boolean validationDisabled = false;

        /// <summary>
        /// Validates the table.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Boolean validateTable(this DataTable source)
        {
            if (validationDisabled) return true;
            if (source == null) return false;
            if (source.Columns.Count == 0) return false;
            if (source.Rows.Count == 0) return false;

            if (source.TableName.isNullOrEmpty())
            {
                source.TableName = source.GetTitle().getFilename();
                if (source.TableName.isNullOrEmpty())
                {
                    source.TableName = "DataTable_" + imbStringGenerators.getRandomString(8);
                    return true;
                }
                else
                {
                    return true;
                }

            }
            return true;
        }
    }

}