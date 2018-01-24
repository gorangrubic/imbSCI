using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using Accord;
using imbSCI.Core.reporting.colors;
using AForge.Imaging;
using System.Xml.Serialization;

namespace imbSCI.Graph.Converters.tools
{

    [Flags]
    public enum ColorGradientFunction
    {
        none=0,
        Hue =1,
        Saturation = 2,
        Value = 4,
        AtoB = 8,
        A = 16,
        B = 32,
        Linear = 64,
        InverseLinear = 128,
        CircleCW = 256,
        CircleCCW = 512,

        
        HueAToB = Hue | AtoB,
        HueSaturationAToB = Hue | Saturation | AtoB,
        AllAToB = Hue | Value | Saturation | AtoB | Linear | Alpha,
        HueValueAToB = Hue | Value | AtoB,
        Alpha = 1024
    }

}