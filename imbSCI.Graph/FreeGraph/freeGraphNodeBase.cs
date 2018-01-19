using imbSCI.Core.extensions.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    public class freeGraphNodeBase
    {
        public freeGraphNodeBase()
        {

        }

        /// <summary>
        /// Just clones the node and adds specified distance 
        /// </summary>
        /// <param name="distanceIncrease">The distance increase.</param>
        /// <returns></returns>
        public freeGraphNodeBase GetQueryResultClone(Int32 distanceIncrease = 1)
        {
            freeGraphNodeBase node = new freeGraphNodeBase();
            node.name = name;
            node.weight = weight;
            node.type = type;
            node.distance = distance + distanceIncrease;
            return node;
        }

        public String name { get; set; }

        public Double weight { get; set; } = 1;

        public Int32 type { get; set; } = 0;

        /// <summary>
        /// Distance from query node/s, only relevant when it is query result
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        [XmlIgnore]
        public Double distance { get; set; } = 1;
    }

}