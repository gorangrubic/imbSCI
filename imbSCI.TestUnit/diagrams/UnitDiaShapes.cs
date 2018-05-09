using System;
using imbSCI.Core.files.folders;
using imbSCI.Graph.DiagramLibraries.DiaShape;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit.diagrams
{
    [TestClass]
    public class UnitDiaShapes
    {
        [TestMethod]
        public void TestDiaShape()
        {

            folderNode folder = new folderNode().Add("resources", "TestResources", "").Add("flowchart", "Flowchart", "Dia shapes and sheet");

            folderNode folderOutput = new folderNode().Add("diagrams", "Diagram test output", "Directory with results of diagram tests");

            diaShape shapeOne = new diaShape("Test", "test.png"); // = diaShape.Load(folder.findFile("preparation.shape"));

            shapeOne.AddConnection(0, 0, true);

            shapeOne.Save(folderOutput, "test", "generation test");


            // shape

            diaShape shape = diaShape.Load(folder.findFile("preparation.shape"));


            shape.Save(folderOutput, "preparation", "Load, save test");


            var svg = shape.GetSVG();
            svg.re

        }

        [TestMethod]
        public void TestDiaSheet()
        {
            folderNode folder = new folderNode().Add("resources", "TestResources", "").Add("flowchart", "Flowchart", "Dia shapes and sheet");

            folderNode folderOutput = new folderNode().Add("diagrams", "Diagram test output", "Directory with results of diagram tests");


            var sheet = diaSheet.Load(folder.findFile("Flowchart.sheet"));


            sheet.Save(folderOutput, "Flowchart", "Load-Save test");
        }
    }
}
