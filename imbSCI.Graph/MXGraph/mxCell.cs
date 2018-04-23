using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Graph.MXGraph
{

    public class mxCell
    {

        public mxCell() { }

        [XmlAttribute(DataType ="string")]
        public Int32 id { get; set; } = 0;


        [XmlAttribute(DataType = "string")]
        public Int32 parent { get; set; } = 0;


        [XmlAttribute(DataType = "string")]
        public Int32 source { get; set; } = 0;

        [XmlAttribute(DataType = "string")]
        public Int32 target { get; set; } = 0;


        [XmlAttribute]
        public String style { get; set; } = "";


        [XmlAttribute]
        public String value { get; set; } = "";


        [XmlAttribute(DataType = "int")]
        public Boolean edge { get; set; } = false;





    }

}