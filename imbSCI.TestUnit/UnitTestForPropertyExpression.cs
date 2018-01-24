using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.TestUnit
{
using Microsoft.VisualStudio.TestTools.UnitTesting;
    using imbSCI.Core;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.appends;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.data;
    using imbSCI.DataComplex.extensions.data.modify;
    using imbSCI.DataComplex.extensions.data.schema;
    using imbSCI.DataComplex.tables.extensions;
    using imbSCI.TestUnit.testObjects;
    using imbSCI.Core.files.fileDataStructure;
    using System.IO;
    using imbSCI.Core.files.folders;
    using imbSCI.DataComplex.tables;
    using imbSCI.Core.extensions.table;
    using imbSCI.Core.files;
    using imbSCI.Core.data;
    using imbSCI.Graph.Converters;
    using imbSCI.Graph.config;
    using imbSCI.Graph.FreeGraph;

    [TestClass]
    public class UnitTestForPropertyExpression
    {
        [TestMethod]
        public void TestPropertyExpressionFunctions()
        {
            folderNode folder = new folderNode();
            var DMGLFolder = folder.Add("DirectedGraphs", "Folder with directed graph tests", "Some description: ");

            var settings = new imbSCIGraphConversionConfig();

            var obj = new imbSCIGraphConversionConfig();

            PropertyExpression pe = new PropertyExpression(obj, "config",10, false, true);

            Assert.IsTrue(pe.Count() > 0);
            freeGraph fg = pe.ConvertToFreeGraph(50);

            var pe2 = obj.GetExpressionResolved("DefaultGraphExportStyle.LinkWeightFormat");
            //

            pe2.setValue("L5");

            //pe2.Expand(50, false, true);

            pe2.parentExpression.ConvertToDGML().Save(DMGLFolder.pathFor("propertyExpression2Test", getWritableFileMode.overwrite, "Testing property expression tree expansion"));

            fg.Save(DMGLFolder.pathFor("freeGraphOfPropertyExpression.xml", getWritableFileMode.none, "XML export of the graph"), getWritableFileMode.overwrite);

            var dmgl = pe.ConvertToDGML(50);
            dmgl.Save(DMGLFolder.pathFor("propertyExpressionTest", getWritableFileMode.overwrite, "Testing property expression tree expansion"));

            var dmgl2 = fg.ConvertToDGML();
            dmgl2.Save(DMGLFolder.pathFor("propertyExpressionTestViaFreeGraph", getWritableFileMode.overwrite, "Testing property expression tree expansion"));


            Assert.IsTrue(dmgl.Nodes.Count > 0);
            Assert.IsTrue(dmgl.Links.Count > 0);
            Assert.IsTrue(pe2.state == PropertyExpressionStateEnum.resolvedAll);
            DMGLFolder.generateReadmeFiles(new aceAuthorNotation());

        } 


    }

}