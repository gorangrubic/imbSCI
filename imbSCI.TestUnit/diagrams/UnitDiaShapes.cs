using System;
using imbSCI.Core.files.folders;
using imbSCI.Graph.DiagramLibraries.DiaShape;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Svg;

namespace imbSCI.TestUnit.diagrams
{
    [TestClass]
    public class UnitDiaShapes
    {

[TestMethod]
public void TestDiaToolkit()
{
    folderNode folder = new folderNode().Add("resources", "TestResources", "").Add("new_shapes", "Shape folder", "New shapes for Dia");

    folderNode folderOutput = new folderNode().Add("diagrams", "Diagram test output", "Directory with results of diagram tests").Add("new_shapes", "Toolkit test", "Shapes and sheet definition");

    diaToolKit toolkit = new diaToolKit(folder, folderOutput);

    toolkit.ConstructSheetAndIcons(diaToolKit.diaToolKitOperationEnum.exportIcon | diaToolKit.diaToolKitOperationEnum.exportSheetFile | diaToolKit.diaToolKitOperationEnum.exportSVG | diaToolKit.diaToolKitOperationEnum.sheetNameFromFolder | diaToolKit.diaToolKitOperationEnum.copyShapes | diaToolKit.diaToolKitOperationEnum.exportBigIcon | diaToolKit.diaToolKitOperationEnum.generateOverviewPNG | diaToolKit.diaToolKitOperationEnum.generateOverviewSVG);
}

[TestMethod]
public void TestDiaShape()
{

folderNode folder = new folderNode().Add("resources", "TestResources", "").Add("flowchart", "Flowchart", "Dia shapes and sheet");

folderNode folderOutput = new folderNode().Add("diagrams", "Diagram test output", "Directory with results of diagram tests");

diaShape shapeOne = new diaShape("Test", "test.png"); // = diaShape.Load(folder.findFile("preparation.shape"));

shapeOne.AddConnection(0, 0, true);

shapeOne.Save(folderOutput, "test", "generation test");


            
// Loads original shape definition
diaShape shape = diaShape.Load(folder.findFile("preparation.shape"));

// Saves shape definition
shape.Save(folderOutput, "preparation", "Load, save test");

// Exports SVG with default style
shape.SaveSVG(folderOutput);

// Renders icon .png file with default size (22px)
shape.RenderIcon(folderOutput);

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
