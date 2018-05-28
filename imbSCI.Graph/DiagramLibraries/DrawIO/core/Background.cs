namespace imbSCI.Graph.DiagramLibraries.DrawIO.core
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;


        [XmlRoot(ElementName = "background")]
        public class Background
        {
            [XmlElement(ElementName = "strokecolor")]
            public Strokecolor Strokecolor { get; set; }
            [XmlElement(ElementName = "fillcolor")]
            public Fillcolor Fillcolor { get; set; }
            [XmlElement(ElementName = "rect")]
            public Rect Rect { get; set; }
        }

}