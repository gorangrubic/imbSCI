using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using imbSCI.Core.reporting.zone;

namespace imbSCI.Graph.Graphics.SvgAPI.Containers
{




    [XmlRoot("g")]
    public class svgGroup : svgContainerElement
    {
        public svgGroup(String _id) {
            id = _id;
        }
        [XmlIgnore]
        public override String name {
            get { return "g"; } }

      
    }

}