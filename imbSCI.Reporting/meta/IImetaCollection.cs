namespace imbSCI.Reporting.meta
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
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
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    public interface IImetaCollection: IEnumerable<IMetaContentNested>
    {
        int Count { get; }

        bool Any();

        /// <summary>
        /// Deploy 
        /// </summary>
        void Sort();

        /// <summary>
        /// Discovers the common parent or sets the one provided in arguments
        /// </summary>
        /// <param name="__parent">The parent.</param>
        /// <returns></returns>
        /// <exception cref="aceReportException">Can't discover the parent when the collection is empty!! - null - discoverCommonParent exception</exception>
        IMetaContentNested discoverCommonParent(IMetaContentNested __parent=null);

        /// <summary>
        /// Method to register new page in collection - you must get new instance from parent object
        /// </summary>
        /// <param name="newChild"></param>
        /// <returns></returns>
        int Add(IMetaContentNested newChild, IMetaContentNested __parent=null);

        int IndexOf(IMetaContentNested child);

        /// <summary>
        /// Set parent 
        /// </summary>
        /// <param name="__parent">The parent.</param>
        void setParentToItems(IMetaContentNested __parent);

        IMetaContentNested this[string key] { get; }

        IEnumerator GetEnumerator();
        IMetaContentNested this[int key] { get; }
    }
}