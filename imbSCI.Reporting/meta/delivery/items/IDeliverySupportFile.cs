namespace imbSCI.Reporting.meta.delivery.items
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Support file
    /// </summary>
    /// <seealso cref="imbSCI.Reporting.meta.delivery.items.IDeliveryUnitItemFromFileSource" />
    /// <seealso cref="imbSCI.Reporting.meta.delivery.IDeliveryUnitItem" />
    public interface IDeliverySupportFile:IDeliveryUnitItemFromFileSource, IDeliveryUnitItem
    {
        FileInfo sourceFileInfo
        {
            get;
            set;
        }

        FileInfo output_fileinfo { get; }

        appendLinkType linkType { get; }

        string getRelativeUrl(IRenderExecutionContext context, string __relToRoot = null);

        void appendToRender(IRenderExecutionContext context,ITextRender outputRender);
    }
}