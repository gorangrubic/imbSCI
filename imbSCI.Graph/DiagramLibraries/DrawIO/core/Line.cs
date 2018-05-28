namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "line")]
        public class Line
        {
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }

}