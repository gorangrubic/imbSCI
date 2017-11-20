namespace imbSCI.Data.interfaces
{
    using System;
    using System.Collections;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IObjectWithName" />
    public interface IObjectWithChildSelector: IObjectWithName, IEnumerable
    {

        IEnumerator GetEnumerator();

        Object this[Int32 key] { get; }
        


        /// <summary>
        /// Index of supplied child - in his collection
        /// </summary>
        /// <returns>-1 if not found</returns>
        Int32 indexOf(IObjectWithChildSelector child);

        /// <summary>
        /// Number of child items
        /// </summary>
        /// <returns></returns>
        Int32 Count();

        /// <summary>
        /// Gets the <see cref="Object"/> with the specified child name.
        /// </summary>
        /// <value>
        /// The <see cref="Object"/>.
        /// </value>
        /// <param name="childName">Name of the child.</param>
        /// <returns></returns>
        Object this[String childName]
        {
            get;
        }
    }

}