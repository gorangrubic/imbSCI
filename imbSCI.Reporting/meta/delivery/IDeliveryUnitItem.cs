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
    /// 
    /// </summary>
    /// <seealso cref="IObjectWithNameAndDescription" />
    public interface IDeliveryUnitItem : IObjectWithNameAndDescription, IDeliveryComposer
    {

        void prepareOperation(IRenderExecutionContext context);

        PropertyCollectionDictionary collectOperationStart(IRenderExecutionContext context, IMetaContentNested composer, PropertyCollectionDictionary dict);

        //docScript composeOperationStart(IRenderExecutionContext context, IMetaContent composer, docScript script);

        //docScript composeOperationEnd(IRenderExecutionContext context, IMetaContent composer, docScript script);


        void scopeInOperation(IRenderExecutionContext context, IMetaContentNested newScope);

        void executeScriptInstruction(IRenderExecutionContext context, docScriptInstructionCompiled instruction);
       

        void scopeOutOperation(IRenderExecutionContext context, IMetaContentNested oldScope);


        void reportFinishedOperation(IRenderExecutionContext context);

        string name { get; }
        string description { get; }
        deliveryUnitItemType itemType { get; }
        deliveryUnitItemLocationBase location { get; }
        deliveryUnitItemFlags flags { get; }

        //    string filepath { get; }
        //    aceFolderInfo sourceFolder { get; set; }
        //    string sourcepath { get; }
    }
}