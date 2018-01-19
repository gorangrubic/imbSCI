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
    using imbSCI.TestUnit.testObjects;
    using imbSCI.Core.files.fileDataStructure;
    using System.IO;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.reporting.render.builders;

    [TestClass]
    public class UnitTestForFileDataStructure
    {
        [TestMethod]
        public void TestFileDataStructureLoadSave()
        {
            folderNode folder = new folderNode();

            customFileDataStructure cStruct = new customFileDataStructure();
            cStruct.name = "test3";
            cStruct.description = "BANANA";

            String whereItWasSaved = cStruct.SaveDataStructure<customFileDataStructure>();
            Assert.IsTrue(whereItWasSaved.Contains("test3"));

            cStruct.setup();

            cStruct.name = "text2";

            Assert.AreEqual(cStruct.name, "text2");

            builderForLogBase logger = new builderForLogBase();

            cStruct.Save(logger);

            Assert.AreEqual(cStruct.name, "text2");

            String whereItWasSaved2 = cStruct.SaveDataStructure<customFileDataStructure>();

            Assert.IsTrue(whereItWasSaved2.Contains("text2"));

            customFileDataStructure eStruct = cStruct.name.LoadDataStructure<customFileDataStructure>(folder);

            Assert.AreEqual(cStruct.dataObjects.Count, eStruct.dataObjects.Count);

        }

        [TestMethod]
        public void TestFileDataStructure()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());

            

            folderNode folder = di;

            customFileDataStructure cStruct = new customFileDataStructure();
            

            var cEntry = new customTableEntry();
            cEntry.name = "testEntry";


            cStruct.table.Add(cEntry);

            String path = cStruct.SaveDataStructure(folder);

            Console.WriteLine(path);


            customFileDataStructure dStruct = null;

            dStruct = cStruct.name.LoadDataStructure<customFileDataStructure>(di);


            Assert.IsNotNull(dStruct);

            Assert.IsNotNull(dStruct.table);

           

            //Assert.IsTrue((dStruct.table.Any()));

            //var dEntry = dStruct.table.GetOrCreate("testEntry");

            //Assert.IsNotNull(dEntry);


        }

    }

}