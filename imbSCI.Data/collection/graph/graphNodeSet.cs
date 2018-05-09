using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Data.collection.graph
{
    using System.Collections;
    using imbSCI.Data.interfaces;


    public class graphNodeSet : List<IGraphNode> {

        public graphNodeSet(IGraphNode localRoot)
        {
            root = localRoot;
            
        }

        public graphNodeSet(IEnumerable<IGraphNode> source, IGraphNode localRoot) {
            root = localRoot;
            this.AddRange(source);
        }
        /// <summary>
        /// Common root of the set - if exists
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public IGraphNode root { get; set; }

        /// <summary>
        /// Creates the graph from local root. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localRootName">Name of the local root - in case there is no common <c>root</c> for the set</param>
        /// <returns></returns>
        public T CreateGraphFromLocalRoot<T>(String localRootName="") where T:IGraphNode, new()
        {
            throw new NotImplementedException("Still not ready");

            T output = new T();

            if (root != null)
            {
                output.name = root.name;
            }
            else
            {
                output.name = localRootName;

                foreach (var nd in this) {
                    output.Add(nd);
                }

                
            }

            foreach (var nd in this)
            {

                nd.MergeWith(output, graphOperationFlag.mergeOnSameName);
                
            }

            if (root == null)
            {
                root = new T();
                root.name = localRootName;
            }

            return output;
        }

    }

}