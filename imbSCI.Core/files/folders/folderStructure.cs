// --------------------------------------------------------------------------------------------------------------------
// <copyright file="folderStructure.cs" company="imbVeles" >
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

namespace imbSCI.Core.files.folders
{
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public class folderStructure: folderNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="folderStructure"/> class.
        /// </summary>
        /// <param name="__baseDirectoryPath">The base directory path - le</param>
        /// <param name="__caption">The caption.</param>
        /// <param name="__description">The description.</param>
        public folderStructure(String __baseDirectoryPath, String __caption, String __description):base("", __caption, __description)
        {
            baseDirectoryPath = __baseDirectoryPath;
            
        }

        /// <summary>
        /// Creates new instance of structure by scanning <see cref="DirectoryInfo"/> object subfolders
        /// </summary>
        /// <param name="directory">The directory.</param>
        public folderStructure(DirectoryInfo directory, String __caption= folderNode.CAPTION_FOR_TUNNELFOLDER, String __description= folderNode.CAPTION_FOR_TUNNELFOLDER, SearchOption options = SearchOption.TopDirectoryOnly) :base("",__caption, __description)
        {
            baseDirectoryPath = directory.FullName;
            foreach (DirectoryInfo info in directory.GetDirectories("*", options)) {
                String relativePath = imbSciStringExtensions.removeStartsWith(info.FullName, baseDirectoryPath);
                String subdirName = relativePath.getPathVersion(-1, "\\");
                Add(relativePath, subdirName.imbTitleCamelOperation(true), "Automatically generated node on (" + relativePath + ") by scanning DirectoryInfo (" + directory.FullName + ")");
            }
        }


        private Object GenerateReadmeLock = new Object();


        /// <summary>
        /// Generates the readme files and the folder structure
        /// </summary>
        /// <param name="notation">The notation.</param>
        public void generateReadmeFiles(aceAuthorNotation notation, String readmeFileName= "readme_directory.md")
        {
            lock (GenerateReadmeLock)
            {

                String readme_filename = readmeFileName;
                String mpath = imbSciStringExtensions.add(path, readme_filename, "\\");
                generateFolderReadme(notation).saveStringToFile(mpath);



                foreach (KeyValuePair<String, folderNode> ni in this)
                {

                    String path = imbSciStringExtensions.add(ni.Value.path, readme_filename, "\\");


                    FileInfo fi = path.getWritableFile(getWritableFileMode.overwrite);

                    String content = ni.Value.generateFolderReadme(notation);
                    content.saveStringToFile(fi.FullName, getWritableFileMode.overwrite);
                    saveBase.saveToFile(fi.FullName, content);

                }
            } 

        }


        private String _baseDirectoryPath;
        /// <summary>
        /// 
        /// </summary>
        public String baseDirectoryPath
        {
            get { return _baseDirectoryPath; }
            set { _baseDirectoryPath = value; }
        }

        public override string path
        {
            get
            {
                return baseDirectoryPath;
            }
        }

        public override IFolderNode parent
        {
            get
            {
                return null;
            }
        }
        

        public override string name
        {
            get
            {

                return baseDirectoryPath.getPathVersion(-1);  //Path.GetDirectoryName(baseDirectoryPath);
            }
        }
    }

}