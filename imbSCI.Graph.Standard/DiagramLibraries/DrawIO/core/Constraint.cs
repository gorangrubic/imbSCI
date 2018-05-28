namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "constraint")]
        public class Constraint
        {
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
            [XmlAttribute(AttributeName = "perimeter")]
            public string Perimeter { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

}