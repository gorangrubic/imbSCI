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
    using System.Collections.Generic;

    [TestClass]
    public class UnitTestForSCIData
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    

    [TestClass]
    public class UnitTestForSCICode
    {
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



        }
    }
}
