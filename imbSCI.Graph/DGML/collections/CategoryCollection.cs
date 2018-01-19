using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Graph.DGML.core;
using System.Text;

namespace imbSCI.Graph.DGML.collections
{

    public class CategoryCollection : List<Category>
    {
        public CategoryCollection()
        {

        }


        /// <summary>
        /// Gets the <see cref="Category"/> with the specified identifier.
        /// </summary>
        /// <value>
        /// The <see cref="Category"/>.
        /// </value>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Category this[String id]
        {
            get
            {
                return this.FirstOrDefault(x => x.Id == id);
            }
        }

        public void AddUnique(Category cat)
        {
            if (!this.Any(x => (x.Id == cat.Id)))
            {
                Add(cat);
            } else
            {

            }
        }

        /// <summary>
        /// Adds the or get category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="basedOn">The based on.</param>
        /// <returns></returns>
        public Category AddOrGetCategory(Int32 id, String label, String basedOn)
        {
            String sid = id.ToString();
            if (!this.Any(x => x.Id == sid))
            {
                Category cat = new Category(id, label, basedOn);
                AddUnique(cat);
                return cat;
            }
            return this[sid];
        }

        public Category AddOrGetCategory(String sid, String label, String basedOn)
        {
            
            if (!this.Any(x => x.Id == sid))
            {
                Category cat = new Category(label, basedOn);
                cat.Id = sid;
                AddUnique(cat);
                return cat;
            }
            return this[sid];
        }

      
    }

}