﻿namespace imbSCI.DataComplex.linknode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Static tree structure
    /// </summary>
    public class linknodeBuilder
    {


        /// <summary>
        /// The root element of the tree
        /// </summary>
        private linknodeElement _root = new linknodeElement();
        /// <summary> </summary>
        public linknodeElement root
        {
            get
            {
                return _root;
            }
            protected set
            {
                _root = value;
            }
        }



        /// <summary>
        /// The source node list
        /// </summary>
        private List<linknodeElement> _sourceNodeList = new List<linknodeElement>();
        /// <summary> </summary>
        public List<linknodeElement> sourceNodeList
        {
            get
            {
                return _sourceNodeList;
            }
            protected set
            {
                _sourceNodeList = value;
                
            }
        }


        /// <summary>
        /// The source nodes
        /// </summary>
        private Dictionary<string, linknodeElement> _sourceNodes = new Dictionary<string, linknodeElement>();
        /// <summary>All source nodes (the ones used to build the structure) indexed by original path</summary>
        public Dictionary<string, linknodeElement> sourceNodes
        {
            get
            {
                return _sourceNodes;
            }
            protected set
            {
                _sourceNodes = value;
            }
        }


        /// <summary>
        /// The newpath nodes
        /// </summary>
        private Dictionary<string, linknodeElement> _newpathNodes = new Dictionary<string, linknodeElement>();
        /// <summary> </summary>
        public Dictionary<string, linknodeElement> newpathNodes
        {
            get
            {
                return _newpathNodes;
            }
            protected set
            {
                _newpathNodes = value;
            }
        }


        /// <summary> </summary>
        public bool countExisting { get; set; } = true;


        /// <summary>
        /// Adds the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="metaObject">The meta object.</param>
        /// <returns></returns>
        public linknodeElement Add(string path, object metaObject, int score=1)
        {
            if (sourceNodes.ContainsKey(path))
            {
                if (countExisting)
                {
                    linknodeElement tmp = sourceNodes[path];
                    while (tmp != null)
                    {
                        tmp.score++;
                        tmp = tmp.parent;
                    }
                }
                else
                {

                }
            }
            else
            {

                if (!path.isNullOrEmpty())
                {
                    linknodeElement tmp = root.buildNode(path, metaObject, score);
                    if (!tmp.path.isNullOrEmpty())
                    {
                        sourceNodes.Add(path, tmp);

                        if (!newpathNodes.ContainsKey(tmp.path))
                        {
                            newpathNodes.Add(tmp.path, tmp);
                        }
                        sourceNodeList.Add(tmp);
                        tmp.originalPath = path;
                    } else
                    {
                        return null;
                    }
                    return tmp;
                }
            }
            return null;
        }


        /// <summary>
        /// Gets the metas by path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <param name="useNewPath">if set to <c>true</c> [use new path].</param>
        /// <returns></returns>
        public List<T> GetMetasByPath<T>(string path, bool useNewPath=false) {
            List<object> metas = new List<object>();
            if (useNewPath)
            {
                metas = GetByStructurePath(path).meta;
            } else
            {
                metas = GetByOriginalPath(path).meta;
            }
            List<T> output = new List<T>();
            foreach(var me in metas)
            {
                output.Add((T)me);
            }

            return output;
        }

        /// <summary>
        /// Gets the by meta.
        /// </summary>
        /// <param name="meta">The meta.</param>
        /// <returns></returns>
        public linknodeElement GetByMeta(object meta)
        {
            for (int i = 0; i < sourceNodeList.Count(); i++)
            {
                if (sourceNodeList[i].meta.Contains(meta))
                {
                    return sourceNodeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the by structure path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public linknodeElement GetByStructurePath(string path)
        {
            if (newpathNodes.ContainsKey(path))
            {
                return newpathNodes[path];
            }
            return null;
        }

        /// <summary>
        /// Gets the by original path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public linknodeElement GetByOriginalPath(string path)
        {
            if (sourceNodes.ContainsKey(path))
            {
                return sourceNodes[path];
            }
            return null;
        }
    }
}