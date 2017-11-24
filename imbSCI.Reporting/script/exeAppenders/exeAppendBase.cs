﻿namespace imbSCI.Reporting.script.exeAppenders
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
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
    using imbSCI.DataComplex.data.modelRecords;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;

    /// <summary>
    /// exeAppend is custom-code module injectable in <see cref="docScript"/> execution pipeline.
    /// </summary>
    /// <seealso cref="IExeAppend" />
    public abstract class exeAppendBase: imbBindable, IExeAppend
    {
        /// <summary>
        /// Name for this instance - opional, used for content creation
        /// </summary>
        public string name { get; set; } = "";

        /// <summary>
        /// Human-readable description of object instance - optional used for content cretion
        /// </summary>
        public string description { get; set; } = "";


        private IModelRecord _record;
        /// <summary> </summary>
        public IModelRecord record
        {
            get
            {
                return _record;
            }
            set
            {
                _record = value;
                OnPropertyChanged("record");
            }
        }


        /// <summary>
        /// The implementation requres parametarless constructor to be only one 
        /// </summary>
        public exeAppendBase()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, PropertyCollectionExtended> staticData { get; set; } = new Dictionary<string, PropertyCollectionExtended>();


        /// <summary>
        /// Gets or sets the data set.
        /// </summary>
        /// <value>
        /// The data set.
        /// </value>
        protected DataSet dataSet { get; set; } = new DataSet();

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="_data">The data.</param>
        /// <returns></returns>
        public IExeAppend setData(DataTable _data)
        {
            dataSet.Tables.Add(_data);
            return this;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="_data">The data.</param>
        /// <returns></returns>
        public IExeAppend setData(string key, PropertyCollectionExtended _data)
        {
            staticData.Add(key, _data);
            return this;
        }


        /// <summary>
        /// Executes the <see cref="exeAppendBase"/> instance 
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="render">The render.</param>
        public abstract IExeAppend execute(IRenderExecutionContext context, ITextRender render);
    }
}