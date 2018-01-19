using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using imbSCI.Data;
using imbSCI.Core.extensions.text;
using System.Xml.Serialization;

namespace imbSCI.Graph.DGML.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        public Property()
        {

        }

        public Property(String propertyName, String label, Type type)
        {
            Id = propertyName;
            Label = label;
            DataType = type.FullName;
        } 

        /// <summary>
        /// Creates new property [Experimental]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="_label">The label.</param>
        /// <returns></returns>
        public Property MakeProperty<T>(T value, String _label)
        {
            var tmp = new Property();
            tmp.Id = _label.getValidFileName();
            tmp.Label = _label;
            tmp.DataType = typeof(T).FullName;
            tmp.Value = value;
            return tmp;
        }

        public String Id { get; set; } = "";

        public String Label { get; set; } = "";

        public String DataType { get; set; } = "";

        public Boolean IsReference { get; set; } = false;

        [XmlIgnore]
        public Object Value { get; set; }
    }
}
