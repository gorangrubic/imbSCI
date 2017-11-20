namespace imbSCI.Data.data.text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Data.collection.nested;

    /// <summary>
    /// Single dimension marker map
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class regexMarkerResultCollection<T> 
    {

        /// <summary>
        /// Gets the marker results by order of appearance -- taking only first layer
        /// </summary>
        /// <returns></returns>
        public List<regexMarkerResult> GetByOrder()
        {
            List<regexMarkerResult> output = new List<regexMarkerResult>();
            Int32 index = 0;
                      
            regexMarkerResult head = null;

            while (index < length)
            {
                if (byAllocation.ContainsKey(index))
                {
                    var tmp = byAllocation[index].First();
                    output.Add(tmp);
                    index = index + tmp.length;
                } else
                {
                    index++;
                }
            }
            return output;
        }


        private aceDictionarySet<T, regexMarkerResult> _byMarker = new aceDictionarySet<T, regexMarkerResult>();
        /// <summary> Dictionary set by marker rule</summary>
        public aceDictionarySet<T, regexMarkerResult> byMarker
        {
            get
            {
                return _byMarker;
            }
            protected set
            {
                _byMarker = value;

            }
        }


        private aceDictionarySet<Int32, regexMarkerResult> _byAllocation = new aceDictionarySet<Int32, regexMarkerResult>();
        /// <summary> Indexed by allocation </summary>
        public aceDictionarySet<Int32, regexMarkerResult> byAllocation
        {
            get
            {
                return _byAllocation;
            }
            protected set
            {
                _byAllocation = value;

            }
        }

        internal Int32 AddResult(String rest, Int32 index)
        {
            var restResult = new regexMarkerResult(rest, index, defaultMarker);
            
            AddResult(restResult);
            return restResult.index + restResult.length;
        }

        /// <summary>
        /// Length of the complete result collection
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public Int32 length { get; set; }

        internal void AddResult(regexMarkerResult res)
        {

            for (Int32 ind = res.index; ind <= res.index + res.length; ind++)
            {
                byAllocation.Add(ind, res);
            }

            byMarker.Add((T)res.marker, res);
        }

        /// <summary>
        /// Default marker to apply
        /// </summary>
        public T defaultMarker = default(T);


        public regexMarkerResultCollection()
        {

        }
    }

}