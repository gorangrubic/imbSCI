using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Core.documents.openDocument.meta
{
    [XmlRoot("document-meta")]
    public class documentMeta
    {

        public documentMeta()
        {
            deploy();
        }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns { get; set; }


        [XmlAttribute(Namespace = "urn:oasis:names:tc:opendocument:xmlns:office:1.0")]
        public String version { get; set; } = "1.2";

        [XmlElement(ElementName = "meta", Namespace = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0")]
        public metaContainer metaObject { get; set; } = new metaContainer();

        protected void deploy()
        {
            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("office", "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
            xmlns.Add("xlink", "http://www.w3.org/1999/xlink");
            xmlns.Add("dc", "http://purl.org/dc/elements/1.1/");
            xmlns.Add("meta", "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
            xmlns.Add("ooo", "http://openoffice.org/2004/office");
            xmlns.Add("grddl", "http://www.w3.org/2003/g/data-view#");

        }



    }


}
