using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Data.data.package
{

    /// <summary>
    /// Stored XML content, paired with ID
    /// </summary>
    public class dataItemContainer
    {
        /// <summary>
        /// Used by XmlSerialization
        /// </summary>
        public dataItemContainer()
        {

        }

        /// <summary>
        /// ID associated to the stored instance
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public String id { get; set; }

        /// <summary>
        /// XML code of stored instance
        /// </summary>
        /// <value>
        /// The instance XML.
        /// </value>
        public String instanceXml { get; set; }
    }

}