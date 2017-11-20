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
    /// Utility class with methods and extensions for easier work with <see cref="dataPackage{T, TWrapper}"/>
    /// </summary>
    public static class dataPackageExtensions
    {

        /// <summary>
        /// Saves the data package.
        /// </summary>
        /// <typeparam name="TPackage">The type of the package.</typeparam>
        /// <param name="package">The package.</param>
        /// <param name="path">The path.</param>
        public static void SaveDataPackage<TPackage>(this TPackage package, String path) where TPackage:IDataPackage, new()
        {
            var xmlSer = new XmlSerializer(typeof(TPackage));
                       

            TextWriter writer = new StringWriter();
            
            xmlSer.Serialize(writer, package);
            writer.Close();

        }

        /// <summary>
        /// Loads the data package.
        /// </summary>
        /// <typeparam name="TPackage">The type of the package.</typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static TPackage LoadDataPackage<TPackage>(String path) where TPackage:IDataPackage, new()
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(TPackage), new Type[] { typeof(dataItemContainer) });
            String xmlText = "";
            if (File.Exists(path))
            {
                xmlText = File.ReadAllText(path);
            } else
            {
                return default(TPackage);
            }

            TextReader reader = new StringReader(xmlText);
            object obj = deserializer.Deserialize(reader);
            TPackage output = (TPackage)obj;
            reader.Close();

            return output;
        }

        // public static IDataPackage
    }

}