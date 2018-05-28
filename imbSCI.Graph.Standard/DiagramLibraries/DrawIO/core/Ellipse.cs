namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "ellipse")]
        public class Ellipse
        {
            [XmlAttribute(AttributeName = "h")]
            public string H { get; set; }
            [XmlAttribute(AttributeName = "w")]
            public string W { get; set; }
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }

}