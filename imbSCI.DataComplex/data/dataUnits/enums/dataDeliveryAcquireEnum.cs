namespace imbSCI.DataComplex.data.dataUnits.enums
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

    [Flags]
    public enum dataDeliveryAcquireEnum
    {
        nameAsRegex = 1,

        orderByField = 2,

        orderByAlfabet = 4,

        collectionLimitShowCase10 = 8,

        collectionLimitShowCase25 = 16,

        insertCountRow = 32,
        
    }


}
