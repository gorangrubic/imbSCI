namespace imbSCI.Core.syntax.code
{
    using System;
    using imbSCI.Core.syntax.codeSyntax;
    using imbSCI.Core.extensions.text;

    public class codeBlock: codeElementBase, ICodeElement
    {
        public codeBlock()
        {
            _children = new codeElementCollection(this, typeof(codeLine), typeof(codeBlock));
        }

        public codeBlock(String __name, syntaxBlockDeclaration __syntax)
        {
            baseSetup(__name, "", __syntax);

            //_name = __name.Trim();
            //_declarationBase = __syntax;

            _children = new codeElementCollection(this, typeof(codeLine), typeof(codeBlock));

           // deployDeclaration();
        }


        public void deployDeclaration(syntaxDeclaration syntax)
        {
            
            foreach (syntaxBlockLineDeclaration ln in declaration.lines)
            {
                switch (ln.render)
                {
                    case syntaxBlockLineType.block:
                        syntaxBlockDeclaration bls = syntax.blocks.find(ln.name);
                        codeBlock cb = new codeBlock(ln.name, bls);
                        children.Add(cb);
                        cb.deployDeclaration(syntax);
                        break;
                    case syntaxBlockLineType.comment:
                    case syntaxBlockLineType.custom:
                    case syntaxBlockLineType.normal:
                        codeLine cl = new codeLine(ln.name, ln);
                        children.Add(cl);
                        cl.deployDeclaration(syntax);
                        break;
                }
               
            }
        }

        public void deployCode(codeSourceElement el, syntaxDeclaration syntax)
        {
            codeSourceElementCollection subElements = new codeSourceElementCollection(el, syntax);
            syntaxBlockDeclaration sb;
            foreach (codeSourceElement subEl in subElements.codeElements)
            {
                if (subEl.lineClass != null)
                {
                    switch (subEl.lineClass.lineType)
                    {
                        case syntaxBlockLineType.normal:
                            codeLine cl = children.getElement<codeLine>(subEl.name);
                            if (cl == null)
                            {

                                syntaxBlockLineDeclaration cld = declaration.lines.Find(x => x.name == subEl.name);
                                cl = new codeLine(subEl.name, cld);
                                children.Add(cl);
                                
                            }
                            cl.deployDeclaration(syntax);
                            cl.deployCode(subEl);
                            break;
                        case syntaxBlockLineType.block:

                            sb = syntax.blocks.find(subEl.name);

                            codeBlock cb = children.getElement<codeBlock>(subEl.name);

                            if (cb == null)
                            {
                                cb = new codeBlock(subEl.name, sb);
                                children.Add(cb);
                                
                            }
                           // cb.deployDeclaration(syntax);
                            cb.deployCode(subEl, syntax);
                            ////// ovde poziva obradu koda


                            break;
                        case syntaxBlockLineType.emptyLine:
                            break;
                        default:
                            break;

                    }
                }
            }
        }


        //public String renderInto(syntaxDeclaration syntax)
        //{

        //    String output = "";
        //    String inner = "";

        //    syntaxBlockDeclaration blockclass = syntax.blocks.find(name);

        //    if (blockclass == null) return output;

        //    syntaxBlockRenderMode mode = blockclass.render;
        //    String tab = "\t".Repeat(level);

        //    switch (mode)
        //    {
        //        case syntaxBlockRenderMode.complete:
        //            tab = "\t".Repeat(level);
        //            break;
        //        case syntaxBlockRenderMode.inner:
        //            tab = "";
        //            break;


        //    }

        //    foreach (ICodeElement cl in children.items)
        //    {
        //        String cls = cl.renderInto(syntax);
        //        if (!string.IsNullOrEmpty(cls))
        //        {
        //            inner = inner + tab + cls;
        //        }
        //    }

        //    switch (mode)
        //    {
        //        case syntaxBlockRenderMode.complete:
        //            output = String.Format(syntax.blockClass.template, new object[] { name, inner });
        //            break;
        //        case syntaxBlockRenderMode.inner:
        //            output = inner;
        //            break;
        //    }


        //    return output;
        //}

        public String render(syntaxDeclaration syntax)
        {
           
            String output = "";
            String inner = "";
            
            syntaxBlockDeclaration blockclass = syntax.blocks.find(name);

            if (blockclass == null) return output;

            syntaxBlockRenderMode mode = blockclass.render;
            String tab = "\t".Repeat(level);

            switch (mode)
            {
                case syntaxBlockRenderMode.complete:
                    tab = "\t".Repeat(level);
                    break;
                case syntaxBlockRenderMode.inner:
                    tab = "";
                    break;


            }
            
            foreach (ICodeElement cl in children.items)
            {
                String cls = cl.render(syntax);
                if (!string.IsNullOrEmpty(cls)) {
                    inner = inner + tab + cls;
                }
            }

            switch (mode)
            {
                case syntaxBlockRenderMode.complete:
                    output = String.Format(syntax.blockClass.template, new object[] { name, inner });
                    break;
                case syntaxBlockRenderMode.inner:
                    output = inner;
                    break;
            }
            

            return output;
        }

        public void buildFrom(ICodeElement input)
        {
            codeBlock cb = null;
            codeBlock cbi = input as codeBlock;
            syntaxBlockDeclaration sb;

            if (input is codeBlock)
            {
                sb = cbi.declaration;

                foreach (var sbl in sb.lines)
                {
                    ICodeElement cli = cbi.children.findElement(sbl.name);
                    ICodeElement cl = this.children.findElement(sbl.name);

                    if (cl == null)
                    {

                    } else 
                    {
                        cl.buildFrom(cli);
                    }
                    /*
                    if (cli != null)
                    {
                        cli.buildFrom()
                        //cli.value = cbi.value;
                    }
                    else if (cli is codeBlock)
                    {
                        {

                        }

                    }*/
                }

            }

        }

        public void build(String __source, syntaxDeclaration syntax)
        {

        }

        ///internal syntaxBlockDeclaration _syntax; // = "";
        /// <summary>
        /// Referenca prema deklaraciji sintakse
        /// </summary>
        public syntaxBlockDeclaration declaration
        {
            get { return declarationBase as syntaxBlockDeclaration; }
        }



    }

}