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
    /// Package very foundation
    /// </summary>
    /// <seealso cref="imbSCI.Data.data.package.IDataPackage" />
    public abstract class dataPackageBase :IDataPackage
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String name
        {
            get; set;
        }

        /// <summary>
        /// Content collection that is serialized
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public List<dataItemContainer> content { get; set; }
        

    }

}