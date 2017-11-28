namespace imbSCI.Core.syntax.codeSyntax
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Declaration element - any 
    /// </summary>
    public interface ISyntaxDeclarationElement
    {
        String name { get; set; }

        //List<String> aliasList { get; }

        Boolean isNameOrAlias(String nameOrAlias);

        void setAlias(IEnumerable<String> __alias);

        void setAlias(String __alias);
    }

}