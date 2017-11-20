namespace imbSCI.Data.data.text
{
    using System;
    using System.Text.RegularExpressions;
// using aceCommonTypes.core.exceptions;
    //using aceCommonTypes.extensions;
    //using aceCommonTypes.extensions.text;
    //using aceCommonTypes.extensions.typeworks;
    //using aceCommonTypes.primitives;
    //using aceCommonTypes.zone;


    /// <summary>
    /// Single entry of regex marker result
    /// </summary>
    public class regexMarkerResult
    {
        /// <summary>
        /// Regex result
        /// </summary>
        /// <value>
        /// The match.
        /// </value>
        public Match match { get; set; }
        /// <summary>
        /// Marker (rule) that created this result
        /// </summary>
        /// <value>
        /// The marker.
        /// </value>
        public Object marker { get; set; }

        /// <summary>
        /// Content wrapped
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public String content { get; set; }

        private Int32 _index = 0;

        /// <summary>
        /// Starting point
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public Int32 index {
            get
            {
                if (match != null) return match.Index;
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        private Int32 _length = 0;
        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public Int32 length
        {
            get
            {
                if (match != null) return match.Length;
                return _length;
            }
            set
            {
                _length = value;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="regexMarkerResult"/> class.
        /// </summary>
        /// <param name="__content">The content.</param>
        /// <param name="__index">The index.</param>
        /// <param name="__marker">The marker.</param>
        public regexMarkerResult(String __content, Int32 __index, Object __marker)
        {
            _index = __index;
            length = __content.Length;
            content = __content;
            marker = __marker;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="regexMarkerResult"/> class.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="__marker">The marker.</param>
        public regexMarkerResult(Match m, Object __marker)
        {
            match = m;
            content = m.Value;
            marker = __marker;
        }
    }

}