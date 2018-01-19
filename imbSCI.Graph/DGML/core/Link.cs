using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Graph.DGML.core
{
    public class Link:GraphElement
    {

        public Link()
        {

        }

        public Link(String _source, String _target)
        {
            Source = _source;
            Target = _target;

        }

        [XmlAttribute]
        public String Source { get; set; } = "";

        [XmlAttribute]
        public String Target { get; set; } = "";

        

    }
}
