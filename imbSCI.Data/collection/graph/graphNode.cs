// --------------------------------------------------------------------------------------------------------------------
// <copyright file="graphNode.cs" company="imbVeles" >
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

// using aceCommonTypes.core.interfaces;
// using aceCommonTypes.extensions.io;
// using aceCommonTypes.extensions.text;
// using aceCommonTypes.interfaces;
// using aceCommonTypes.extensions;

namespace imbSCI.Data.collection.graph
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Universal T-Graph structure with nodes having unique <see cref="name"/> property. To be used without <see cref="graph{TItem}"/> class.
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{aceCommonTypes.collection.nested.graphNode}" />
    /// <seealso cref="aceCommonTypes.core.interfaces.IObjectWithParent" />
    /// <seealso cref="aceCommonTypes.core.interfaces.IObjectWithPath" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithName" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithPathAndChildren" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithTreeView" />
    public class graphNode:IEnumerable, IEnumerable<graphNode>, IObjectWithParent, IObjectWithPath, IObjectWithName, IObjectWithPathAndChildren, IObjectWithTreeView
    {
        /// <summary>
        /// Gets the depth level, where 1 is the root
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public Int32 level
        {
            get
            {
                Int32 output = 1;
                if (parent != null) return parent.level + output;
                return output;
            }
        }

        /// <summary>
        /// Gets the child names.
        /// </summary>
        /// <returns></returns>
        public List<String> getChildNames()
        {
            return children.Keys.ToList();
        }


        /// <summary>
        /// Gets the first.
        /// </summary>
        /// <returns></returns>
        public graphNode getFirst()
        {
            if (children.Any())
            {
                return children.First().Value;
            }
            else
            {
                return null;
            }
        }

        private Dictionary<String, graphNode> _children = new Dictionary<String, graphNode>();
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        protected Dictionary<String, graphNode> children
        {
            get
            {
                return _children;
            }
            set { _children = value; }
        }


        public Int32 Count()
        {
            return children.Count();
        }

        /// <summary>
        /// Removes by the key specified
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(String key)
        {
            children.Remove(key);
        }



        IEnumerator<graphNode> IEnumerable<graphNode>.GetEnumerator()
        {
            return children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.Values.GetEnumerator();
        }

        public IEnumerator<IObjectWithPathAndChildren> GetEnumerator()
        {
            return children.Values.GetEnumerator();
        }

        /// <summary>
        /// Name format used for textual tree view representation
        /// </summary>
        /// <value>
        /// For treeview.
        /// </value>
        public virtual String forTreeview
        {
            get
            {
                return name;
            }
        }


        private graphNode _parent;
        /// <summary>
        /// Referenca prema parent objektu
        /// </summary>
        public virtual graphNode parent
        {
            get
            {
                return _parent;
            }
            protected set
            {
                _parent = value;
            }
        }


        private String _name;
        /// <summary>
        /// Ime koje je dodeljeno objektu
        /// </summary>
        public virtual String name
        {
            get
            {
                return _name;
               
            }
            set
            {
               
                    _name = value;
                

            }
        }

        /// <summary>
        /// Gets the path separator used in this path format
        /// </summary>
        /// <value>
        /// The path separator.
        /// </value>
        public virtual string pathSeparator
        {
            get
            {
                return "\\";
            }
        }

        /// <summary>
        /// Putanja objekta
        /// </summary>
        public virtual string path
        {
            get
            {
                String output = name;
                if (parent != null) return parent.path + pathSeparator + name;
                return output;
            }
        }



        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public object root
        {
            get
            {
                if (parent == null) return this;
                return parent.root;
            }
        }

        /// <summary>
        /// Referenca prema parent objektu
        /// </summary>
        object IObjectWithParent.parent
        {
            get
            {
                return parent;
            }
        }
    }

}