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

    public class svgPathInstruction_closePath : svgPathInstructionBase
    {
        public svgPathInstruction_closePath()
        {
            arguments = new SVGInlineArguments(new SVGLetterArgument("z"));
        }
    }

}