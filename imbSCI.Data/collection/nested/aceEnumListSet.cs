namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class aceEnumListSet<TEnum, T> : aceEnumDictionary<TEnum, List<T>> 
    {

        protected Int32 oldHash = -1;

        /// <summary>
        /// If TRUE any statistics child class may use shoud be recalculated
        /// </summary>
        /// <value>
        ///   <c>true</c> if [have change]; otherwise, <c>false</c>.
        /// </value>
        protected Boolean haveChange
        {
            get
            {
                if (oldHash == -1) return true;
                return (oldHash == GetHashCode());
            }
        }

        /// <summary>
        /// Accepts the changes: it will update change hash, call this after recalculation of the statistics
        /// </summary>
        protected void AcceptChanges()
        {
            oldHash = GetHashCode();
        }
        

        public aceEnumListSet():base(){

        }
        /// <summary>
        /// Support Flags and Enums
        /// </summary>
        /// <param name="flags">The flags.</param>
        /// <param name="link">The link.</param>
        public virtual void Add(TEnum flags, T link)
        {
            Enum fl = flags as Enum;
            List<TEnum> flagList = fl.getEnumListFromFlags<TEnum>();
            foreach (TEnum flag in flagList)
            {
                this[flag].Add(link);
                oldHash = -1;
            }
        }

        /// <summary>
        /// Counts all items in all sub collections
        /// </summary>
        /// <returns></returns>
        public Int32 CountAll()
        {
            Int32 i = 0;
            foreach (TEnum k in Keys)
            {
                i += Enumerable.Count<T>(this[k]);   
            }
            return i;
        }

        /// <summary>
        /// Removes the specified item from all dictionaries
        /// </summary>
        /// <param name="link">The link.</param>
        public virtual Int32 Remove(T link)
        {
            Int32 i = 0;
            foreach (TEnum k in Keys)
            {

                if (this[k].Remove(link))
                {
                    i++;
                    oldHash = -1;
                }       
            }
            return i;
        }
    }

    
}
