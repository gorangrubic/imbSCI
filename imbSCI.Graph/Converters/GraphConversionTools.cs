// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphConversionTools.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Graph
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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
using imbSCI.Graph.DOT;

namespace imbSCI.Graph.Converters
{

    /// <summary>
    /// Set of default graph converters
    /// </summary>
    public static class GraphConversionTools
    {

        public static List<DotNode> ConvertNodes(this List<Node> nodes)
        {
            List<DotNode> output = new List<DotNode>();

            foreach (Node n in nodes)
            {
                DotNode dn = new DotNode(n.Label);
                dn.Group = n.Group;
                dn.Shape = DotNodeShape.Box;
                dn.Style = DotNodeStyle.Dashed;
                dn.Visibility = n.Visibility;
                output.Add(dn);
            }

            return output;
        }

        /// <summary>
        /// Converts to free graph -- from the specified node to its leafs (downwards)
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="DepthLimit">The depth limit.</param>
        /// <returns></returns>
        public static freeGraph ConvertToFreeGraph(this graphNode graph, Int32 DepthLimit = 300)
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
        public static DirectedGraph ConvertToDGML(this graphNode graph, Int32 DepthLimit = 300)
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



        private static graphToFreeGraphConverterBasic<graphNode> _DefaultFreeGraphConverterInstance;
        /// <summary>
        /// Basic instance of <see cref="graphNode"/> to <see cref="freeGraph"/> converter
        /// </summary>
        public static graphToFreeGraphConverterBasic<graphNode> BasicConverterInstance
        {
            get
            {
                if (_DefaultFreeGraphConverterInstance == null)
                {
                    _DefaultFreeGraphConverterInstance = new graphToFreeGraphConverterBasic<graphNode>();
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