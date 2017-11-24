﻿namespace imbSCI.Reporting.charts.core
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
    public enum chartTypeEnum
    {
        /// <summary>
        /// The donut: prsten-krug izdeljen na procente
        /// </summary>
        none = 0,
        donut=1,
        line=2,
        spline=4,
        area=8,
        area_spline=16,
        stepchart=32,
        bar=64,
        gauge=128,
pie

    }
}
