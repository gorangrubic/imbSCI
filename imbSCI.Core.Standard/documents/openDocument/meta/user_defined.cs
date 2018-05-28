using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Core.documents.openDocument
{

    [XmlRoot(ElementName ="user-defined", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
    public class user_defined
    {

        public user_defined()
        {

        }

        [XmlAttribute("name", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
        public String name { get; set; } = "";

        [XmlAttribute("value-type", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
        public String value_type { get; set; } = "string";

        [XmlText]
        public String value { get; set; } = "";
    }

}