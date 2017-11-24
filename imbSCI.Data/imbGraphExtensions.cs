// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbGraphExtensions.cs" company="imbVeles" >
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
namespace imbSCI.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using imbSCI.Data.interfaces;

    public static class imbGraphExtensions
    {

        /// <summary>
        /// Gets all children. If pathFilder defined, it uses it to select only children with appropriate path
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="pathFilter">The path filter.</param>
        /// <returns></returns>
        public static List<IObjectWithPathAndChildren> getAllChildren(this IObjectWithPathAndChildren parent, Regex pathFilter = null, Boolean inverse = false)
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();

            List<IObjectWithPathAndChildren> stack = new List<IObjectWithPathAndChildren>();
            stack.Add(parent);

            while (stack.Any())
            {
                var n_stack = new List<IObjectWithPathAndChildren>();

                foreach (IObjectWithPathAndChildren child in stack)
                {
                    if (pathFilter != null)
                    {
                        if (pathFilter.IsMatch(child.path))
                        {
                            if (!inverse) output.Add(child);
                        }
                        else
                        {
                            if (inverse) output.Add(child);
                        }
                    }
                    else
                    {
                        output.Add(child);
                    }

                    if (child.Any())
                    {
                        foreach (IObjectWithPathAndChildren c in child) n_stack.Add(c);
                    }
                }

                stack = n_stack;

            }
            return output;
        }

        /// <summary>
        /// Removes all children from parent nodes
        /// </summary>
        /// <param name="children">The children.</param>
        public static void removeFromParent(this IEnumerable<IObjectWithPathAndChildren> children)
        {
            foreach (IObjectWithPathAndChildren ch in children)
            {
                if (ch.parent != null)
                {
                    var chp = ch.parent as IObjectWithPathAndChildren;
                    chp.Remove(ch.name);
                }
            }
        }

        public static List<String> getNames(this IEnumerable<IObjectWithName> source, Boolean unique = true)
        {
            List<String> output = new List<string>();
            foreach (IObjectWithName on in source)
            {
                if (unique)
                {
                    if (!output.Contains(on.name)) output.Add(on.name);
                    
                }
                else
                {
                    output.Add(on.name);
                }

            }
            return output;
        }

        public static List<String> getPaths(this IEnumerable<IObjectWithPath> source)
        {
            List<String> output = new List<string>();
            foreach (IObjectWithPath on in source) output.Add(on.path);
            return output;
        }


        /// <summary>
        /// Gets the deepest.
        /// </summary>
        /// <param name="children">The children.</param>
        /// <param name="margine">The margine.</param>
        /// <returns></returns>
        public static List<IObjectWithPathAndChildren> getDeepest(this IEnumerable<IObjectWithPathAndChildren> children, Int32 margine = 0)
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();
            Int32 maxl = Int32.MinValue;
            foreach (IObjectWithPathAndChildren child in children)
            {
                maxl = Math.Max(child.level, maxl);
            }

            maxl = maxl - margine;

            foreach (IObjectWithPathAndChildren child in children)
            {
                if (child.level >= maxl) output.Add(child);
            }
            return output;
        }

        /// <summary>
        /// Gets the on level.
        /// </summary>
        /// <param name="children">The children.</param>
        /// <param name="level">The level.</param>
        /// <param name="downMargin">Down margin.</param>
        /// <param name="upMargin">Up margin.</param>
        /// <returns></returns>
        public static List<IObjectWithPathAndChildren> getOnLevel(this IEnumerable<IObjectWithPathAndChildren> children, Int32 level = 0, Int32 downMargin = 0, Int32 upMargin = 0)
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();
            Int32 min = level - downMargin;
            Int32 max = level + upMargin;

            foreach (IObjectWithPathAndChildren child in children)
            {
                if (child.level == level)
                {
                    output.Add(child);

                }

                else if (child.level > min && child.level < max)
                {

                    
                    output.Add(child);
                }
            }
            return output;
        }

        /// <summary>
        /// Filters out the collection by path regex, <c>nameRegex</c> is optional AND criterion
        /// </summary>
        /// <param name="children">The children.</param>
        /// <param name="pathRegex">The path regex.</param>
        /// <param name="nameRegex">The name regex.</param>
        /// <returns></returns>
        public static List<IObjectWithPathAndChildren> getFilterOut(this IEnumerable<IObjectWithPathAndChildren> children, Regex pathRegex, Regex nameRegex = null)
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();

            foreach (IObjectWithPathAndChildren child in children)
            {
                if (pathRegex.IsMatch(child.path))
                {
                    if (nameRegex != null)
                    {
                        if (nameRegex.IsMatch(child.name)) output.Add(child);
                    }
                    else
                    {
                        output.Add(child);
                    }
                }
                else { }
            }
            return output;
        }

        //public static List<IObjectWithPathAndChildren> getOnlyWithFullBranch(this IEnumerable<IObjectWithPathAndChildren> children, Regex pathRegex, Regex nameRegex = null)
        //{
        //    List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();

        //    foreach (IObjectWithPathAndChildren child in children)
        //    {
        //        if (pathRegex.IsMatch(child.path))
        //        {
        //            if (nameRegex != null)
        //            {
        //                if (nameRegex.IsMatch(child.name)) output.Add(child);
        //            }
        //            else
        //            {
        //                output.Add(child);
        //            }
        //        }
        //        else { }
        //    }
        //    return output;
        //}


        /// <summary>
        /// Gets all leafs, optionally applies Regex criteria used to child name
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nameFilter">The name filter.</param>
        /// <returns></returns>
        public static List<IObjectWithPathAndChildren> getAllLeafs(this IObjectWithPathAndChildren parent, Regex nameFilter = null, Boolean inverse = false)
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();

            List<IObjectWithPathAndChildren> stack = new List<IObjectWithPathAndChildren>();
            stack.Add(parent);

            while (stack.Any())
            {
                var n_stack = new List<IObjectWithPathAndChildren>();

                foreach (IObjectWithPathAndChildren child in stack)
                {
                    if (child.Any())
                    {
                        foreach (IObjectWithPathAndChildren c in child) n_stack.Add(c);
                    }
                    else
                    {
                        if (nameFilter != null)
                        {
                            if (nameFilter.IsMatch(child.name))
                            {

                                if (!inverse) output.Add(child);

                            }
                            else
                            {
                                if (inverse) output.Add(child);
                            }
                        }
                        else
                        {
                            output.Add(child);
                        }
                    }
                }
                stack = n_stack;
            }
            return output;
        }
    }

}