namespace imbSCI.Core.reporting
{
    using System.Data;

    /// <summary>
    /// Objects that have method for manual data field mapping (data for report templates)
    /// </summary>
    public interface IAppendDataFields
    {
        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        PropertyCollection AppendDataFields(PropertyCollection data = null);
    }
}