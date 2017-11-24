namespace imbSCI.Data.data.text
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class regexMarker<T>
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="regexMarker{T}"/> class.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="__m">The m.</param>
        public regexMarker(String regex, T __m)
        {
            marker = __m;
            test = new Regex(regex);

        }



        /// <summary>
        /// Gets or sets the test.
        /// </summary>
        /// <value>
        /// The test.
        /// </value>
        public Regex test { get; set; }
        /// <summary>
        /// Gets or sets the marker.
        /// </summary>
        /// <value>
        /// The marker.
        /// </value>
        public T marker { get; set; }
    }

}