namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Concurrent Bag with implicit conversion
    /// </summary>
    /// <typeparam name="T">Item to store</typeparam>
    /// <seealso cref="System.Collections.Concurrent.ConcurrentBag{T}" />
    public class aceConcurrentBag<T>:ConcurrentBag<T>
    {
        public aceConcurrentBag()
        {

        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="aceConcurrentBag{T}"/> to <see cref="List{T}"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator List<T>(aceConcurrentBag<T> input)
        {
            List<T> output = new List<T>();
            foreach (T item in input)
            {
                output.Add(item);
            }
            return output;
        }


        /// <summary>
        /// The add lock
        /// </summary>
        private Object AddLock = new Object();


        /// <summary>
        /// Adds the unique.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddUnique(T item)
        {
            if (item == null) return;
            lock (AddLock)
            {
                if (!this.Contains(item)) Add(item);
            }
        }
    }

}