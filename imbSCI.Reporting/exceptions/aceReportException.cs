namespace imbSCI.Reporting.exceptions
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
    using imbSCI.DataComplex.exceptions;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Cores.core.exceptions.aceReportException" />
    public class aceReportException:dataException
    {
        public aceReportException(string message, aceReportExceptionType type = aceReportExceptionType.composeScriptError, Exception innerEx = null) : base(message, innerEx, null, "Reporting:" + type.ToString())
        {

        }

        public String addMessage { get; protected set; } = "";


        public aceReportException add(String newLine)
        {
            addMessage += Environment.NewLine + newLine;
            return this;
        }

        public aceReportException(docScript script, string message, aceReportExceptionType type = aceReportExceptionType.composeScriptError, Exception innerEx=null) : base(message, innerEx, script, "Reporting:" + type.ToString())
        {

        }

        public aceReportException(IRenderExecutionContext context, string message, aceReportExceptionType type = aceReportExceptionType.executeScriptError, Exception innerEx=null) : base(message, innerEx, context, "Reporting:" + type.ToString())
        {

        }

        public aceReportException(IMetaContentNested metaModel, string message, aceReportExceptionType type = aceReportExceptionType.constructMetaModelError, Exception innerEx = null) : base(message, innerEx, metaModel, "Reporting:" + type.ToString())
        {

        }

        public aceReportException(string __message , Exception __innerException , object __callerInstance = null, string __title = "") : base(__message, __innerException, __callerInstance, __title)
        {
        }
    }
}
