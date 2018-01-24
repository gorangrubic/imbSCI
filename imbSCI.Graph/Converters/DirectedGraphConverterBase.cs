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
using Accord;

namespace imbSCI.Graph.Converters
{

    /// <summary>
    /// Foundation for DirectedGraph converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="imbSCI.Graph.Converters.graphToGraphConverterBase{T, imbSCI.Graph.DGML.DirectedGraph}" />
    public abstract class DirectedGraphConverterBase<T> : graphToGraphConverterBase<T, DirectedGraph> where T : IObjectWithName
    {

        protected void Deploy(GraphStylerSettings settings = null)
        {
            setup = settings;
            if (setup == null)
            {
                setup = imbSCI.Graph.config.imbSCIGraphConversionConfig.settings.DefaultGraphExportStyle;
            }
        }

        public GraphStylerSettings setup { get; set; } 


        public abstract DirectedGraphStylingCase GetStylingCase(IEnumerable<T> source);

        public abstract String GetCategoryID(T nodeOrLink);

        public abstract Int32 GetTypeID(T nodeOrLink);

        ///// <summary>
        ///// Gets the node weight - by default implementation it is 1 / <see cref="IGraphNode.level"/>
        ///// </summary>
        ///// <param name="node">The node.</param>
        ///// <returns></returns>
        //public abstract Double GetNodeWeight(T node);


        ///// <summary>
        ///// Gets the link weight.
        ///// </summary>
        ///// <param name="nodeA">The node a.</param>
        ///// <param name="nodeB">The node b.</param>
        ///// <returns></returns>
        //public abstract Double GetLinkWeight(T nodeA, T nodeB);

        /// <summary>
        /// Gets the node label.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public virtual String GetNodeLabel(T node)
        {
            return GetNodeName(node);
        }

        /// <summary>
        /// Gets the node identifier.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public abstract String GetNodeID(T node);

        

        /// <summary>
        /// Gets a new <see cref="Link"/>
        /// </summary>
        /// <param name="nodeA">The node a.</param>
        /// <param name="nodeB">The node b.</param>
        /// <returns></returns>
        public Link GetLink(T nodeA, T nodeB)
        {
            Link output = new Link();
            output.Source = GetNodeID(nodeA);
            output.Target = GetNodeID(nodeB);
            output.Label = GetLinkLabel(nodeA, nodeB);
            return output;
        }
        
        
    }

}