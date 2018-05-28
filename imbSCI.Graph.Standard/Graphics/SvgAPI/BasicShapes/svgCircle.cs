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

    


    /// <summary>
    /// Cicle
    /// </summary>
    /// <seealso cref="imbSCI.Graph.Graphics.SvgAPI.Core.svgGraphicElementBase" />
    /// <seealso cref="imbSCI.Graph.Graphics.SvgDocument.ISVGTranform" />
    public class svgCircle : svgGraphicElementBase, ISVGTranform
    {
        public override string name { get { return "circle"; } }

        /// <summary>
        /// To the XML.
        /// </summary>
        /// <returns></returns>
        public override XmlNode ToXml()
        {
            return ToXmlBase();
        }

       
    }

}