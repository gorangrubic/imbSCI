using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data.collection.special;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.data;
using imbSCI.Graph.DGML;
using imbSCI.Graph.DGML.collections;
using imbSCI.Graph.DGML.core;
using System.Drawing;
using System.Text;
using imbSCI.Core.reporting.colors;
using imbSCI.Graph.Converters.tools;
using imbSCI.Data.collection.graph;
using imbSCI.Data;
using imbSCI.Core.math;
using imbSCI.Graph.FreeGraph;
using imbSCI.Data.interfaces;
using System.Web.UI.WebControls;

namespace imbSCI.Graph.Converters
{

    /// <summary>
    /// Common foundation of graph converters
    /// </summary>
    /// <typeparam name="TGraphFrom">The type of the graph from.</typeparam>
    /// <typeparam name="TGraphTo">The type of the graph to.</typeparam>
    public abstract class graphToGraphConverterBase<TGraphFrom, TGraphTo> where TGraphFrom:IObjectWithName
        where TGraphTo:IObjectWithName
    {
        /// <summary>
        /// Gets the node weight - by default implementation it is 1 / <see cref="IGraphNode.level"/>
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public abstract Double GetNodeWeight(TGraphFrom node);



        /// <summary>
        /// Provides the link weight, by default implementation returns 1 / <see cref="IGraphNode.Count"/>
        /// </summary>
        /// <param name="nodeA">The node a.</param>
        /// <param name="nodeB">The node b.</param>
        /// <returns></returns>
        public abstract Double GetLinkWeight(TGraphFrom nodeA, TGraphFrom nodeB);
        
        /// <summary>
        /// Gets the label for link - by default implementation returns empty string
        /// </summary>
        /// <param name="nodeA">The node a.</param>
        /// <param name="nodeB">The node b.</param>
        /// <returns></returns>
        public virtual String GetLinkLabel(TGraphFrom nodeA, TGraphFrom nodeB)
        {
            String output = "";
            if (nodeA == null)
            {
                output = "[a:null]";
            }
            if (nodeB == null)
            {
                output += "[b:null]";
            }
            return output;
        }

        /// <summary>
        /// Provides display Label for specified node, in default implementation returns <see cref="IGraphNode.name"/>
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public virtual String GetNodeName(TGraphFrom node)
        {
            if (node == null)
            {
                return "[null]";
            }
            return node.name;
        }

        public abstract TGraphTo Convert(TGraphFrom source, Int32 depthLimit = 500);

    }

}