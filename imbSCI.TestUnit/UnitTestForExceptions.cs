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


    [TestClass]
    public class UnitTestForExceptions
    {
        [TestMethod]
        public void TestException()
        {
            folderNode folder = new folderNode();
            folder = folder.Add("ExceptionTest", "Exception", "Testing exception");

            folder.generateReadmeFiles(new aceAuthorNotation());

            Dictionary<String, String> dict = new Dictionary<string, string>();


            try
            {
                dict["nesto"] = "tamo";

                Console.WriteLine(dict["ta"]);

            }
            catch (Exception ex)
            {
                String msg = ex.LogException("test", ">>");
                File.WriteAllText(folder.pathFor("ex.txt", getWritableFileMode.overwrite, "test"), msg);
            }




        }

    }

}