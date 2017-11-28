// --------------------------------------------------------------------------------------------------------------------
// <copyright file="graphDataPackage.cs" company="imbVeles" >
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
namespace imbSCI.Data.collection.graph
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Data.data.package;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="imbSCI.Data.data.package.dataPackage{TItem, aceCommonTypes.collection.nested.graphWrapNode{TItem}}" />
    public class graphDataPackage<TItem> : dataPackage<TItem, graphWrapNode<TItem>>  where TItem : class, IObjectWithName,  new()
    {
        public graphDataPackage() : base()
        {
        }



        public void Store(graphWrapNode<TItem> input, String path)
        {
            List<graphWrapNode<TItem>> chld = new List<graphWrapNode<TItem>>();
            input.getAllChildren().ForEach(x => chld.Add((graphWrapNode<TItem>)x));
            
            AddDataItems(chld, true);

            this.SaveDataPackage(path);
            
        }



        protected override string GetDataPackageID(graphWrapNode<TItem> wrapper)
        {
            return wrapper.path;
        }

        protected override TItem GetInstanceToPack(graphWrapNode<TItem> wrapper)
        {
            return wrapper.item;
        }
    }
}