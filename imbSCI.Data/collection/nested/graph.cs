

// using aceCommonTypes.extensions.io;
// using aceCommonTypes.extensions.text;
// using aceCommonTypes.interfaces;

namespace imbSCI.Data.collection.nested
{
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Universal wrapped-graph structure - the graph root class
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
