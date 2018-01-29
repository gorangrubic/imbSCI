using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.DataComplex.tables
{
    using System.Data;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.files;
    using imbSCI.DataComplex.extensions.data.operations;
    using imbSCI.Data.enums;
    using imbSCI.Core.extensions.table;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Core.extensions.io;
    using imbSCI.DataComplex.extensions.data.schema;
    using OfficeOpenXml.Style.XmlAccess;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Core.reporting.zone;
    using OfficeOpenXml.Style;
    using OfficeOpenXml;
    using imbSCI.Core.extensions.enumworks;
    using System.Threading.Tasks;
    using System.Threading;


    /// <summary>
    /// Temporary object - handling report export process
    /// </summary>
    public class DataTableForStatisticsExportJob
    {
        DataTable source;
        folderNode folder;
        aceAuthorNotation notation;
        String filenamePrefix;
        Boolean disablePrimaryKey;
        public DataTableForStatisticsExportJob(DataTable _source, folderNode _folder, aceAuthorNotation _notation = null, string _filenamePrefix = "", bool _disablePrimaryKey = true)
        {
            source = _source;
            folder = _folder;
            notation = _notation;
            filenamePrefix = _filenamePrefix;
            disablePrimaryKey = _disablePrimaryKey;
        }

        public void Do()
        {
            source.GetReportAndSave(folder, notation, filenamePrefix, disablePrimaryKey, false);

        }
    }

}