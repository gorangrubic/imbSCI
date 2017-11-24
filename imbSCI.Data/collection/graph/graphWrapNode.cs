//using aceCommonTypes.core.interfaces;
//using aceCommonTypes.extensions.io;
//using aceCommonTypes.extensions.text;
//using aceCommonTypes.interfaces;

namespace imbSCI.Data.collection.graph
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{aceCommonTypes.collection.nested.graphWrapNode{TItem}}" />
    /// <seealso cref="aceCommonTypes.core.interfaces.IObjectWithParent" />
    /// <seealso cref="aceCommonTypes.core.interfaces.IObjectWithPath" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithName" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithPathAndChildren" />
    public class graphWrapNode<TItem> : graphNode, IEnumerable, IEnumerable<graphWrapNode<TItem>>, 
        IObjectWithParent, IObjectWithPath, IObjectWithName, IObjectWithPathAndChildren, IObjectWithTreeView where TItem : IObjectWithName
    {

        //public void OnBeforeSave()

        IEnumerator<graphWrapNode<TItem>> IEnumerable<graphWrapNode<TItem>>.GetEnumerator()
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



        private Dictionary<String, graphWrapNode<TItem>> _children = new Dictionary<String, graphWrapNode<TItem>>();
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        protected Dictionary<String, graphWrapNode<TItem>> children
        {
            get
            {
                return _children;
            }
            set { _children = value; }
        }


        private TItem _item; // = "";
        /// <summary>
        /// The object associated with the graph
        /// </summary>
        [XmlIgnore]
        public TItem item
        {
            get { return _item; }
            protected set { _item = value; }
        }

        public void SetItem(TItem __item)
        {
            String __name = name;
            __item.name = __name;
            _item = __item;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty graph node, containing no wrapped item node.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is null node; otherwise, <c>false</c>.
        /// </value>
        public Boolean isNullNode
        {
            get {
                return (item == null);
            }
        }

        public graphWrapNode()
        {

        }

        protected graphWrapNode(String __name, graphWrapNode<TItem> __parent=null)
        {
            name = __name;
            parent = __parent;
        }

        protected graphWrapNode(TItem __item, graphWrapNode<TItem> __parent=null)
        {
            _item = __item;
            parent = __parent;
        }


        /// <summary>
        /// Gets or sets the <see cref="graphWrapNode{TItem}"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="graphWrapNode{TItem}"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public graphWrapNode<TItem> this[String key]
        {
            get
            {

                return children[key];
            }
            set
            {
                if (children.ContainsKey(key))
                {
                    children[key].item = value;
                }
                else
                {
                    Add(value);
                }
            }
        }

        /// <summary>
        /// Ime koje je dodeljeno objektu
        /// </summary>
        public override string name
        {
            get
            {
                if (isNullNode)
                {
                    return base.name;
                }
                return item.name;
            }

            set
            {

                base.name = value;
            }
        }

        private graphWrapNode<TItem> _parent;
        /// <summary>
        /// Referenca prema parent objektu
        /// </summary>
        public override graphNode parent
        {
            get
            {
                return _parent;
            }
            protected set
            {
                _parent = (graphWrapNode<TItem>) value;
            }
        }


        public static implicit operator TItem(graphWrapNode<TItem> gr)
        {
            return gr.item;
        }

      
        /// <summary>
        /// Adds the specified item into graph structure
        /// </summary>
        /// <param name="__item">The item.</param>
        public virtual graphWrapNode<TItem> Add(TItem __item)
        {
            if (!children.ContainsKey(__item.name))
            {
                var tkng = new graphWrapNode<TItem>(__item, this);
                
                children.Add(__item.name, tkng);
                return tkng;
            }
            return this[__item.name];
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="__name">The name.</param>
        /// <returns></returns>
        public virtual graphWrapNode<TItem> Add(String __name)
        {
            if (!children.ContainsKey(__name))
            {
                var tkng = new graphWrapNode<TItem>(__name, this);
                children.Add(__name, tkng);
                tkng.parent = this;
                return tkng;
            }
            return this[__name];
        }

        /// <summary>
        /// Adds new node or nodes to correspond to specified path or name. <c>pathOrName</c> can be path like: path1\\path2\\path3
        /// </summary>
        /// <param name="pathOrName">Name of the path or.</param>
        /// <param name="__caption">The caption - display name of the folder</param>
        /// <param name="__description">The description - description about the folder</param>
        /// <returns></returns>
        public virtual graphWrapNode<TItem> Add(String pathWithName, TItem __item)
        {
            List<String> pathParts = pathWithName.SplitSmart(pathSeparator);
            graphWrapNode<TItem> head = this;

            foreach (String part in pathParts)
            {
                head = head.Add(part);
            }

            head.SetItem(__item);

            return head;
            
        }




        public const String SEPARATOR = "--> ";
        public const String SEPARATOR_CHILD = "|-> ";

        /// <summary>
        /// To the string path list.
        /// </summary>
        /// <returns></returns>
        public String ToStringPathList()
        {
            String output = "";
            var allLeafs = this.getAllLeafs();

            foreach (IObjectWithPathAndChildren pair in allLeafs)
            {
                output = output + pair.path + Environment.NewLine;
            }
            return output;
        }


        public virtual String forTreeview
        {
            get
            {
                return name;
            }
        }

        /*
        public String ToStringTreeview(String prefix = "", Boolean showType = false, Int32 gen = 0)
        {
            String output = forTreeview; // + "[l:" + level.ToString("D2") + "]";

            //if (showType) output += ":" + type.ToString();

            //Int32 l = 0;
            //foreach (var pair in children)
            //{
            //    l = Math.Max(pair.Value.forTreeview.Length, l);
            //}
            //l = l + 2;

            //output = output.PadRight(l);

            output = prefix + output;

            Boolean firstChild = true;
            //Int32 pad = Math.Max(output.Length, 20);

            String cPrefix = new String(' ', output.Length);

           // var thelast = ;

            foreach (var pair in children)
            {
                if (firstChild)
                {
                    String ch = pair.Value.ToStringTreeview(cPrefix + SEPARATOR, showType, gen + 1);
                    output = output + ch.removeStartsWith(cPrefix);
                    firstChild = false;
                }
                else
                {
                    output = output + Environment.NewLine;
                    output = output + pair.Value.ToStringTreeview(cPrefix + SEPARATOR_CHILD, showType, gen + 1);
                    if (pair.Value == children.Last().Value)
                    {
                        output = output + Environment.NewLine;
                    }
                }
            }
            return output;
        }*/


        /*
       /// <summary>
       /// Returns string representation of the graph
       /// </summary>
       /// <param name="prefix">The prefix.</param>
       /// <param name="showType">if set to <c>true</c> [show type].</param>
       /// <param name="gen">The gen.</param>
       /// <returns></returns>
       public String ToStringTreeviewAlt(String prefix = "", Boolean showType = false, Int32 gen = 0)
       {

           String output = "";

           List <graphWrapNode<TItem>> output = new List<graphWrapNode<TItem>>();
           List<graphWrapNode<TItem>> stack = new List<graphWrapNode<TItem>>();
           stack.Add(this);

           List<String> lines = new List<string>();

           while (stack.Any())
           {
               var n_stack = new List<graphWrapNode<TItem>>();


               Int32 l = 0;
               foreach (var pair in stack)
               {
                   l = Math.Max(pair.forTreeview.Length, l);
               }
               l = l + 2;


               foreach (graphWrapNode<TItem> child in stack)
               {

                   String oput = child.forTreeview;
                   oput = oput.PadRight(l);
                   if ()
                   {
                       output.Add(child);
                   }


                   stack.AddRange(child);
               }



               stack = n_stack;
           }


           //String  // + "[l:" + level.ToString("D2") + "]";

           //if (showType) output += ":" + type.ToString();





           output = prefix + output;

           Boolean firstChild = true;
           //Int32 pad = Math.Max(output.Length, 20);

           String cPrefix = new String(' ', output.Length);


           foreach (var pair in children)
           {
               if (firstChild)
               {
                   String ch = pair.Value.ToStringTreeview(cPrefix + SEPARATOR, showType, gen + 1);
                   output = output + ch.removeStartsWith(cPrefix);
                   firstChild = false;
               }
               else
               {
                   output = output + Environment.NewLine;
                   output = output + pair.Value.ToStringTreeview(cPrefix + SEPARATOR_CHILD, showType, gen + 1);
               }

           }

           return output;
       }
       */

        

    }

}