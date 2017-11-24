namespace imbSCI.Reporting.meta.delivery
{
    using System;
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

    /// <summary>
    /// Targeted location of the unit item
    /// </summary>
    public enum deliveryUnitItemLocationBase
    {

        /// <summary>
        /// The location of item is unset
        /// </summary>
        unknown,

        /// <summary>
        /// The local resource - item will be saved into current scope <see cref="imbSCI.Reporting.reporting.render.IRenderExecutionContext.directoryScope"/>
        /// </summary>
        localResource,

        /// <summary>
        /// It is a resource shared within the current document (closest parent to the current logical scope)
        /// </summary>
        globalDocumentResource,


        /// <summary>
        /// It is a resource shared within the document set (closest parent to the current logical scope)
        /// </summary>
        globalDocumentSetResource,


        /// <summary>
        /// It is a resources shared within the complete deliveryInstance output
        /// </summary>
        globalDeliveryResource,

        /// <summary>
        /// The item is actually an URI retrieved via http request
        /// </summary>
        externalWebResource,
        globalDeliveryContent,
    }

}