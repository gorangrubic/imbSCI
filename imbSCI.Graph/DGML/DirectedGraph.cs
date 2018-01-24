// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectedGraph.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
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
// Project: imbSCI.Graph
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using imbSCI.Graph.DGML.collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.io;
using imbSCI.Core.files.folders;
using imbSCI.Core.files;
using imbSCI.Data.enums;
using System.IO;
using imbSCI.Graph.DGML.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Graph.DGML
{

    [XmlRoot(Namespace = "http://schemas.microsoft.com/vs/2009/dgml",
     ElementName = "DirectedGraph",
     IsNullable = true)]
    public class DirectedGraph:IObjectWithName
    {
        [XmlIgnore]
        public List<String> ConversionErrors { get; set; } = new List<string>();

        public DirectedGraph()
        {

        }

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static T Load<T>(String path) where T:DirectedGraph
        {
            FileInfo fi = path.getWritableFile(getWritableFileMode.existing);
            if (fi.Exists)
            {
                return objectSerialization.loadObjectFromXML<T>(path);
            }
            return default(T);
        }

        /// <summary>
        /// Saves the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        public void Save(String path, getWritableFileMode mode = Data.enums.getWritableFileMode.overwrite)
        {
            if (!path.EndsWith(".dgml"))
            {
                path = path + ".dgml";
            }

            FileInfo fi = path.getWritableFile(mode);

            objectSerialization.saveObjectToXML(this, fi.FullName);
            if (ConversionErrors.Any())
            {
                String errFileName = Path.GetFileNameWithoutExtension(path) + "_conversionErrors.txt";
                folderNode fl = fi.Directory;
                String errFilePath = fl.pathFor(errFileName, getWritableFileMode.overwrite);
                File.WriteAllLines(errFilePath, ConversionErrors);
            }
        }


        public virtual void OnBeforeSave(folderNode folder)
        {

        }

        public virtual void OnAfterLoad(folderNode folder)
        {

        }

        [XmlAttribute]
        public GraphDirectionEnum GraphDirection { get; set; } = GraphDirectionEnum.TopToBottom;

        [XmlAttribute]
        public GraphLayoutEnum Layout { get; set; } = GraphLayoutEnum.Sugiyama;


        [XmlAttribute]
        public Int32 NeighborhoodDistance { get; set; } = 25;

        [XmlAttribute]
        public String Background {get;set;}

        [XmlAttribute]
        public String Title { get; set; }

        [XmlIgnore]
        string IObjectWithName.name {
            get
            {
                return Title;
            }
            set {
                Title = value;
            }
        }

        
        public LinkCollection Links { get; set; } = new LinkCollection();

        public NodeCollection Nodes { get; set; } = new NodeCollection();

        public PropertyList Properties { get; set; } = new PropertyList();

        public CategoryCollection Categories { get; set; } = new CategoryCollection();
         
    }
}
