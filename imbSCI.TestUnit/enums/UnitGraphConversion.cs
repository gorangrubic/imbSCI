using System;
using imbSCI.Graph.Converters.enumToGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imbSCI.TestUnit.enums
{
    [TestClass]
    public class UnitGraphConversion
    {
        [TestMethod]
        public void TestEnumToDGMLConverter()
        {


            Type enumType = typeof(dat_business);

            Type enumType2 = typeof(tkn_stream);

            enumToDMGLConverter converter = new enumToDMGLConverter();

            var dg = converter.ConvertEnumType(enumType);

            dg.Save("dat_business", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType, false).Save("dat_business_notype", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType2).Save("tkn_stream", Data.enums.getWritableFileMode.overwrite);

            converter.ConvertEnumType(enumType2, false).Save("tkn_stream_notype", Data.enums.getWritableFileMode.overwrite);

        }
    }
}
