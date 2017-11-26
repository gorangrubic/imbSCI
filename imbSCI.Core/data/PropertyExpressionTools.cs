// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyExpressionTools.cs" company="imbVeles" >
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
// Project: imbSCI.Core
// Author: Goran Grubi?
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.data
{
    using imbSCI.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Tools for property selection expression resolution
    /// </summary>
    public static class PropertyExpressionTools
    {

        public static PropertyExpression GetExpressionResolved(this Object host, String path)
        {
            PropertyExpression output = null;

            List<String> pathPart = imbSciStringExtensions.SplitSmart(path, ".");
            String root = "";
            if (pathPart.Any())
            {
                root = pathPart.First();
                output = new PropertyExpression(host, root);
            }
            pathPart.Remove(pathPart.First());

            Object head = host;
            if (output.property == null)
            {
                output.state = PropertyExpressionStateEnum.nothingResolved;
                output.undesolvedPart = path;
                return output;
            }
            String currentPart = root;
            foreach (String pp in pathPart)
            {
                currentPart = pp;
                var tmp = output.Add(pp);
                if (tmp.host == null)
                {
                    output.state = PropertyExpressionStateEnum.resolvedSome;
                    break;
                }
                else
                {
                    output = tmp;
                }

            }

            if (currentPart != pathPart.Last())
            {
                String unp = "";
                Int32 i = pathPart.IndexOf(currentPart);
                for (int j = i; j < pathPart.Count; j++)
                {
                    unp = imbSciStringExtensions.add(unp, pathPart[j], ".");
                }
                output.undesolvedPart = unp;
            }
            else
            {
                if (output.property != null)
                {
                    output.state = PropertyExpressionStateEnum.resolvedAll;
                }
                
            }
            return output;
        }
    }

}