using System;
using System.IO;
using System.Xml;

using imbSCI.Core.files.folders;
using imbSCI.Data.enums;
using imbSCI.Graph.Converters.enumToGraph;
using imbSCI.Graph.MXGraph;
using imbSCI.Graph.MXGraph.io;
using imbSCI.Graph.MXGraph.utils;
using imbSCI.Graph.MXGraph.view;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit.enums
{
    [TestClass]
    public class UnitGraphConversion
    {
        [TestMethod]
        public void TestEnumToDGMLConverter()
        {


            Type enumType = typeof(dat_business);

            Type enumType2 = typeof(tkn_stream);

            enumToDMGLConverter converter = new enumToDMGLConverter();

            var dg = converter.ConvertEnumType(enumType);

            dg.Save("dat_business", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType, false).Save("dat_business_notype", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType2).Save("tkn_stream", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType2, false).Save("tkn_stream_notype", Data.enums.getWritableFileMode.overwrite);

            folderNode folder = new folderNode();
            folderNode mxFolder = folder.Add("mxGraph", "Draw IO", "Graphs created for Draw.io");

            folder.AttachSubfolders();


        
            mxGraph graph = dg.ConvertToMXGraph();

            mxCodec codec = new mxCodec();
            XmlNode node = codec.Encode(graph.Model);
            string xml1 = mxUtils.GetPrettyXml(node);

            String p = mxFolder.pathFor("mxGraph.xml", getWritableFileMode.newOrExisting, "mxGraph converted from directed graph", true);

            File.WriteAllText(p, xml1);

        }
    }
}
