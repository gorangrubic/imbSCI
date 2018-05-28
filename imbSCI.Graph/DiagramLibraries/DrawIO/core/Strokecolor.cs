namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "strokecolor")]
        public class Strokecolor
        {
            [XmlAttribute(AttributeName = "color")]
            public string Color { get; set; }
        }

}