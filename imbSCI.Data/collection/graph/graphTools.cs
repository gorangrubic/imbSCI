// --------------------------------------------------------------------------------------------------------------------
// <copyright file="graphTools.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
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
// Project: imbSCI.Data
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
namespace imbSCI.Data.collection.graph
{
using imbSCI.Data.interfaces;
    using System.Runtime.CompilerServices;


    /// <summary>
    /// Extensions for <see cref="graphNode"/> and <see cref="graphWrapNode{TItem}"/>
    /// </summary>
    public static class graphTools
    {


        /// <summary>
        /// If the graph <c>target</c> has parent, it will move to its level (one level closer to the root)
        /// </summary>
        /// <param name="target">The graph that is moving</param>
        /// <param name="flags">The operation flags</param>
        /// <returns></returns>
        public static IGraphNode RetreatToParent(this IGraphNode target, graphOperationFlag flags = graphOperationFlag.mergeOnSameName)
        {
            if (target.parent != null)
            {
                return target.MoveTo(target.parent, flags);
            }
            return target;
        }


        /// <summary>
        /// Moves to new parent node <c>moveInto</c>
        /// </summary>
        /// <param name="graphToMove">The graph to move.</param>
        /// <param name="moveInto">The move into (future parent graph)</param>
        /// <param name="flags">The operation flags</param>
        /// <returns>Resulting graph, relevant in case of merging</returns>
        public static IGraphNode MoveTo(this IGraphNode graphToMove, IGraphNode moveInto, graphOperationFlag flags = graphOperationFlag.mergeOnSameName)
        {
            if (moveInto.getChildNames().Contains(graphToMove.name))
            {
                if (flags.HasFlag(graphOperationFlag.mergeOnSameName))
                {
                    graphToMove.MergeWith(moveInto[graphToMove.name], flags);
                } else if(flags.HasFlag(graphOperationFlag.overwriteOnSameName))
                {
                    moveInto.RemoveByKey(graphToMove.name);
                    moveInto.Add(graphToMove);

                }

            } else
            {
                moveInto.Add(graphToMove);
            }
            return graphToMove;
        }

        /// <summary>
        /// Graph node <c>graphToMerge</c> transfers all child nodes to <c>graphToMergeWith</c> and disconnects from its parent
        /// </summary>
        /// <param name="graphToMerge">The graph to merge.</param>
        /// <param name="graphToMergeWith">The graph to merge with.</param>
        /// <param name="flags">The operation flags</param>
        /// <returns></returns>
        public static IGraphNode MergeWith(this IGraphNode graphToMerge, IGraphNode graphToMergeWith, graphOperationFlag flags = graphOperationFlag.mergeOnSameName)
        {
            foreach (IGraphNode child in graphToMerge)
            {
                child.MoveTo(graphToMergeWith, flags);

            }

            graphToMerge.parent.RemoveByKey(graphToMerge.name);

            return graphToMergeWith;

        }
    }

}