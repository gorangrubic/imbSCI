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
using imbSCI.Core.data;
using System.Collections;
using imbSCI.Core.extensions.typeworks;

namespace imbSCI.Graph.Converters
{
    public class graphToDirectedGraphConverterBasic:graphToDirectedGraphConverterBase<IGraphNode>
    {

        public override string GetCategoryID(IGraphNode nodeOrLink)
        {
            if (nodeOrLink == null) return "null";
            return nodeOrLink.GetType().Name;
        }



        public override int GetTypeID(IGraphNode nodeOrLink)
        {
            if (nodeOrLink == null) return 0;
            return nodeOrLink.GetType().GetHashCode();
        }



        public override double GetLinkWeight(IGraphNode nodeA, IGraphNode nodeB)
        {
            if (nodeA == null) return 0;
            if (nodeB == null) return 0;
            return 1.GetRatio(nodeA.Count() + 1);
        }

        public override double GetNodeWeight(IGraphNode node)
        {
            if (node == null) return 0;
            return ((node.Count() + 1) * (1.GetRatio(node.level)));
        }
    }


}