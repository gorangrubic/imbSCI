using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using imbSCI.Graph.DGML.enums;
using System.Xml.Serialization;

namespace imbSCI.Graph.DGML.core
{

    public abstract class GraphNodeElement:GraphElement
    {
        [XmlAttribute]
        public String Id { get; set; }

        [XmlAttribute]
        public String Background { get; set; }

        [XmlAttribute]
        public String Foreground { get; set; }

    }

}