using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.TestUnit
{
using Microsoft.VisualStudio.TestTools.UnitTesting;
    using imbSCI.Core;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.appends;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.data;
    using imbSCI.Reporting.script;

    [TestClass]
    public class UnitTestForSCICore
    {
        [TestMethod]
        public void TextObjectForSettings()
        {

            Type t = typeof(docScript);

            settingsEntriesForObject sEO = new settingsEntriesForObject(t, false);

            Assert.IsTrue(sEO.pis.Any());


            //docScript ds = new docScript("testScript");

            //sEO = new settingsEntriesForObject(ds, false, false);

            //Assert.IsTrue(sEO.pis.Any());


            //sEO = new settingsEntriesForObject(ds, true, true);

            //Assert.IsTrue(sEO.pis.Any());

        }



        [TestMethod]
        public void TestCollectTypes()
        {

            Type t = typeof(imbSCI.Data.enums.appends.appendLinkType);

            List<Type> testOneResult = new List<Type>();
            testOneResult.AddRange(new Type[] { typeof(appendLinkType), typeof(appendOpenTag), typeof(appendRelativeLinkType), typeof(appendTableBorderFlags), typeof(appendTableOptionFlags) });


            var testTwoResult = new List<Type>();
            testTwoResult.AddRange(testOneResult);
            testTwoResult.Add(typeof(typedParamDeclarationType));
            testTwoResult.Add(typeof(exportFormats));

            var testOneDict = testOneResult.TypeListToDictionary();
            var testTwoDict = testTwoResult.TypeListToDictionary();

            var sameNamespace = t.CollectTypes(CollectTypeFlags.includeEnumTypes | CollectTypeFlags.ofSameNamespace | CollectTypeFlags.ofThisAssembly);

            Boolean hasAll = true;

            foreach (String key in testOneDict.Keys)
            {
                if (!sameNamespace.ContainsKey(key))
                {
                    hasAll = false;
                    break;
                }
            }

            Assert.AreEqual(hasAll, true);


            var parentNamespace = t.CollectTypes(CollectTypeFlags.includeEnumTypes | CollectTypeFlags.ofParentNamespace | CollectTypeFlags.ofThisAssembly);

            hasAll = true;

            foreach (String key in testTwoDict.Keys)
            {
                if (!parentNamespace.ContainsKey(key))
                {
                    hasAll = false;
                    break;
                }
            }

            Assert.AreEqual(hasAll, true);

            Type ct = typeof(modelDataSet);

            var classTypes = ct.CollectTypes(CollectTypeFlags.includeClassTypes | CollectTypeFlags.ofChildNamespaces | CollectTypeFlags.ofThisAssembly);

            Assert.AreEqual(classTypes.Any(), true);



        }
    }

}