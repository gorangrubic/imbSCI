

// using aceCommonTypes.extensions.io;
// using aceCommonTypes.extensions.text;
// using aceCommonTypes.interfaces;

namespace imbSCI.Data.collection.graph
{
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Universal wrapped-graph-tree structure - the class of the root element in a graph-tree structure
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="graphWrapgraphWrapNode{TItem}" />
    public class graph<TItem> : graphWrapNode<TItem> where TItem : IObjectWithName
    {
        public graph(TItem __item) : base(__item, null)
        {
        }

        
    }


    
}
