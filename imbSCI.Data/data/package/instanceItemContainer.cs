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
    /// Temporary structure used for id/instance pair exchange
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class instanceItemContainer<T>
    {
        public instanceItemContainer(String __id, T __instance)
        {
            id = __id;
            instance = __instance;
        }
        public String id;
        public T instance { get; set; }
    }

}