namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "linecap")]
        public class Linecap
        {
            [XmlAttribute(AttributeName = "cap")]
            public string Cap { get; set; }
        }

}