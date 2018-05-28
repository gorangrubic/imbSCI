using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Xml;
using imbSCI.Graph.Graphics.SvgAPI.Core;
using imbSCI.Graph.Graphics.SvgAPI;
using System.Xml.Serialization;

namespace imbSCI.Graph.Graphics.SvgAPI.BasicShapes
{






    public class svgPolyline:svgMultiPointGraphicsBase, ISVGTranform
    {
        /// <summary>
        /// XML/SVG node name
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string name { get { return "polyline"; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="svgPolyline"/> class.
        /// </summary>
        public svgPolyline() { }

        /// <summary>
        /// Creates poliline from points. <see cref="svgToolkitExtensions.GetPointsFromString(string)"/>
        /// </summary>
        /// <param name="_points">The points.</param>
        public svgPolyline(String _points) {
            points.AddRange(_points.GetPointsFromString());
        }

        /// <summary>
        /// Creates poliline from points.
        /// </summary>
        /// <param name="_points">The points.</param>
        public svgPolyline(IEnumerable<SVGPoint> _points) {

            points.AddRange(_points);
        }
    }

}