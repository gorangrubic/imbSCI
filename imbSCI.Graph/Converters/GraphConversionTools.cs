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
using imbSCI.Core.data;

namespace imbSCI.Graph.Converters
{

    /// <summary>
    /// Set of default graph converters
    /// </summary>
    public static class GraphConversionTools
    {

        /// <summary>
        /// Converts to free graph -- from the specified node to its leafs (downwards)
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="DepthLimit">The depth limit.</param>
        /// <returns></returns>
        public static freeGraph ConvertToFreeGraph(this IGraphNode graph, Int32 DepthLimit = 300)
        {
            return GraphConversionTools.BasicConverterInstance.Convert(graph, DepthLimit);
        }

        /// <summary>
        /// Converts to free graph -- from the specified node to its leafs (downwards)
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="DepthLimit">The depth limit.</param>
        /// <returns></returns>
        public static DirectedGraph ConvertToDGML(this freeGraph graph)
        {
            return GraphConversionTools.DefaultDMGLConverter.ConvertToDMGL(graph);
        }


        /// <summary>
        /// Converts to free graph -- from the specified node to its leafs (downwards)
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="DepthLimit">The depth limit.</param>
        /// <returns></returns>
        public static DirectedGraph ConvertToDGML(this IGraphNode graph, Int32 DepthLimit = 300)
        {
            
            return DefaultGraphToDGMLConverterInstance.Convert(graph, DepthLimit);
        }

        public static DirectedGraph ConvertToDGML(this PropertyExpression pe, Int32 DepthLimit = 20)
        {
            return PropertyExpressionConverterToDGML.Convert(pe, DepthLimit);
        }


        private static propertyExpressionToDirectedGraphConverter _PropertyExpressionConverterToDGML;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static propertyExpressionToDirectedGraphConverter PropertyExpressionConverterToDGML
        {
            get
            {
                if (_PropertyExpressionConverterToDGML == null)
                {
                    _PropertyExpressionConverterToDGML = new propertyExpressionToDirectedGraphConverter();
                }
                return _PropertyExpressionConverterToDGML;
            }
        }


        private static graphToDirectedGraphConverterBasic _DefaultGraphToDGMLConverterInstance;
        /// <summary>
        /// Basic implementation of the graph to <see cref="DirectedGraph"/> converter
        /// </summary>
        public static graphToDirectedGraphConverterBasic DefaultGraphToDGMLConverterInstance
        {
            get
            {
                if (_DefaultGraphToDGMLConverterInstance == null)
                {
                    _DefaultGraphToDGMLConverterInstance = new graphToDirectedGraphConverterBasic();
                }
                return _DefaultGraphToDGMLConverterInstance;
            }
        }



        private static graphToFreeGraphConverterBasic<IGraphNode> _DefaultFreeGraphConverterInstance;
        /// <summary>
        /// Basic instance of <see cref="graphNode"/> to <see cref="freeGraph"/> converter
        /// </summary>
        public static graphToFreeGraphConverterBasic<IGraphNode> BasicConverterInstance
        {
            get
            {
                if (_DefaultFreeGraphConverterInstance == null)
                {
                    _DefaultFreeGraphConverterInstance = new graphToFreeGraphConverterBasic<IGraphNode>();
                }
                return _DefaultFreeGraphConverterInstance;
            }
        }


        private static freeGraphToDMGL _DefaultDMGLConverter;
        /// <summary>
        /// Default instance of <see cref="freeGraph"/> to <see cref="DirectedGraph"/> converter
        /// </summary>
        public static freeGraphToDMGL DefaultDMGLConverter
        {
            get
            {
                if (_DefaultDMGLConverter == null)
                {
                    _DefaultDMGLConverter = new freeGraphToDMGL();
                    
                }
                return _DefaultDMGLConverter;
            }
        }


    }

}