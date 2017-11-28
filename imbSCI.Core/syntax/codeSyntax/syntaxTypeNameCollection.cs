namespace imbSCI.Core.syntax.codeSyntax
{
    using imbSCI.Core.extensions.typeworks;
    using System;
    using System.Collections.Generic;

    public class syntaxTypeNameCollection:List<syntaxTypeName>
    {

        public Type getType(String name)
        {
            String tname = name;
            syntaxTypeName stn = this.Find(x => x.name == tname);
            if (stn != null)
            {
                tname = stn.fullname;
            }
            return tname.getTypeFromName();


        }

        public void AddType(String __name, String __fullname)
        {
            syntaxTypeName tmp = new syntaxTypeName(__name, __fullname);
            Add(tmp);
        }
    }
}