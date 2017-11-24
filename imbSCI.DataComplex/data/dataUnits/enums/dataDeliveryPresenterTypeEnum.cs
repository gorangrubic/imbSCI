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

    public enum dataDeliveryPresenterTypeEnum
    {
        spLineGraph = 256,
        lineGraph = 512,

        pieGraph = 8192,

        barGraph = 16384,

        tableVertical = 1024,

        tableHorizontal = 2048,

        tableTwoColumnParam = 4096,
    }

}