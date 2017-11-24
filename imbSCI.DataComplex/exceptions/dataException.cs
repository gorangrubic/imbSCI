namespace imbSCI.DataComplex.exceptions
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

    public class dataException:Exception
    {
        public object callerInstance { get; set; }
        public string title { get; set; }
        public dataException(string __message = "", Exception __innerException=null, object __callerInstance = null, string __title = "") :base(__message, __innerException)
        {
            callerInstance = __callerInstance;
            title = __title;
            
        }
    }
}
