namespace imbSCI.Core.syntax.param
{
    using System;
    using imbSCI.Data.enums;

    public static class typedParamInfoExtensions
    {
        public static String getSeparator(this typedParamDeclarationType declaration)
        {
            String separator = Environment.NewLine;

            switch (declaration)
            {
                case typedParamDeclarationType.nameDoubleDotType:
                    separator = ";";

                    ////parts = input.Split(':');
                    //output = name.add(tName, ":");
                    //if (addCollectionSufix) output += ";";
                    break;
            }

            return separator;
        }
    }
}