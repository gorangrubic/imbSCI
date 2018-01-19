// --------------------------------------------------------------------------------------------------------------------
// <copyright file="graphNodeBase.cs" company="imbVeles" >
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
namespace imbSCI.Data.collection.graph
{
    using System.Collections;
    using imbSCI.Data.interfaces;
    using System.Collections.Concurrent;


    ///// <summary>
    ///// Graph tree, without "unique-child name at parent" constrain, and with n-dymensional child-plane model (for node distance calculation)
    ///// </summary>
    ///// <seealso cref="imbSCI.Data.collection.graph.IGraphNode" />
    //public abstract class planarGraphBase:IGraphNode
    //{

    //}



    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithParent" />
    public abstract class graphNodeBase: IObjectWithParent, IEnumerable<IGraphNode>
    {
        public const String defaultPathSeparator = "\\";
       // private ConcurrentDictionary<String, IGraphNode> _children = new ConcurrentDictionary<String, IGraphNode>();
        private IGraphNode _parent;
        private String _name;
        private String _pathSeparator = "";

        public abstract Boolean Add(IGraphNode child);


        public abstract IGraphNode this[String key] { get; set; }

       
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
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        protected abstract IDictionary children { get; }
        
        /// <summary>
        /// Referenca prema parent objektu
        /// </summary>
        public virtual IGraphNode parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

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
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public Boolean ContainsKey(String key)
        {
            return children.Contains(key);
        }

        /// <summary>
        /// Gets the path separator used in this path format - if its not set it will look for parent's default path separator to set it. If there is no parent, it will use <see cref="defaultPathSeparator"/>
        /// </summary>
        /// <value>
        /// The path separator.
        /// </value>
        public virtual string pathSeparator
        {
            get
            {
                if (_pathSeparator != "") return _pathSeparator;

                if (parent != null)
                {
                    //graphNode graphParent = (graphNode)parent;
                    _pathSeparator = parent.pathSeparator;
                    return _pathSeparator;

                }

                return defaultPathSeparator;
            }
            set
            {
                _pathSeparator = value;
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

        /// <summary>
        /// Gets the child names.
        /// </summary>
        /// <returns></returns>
        public List<String> getChildNames()
        {
            List<String> output = new List<string>();
            foreach (Object k in children.Keys)
            {
                output.Add(k.ToString());
            }
            return output;
        }

        /// <summary>
        /// Gets the first.
        /// </summary>
        /// <returns></returns>
        public IGraphNode getFirst()
        {
            foreach (Object k in children.Keys)
            {
                return children[k] as IGraphNode;
            }
            return null;
        }

        public Int32 Count()
        {
            return children.Count;
        }

        /// <summary>
        /// Removes by the key specified
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(String key)
        {
            IGraphNode pop;
            children.Remove(key);
            //children.TryRemove(key, out pop); // .Remove(key);
        }

        public IEnumerator<IObjectWithPathAndChildren> GetEnumerator()
        {
            List<IObjectWithPathAndChildren> output = new List<IObjectWithPathAndChildren>();
            foreach (Object k in children.Keys)
            {
                output.Add(children[k] as IGraphNode);
            }

            return output.GetEnumerator(); //.GetEnumerator();
        }

        /// <summary>
        /// Removes child matching the specified key, on no match returns <c>false</c>
        /// </summary>
        /// <param name="key">The key to match children against</param>
        /// <returns>
        /// True if a child removed, false if no child matched by the key
        /// </returns>
        public bool RemoveByKey(string key)
        {
                       

            if (children.Contains(key))
            {
                //children[key].parent = null;
                IGraphNode gn;
                children.Remove(key);

                //if (children.TryRemove(key, out gn))
                //{
                //    gn.parent = null;
                //}
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes all children with matching <see cref="graphNode.name" />
        /// </summary>
        /// <param name="keys">The keys to match children with</param>
        /// <returns>
        /// Number of child nodes matched and removed
        /// </returns>
        public int Remove(IEnumerable<string> keys)
        {
            Int32 c = 0;
            foreach (String k in keys)
            {
                if (RemoveByKey(k)) c++;
            }
            return c;
        }

        IEnumerator<IGraphNode> IEnumerable<IGraphNode>.GetEnumerator()
        {
            List<IGraphNode> output = new List<IGraphNode>();
            foreach (Object k in children.Keys)
            {
                output.Add(children[k] as IGraphNode);
            }

            return output.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }

}