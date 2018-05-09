using System;
namespace imbSCI.TestUnit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using imbSCI.Data.enums;
    using System.IO;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.data;
    using imbSCI.Core.reporting.render.builders;
    using imbSCI.Graph.Graphics.HeatMap;
    using imbSCI.Core.math.range.matrix;

    [TestClass]
    public class UnitGraphTests
    {
        [TestMethod]
        public void TestHeatMap()
        {
            var map = HeatMapModel.CreateRandom(10, 5, -1, 2);
            HeatMapRender render = new HeatMapRender();

            folderNode folder = new folderNode();

            var heatMapFolder = folder.Add("HeatMap", "Heat map tests", "Folder with files produced during heat map generation test");
            folder.generateReadmeFiles(new aceAuthorNotation());

            render.RenderAndSave(map, heatMapFolder.pathFor("heatmap.svg"));

        }

[TestMethod]
public void TestGrayscaleToMatrix()
{
    HeatMapRender render = new HeatMapRender();

    folderNode folder = new folderNode();
            var heatMapFolder = folder.Add("HeatMap", "Heat map tests", "Folder with files produced during heat map generation test");

            String fl = folder.findFile("testArts01.jpg", SearchOption.AllDirectories);

            
    var map = imbSCI.Core.math.range.matrix.imageToHeatMap.CreateFromImage(fl, 100, new builderForLogBase());

    render.RenderAndSave(map, heatMapFolder.pathFor("testArts01.svg"));
}


[TestMethod]
public void TestProceduralHeatMaps()
{
    HeatMapRender render = new HeatMapRender();

    folderNode folder = new folderNode();
    var heatMapFolder = folder.Add("HeatMap", "Heat map tests", "Folder with files produced during heat map generation test");

    var sineWave = proceduralHeatMapGenerator.PresetSineWave();

    render.RenderAndSave(sineWave.MakeHeatMap(100, 50, 50,10), heatMapFolder.pathFor("sine_wave.svg", getWritableFileMode.overwrite));

    sineWave = proceduralHeatMapGenerator.PresetDoubleSineWave();
    render.RenderAndSave(sineWave.MakeHeatMap(100, 50, 50,50), heatMapFolder.pathFor("sine_double_wave.svg", getWritableFileMode.overwrite));

            
}

    }

}