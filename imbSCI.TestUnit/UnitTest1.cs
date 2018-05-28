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
    using imbSCI.Core.syntax.converter;

    [TestClass]
    public class UnitCodeConversionTest
    {


        [TestMethod]
        public void UnitTestMethod()
        {

            javaToCSharp conv = new javaToCSharp(new DirectoryInfo(@"G:\imbVelesOpenSourceForks\mxgraph-master\java\src\com\mxgraph\layout"), new folderNode().Add("SourceCode", "Java conversion", "Converted"));
            conv.process();
        }

    }
}
