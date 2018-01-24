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

    public class DirectedGraphStylingCase
    {
        public GraphStylerSettings setup { get; set; }
        public DirectedGraphStylingCase(GraphStylerSettings settings)
        {
            setup = settings;
            nodeStyler = new NodeWeightStylerCategories(setup.NodeGradient, setup);
            linkStyler = new NodeWeightStylerCategories(setup.LinkGradient, setup);

        }

        public CategoryCollection Categories { get; set; } = new CategoryCollection();

        public NodeWeightStylerCategories nodeStyler { get; set; }

        public NodeWeightStylerCategories linkStyler { get; set; }

    }

}