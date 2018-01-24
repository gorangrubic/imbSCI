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


    [TestClass]
    public class UnitTestForDataTableExtended
    {
        [TestMethod]
        public void TestDataTableTyped()
        {

            folderNode folder = new folderNode();

            folder = folder.Add("TableTest", "DataTableExtended", "Tests with DataTableExtended");


            DataTableTypeExtended<customTableEntry> table = new DataTableTypeExtended<customTableEntry>();

            table.SetDescription("Custom data table extended");

            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry("T2"));
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry("T1"));
            table.AddRow(new customTableEntry());
            table.AddRow(new customTableEntry("T3"));

            table.AddExtra("This is a custom data table used for testing");
            table.AddExtra("Lorem Ipsum BRE");
            table.AddExtra("I tako. Šta rade tvoji?");
            Assert.IsTrue(table.Rows.Count > 0);

            table.GetRowMetaSet().AddUnit(new dataNumericCriterionDynamicStyle<Int32, DataRowInReportTypeEnum>(new Core.math.range.rangeCriteria<int>(10, 60), DataRowInReportTypeEnum.dataHighlightA, "number"));

            var indexC = new dataRowIndexDynamicStyle<DataRowInReportTypeEnum>(DataRowInReportTypeEnum.dataHighlightB, new Int32[] { 2, 8 });
            indexC.indexFromSourceTable = true;

            table.GetRowMetaSet().AddUnit(indexC);

            table.GetRowMetaSet().AddUnit(new dataValueMatchCriterionDynamicStyle<String, DataRowInReportTypeEnum>(new String[] { "T1", "T2" }, DataRowInReportTypeEnum.dataHighlightC, "name"));

            table.GetReportAndSave(folder, new Core.data.aceAuthorNotation(), "customDataTable");

            table.saveObjectToXML(folder.pathFor("customTableXML.xml"));

            String file = folder.findFile("*custom*.*", SearchOption.AllDirectories);

            Assert.IsTrue(File.Exists(file));

            file = folder.findFile("customTableXML*.*", SearchOption.AllDirectories);

            Assert.IsTrue(File.Exists(file));


            DataTableTypeExtended<customTableEntry> table2 = objectSerialization.loadObjectFromXML<DataTableTypeExtended<customTableEntry>>(file);

            Assert.IsNotNull(table2);

            Assert.IsTrue(table2.Rows.Count > 0);


            folder.generateReadmeFiles(new Core.data.aceAuthorNotation());

            //  Assert.IsTrue(table2.GetDescription() == table.GetDescription());


            //Assert.IsTrue(readmeFiles.Count > 5);

        }

    }

}