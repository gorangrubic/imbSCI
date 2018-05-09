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

    public class svgElipse:svgGraphicElementBase, ISVGTranform
    {
        public override string name { get { return "elipse"; } }

        public override XmlNode ToXml()
        {
            return ToXmlBase();
        }

        //public override string ToXmlString()
        //{
        //    return ToXml().OuterXml;
        //}
    }

}