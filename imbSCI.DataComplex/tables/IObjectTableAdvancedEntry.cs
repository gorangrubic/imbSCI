namespace imbSCI.DataComplex.tables
{
    using System;
    using System.Collections.Generic;
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

    /// <summary>
    /// Za kasniju implementaciju (ideja)
    /// </summary>
    /// <seealso cref="IObjectTableEntry" />
    public interface IObjectTableAdvancedEntry:IObjectTableEntry
    {
        /// <summary>
        /// Linked to
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        objectTableBase GetParent();

        /// <summary>
        /// Set the parent (do not c
        /// </summary>
        /// <param name="__parent">The parent.</param>
        void SetParent(objectTableBase __parent);

        /// <summary>
        /// Updates the row in the linked object table
        /// </summary>
        void UpdateRow();

        /// <summary>
        /// Unlinks this instance from the current parent
        /// </summary>
        void Unlink();

        /// <summary>
        /// Links to the specified parent -- and removes link with the previous parent
        /// </summary>
        /// <param name="parent">The parent.</param>
        void Link(objectTableBase parent);

        /// <summary>
        /// Removes this instance from the linked parent
        /// </summary>
        void Remove();

        /// <summary>
        /// Clones the entry -- optionally transfering the link to the newly created
        /// </summary>
        /// <param name="linkWithNew">if set to <c>true</c> [link with new].</param>
        void Clone(bool linkWithNew);

        /// <summary>
        /// Gets the key for this entry
        /// </summary>
        /// <returns></returns>
        string GetTableKey();

    }

}