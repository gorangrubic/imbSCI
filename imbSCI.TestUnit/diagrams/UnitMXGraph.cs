
using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.Data.enums;
using imbSCI.Graph.Converters;
using imbSCI.Graph.MXGraph;
using imbSCI.Graph.MXGraph.io;
using imbSCI.Graph.MXGraph.utils;
using imbSCI.Graph.MXGraph.view;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace imbSCI.TestUnit.diagrams
{
    [TestClass]
    public class UnitMXGraph
    {

        [TestMethod]
        public void TestMXGraphConversions()
        {

            folderNode folder = new folderNode();
            folderNode mxFolder = folder.Add("mxGraph", "Draw IO", "Graphs created for Draw.io");

            folder.AttachSubfolders();


            var dgml = folder.GetDirectedGraph(true, true, true);
            dgml.Save(mxFolder.pathFor("folderStructure.dgml", getWritableFileMode.overwrite, "DGML of folder"));

            mxGraph graph = dgml.ConvertToMXGraph();

            mxCodec codec = new mxCodec();
            XmlNode node = codec.Encode(graph.Model);
            string xml1 = mxUtils.GetPrettyXml(node);

            String p = mxFolder.pathFor("converted.xml", getWritableFileMode.newOrExisting, "mxGraph converted from directed graph", true);

            File.WriteAllText(p, xml1);

            


        }
        
    }
}
