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

    //public enum propertyExpression

    public class propertyExpressionToDirectedGraphConverter : graphToDirectedGraphConverterBase<PropertyExpression>
    {
        public propertyExpressionToDirectedGraphConverter():base()
        {
            setup = new GraphStylerSettings();
            setup.GraphDirection = DGML.enums.GraphDirectionEnum.LeftToRight;
            setup.GraphLayout = DGML.enums.GraphLayoutEnum.DependencyMatrix;
            setup.alphaMin = 0.7;
            setup.NodeGradient = new ColorGradient("#FF195ac5", "#FF195ac5", ColorGradientFunction.AtoB | ColorGradientFunction.Hue | ColorGradientFunction.CircleCCW);
            setup.LinkGradient = new ColorGradient("#FF6c6c6c", "#FF6c6c6c", ColorGradientFunction.AllAToB);
            
            Deploy(setup);
        }

        public override string GetCategoryID(PropertyExpression nodeOrLink)
        {
            return GetTypeID(nodeOrLink).ToString();
        }

        public override double GetLinkWeight(PropertyExpression nodeA, PropertyExpression nodeB)
        {
            if (nodeA == null) return 0;
            if (nodeB == null) return 0;
            return 1.GetRatio(nodeA.Count() + 1);
        }

        public override double GetNodeWeight(PropertyExpression node)
        {
            if (node == null) return 0;
            return ((node.Count() + 1) * (1.GetRatio(node.level)));
        }

        public override string GetLinkLabel(PropertyExpression nodeA, PropertyExpression nodeB)
        {
            if (nodeB.valueType == null) return "[?]";
            return nodeB.valueType.Name; //  base.GetLinkLabel(nodeA, nodeB);
        }

        public override string GetNodeLabel(PropertyExpression node)
        {
            Object vl = node.getValue();

            if (node.host is IList) return node.name + "[ ]";
            if (node.host is IDictionary) return node.name + "[ ]";

            if (node.valueType == null) return node.name + " [!]";
            //if (node.valueType.isToggleValue() || node.valueType.isNumber()) return node.name + " = " + node.getValue().toStringSafe("") + "";
            if (node.valueType.isText()) return node.name + " = \"" + vl.toStringSafe("") + "\"";
            if (node.valueType.IsClass) return node.name;
            return node.name;
        }

        public override int GetTypeID(PropertyExpression nodeOrLink)
        {
            
            if (nodeOrLink.valueType == null) return 0;
            
            if (nodeOrLink.valueType.isNumber()) return 1;
            if (nodeOrLink.valueType.isToggleValue()) return 2;
            
            if (nodeOrLink.valueType.IsGenericType) return 4;
            if (nodeOrLink.Count() > 0) return 5;
            if (nodeOrLink.valueType.isText()) return 3;
            return 0;
        }
    }

}