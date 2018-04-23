﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Graph.Graphics.Shapes
{
    public enum basicShapes
    {
        none,
        square,
        rectangle,
        rectangleRounded,
        /// <summary>
        /// The rectangle obround: like <see cref="rectangleRounded"/> where r = b/2
        /// </summary>
        rectangleObround,
        triangle,
        triangleTwoEqualArcs,
        triangleThreeEqualArcs,
        circle,
        elipse,
        hexagon,
        Dshape,

    }
}
