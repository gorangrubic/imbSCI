using imbSCI.Core.collection;

namespace imbSCI.Core.reporting
{
    /// <summary>
    /// Class that supports AppendDataFields
    /// </summary>
    /// <seealso cref="imbSCI.Core.reporting.IAppendDataFields" />
    public interface IAppendDataFieldsExtended:IAppendDataFields
    {
        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        
        PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data = null);
    }
}