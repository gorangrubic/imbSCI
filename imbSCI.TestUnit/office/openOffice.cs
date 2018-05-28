using System;
using imbSCI.Core.files.folders;
using imbSCI.Core.reporting.render.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit.office
{
    [TestClass]
    public class openOffice
    {
        [TestMethod]
        public void openTestMethod()
        {


            folderNode folder = new folderNode().Add("OpenOffice", "Open office", "Experiments with open document format");

            builderForODT builder = new builderForODT();

            builder.AppendHeading("Test document", 0);

            builder.AppendParagraph("This is some textual content");

            builder.textDocument.SaveTo(folder.pathFor("test.odt", Data.enums.getWritableFileMode.newOrExisting, "Test open office document"));

        }
    }
}
