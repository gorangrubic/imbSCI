namespace imbSCI.Core.syntax.code
{
    using System;
    using imbSCI.Core.syntax.codeSyntax;

    public interface ICodeElement
    {
        String name { get; }
        String source { get; }



        String render(syntaxDeclaration syntax);

       // String renderInto(syntaxDeclaration syntax);

        Int32 level { get; }

        ICodeElement parent
        {
            get;
        }
        ICodeElement root
        {
            get;
        }

        ICodeElement this[Int32 __index]
        {
            get;
        }

        ICodeElement this[String __name]
        {
            get;
           
        }


        void buildFrom(ICodeElement input);


        Object value
        {
            get;
            set;
        }





        Int32 index
        {
            get;
        }
        ISyntaxDeclarationElement declarationBase { get; }

       // Object objectValue { get; set; }
        codeElementCollection children
        {
            get;
        }
    }

}