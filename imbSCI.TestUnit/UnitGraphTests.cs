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
    using imbSCI.Graph.Graphics;
    using imbSCI.Graph.Graphics.HeatMap;

    [TestClass]
    public class UnitGraphTests
    {
        [TestMethod]
        public void TestHeatMap()
        {
            var map = HeatMapModel.CreateRandom(10, 5, -1, 2);
            HeatMapRender render = new HeatMapRender();

            folderNode folder = new folderNode();

            var heatMapFolder = folder.Add("HeatMap", "Test one", "Some description: ");
            folder.generateReadmeFiles(new aceAuthorNotation());

            render.RenderAndSave(map, heatMapFolder.pathFor("heatmap.svg"));

        }

    }

}