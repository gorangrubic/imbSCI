using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Core.documents.openDocument
{

    [XmlRoot("meta", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
    public class metaContainer
    {

        public metaContainer()
        {

        }


        [XmlAttribute(AttributeName ="initial-creator", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
        public String initial_creator { get; set; } = "";


        
        public String generator { get; set; } = "";

        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/")]
        public String subject { get; set; } = "";

        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/")]
        public String title { get; set; } = "";


        [XmlElement(ElementName ="user-defined", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
        public List<user_defined> user { get; set; } = new List<user_defined>();

    }

}