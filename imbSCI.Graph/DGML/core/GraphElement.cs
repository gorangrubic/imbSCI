using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using imbSCI.Graph.DGML.enums;
using System.Xml.Serialization;

namespace imbSCI.Graph.DGML.core
{


    /// <summary>
    /// 
    /// </summary>
    public abstract class GraphElement
    {
        [XmlAttribute]
        public String Stroke { get; set; }

        [XmlAttribute]
        public Int32 StrokeThinkness { get; set; } = 1;

        [XmlAttribute]
        public String StrokeDashArray { get; set; }

        [XmlAttribute]
        public String Label { get; set; } = "";

        [XmlAttribute]
        public String Category { get; set; }

        [XmlAttribute]
        public GroupEnum Group { get; set; } = GroupEnum.Collapsed;

        [XmlAttribute]
        public Visibility Visibility { get; set; } = Visibility.Visible;


    }

}