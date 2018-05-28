namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "strokewidth")]
        public class Strokewidth
        {
            [XmlAttribute(AttributeName = "width")]
            public string Width { get; set; }
        }

}