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

namespace imbSCI.Core.files.fileDataStructure
{
    using imbSCI.Core.files.folders;

    /// <summary>
    /// Methods used via <see cref="IFileDataStructure"/> interface
    /// </summary>
    public static class fileDataStructureExtensions
    {

        /// <summary>
        /// Gets the file data structure descriptor.
        /// </summary>
        /// <param name="dataStructure">The data structure.</param>
        /// <returns></returns>
        public static fileDataStructureDescriptor GetFileDataStructureDescriptor(this IFileDataStructure dataStructure)
        {
            fileDataStructureDescriptor output = new fileDataStructureDescriptor(dataStructure);
            return output;

        }

        /// <summary>
        /// Gets the file data structure descriptor for class implementing <see cref="IFileDataStructure"/> interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static fileDataStructureDescriptor GetFileDataStructureDescriptor<T>() where T : IFileDataStructure
        {
            Type type = typeof(T);

            fileDataStructureDescriptor descriptor = new fileDataStructureDescriptor();
            descriptor.deployDescriptor(type, null);

            return descriptor;
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static String GetExtension(this fileDataPropertyMode format)
        {
            switch (format)
            {
                default:
                case fileDataPropertyMode.autoTextOrXml:
                case fileDataPropertyMode.XML:
                    return ".xml";
                    break;
                case fileDataPropertyMode.text:
                    return ".txt";
                    break;
                case fileDataPropertyMode.JSON:
                    return ".json";
                    break;
                case fileDataPropertyMode.binary:
                    return ".dat";
                    break;

            }
        }





        /// <summary>
        /// Loads the data structure from path. Use path with file name if <see cref="fileDataFilenameMode.propertyValue"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <param name="parentFolder">The parent folder.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">
        /// Can't have File Data Structure loaded if no file structure mode specified
        /// or
        /// JSON not implemented yet
        /// or
        /// binary file not implemented yet
        /// </exception>
        public static T LoadDataStructure<T>(this String path, folderNode parentFolder=null, ILogBuilder output = null) where T:IFileDataStructure, new()
        {
            fileDataStructureDescriptor descriptor = GetFileDataStructureDescriptor<T>();
            T instance = new T();

            instance = (T)descriptor.LoadDataStructure(path, parentFolder, instance, output);
            return instance;
        }

        public static String SaveDataStructure<T>(this T dataStructure, folderNode parentFolder = null, ILogBuilder output = null) where T : IFileDataStructure {

            fileDataStructureDescriptor descriptor = GetFileDataStructureDescriptor(dataStructure);

            return descriptor.SaveDataStructure(dataStructure, parentFolder, output);

        }


        /// <summary>
        /// Deletes the data structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataStructure">The data structure.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        public static Boolean DeleteDataStructure<T>(this T dataStructure, ILogBuilder output = null) where T:IFileDataStructure
        {
            fileDataStructureDescriptor descriptor = GetFileDataStructureDescriptor(dataStructure);

            return descriptor.DeleteDataStructure(dataStructure, output);
        }

    }

}