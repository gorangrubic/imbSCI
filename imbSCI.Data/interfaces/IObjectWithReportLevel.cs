using imbSCI.Data.enums;

namespace imbSCI.Data.interfaces
{
    /// <summary>
    /// Reporting related object - that has the <see cref="reportElementLevel"/> property
    /// </summary>
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithParent" />
    public interface IObjectWithReportLevel:IObjectWithParent
    {
        /// <summary>
        /// Indicates the element level of this object, in context of the reporting meta structure
        /// </summary>
        /// <value>
        /// The element level.
        /// </value>
        reportElementLevel elementLevel { get; }
    }

    
}