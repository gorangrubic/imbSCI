namespace imbSCI.Core.syntax.codeSyntax
{
    using System;
    using System.Linq;

    public class syntaxLineClassDeclarationCollection: syntaxDeclarationElementCollection<syntaxLineClassDeclaration>
    {

        public syntaxLineClassDeclaration this[String __name]
        {
            get
            {
                var cl = this.Find(x => x.name == __name);

                if (cl!=null)
                {
                    return cl;
                } else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns lineclass declaration using classname. If failed, returns first class in the collection.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public syntaxLineClassDeclaration getClass(String className)
        {
            //this.Find(x=>x.name == className)
            foreach (syntaxLineClassDeclaration tmp in this)
            {
                if (tmp.name == className)
                {
                    return tmp;
                }
            }
            return this.First();
        }

        //public void AddLineClass(syntaxBlockLineType __type, String __template, String __tokenQuery)
        //{
        //    String __className = __type.ToString();
        //    syntaxLineClassDeclaration lc = new syntaxLineClassDeclaration(__className, __template, __tokenQuery);
        //    Add(lc);
        //}
    }

}