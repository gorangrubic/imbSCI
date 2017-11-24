
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