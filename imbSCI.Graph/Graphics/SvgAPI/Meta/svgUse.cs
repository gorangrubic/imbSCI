using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using imbSCI.Core.reporting.zone;
using imbSCI.Graph.Graphics.SvgAPI.Core;
using imbSCI.Graph.Graphics.SvgAPI.Containers;
using imbSCI.Graph.Graphics.SvgAPI.Meta;
using imbSCI.Graph.Graphics.SvgAPI.BasicShapes;
using imbSCI.Graph.Graphics.SvgAPI.Animation;

namespace imbSCI.Graph.Graphics.SvgAPI.Meta
{

    /// <summary>
    /// The use element is instantiating already defined objects. It is a placeholder for <see cref="svgSymbol"> and other predefined elements.
    /// </summary>
    /// <seealso cref="svgDocument.definitions"/>
    /// <seealso cref="svgContainerElement.AddUse(svgSymbol, int, int, string)"/>
    /// <seealso cref="imbSCI.Graph.Graphics.SvgAPI.Core.svgGraphicElementBase" />
    [XmlRoot("use")]
    public class svgUse: svgGraphicElementBase
    {
        [XmlIgnore]
        public override String name { get { return "use"; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="svgUse"/> class. 
        /// </summary>
        /// <see cref="svgContainerElement.AddUse(svgSymbol, int, int, string)"/>
        public svgUse()
        {

        }



        /// <summary>
        /// ID of predefined element that you want to place with this svgUse instance
        /// </summary>
        /// <value>
        /// The href.
        /// </value>
        [XmlAttribute]
        public String href { get; set; } = "";

        ///// <summary>
        ///// To the XML string.
        ///// </summary>
        ///// <returns></returns>
        //public override string ToXmlString()
        //{
        //    return ToXml().OuterXml;
        //}

        /// <summary>
        /// To the XML.
        /// </summary>
        /// <returns></returns>
        public override XmlNode ToXml()
        {
            attributes.Set("href", href);
            return ToXmlBase(); 
        }
    }

}