using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using imbSCI.Graph.Graphics.SvgAPI;
using imbSCI.Core.files.folders;
using imbSCI.Graph.Graphics.SvgAPI.BasicShapes;

namespace imbSCI.TestUnit.svg
{
    /// <summary>
    /// Summary description for UnitSVG
    /// </summary>
    [TestClass]
    public class UnitSVG
    {
        public UnitSVG()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        [TestMethod]
        public void TestDocumentTest()
        {

            svgDocument svg = new svgDocument(1000,500);

            folderNode folder = new folderNode().Add("SVG", "SVG tests", "");



            svg.Add(new svgRectangle(10, 10, 50, 50));


            svg.Save(folder, "test", "test1",true);






           
        }
    }
}
