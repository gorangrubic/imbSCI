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

namespace imbSCI.Graph.DGML
{

    [XmlRoot(Namespace = "http://schemas.microsoft.com/vs/2009/dgml",
     ElementName = "DirectedGraph",
     IsNullable = true)]
    public class DirectedGraph
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
        
        public LinkCollection Links { get; set; } = new LinkCollection();

        public NodeCollection Nodes { get; set; } = new NodeCollection();

        public PropertyList Properties { get; set; } = new PropertyList();

        public CategoryCollection Categories { get; set; } = new CategoryCollection();
    }
}
