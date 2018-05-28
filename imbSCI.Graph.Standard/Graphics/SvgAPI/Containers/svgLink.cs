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

    [XmlRoot("a")]
    public class svgLink : svgContainerElement
    {
        public svgLink(String href)
        {
            attributes.Set("href", href);
        }
        [XmlIgnore]
        public override String name
        {
            get { return "a"; }
        }


    }

}