using System;
using System.Linq;
using System.Collections.Generic;
// using imbNLP.PartOfSpeech.TFModels.semanticCloud.core;
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
    /// Basic <see cref="IGraphNode"/> to <see cref="freeGraph"/> converter
    /// </summary>
    /// <typeparam name="T">Base type of <see cref="IGraphNode"/> this converter interprets</typeparam>
    public class graphToFreeGraphConverterBasic<T>:graphToGraphConverterBase<T, freeGraph> where T: IGraphNode
    {
        /// <summary>
        /// Gets the type of the node - by default implementation returns <see cref="IGraphNode.level"/>
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public virtual Int32 GetNodeType(T node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.level;
        }

        /// <summary>
        /// Gets the node weight - by default implementation it is 1 / <see cref="IGraphNode.level"/>
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public override Double GetNodeWeight(T node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1.GetRatio(node.level);
        }

        

        /// <summary>
        /// Provides the link weight, by default implementation returns 1 / <see cref="IGraphNode.Count"/>
        /// </summary>
        /// <param name="nodeA">The node a.</param>
        /// <param name="nodeB">The node b.</param>
        /// <returns></returns>
        public override Double GetLinkWeight(T nodeA, T nodeB)
        {
            if (nodeA == null)
            {
                return 0;
            }
            return 1.GetRatio(nodeA.Count());
        }

        /// <summary>
        /// Provides type of link between nodeA and nodeB
        /// </summary>
        /// <param name="nodeA">The node a.</param>
        /// <param name="nodeB">The node b.</param>
        /// <returns></returns>
        public virtual Int32 GetLinkType(T nodeA, T nodeB)
        {
            if (nodeA == null)
            {
                return -1;
            }
            return 0;
        }

     
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="depthLimit">The depth limit.</param>
        /// <returns></returns>
        public override freeGraph Convert(T source, Int32 depthLimit=500)
        {
            freeGraph output = new freeGraph();
            output.DisableCheck = true;
            output.name = source.name;
            output.description = "FreeGraph built from " + source.GetType().Name + ":GraphNodeBase graph";
                        
            var nodes = source.getAllChildren(null, false, false, 1, depthLimit, true);

            Dictionary<T, freeGraphNodeBase> nodeDict = new Dictionary<T, freeGraphNodeBase>();

            foreach (var ch in nodes)
            {
                T child = (T)ch;
                var node = output.AddNewNode(GetNodeName(child), GetNodeWeight(child), GetNodeType(child));
                nodeDict.Add(child, node);
            }

            foreach (var ch in nodes)
            {
                if (ch.parent != null)
                {
                    T parent = (T)ch.parent;
                    T child = (T)ch;
                    if ((parent != null) && (child != null))
                    {
                        freeGraphNodeBase gParent = nodeDict[parent];
                        freeGraphNodeBase gChild = nodeDict[child];
                        var lnk = output.AddLink(gParent.name, gChild.name, GetLinkWeight(parent, child), GetLinkType(parent, child));
                        lnk.linkLabel = GetLinkLabel(parent, child);
                    }
                }

            }
            output.DisableCheck = false;
            output.RebuildIndex();
            return output;
        }

        //public override double GetLinkWeight(T nodeA, T nodeB)
        //{
        //    return 1.GetRatio(nodeA.Count() + 1);
        //}

        //public override double GetNodeWeight(T node)
        //{
        //    return ((node.Count() + 1) * (1.GetRatio(node.level)));
        //}
    }

}