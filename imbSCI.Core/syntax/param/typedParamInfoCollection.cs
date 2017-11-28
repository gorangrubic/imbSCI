namespace imbSCI.Core.syntax.param
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Skup typedParamInfo deklaracija (bez dodeljenih vrednosti). 
    /// </summary>
    public class typedParamInfoCollection:List<typedParamInfo>, IGetToSetFromString
    {
        public typedParamInfoCollection()
        {
            
        }

        public typedParamInfoCollection(String paramList, typedParamDeclarationType declaration=typedParamDeclarationType.nameDoubleDotType)
        {
            setFromString(paramList, declaration);
        }

        /// <summary>
        /// Makes string declaration of the param;
        /// </summary>
        /// <param name="declaration">Declaration format</param>
        /// <returns></returns>
        public String getToString(typedParamDeclarationType declaration=typedParamDeclarationType.nameDoubleDotType)
        {
            String output = "";
            String separator = declaration.getSeparator();

            foreach (var pr in this)
            {
                output = imbSciStringExtensions.add(output, pr.getToString(declaration), separator); //, (pr != this[Count - 1]));
            }
            return output;
        }


        


        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="declaration"></param>
        /// <returns></returns>
        public void setFromString(String paramList, typedParamDeclarationType declaration=typedParamDeclarationType.nameDoubleDotType)
        {
            String separator = declaration.getSeparator();

            paramList = paramList.Trim();
            if (paramList.Contains(separator))
            {
                var parts = paramList.Split(separator.ToCharArray());
                foreach (var pr in parts)
                {
                    Add(new typedParamInfo(pr.Trim(), declaration));
                }
            } else
            {
                Add(new typedParamInfo(paramList, declaration));
            }
            //return Count - c;
        }
    }
}