/// <summary>
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.collection;
using imbSCI.Core.data;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Core.reporting;
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files
{
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Tool for easy object serialization 
    /// </summary>
    public static class objectSerialization
    {
        /// <summary>
        /// Serialize object to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static String ObjectToXML<T>(T settings) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StringWriter();

            serializer.Serialize(writer, settings);
            writer.Close();
            return writer.ToString();
        }

        public static String ObjectToXML(Object data)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            TextWriter writer = new StringWriter();

            serializer.Serialize(writer, data);
            writer.Close();
            return writer.ToString();
        }

        /// <summary>
        /// Unserialize object from XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T ObjectFromXML<T>(String xml) 
        {
            
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(xml);
            object obj = deserializer.Deserialize(reader);
            T output = (T)obj;
            reader.Close();
            return output;
        }

        public static void saveObjectToXML(this Object data, String filepath) // where T:class, new()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            XmlSerializer serializer = new XmlSerializer(data.GetType());
            FileInfo fi = filepath.getWritableFile();

            TextWriter writer = new StreamWriter(fi.FullName);
            serializer.Serialize(writer, data);
            writer.Close();
        }


        /// <summary>
        /// Saves the object to XML file at specified filepath
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath">The filepath.</param>
        /// <param name="data">The data instance to be saved</param>
        /// <exception cref="System.ArgumentNullException">data</exception>
        public static void saveObjectToXML<T>(String filepath, T data, ILogBuilder logger = null) // where T:class, new()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileInfo fi = filepath.getWritableFile();

            TextWriter writer = new StreamWriter(fi.FullName);
            serializer.Serialize(writer, data);
            writer.Close();
        }

        /// <summary>
        /// Loads the object from XML.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="type">The type.</param>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        public static Object loadObjectFromXML(String filepath, Type type, ILogBuilder logger = null) // where T : class, new()
        {
            if (!File.Exists(filepath))
            {
                return type.getInstance();
            }

            FileInfo fi = new FileInfo(filepath);
            if (fi.Length == 0)
            {
               if (logger != null) logger.log("Loading XML object from [" + filepath + "] aborted because file has 0 bytes. Default instance is created.");
                return type.getInstance();
            }

            XmlSerializer deserializer = new XmlSerializer(type);
            TextReader reader = new StreamReader(filepath);
            
            object obj = deserializer.Deserialize(reader);
            
            reader.Close();
            return obj;
        }

        /// <summary>
        /// Loads the object from XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        public static T loadObjectFromXML<T>(String filepath, ILogBuilder logger = null) // where T : class, new()
        {
            if (!File.Exists(filepath))
            {
                return default(T);
            }

            FileInfo fi = new FileInfo(filepath);
            if (fi.Length == 0)
            {
                if (logger != null) logger.log("Loading XML object from [" + filepath + "] aborted because file has 0 bytes. Default instance is created.");
                return default(T);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(filepath);
            object obj = deserializer.Deserialize(reader);
            T output = (T)obj;
            reader.Close();
            return output;
        }
    }
}
