using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.extensions.data;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    /// <summary>
    /// Result of a query over <see cref="freeGraph"/> collection, contains clones of  matched graphs
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{imbNLP.PartOfSpeech.TFModels.semanticCloud.core.freeGraphNodeBase}" />
    public class freeGraphQueryResult:List<freeGraphNodeBase>
    {
        public freeGraphQueryResult()
        {

        }

        public freeGraphQueryResult(freeGraphNodeBase centralNode)
        {
            queryNodes.Add(centralNode);
        }

        public freeGraphQueryResult(IEnumerable<freeGraphNodeBase> centralNodes)
        {
            queryNodes.AddRange(centralNodes);
        }


        public Boolean graphNotReady { get; set; } = false;

        public freeGraphNodeBase queryNode
        {
            get
            {
                return queryNodes.FirstOrDefault();
            }
        }

        public List<freeGraphNodeBase> queryNodes { get; protected set; } = new List<freeGraphNodeBase>();

        public Boolean graphNodeNotFound
        {
            get
            {
                return queryNode == null;
            }
        }
        public Boolean includeBtoALinks { get; set; }

        /// <summary>
        /// Adds nodes if they are not already inside, and returns the ones that were new fot this result
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns></returns>
        public List<freeGraphNodeBase> AddNewNodes(IEnumerable<freeGraphNodeBase> nodes)
        {
            List<freeGraphNodeBase> newNodes = new List<freeGraphNodeBase>();
            foreach (freeGraphNodeBase node in nodes)
            {
                if (!queryNodes.Any(x => x.name == node.name))
                {
                    if (!this.Any(x => x.name == node.name))
                    {
                        Add(node);
                        newNodes.Add(node);
                    }
                }
            }
            return newNodes;
        }
    }

}