using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Xml;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.data;
using imbSCI.Core.data;
using imbSCI.Data;
using System.Xml.Serialization;
using imbSCI.Core.files;
using imbSCI.Graph.Graphics.SvgAPI.Core;

namespace imbSCI.Graph.Graphics.SvgAPI.Meta
{


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Graph.Graphics.SvgAPI.svgGraphicElementBase" />
    public class svgDescriptiveElement : svgGraphicElementBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="svgDescriptiveElement"/> class.
        /// </summary>
        /// <param name="_content">The content.</param>
        /// <param name="type">The type.</param>
        public svgDescriptiveElement(String _content = "", svgDescriptiveElementEnum type=svgDescriptiveElementEnum.title)
        {
            _name = type.toString();
            content = _content;
        }
        private String _name;

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public String content { get; set; }

        /// <summary>
        /// To the XML.
        /// </summary>
        /// <returns></returns>
        public override XmlNode ToXml()
        {
            XmlDocument output = new XmlDocument();
            output.LoadXml(ToXmlOpenTag() + content + ToXmlCloseTag());

            return output;
        }



      


        public override string name => _name;
    }

}