using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Graph.DiagramLibraries.DrawIO
{
    /* 
     Licensed under the Apache License, Version 2.0

     http://www.apache.org/licenses/LICENSE-2.0
     */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
        [XmlRoot(ElementName = "constraint")]
        public class Constraint
        {
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
            [XmlAttribute(AttributeName = "perimeter")]
            public string Perimeter { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "connections")]
        public class Connections
        {
            [XmlElement(ElementName = "constraint")]
            public List<Constraint> Constraint { get; set; }
        }

        [XmlRoot(ElementName = "strokecolor")]
        public class Strokecolor
        {
            [XmlAttribute(AttributeName = "color")]
            public string Color { get; set; }
        }

        [XmlRoot(ElementName = "fillcolor")]
        public class Fillcolor
        {
            [XmlAttribute(AttributeName = "color")]
            public string Color { get; set; }
        }

        [XmlRoot(ElementName = "rect")]
        public class Rect
        {
            [XmlAttribute(AttributeName = "h")]
            public string H { get; set; }
            [XmlAttribute(AttributeName = "w")]
            public string W { get; set; }
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }   

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

        [XmlRoot(ElementName = "dashpattern")]
        public class Dashpattern
        {
            [XmlAttribute(AttributeName = "pattern")]
            public string Pattern { get; set; }
        }

        [XmlRoot(ElementName = "dashed")]
        public class Dashed
        {
            [XmlAttribute(AttributeName = "dashed")]
            public string _dashed { get; set; }
        }

        [XmlRoot(ElementName = "strokewidth")]
        public class Strokewidth
        {
            [XmlAttribute(AttributeName = "width")]
            public string Width { get; set; }
        }

        [XmlRoot(ElementName = "linejoin")]
        public class Linejoin
        {
            [XmlAttribute(AttributeName = "join")]
            public string Join { get; set; }
        }

        [XmlRoot(ElementName = "linecap")]
        public class Linecap
        {
            [XmlAttribute(AttributeName = "cap")]
            public string Cap { get; set; }
        }

        [XmlRoot(ElementName = "alpha")]
        public class Alpha
        {
            [XmlAttribute(AttributeName = "alpha")]
            public string _alpha { get; set; }
        }

        [XmlRoot(ElementName = "move")]
        public class Move
        {
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }

        [XmlRoot(ElementName = "line")]
        public class Line
        {
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }

        [XmlRoot(ElementName = "path")]
        public class Path
        {
            [XmlElement(ElementName = "move")]
            public Move Move { get; set; }
            [XmlElement(ElementName = "line")]
            public List<Line> Line { get; set; }
            [XmlElement(ElementName = "close")]
            public string Close { get; set; }
            [XmlElement(ElementName = "curve")]
            public List<Curve> Curve { get; set; }
        }

        [XmlRoot(ElementName = "ellipse")]
        public class Ellipse
        {
            [XmlAttribute(AttributeName = "h")]
            public string H { get; set; }
            [XmlAttribute(AttributeName = "w")]
            public string W { get; set; }
            [XmlAttribute(AttributeName = "x")]
            public string X { get; set; }
            [XmlAttribute(AttributeName = "y")]
            public string Y { get; set; }
        }

        [XmlRoot(ElementName = "curve")]
        public class Curve
        {
            [XmlAttribute(AttributeName = "x1")]
            public string X1 { get; set; }
            [XmlAttribute(AttributeName = "x2")]
            public string X2 { get; set; }
            [XmlAttribute(AttributeName = "x3")]
            public string X3 { get; set; }
            [XmlAttribute(AttributeName = "y1")]
            public string Y1 { get; set; }
            [XmlAttribute(AttributeName = "y2")]
            public string Y2 { get; set; }
            [XmlAttribute(AttributeName = "y3")]
            public string Y3 { get; set; }
        }

        [XmlRoot(ElementName = "foreground")]
        public class Foreground
        {
            [XmlElement(ElementName = "fillstroke")]
            public List<string> Fillstroke { get; set; }
            [XmlElement(ElementName = "save")]
            public List<string> Save { get; set; }
            [XmlElement(ElementName = "dashpattern")]
            public List<Dashpattern> Dashpattern { get; set; }
            [XmlElement(ElementName = "dashed")]
            public List<Dashed> Dashed { get; set; }
            [XmlElement(ElementName = "rect")]
            public List<Rect> Rect { get; set; }
            [XmlElement(ElementName = "stroke")]
            public List<string> Stroke { get; set; }
            [XmlElement(ElementName = "strokecolor")]
            public List<Strokecolor> Strokecolor { get; set; }
            [XmlElement(ElementName = "strokewidth")]
            public List<Strokewidth> Strokewidth { get; set; }
            [XmlElement(ElementName = "linejoin")]
            public Linejoin Linejoin { get; set; }
            [XmlElement(ElementName = "linecap")]
            public List<Linecap> Linecap { get; set; }
            [XmlElement(ElementName = "restore")]
            public List<string> Restore { get; set; }
            [XmlElement(ElementName = "fillcolor")]
            public List<Fillcolor> Fillcolor { get; set; }
            [XmlElement(ElementName = "alpha")]
            public List<Alpha> Alpha { get; set; }
            [XmlElement(ElementName = "path")]
            public List<Path> Path { get; set; }
            [XmlElement(ElementName = "ellipse")]
            public List<Ellipse> Ellipse { get; set; }
        }

        [XmlRoot(ElementName = "shape")]
        public class Shape
        {
            [XmlElement(ElementName = "connections")]
            public Connections Connections { get; set; }
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

}
