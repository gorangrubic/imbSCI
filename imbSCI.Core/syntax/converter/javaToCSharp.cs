using imbSCI.Core.files.folders;
using imbSCI.Core.syntax.converter.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.syntax.converter
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Core.syntax.converter.core.conversionRuleSet" />
    public class javaToCSharp:conversionRuleSet
    {
        public javaToCSharp(folderNode _in, folderNode _out) : base(_in, _out)
        {
            Add().SetStart("/**", "/// <summary>").trim = true;
            Add().SetStart("/* ", "/// <summary>").trim = true;
            Add().SetStart("* ", "/// ").trim = true; 
            Add().SetStart("*/", "/// </summary>").trim = true;
            Add().SetReplace("import ", "using ");
            Add().SetReplace(" int ", " Int32 ");
            Add().SetReplace(" extends ", " : ");

            inputExtension = ".java";
            outputExtension = ".cs";
        }


    }
}
