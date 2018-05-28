using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.Data;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Svg;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using imbSCI.Core.extensions.io;

namespace imbSCI.Graph.DiagramLibraries.DiaShape
{

    /// <summary>
    /// Custom diaShape attribute
    /// </summary>
    public class diaShapeAttribute
    {

        public diaShapeAttribute() { }

        [XmlAttribute]
        public String name { get; set; }

        [XmlAttribute]
        public String type { get; set; }

    }

}