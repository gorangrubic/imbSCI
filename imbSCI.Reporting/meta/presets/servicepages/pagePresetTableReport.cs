namespace imbSCI.Reporting.meta.presets.servicepages
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
    using imbSCI.Reporting.meta.page;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Data.enums.fields;
    using imbSCI.Reporting.enums;

    /// <summary>
    /// PREVAZIDJENO Overview page for imbDataReportDocument.
    /// </summary>
    /// <remarks>
    /// Containes short information on each DataTable page inside the collection
    /// </remarks>
    /// <seealso cref="metaServicePage" />
    public class pagePresetTableReport : metaServicePage
    {

        #region --- table ------- reference to data table to display 
        private DataTable _table;
        /// <summary>
        /// reference to data table to display
        /// </summary>
        public DataTable table
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
                OnPropertyChanged("table");
            }
        }
        #endregion

        public pagePresetTableReport(DataTable __table):base("")
        {
            table = __table;
            name = table.ExtendedProperties.getProperString(templateFieldDataTable.data_tablenamedb, templateFieldDataTable.data_tablename, templateFieldDataTable.shema_sourcename);

            header.name = "DB table " + name + "";
            header.description = "Columns: ".t(templateFieldDataTable.data_columncount) +(" - Rows: ").t(templateFieldDataTable.data_rowcounttotal);

            metaDataTable metaTable = new metaDataTable(table);


            footer.bottomLine = "Query: ".t(templateFieldDataTable.data_query) + (" | ").t(templateFieldBasic.sys_time) + (" - mem.alloc: ").t(templateFieldBasic.sys_mem) +(" - threads: ").t(templateFieldBasic.sys_threads);

        }



     
    }

}