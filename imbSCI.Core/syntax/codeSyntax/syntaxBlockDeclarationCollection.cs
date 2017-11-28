namespace imbSCI.Core.syntax.codeSyntax
{
    using System;
    using System.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Collection of block declaration
    /// </summary>
    public class syntaxBlockDeclarationCollection: syntaxDeclarationElementCollection<syntaxBlockDeclaration>
    {


        //public syntaxBlockDeclaration find(String nameOrAlias)
        //{
        //    syntaxBlockDeclaration output = null;

        //    output = this.Find(x => x.name == nameOrAlias);
        //    if (output == null)
        //    {
        //        output = this.Find(x => x.aliasList.Contains(nameOrAlias));
        //    }

        //    return output;
        //}

        /// <summary>
        /// Creates new block inside collection - role: supported -- adds aliases
        /// </summary>
        /// <param name="__alias"></param>
        /// <returns>Reference to newly created block declaration</returns>
        public syntaxBlockDeclaration addNewBlock(params String[] __alias)
        {
            if (!__alias.Any()) return null;


            var blk = new syntaxBlockDeclaration();

            


            blk.setAlias(__alias);
            //blk.name = __alias.First();

            //foreach (var al in __alias)
            //{
            //    if (al != blk.name)
            //    {
            //        blk.aliasList.Add(al);
            //    }
            //}

            blk.role = syntaxBlockRole.supported;
            blk.render = syntaxBlockRenderMode.complete;
            Add(blk);
            _current = blk;
            return blk;
        }


        /// <summary>
        /// Declares new block for "supported" role and assignes it with an array of alias names
        /// </summary>
        /// <param name="__alias">Alias names separated by |. Like> hit|grid|circle</param>
        /// <returns>Reference to newly created block declaration</returns>
        public syntaxBlockDeclaration addNewBlockWithAlias(String __alias)
        {
            if (__alias.Contains("|"))
            {

                var _al = __alias.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var blk = new syntaxBlockDeclaration();

                blk.setAlias(_al);

                blk.role = syntaxBlockRole.supported;
                blk.render = syntaxBlockRenderMode.complete;
                Add(blk);
                _current = blk;
                return blk;
                //  var blk = new syntaxBlockDeclaration();
                //blk.name = _al.First();
            } else
            {
                
            }
            return null;
        }


        /// <summary>
        /// Instancira nov permanentni blok
        /// </summary>
        /// <param name="__name">Ime bloka</param>
        /// <param name="__render">Vid prikaza</param>
        /// <returns>Reference to newly created block declaration</returns>
        public syntaxBlockDeclaration addNewBlock(String __name, syntaxBlockRenderMode __render)
        {
            var blk = new syntaxBlockDeclaration();
            blk.name = __name;
            blk.role = syntaxBlockRole.permanent;
            blk.render = __render;

            Add(blk);
            _current = blk;
            return blk;
        }

        private syntaxBlockDeclaration _current; // = "";
        [XmlIgnore]
                                                 /// <summary>
                                                 /// Trenutno selektovan blok
                                                 /// </summary>
        public syntaxBlockDeclaration current
        {
            get { return _current; }
        }


        public syntaxBlockDeclarationCollection()
        {

        }
    }

}