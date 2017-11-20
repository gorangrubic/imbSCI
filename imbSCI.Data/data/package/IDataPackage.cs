using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Data.data.package
{

    public interface IDataPackage
    {
        String name { get; set; }
        
        List<dataItemContainer> content { get; set; }
    }

}