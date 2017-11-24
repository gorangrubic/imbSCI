namespace imbSCI.Reporting.links.enums
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
    /// Uloga koju ima stranica
    /// </summary>
    /// \ingroup_disabled docElementCore
    public enum metaPageLinkRole
    {

        /// <summary>
        /// The page is actually subpage of this page - it opens inside scrollviewer/in the same sheet/PDF
        /// </summary>
        linkedView,

        /// <summary>
        /// The page is among main links od this page, but it is not sub page
        /// </summary>
        linkedPage,

        /// <summary>
        /// The content is created and saved next to page - but it is not linked to index and other pages
        /// </summary>
        unlinkedPage,


        /// <summary>
        /// Link of external url 
        /// </summary>
        externalPage,

        /// <summary>
        /// The page has documentation role (API generation etc)
        /// </summary>
        documentation,

        /// <summary>
        /// Programming help and reference
        /// </summary>
        help,



    }
}
