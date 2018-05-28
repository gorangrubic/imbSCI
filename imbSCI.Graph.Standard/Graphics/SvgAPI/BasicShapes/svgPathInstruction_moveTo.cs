using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Xml;
using imbSCI.Graph.Graphics.SvgAPI.Core;
using imbSCI.Graph.Graphics.SvgAPI;

namespace imbSCI.Graph.Graphics.SvgAPI.BasicShapes
{
    public class svgPathInstruction_moveTo : svgPathInstructionBase
    {
        public svgPathInstruction_moveTo(Int32 x, Int32 y, Boolean relative)
        {
            arguments = new SVGInlineArguments(new SVGLetterArgument("m"), new SVGPoint(x, y));
            IsAbsolute = !relative;
        }

        public svgPathInstruction_moveTo(Double x, Double y, Boolean relative)
        {
            arguments = new SVGInlineArguments(new SVGLetterArgument("m"), new SVGPoint(x, y));
            IsAbsolute = !relative;
        }

        public SVGPoint point => arguments[1] as SVGPoint;
    }

}