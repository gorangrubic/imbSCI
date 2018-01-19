using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Graph.DGML.core;
using System.Text;

namespace imbSCI.Graph.DGML.collections
{

    public class PropertyList:List<Property>
    {
        public PropertyList()
        {

        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="label">The label.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public Property AddProperty(String propertyName, String label, Type type)
        {
            if (!this.Any(x=>x.Id==propertyName))
            {
                Property p = new Property(propertyName, label, type);
                Add(p);
                return p;
            }
            return this.FirstOrDefault(x => x.Id == propertyName);
        }
    }

}