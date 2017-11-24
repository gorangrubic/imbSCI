namespace imbSCI.Reporting.script
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

    [Flags]
    public enum docScriptFlags
    {
        none=0,
        ignoreNavigation = 1,
        /// <summary>
        /// It will not report error on compilation failure
        /// </summary>
        ignoreCompilationFails = 2, //
        ignoreArgumentValueNull = 4, //
        nullDirectoryToCurrent =8,

        /// <summary>
        /// It will allow exection of <see cref="docScriptInstructionCompiled"/> even in case of compilation failure
        /// </summary>
        allowFailedInstructions = 16,
        /// <summary>
        /// The disable global collection call on <see cref="deliveryInstance.executePrepare(meta.documentSet.metaDocumentSet, string, PropertyCollection)"/>
        /// </summary>
        disableGlobalCollection = 32,
        /// <summary>
        /// It will allow AppendDataFields call on newScope when <see cref="deliveryInstance.x_scopeAutoCreate(IObjectWithPathAndChildSelector)"/> performed
        /// </summary>
        enableLocalCollection = 64,
        useDataDictionaryForLocalData = 128,
    }

}