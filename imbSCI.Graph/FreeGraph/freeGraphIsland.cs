using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.attributes;
using imbSCI.Core.math;
using imbSCI.DataComplex.special;
using imbSCI.Data.interfaces;
using System.ComponentModel;
using System.Text;
using imbSCI.Data.collection.nested;

namespace imbSCI.Graph.FreeGraph
{

    /// <summary>
    /// Describes one island, detected in a graph
    /// </summary>
    public class freeGraphIsland
    {

        public freeGraphIsland()
        {

        }

        /// <summary>
        /// Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        public void Add(IEnumerable<freeGraphNodeBase> input) {
            foreach (var n in input) {
                nodes.Add(n.name);
            }
        }

        /// <summary>
        /// Name of nodes found in the island
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public List<String> nodes { get; set; } = new List<string>();
    }

}