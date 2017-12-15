using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.extensions.typeworks
{
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Data;
    using System.Reflection;
    using System.Text;


    [Flags]
    public enum CollectTypeFlags
    {
        none = 0,



        

        includeEnumTypes = 1 << 2,

        includeClassTypes = 1 << 3,

        //includeStrcutTypes = 1 << 4,

        includeValueTypes = 1 << 5,

        includeGenericTypes = 1 << 6,

        includeAll = includeEnumTypes | includeClassTypes | includeValueTypes | includeGenericTypes,


        ofSameNamespace = 1 << 10,

        ofChildNamespaces = 1 << 11,

        ofParentNamespace = 1 <<12,



        ofThisAssembly = 1 << 21,

        ofAllAssemblies = 1 << 22,

        
    }

}