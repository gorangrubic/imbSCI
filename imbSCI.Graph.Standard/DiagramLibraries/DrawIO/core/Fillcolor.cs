namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "fillcolor")]
        public class Fillcolor
        {
            [XmlAttribute(AttributeName = "color")]
            public string Color { get; set; }
        }

}