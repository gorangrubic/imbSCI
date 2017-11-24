namespace imbSCI.Reporting.charts.core
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

    [Flags]
    public enum chartFeatures
    {
        none=0,
        showData=1,
        urlJSON=2,
        urlCSV=4,
        axisY2 = 8,
        showY1AxisLabel = 16,
        showY2AxisLabel = 32,
        withoutHtml = 64,
        skipFirstRow = 128,
        bindto = 256

        ///// <summary>
        ///// The types: one line template for types insertation
        ///// </summary>
        //types = 128,




    }
}