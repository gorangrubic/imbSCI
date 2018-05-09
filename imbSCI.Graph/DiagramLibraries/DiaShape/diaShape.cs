using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using Svg;

namespace imbSCI.Graph.DiagramLibraries.DiaShape
{

    /// <summary>
    /// Describes instance of Dia shape definition
    /// </summary>
    [XmlRoot("shape", Namespace = "http://www.daa.com.au/~james/dia-shape-ns")]
    public class diaShape
    {

        /// <summary>
        /// Additional XML namespaces that shape format uses
        /// </summary>
        /// <value>
        /// The XMLNS.
        /// </value>
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns { get; set; }

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static diaShape Load(String path)
        {
            diaShape output =  objectSerialization.loadObjectFromXML<diaShape>(path);

            return output;
        }

        /// <summary>
        /// Saves the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Save(String path)
        {
            objectSerialization.saveObjectToXML(this, path);
        }

        /// <summary>
        /// Saves the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public String Save(folderNode folder, String filename, String description="")
        {
            filename = filename.ensureEndsWith(".shape");
            String path = folder.pathFor(filename, Data.enums.getWritableFileMode.newOrExisting, description, true);

            objectSerialization.saveObjectToXML(this, path);
            return path;
        }

        public Svg.SvgDocument GetSVG()
        {
            SvgDocument svgDocument = new SvgDocument();
            svgDocument = SvgDocument.Open(svg.OwnerDocument);

            return svgDocument;

        }


        protected void deploy()
        {
            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("svg", "http://www.w3.org/2000/svg");
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="diaShape"/> class.
        /// </summary>
        public diaShape() {
            deploy();   
        }

        public diaShape(String _name, String _icon)
        {
            deploy();
            name = _name;
            icon = _icon;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement]
        public String name { get; set; } = "";

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [XmlElement]
        public String description { get; set; }



        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [XmlElement]
        public String icon { get; set; } = "";


        /// <summary>
        /// Adds the connection.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="main">if set to <c>true</c> [main].</param>
        /// <returns></returns>
        public diaConnectionPoint AddConnection(Double x, Double y, Boolean main = false)
        {
            diaConnectionPoint d = new diaConnectionPoint(x, y, main);
            connections.Add(d);
            return d;
        }

        /// <summary>
        /// Gets or sets the connections.
        /// </summary>
        /// <value>
        /// The connections.
        /// </value>
        [XmlArray("connections")]
        [XmlArrayItem("point")]
        public List<diaConnectionPoint> connections { get; set; } = new List<diaConnectionPoint>();

        /// <summary>
        /// Gets or sets the aspectratio.
        /// </summary>
        /// <value>
        /// The aspectratio.
        /// </value>
        [XmlElement]
        public diaShapeAspectRatio aspectratio { get; set; }

        /// <summary>
        /// Gets or sets the textbox.
        /// </summary>
        /// <value>
        /// The textbox.
        /// </value>
        [XmlElement]
        public diaTextBox textbox { get; set; } = new diaTextBox();


        /// <summary>
        /// Scalable Vector Graphics element
        /// </summary>
        /// <value>
        /// The SVG.
        /// </value>
        [XmlAnyElement(Name ="svg", Namespace = "http://www.w3.org/2000/svg")]
    //    [XmlElement(ElementName ="svg", Namespace = "http://www.w3.org/2000/svg")]
        public XmlElement svg { get; set; } 



    }
}
