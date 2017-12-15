// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileDataStructureDescriptor.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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
    using System.IO;
    using System.Reflection;
    using imbSCI.Core.files.folders;
    using imbStringPathTools = imbSCI.Core.extensions.text.imbStringPathTools;

    /// <summary>
    /// Descriptor for class implementing <see cref="IFileDataStructure"/> interface. Metadata are defined with <see cref="fileStructureAttribute"/>
    /// </summary>
    /// <seealso cref="fileDataDescriptorBase" />
    public class fileDataStructureDescriptor:fileDataDescriptorBase
    {
        internal SortedList<Int32, fileDataPropertyDescriptor> fileDataProperties = new SortedList<int, fileDataPropertyDescriptor>();

        public fileStructureMode mode { get; set; } = fileStructureMode.subdirectory;

        /// <summary>
        /// Loads the data structure.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parentFolder">The parent folder.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Can't have File Data Structure loaded if no file structure mode specified</exception>
        internal IFileDataStructure LoadDataStructure(String path, folderNode parentFolder = null, IFileDataStructure instance=null, ILogBuilder output=null)
        {
            
            if (parentFolder == null) parentFolder = Directory.CreateDirectory(Directory.GetCurrentDirectory());

            String filename = ""; // GetFilepath(path, instance, false);
            

            
            switch (mode)
            {
                case fileStructureMode.subdirectory:
                    if (path.Contains("."))
                    {
                        path = Path.GetDirectoryName(path);
                        if (path.isNullOrEmptyString())
                        {
                            throw new ArgumentException("This is subdirectory data structure, do not use directory names with dot [" + path + "] " + "Path contains dot", nameof(path));
                        }
                    }

                    var folder = parentFolder.createDirectory(path, "", false);
                    filename = type.Name.getCleanPropertyName().add(formatMode.GetExtension(), ".");
                    
                    if (instance != null)
                    {
                        
                        instance.folder = folder;
                        
                    }
                    parentFolder = folder;
                    break;
                case fileStructureMode.none:
                    filename = GetFilepath(path, instance, false);
                    throw new NotImplementedException("Can't have File Data Structure loaded if no file structure mode specified");
                    break;
            }

            String filepath = parentFolder.pathFor(filename);



            if (File.Exists(filepath))
            {

                instance = LoadDataFile(filepath, output) as IFileDataStructure;
            }
                        
            instance.folder = parentFolder;

            
            foreach (var pair in fileDataProperties)
            {
                fileDataPropertyDescriptor pDesc = pair.Value;
                pDesc.LoadDataAndSet(instance, parentFolder, output);
            }


            if (instance != null)
            {
                parentFolder.description = instance.description;
                parentFolder.caption = instance.name;
            }

            instance.OnLoaded();

            return instance;
        }

        /// <summary>
        /// Deletes the data structure file, where filepath is determined using the <see cref="fileDataStructureDescriptor"/> of <see cref="IFileDataStructure"/> instance specified.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Can't have File Data Structure loaded if no file structure mode specified</exception>
        internal Boolean DeleteDataStructure(IFileDataStructure instance, ILogBuilder output = null)
        {
            

            String filename = ""; // GetFilepath("", instance, false);

            switch (mode)
            {
                case fileStructureMode.subdirectory:

                    if (!Directory.Exists(instance.folder.path)) return false;

                    DirectoryInfo di = new DirectoryInfo(instance.folder.path);
                    
                    di.Delete(true);
                    
                    break;
                case fileStructureMode.none:
                    throw new NotImplementedException("Can't have File Data Structure loaded if no file structure mode specified");
                    break;
            }

            return true;
        }



        /// <summary>
        /// Saves the data structure: its properties marked with <see cref="fileDataAttribute"/> attribute and it self
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="parentFolder">The parent folder.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Can't have File Data Structure loaded if no file structure mode specified</exception>
        internal String SaveDataStructure(IFileDataStructure instance, folderNode parentFolder = null, ILogBuilder output = null)
        {
            if (parentFolder == null) parentFolder = instance.folder;

            String filename = ""; // GetFilepath("", instance, false);

            switch (mode)
            {
                case fileStructureMode.subdirectory:
                    //parentFolder = Directory.CreateDirectory(parentFolder.path);
                    if (instance.folder == null) instance.folder = parentFolder.Add(instance.name, instance.name, "Directory for [" + instance.GetType().Name+"]. " + instance.description);
                    filename = type.Name.getCleanPropertyName().add(formatMode.GetExtension(), ".");

                    break;
                case fileStructureMode.none:
                    throw new NotImplementedException("Can't have File Data Structure loaded if no file structure mode specified");
                    break;
            }

            


            instance.OnBeforeSave();

            foreach (var pair in fileDataProperties)
            {
                fileDataPropertyDescriptor pDesc = pair.Value;
                pDesc.SaveData(instance, instance.folder, output);
            }

            String filepath = instance.folder.pathFor(filename);
            SaveDataFile(instance, filepath, output);

            return filepath;
        }



        public fileDataStructureDescriptor()
        {

        }


        public fileDataStructureDescriptor(IFileDataStructure dataStructure)
        {
            deployDescriptor(dataStructure);
        }

      
        internal void deployDescriptor(IFileDataStructure dataStructure)
        {
            Type type = dataStructure.GetType();
            deployDescriptor(type, dataStructure);

        }

        internal void deployDescriptor(Type type, IFileDataStructure dataStructure)
        {
            //Type type = dataStructure.GetType();
            
            fileStructureAttribute attribute = Attribute.GetCustomAttribute(type, typeof(fileStructureAttribute)) as fileStructureAttribute;
            if (attribute != null)
            {
                deployDescriptorBase(type, attribute, dataStructure);
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var prop in properties)
            {
                fileDataAttribute propAttribute = Attribute.GetCustomAttribute(prop, typeof(fileDataAttribute)) as fileDataAttribute;
                if (propAttribute != null)
                {
                    fileDataPropertyDescriptor propDescriptor = new fileDataPropertyDescriptor(prop, propAttribute, dataStructure);
                    Int32 p = propDescriptor.memberMetaInfo.priority;
                    while (fileDataProperties.ContainsKey(p))
                    {
                        p++;
                    }
                    
                    fileDataProperties.Add(p, propDescriptor);
                }
            }
        }

        public override string GetFilepath(string path = "", IFileDataStructure instance = null, bool appendPathInOutput = false)
        {
            String filepath = "";
            switch (filenameMode)
            {
                case fileDataFilenameMode.memberInfoName:
                case fileDataFilenameMode.customName:
                    filepath = filename;
                    break;
                case fileDataFilenameMode.propertyValue:

                    filepath = Path.GetFileNameWithoutExtension(path);
                    path = imbStringPathTools.getPathVersion(path, 1, "\\");
                    if (instance != null)
                    {
                        PropertyExpression pexp = new PropertyExpression(instance, nameOrPropertyPath);
                        pexp.setValue(filename);
                    }
                    break;
                default:

                    // 
                    //throw new NotImplementedException("File Data Structure can't have filename by property value");
                    break;
            }

            if (options.HasFlag(fileDataPropertyOptions.itemAsFile))
            {
                filepath = filepath + "_*";
            }


            //path = path.ensureEndsWith(filepath);

            if (appendPathInOutput) path = path.add(filepath, "\\");

            return path;
        }
    }

}