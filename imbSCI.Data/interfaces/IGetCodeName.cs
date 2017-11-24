namespace imbSCI.Data.interfaces
{
    using System;

    /// <summary>
    /// Object with getCodeName() method
    /// </summary>
    public interface IGetCodeName
    {
        /// <summary>
        /// Gets code name of the object. CodeName should be unique per each unique set of values of properties. In other words: if two instances of the same class have different CodeName that means values of their key properties are not same.
        /// </summary>
        /// <returns>Unique string to identify unique values</returns>
        String getCodeName();
    }

}