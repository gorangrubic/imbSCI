namespace imbSCI.Graph.DiagramLibraries.DrawIO
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using imbSCI.Graph.DiagramLibraries.DrawIO.core;

    [XmlRoot(ElementName = "shape")]
        public class Shape
        {

        public Shape()
        {

        }


            [XmlArray(ElementName = "connections")]
            [XmlArrayItem(ElementName ="constraint")]
            public List<Constraint> Connections { get; set; } = new List<Constraint>();

            [XmlElement(ElementName = "background")]
            public Background Background { get; set; }
            [XmlElement(ElementName = "foreground")]
            public Foreground Foreground { get; set; }
            [XmlAttribute(AttributeName = "aspect")]
            public string Aspect { get; set; }
            [XmlAttribute(AttributeName = "h")]
            public string H { get; set; }
            [XmlAttribute(AttributeName = "w")]
            public string W { get; set; }
            [XmlAttribute(AttributeName = "strokewidth")]
            public string Strokewidth { get; set; }
        }

}