using System;
using System.IO;
using imbSCI.Core.files.folders;
using imbSCI.Core.style.css;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit.css
{
    [TestClass]
    public class UnitCSS
    {
        [TestMethod]
        public void TestCSSGenerateAndSave()
        {
            folderNode folder = new folderNode().Add("CSS", "CSS document tests", "");


            cssEntryDefinition cssDef = new cssEntryDefinition("body", "fill:#FF6600; stroke:#665500;");

            cssCollection css_doc = new cssCollection();
            css_doc.Set(cssDef);

            css_doc.Save(folder, "css_def.css");
            

        }

        [TestMethod]
        public void TestReadModifySave()
        {
            folderNode folder = new folderNode().Add("CSS", "CSS document tests", "");

            folderNode folderResources = new folderNode().Add("resources", "CSS document tests", "");

            String css = @"body {
    background - color: lightblue;
        }

h1, h2, h3, h4 {
    voice-family: male;
    richness: 80;
    cue-before: url('beep.au');
    fill:#554400;
}


p {
    font-family: verdana;
    font-size: 20px;
    fill:#554400;
}";
            cssCollection css_doc = new cssCollection();
            css_doc.FromString(css, cssCollection.cssEntryPolicy.merge);

          //  Assert.IsTrue(css_doc.Get("h1") != null);


            String p=css_doc.Save(folder, "test");

          //  Assert.IsTrue(File.Exists(p));

            var css_doc2 = cssCollection.LoadFile(folderResources, "conceptual.css", cssCollection.cssEntryPolicy.replace);

            css_doc2.Save(folder, "conceptual.css", "");


            var css_doc3 = cssCollection.LoadFile(folderResources, "site.css", cssCollection.cssEntryPolicy.replace);

            css_doc3.Save(folder, "site.css", "");

        }
    }
}
