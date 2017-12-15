using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.DataComplex.tables
{
    using System.Collections;
    using System.Data;
    using System.IO;
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
    using imbSCI.Data;
    using imbSCI.DataComplex.exceptions;
    using imbSCI.Data.enums;
    using imbSCI.Data.collection.nested;
    using imbSCI.Core.files.fileDataStructure;


    /// <summary>
    /// Object table that supports auto load and auto save, as called from the <see cref="fileDataDescriptorBase.LoadDataFile(string, Core.reporting.ILogBuilder, Type)"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="imbSCI.DataComplex.tables.objectTable{T}" />
    /// <seealso cref="imbSCI.Data.interfaces.ISupportLoadSave" />
    public abstract class objectTableCustom<T>:objectTable<T>, ISupportLoadSave where T:class, new()
    {

        public abstract String keyPropertyName { get; }

        public Boolean LoadFrom(String path)
        {
            getReady();
            return Load(path, true);
        }

        protected void getReady()
        {
            primaryKeyName = keyPropertyName;
            
            prepare(typeof(T), keyPropertyName, name, true);
        }

        /// <summary>
        /// Constructor for normal initialization
        /// </summary>
        /// <param name="__name">The name.</param>
        protected objectTableCustom(String __name)
        {
            name = __name;
            getReady();
        }

        /// <summary>
        /// Constructor used only for automatic instance creation
        /// </summary>
        protected objectTableCustom()
        {

        }

    }

}