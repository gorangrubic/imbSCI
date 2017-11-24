namespace imbSCI.DataComplex.data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
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

    public abstract class modelDataSet : imbBindable, IAppendDataFields, IAppendDataFieldsExtended, ILogable, IConsoleControl
    {
        /// <summary>
        /// 
        /// </summary>
        public bool VAR_AllowInstanceToOutputToConsole { get; set; }

        public abstract bool VAR_AllowAutoOutputToConsole { get; }

        public abstract string VAR_LogPrefix { get; }


        /// <summary>
        /// Summary statistics inside <see cref="dataCollectionExtendedList"/> and <see cref="dataSet"/>
        /// </summary>
        public const string DATANAME_Summary = "summary";
        /// <summary>
        /// Children statistics inside <see cref="dataCollectionExtendedList"/> and <see cref="dataSet"/>
        /// </summary>
        public const string DATANAME_Children = "children";
        /// <summary>
        /// Instance statistics inside <see cref="dataCollectionExtendedList"/> and <see cref="dataSet"/>
        /// </summary>
        public const string DATANAME_Instance = "instance";



        private PropertyCollectionExtendedList _dataCollectionExtendedList = new PropertyCollectionExtendedList();
        /// <summary>DataField sets stored at record Finish call</summary>
        public PropertyCollectionExtendedList dataCollectionExtendedList
        {
            get
            {
                return _dataCollectionExtendedList;
            }
            protected set
            {
                _dataCollectionExtendedList = value;
                OnPropertyChanged("dataset");
            }
        }


        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        public abstract PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data = null);

        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>
        /// Updated or newly created property collection
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        PropertyCollection IAppendDataFields.AppendDataFields(PropertyCollection data = null) => (PropertyCollection)AppendDataFields(data as PropertyCollectionExtended);

        public void log(string message)
        {
            ((ILogable)logBuilder).log(message);
        }

        protected ILogBuilder _log; // new ILogBuilder();
        /// <summary>
        /// Log creator
        /// </summary>
        public ILogBuilder logBuilder
        {
            get {
                return _log;
            }
            protected set { _log = value; }
        }


        protected string _logContent;

    }
}
