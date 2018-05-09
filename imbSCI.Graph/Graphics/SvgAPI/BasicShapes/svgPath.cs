using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using imbSCI.Graph.Graphics.SvgAPI.Core;
using imbSCI.Graph.Graphics.SvgAPI;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace imbSCI.Graph.Graphics.SvgAPI.BasicShapes
{



    [XmlRoot("path")]
    public class svgPath : svgGraphicElementBase, ISVGTranform
    {
        protected svgPath()
        {

        }

        public override String name { get { return "path"; } }

        public svgPathInstructionSet instructions { get; set; } = new svgPathInstructionSet();

        
     
        public override XmlNode ToXml()
        {
            attributes.Set("d", instructions.ToString());

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ToXmlOpenTag() + ToXmlCloseTag());
            return xdoc.FirstChild;  
        }

        
    }
}
