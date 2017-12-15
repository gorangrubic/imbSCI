using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Data.collection.graph
{
    using System.Collections;
    using imbSCI.Data.interfaces;
    using System.Collections.Concurrent;
    using System.Collections.Specialized;


    /// <summary>
    /// Graph structure to inherit for custom graph node type
    /// </summary>
    /// <seealso cref="imbSCI.Data.collection.graph.graphNodeBase" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbSCI.Data.collection.graph.IGraphNode}" />
    /// <seealso cref="imbSCI.Data.collection.graph.IGraphNode" />
    public abstract class graphNodeCustom : graphNodeBase, IEnumerable<IGraphNode>, IGraphNode
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="graphNodeCustom"/> class.
        /// </summary>
        protected graphNodeCustom():base()
        {
            if (doAutonameFromTypeName)
            {
                name = makeAutoName();
            }
        }

        /// <summary>
        /// Turns on the autorenaming, when new child is inserted into this node - it will autorename it to have unique name
        /// </summary>
        /// <value>
        ///   <c>true</c> if [do autorename on existing]; otherwise, <c>false</c>.
        /// </value>
        protected abstract Boolean doAutorenameOnExisting { get; }

        /// <summary>
        /// Turns on autonaming, based on type name of this node
        /// </summary>
        /// <value>
        ///   <c>true</c> if [do autoname from type name]; otherwise, <c>false</c>.
        /// </value>
        protected abstract Boolean doAutonameFromTypeName { get; }



        IEnumerator<IGraphNode> IEnumerable<IGraphNode>.GetEnumerator()
        {
            return (IEnumerator<IGraphNode>)children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.Values.GetEnumerator();
        }


        /// <summary>
        /// Creates new child item and sets the name, but still do not add it. Used internally by <see cref="Add(String pathWithName)"/>
        /// </summary>
        /// <param name="nameForChild">The name for child.</param>
        /// <returns></returns>
        public virtual graphNodeCustom CreateChildItem(String nameForChild)
        {
            Type t = GetType();

            graphNodeCustom newChild = Activator.CreateInstance(t, new object[] { }) as graphNodeCustom;
            newChild.name = nameForChild;
            return newChild;
        }


        /// <summary>
        /// Adds the specified path with name.
        /// </summary>
        /// <param name="pathWithName">Name of the path with.</param>
        /// <returns></returns>
        public virtual graphNodeCustom Add(String pathWithName)
        {
            List<String> pathParts = pathWithName.SplitSmart(pathSeparator);
            graphNodeCustom head = this;

            foreach (String part in pathParts)
            {
                head = head.CreateChildItem(part);
                Add(head);
                //head = head.Add(part);
            }
            
            return head;
        }

        /// <summary>
        /// Makes the name of the automatic.
        /// </summary>
        /// <returns></returns>
        internal String makeAutoName()
        {
                var n = "";
                n = GetType().Name + "_" + GetType().Name;
                n = n.Replace("Node", "");
                n = n.Replace("Graph", "");


            return n;
        }

        private const Int32 AUTORENAME_LIMIT = 99;

        /// <summary>
        /// Adds the specified <c>newChild</c>, if its name is not already occupied
        /// </summary>
        /// <param name="newChild">The new child.</param>
        /// <returns></returns>
        public override bool Add(IGraphNode newChild)
        {
            if (doAutonameFromTypeName)
            {
                if (newChild.name.isNullOrEmpty())
                {
                    newChild.name = makeAutoName();
                }
            }


            if (doAutorenameOnExisting && children.Contains(newChild.name))
            {
                newChild.name = this.MakeUniqueChildName(newChild.name, AUTORENAME_LIMIT);

            }
            else
            {
                return false;
            }

           
            IGraphNode gn = newChild as IGraphNode;
            gn.parent = this;
            children.Add(gn.name, gn);
            return true;
           

        }


        /// <summary>
        /// Returns the index of this node at its parent node. If no parent: returns -1
        /// </summary>
        /// <returns></returns>
        public Int32 GetIndex()
        {
            if (parent != null)
            {
                graphNodeCustom cParent = (graphNodeCustom)parent;

                return cParent.mychildren.IndexOfValue(this);


            } else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the sibling, relative to this node, positioned at <c>n</c> places defined by <c>direction</c>. It is range-safe, in sense: if node index + <c>direction</c> is higher then number of siblings, it will return the last sibling.
        /// </summary>
        /// <remarks>
        /// <para>If there is no parent: it will return <c>null</c></para>
        /// <para>If direction + index is less then zero, it will return sibling at zero</para>
        /// </remarks>
        /// <param name="direction">The direction, relative to index of this node. If it is 0, it will return this node</param>
        /// <returns>Sibling node, relative to index of this and <c>direction</c> specified</returns>
        public IGraphNode GetSibling(Int32 direction=1)
        {
            if (direction == 0) return this;

            if (parent == null) return null;

            Int32 index = GetIndex();

            if (index == -1) return null;

            index += direction;

            if (index < 0) index = 0;



            if (index >= parent.Count())
            {
                index = parent.Count() - 1;
            }

            var cParent = parent as graphNodeCustom;

            return cParent[index];

        }


        /// <summary>
        /// Returns node by ordinal index
        /// </summary>
        /// <value>
        /// The <see cref="IGraphNode"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public IGraphNode this[Int32 index]
        {
            get
            {
                if (index < 0) return null;

                if (mychildren.Count > index)
                {
                    String key = mychildren.Keys[index];
                    return mychildren[key];
                } else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Accessing the child nodes using child node name
        /// </summary>
        /// <value>
        /// The <see cref="IGraphNode"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override IGraphNode this[String key]
        {
            get
            {
                if (mychildren.ContainsKey(key))
                {
                    return mychildren[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (mychildren.ContainsKey(key))
                {
                    value.parent = this;
                    mychildren[key] = value;
                }
                else
                {
                    Add(value);
                }
            }
        }





        protected override IDictionary children
        {
            get
            {
                return mychildren;
            }
        }

        protected SortedList<String, IGraphNode> mychildren { get; set; } = new SortedList<string, IGraphNode>();



        /// <summary>
        /// String representetation of the node
        /// </summary>
        /// <value>
        /// For treeview.
        /// </value>
        public virtual string forTreeview
        {
            get
            {
                return name;
            }
        }
    }

}