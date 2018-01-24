using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit
{
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
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core.files.fileDataStructure;
    using System.IO;
    using imbSCI.Core.files.folders;
    using imbSCI.DataComplex.tables;
    using imbSCI.Core.extensions.table;
    using imbSCI.Core.files;
    using imbSCI.Core.data;
    using imbSCI.Graph.Converters;

    [TestClass]
    public class UnitTestForSCIData
    {



        [TestMethod]
        public void TestFolderStructure()
        {

            folderNode folder = new folderNode();

            var t11 = folder.Add("Test1", "Test one", "Some description: ").Add("Test1_1", "Test 1.1", "");
            t11.AdditionalDescriptionLines.Add("line 1");
            t11.AdditionalDescriptionLines.Add("line 2");
            folder.Add("Test2", "Test two", "Some description: ");
            folder.Add("Test3", "Test three", "Some description: ").Add("Test3_1", "Test 3.1", "");

            t11.pathFor("justSomeFake.xml");
            t11.pathFor("justSomeFakeWithDesc.xml", getWritableFileMode.none, "Some fake description");
            List<folderNode> chld = folder.getAllChildrenInType<folderNode>();

            Assert.IsTrue(chld.Any());

            folder.generateReadmeFiles(new Core.data.aceAuthorNotation());

            var readmeFiles = folder.findFiles("directory*.*", SearchOption.AllDirectories);

            Assert.IsTrue(readmeFiles.Count>5);

        }
    }

}
