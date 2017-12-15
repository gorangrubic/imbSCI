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


    [TestClass]
    public class UnitTestForFileDataStructure
    {

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

            Assert.IsTrue((dStruct.table.Any()));

            var dEntry = dStruct.table.GetOrCreate("testEntry");

            Assert.IsNotNull(dEntry);


        }

    }

}