// --------------------------------------------------------------------------------------------------------------------
// <copyright file="graphTools.cs" company="imbVeles" >
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
using imbSCI.Data;
using imbSCI.Data.extensions;
using imbSCI.Data.extensions.data;
using imbSCI.Data.data;
using imbSCI.Data.collection.special;


namespace imbSCI.Data.collection.graph
{
using imbSCI.Data.interfaces;
    using System.Runtime.CompilerServices;


    /// <summary>
    /// Extensions for <see cref="graphNode"/> , <see cref="graphWrapNode{TItem}"/> and other graphNode derivatives
    /// </summary>
    public static class graphTools
    {

        /// <summary>
        /// Builds the graph from paths.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList">The input list.</param>
        /// <param name="splitter">The splitter.</param>
        /// <returns></returns>
        public static T BuildGraphFromPaths<T>(this IEnumerable<String> inputList, String splitter = "") where T : IGraphNode, new()
        {
            if (splitter == "") splitter = System.IO.Path.DirectorySeparatorChar.ToString();

            T parent = default(T);

            foreach (String p in inputList)
            {
                parent.ConvertPathToGraph<T>(p, true, splitter);
            }

            return parent;
        }

        /// <summary>
        /// Builds graph defined by <c>path</c> or selecte existing graphnode, as pointed by path
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="path">The path.</param>
        /// <param name="isAbsolutePath">if set to <c>true</c> [is absolute path].</param>
        /// <param name="splitter">The splitter - by default: directory separator.</param>
        /// <returns></returns>
        public static T ConvertPathToGraph<T>(this T parent, String path, Boolean isAbsolutePath = true, String splitter = "") where T : IGraphNode, new()
        {
            if (splitter == "") splitter = System.IO.Path.DirectorySeparatorChar.ToString();


            if (isAbsolutePath)
            {
                if (!path.StartsWith(parent.path))
                {
                    return parent;
                }
            }


            List<string> pathParts = imbSciStringExtensions.SplitSmart(path, splitter);



            IGraphNode head = parent;


            foreach (string part in pathParts)
            {
                if (head == null)
                {
                    
                    parent = new T();
                    parent.name = part;
                    head = parent;
                    
                }
                else
                {

                    if (head.ContainsKey(part))
                    {
                        head = head[part];
                    }
                    else
                    {
                        T sp = new T();
                        sp.name = part;
                        if (head.Add(sp))
                        {
                            head = sp;
                        }; //.Add(part, CAPTION_FOR_TUNNELFOLDER, CAPTION_FOR_TUNNELFOLDER);
                    }
                }
            }

            return parent;
        

        }

        /// <summary>
        /// Gets first level parents of the source collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keepRootsFromSource">if set to <c>true</c>: the output will also contain any root (node without parent) node from the specified source collection.</param>
        /// <returns></returns>
        public static List<T> GetParents<T>(this IEnumerable<T> source, Boolean keepRootsFromSource=false) where T:class, IGraphNode
        {
            List<T> output = new List<T>();
            foreach (T t in source)
            {
                if (t.parent != null)
                {
                    if (!output.Contains(t.parent as T))
                    {
                        output.Add(t.parent as T);
                    }
                }
                else
                {
                    if (keepRootsFromSource) output.Add(t);
                }
            }
            return output;
        }


        public static graphNodeSet GetNodeSetWithLeafs<T>(this T parent, List<String> leafNames, Int32 min=-1) where T : class, IGraphNode
        {
            var leafList = parent.getAllLeafs().Where(x => leafNames.Any(y => x.name.Contains(y)));
            
            graphNodeSet nodeSet = new graphNodeSet(parent);
            foreach (IGraphNode g in leafList)
            {
                nodeSet.Add(g);
            }

            if (min > -1)
            {
                if (nodeSet.Count() >= min)
                {
                    return nodeSet;
                }
                else
                {
                    return null;
                }
            }

            return nodeSet;
        }


        /// <summary>
        /// Iterative procedure, returning <see cref="graphNodeSetCollection"/> with <see cref="graphNodeSet"/>s rooted at node that has leafs (all or <c>min)</c> with <c>leafNames</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source - starting leaf or other branch nodes.</param>
        /// <param name="leafNames">The leaf names.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="maxIterations">The maximum iterations.</param>
        /// <param name="extraIterations">The extra iterations.</param>
        /// <returns></returns>
        public static graphNodeSetCollection GetFirstNodeWithLeafs<T>(this IEnumerable<T> source, List<String> leafNames, Int32 min=-1, Int32 maxIterations = 50, Int32 extraIterations = 5) where T : class, IGraphNode, new()
        {
            graphNodeSetCollection output = new graphNodeSetCollection();

            //var parents = source.GetParents<T>(false);
            List<T> newSource = new List<T>();

            Int32 extraIndex = 0;
            if (min == -1) min = leafNames.Count();

            Int32 c = 0;

            for (int i = 0; i < (maxIterations + extraIterations); i++)
            {
                c = source.Count();

                newSource = new List<T>();

                foreach (var parent in source)
                {
                    if (!parent.isLeaf)
                    {
                        var nSet = parent.GetNodeSetWithLeafs<T>(leafNames, min);
                        if (nSet != null)
                        {
                            output.Add(nSet);
                        }
                        else
                        {
                            if (parent.parent != null)
                            {
                                newSource.Add(parent.parent as T);
                            }
                        }
                    }
                    else
                    {
                        if (parent.parent != null)
                        {
                            newSource.Add(parent.parent as T);
                        }
                    }
                }

                source = newSource;

                if (source.Count() == c)
                {
                    extraIndex++;
                }
                else
                {
                    extraIndex = 0;
                }

                if (extraIndex > extraIterations)
                {
                    i = maxIterations;
                    extraIndex = 0;
                }

                if (!source.Any()) return output;
            }

            return output;
           
        }


        /// <summary>
        /// Gets all roots.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="maxIterations">The maximum iterations.</param>
        /// <param name="extraIterations">The extra iterations.</param>
        /// <returns></returns>
        public static List<T> GetAllRoots<T>(this IEnumerable<T> source, Int32 maxIterations=50, Int32 extraIterations=2, Int32 targetCount=1) where T : class, IGraphNode
        {
            List<T> output = new List<T>();

            Int32 extraIndex = 0;

            for (int i = 0; i < (maxIterations + extraIterations); i++)
            {
                Int32 c = source.Count();

                output = source.GetParents(true);


                if (output.Count() <= targetCount) {
                    return output;
                }

            

                source = output;

                if (source.Count() == c)
                {
                    extraIndex++;
                }
                else
                {
                    extraIndex = 0;
                }

                if (extraIndex > extraIterations)
                {
                    i = maxIterations;
                    extraIndex = 0;
                }
            }

            return output;
        }


        /// <summary>
        /// Makes the unique name for a child, based on proposal and counter, formatted by limit digit width: e.g. if <c>limit</c> is 100, format is: D3, producing: <c>proposal</c>+001, +002, +003...
        /// </summary>
        /// <param name="parent">The parent for whom the child name is made</param>
        /// <param name="proposal">The proposal form, neither it already exist or not</param>
        /// <param name="limit">The limit: number of cycles to terminate the search</param>
        /// <param name="toSkip">To skip.</param>
        /// <param name="addNumberSufixForFirst">if set to <c>true</c> it adds number sufix even if it is the first child with proposed name</param>
        /// <returns>
        /// Unique name for new child in format: <c>proposal</c>001 up to <c>limit</c>
        /// </returns>
        public static String MakeUniqueChildName(this IGraphNode parent, String proposal, Int32 limit = 999, Int32 toSkip=0, Boolean addNumberSufixForFirst=true)
        {
         
            String originalProposal = proposal;
            if (originalProposal == null) originalProposal = "G";

            limit = limit + toSkip;

            String format = "D" + limit.ToString().Length.ToString();

            Int32 c = toSkip;

            if (addNumberSufixForFirst)
            {
                c++;
                proposal = originalProposal + c.ToString(format);
            }

            

            while (parent.ContainsKey(proposal))
            {
                c++;
                proposal = originalProposal + c.ToString(format);
                if (c > limit)
                {
                    break;
                }
            }

            return proposal;
        }


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