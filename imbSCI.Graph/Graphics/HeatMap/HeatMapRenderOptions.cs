using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.reporting.style.core;
using imbSCI.Core.reporting.style.shot;
using imbSCI.Core.style.color;
using imbSCI.Core.reporting.colors;

using System.Text;
using System.Drawing;
using imbSCI.Core.reporting.style.enums;
using Svg;
using Svg.Transforms;
using Svg.Document_Structure;
using imbSCI.Core.extensions.data;
using System.IO;
using System.Globalization;
using imbSCI.Core.reporting.zone;

namespace imbSCI.Graph.Graphics.HeatMap
{

    /// <summary>
    /// Remdering options 
    /// </summary>
    [Flags]
    public enum HeatMapRenderOptions
    {
        none=0,
        addHorizontalValueScale =1,
        addVerticalValueScale = 2,
        showValueInField = 4,
        showPercentOfRange = 8,
        showSignedPercentOfRange = 16,
        resizeFields = 32,
        addHorizontalLabels = 64,
        addVerticalLabels = 128,
    }

}