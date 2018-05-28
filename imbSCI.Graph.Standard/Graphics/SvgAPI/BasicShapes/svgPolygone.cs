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

    /// <summary>
    /// Polygone, closed shape
    /// </summary>
    /// <seealso cref="imbSCI.Graph.Graphics.SvgAPI.BasicShapes.svgMultiPointGraphicsBase" />
    /// <seealso cref="imbSCI.Graph.Graphics.SvgDocument.ISVGTranform" />
    public class svgPolygone : svgMultiPointGraphicsBase, ISVGTranform
    {
        public override string name { get { return "polygon"; } }

        public svgPolygone() { }

        /// <summary>
        /// Creates polygone from points. <see cref="svgToolkitExtensions.GetPointsFromString(string)"/>
        /// </summary>
        /// <param name="_points">The points.</param>
        public svgPolygone(String _points) {

            points.AddRange(_points.GetPointsFromString());
        }

        /// <summary>
        /// Creates polygone from points
        /// </summary>
        /// <param name="_points">The points.</param>
        public svgPolygone(IEnumerable<SVGPoint> _points) {
            points.AddRange(_points);
        }
        
    }

}