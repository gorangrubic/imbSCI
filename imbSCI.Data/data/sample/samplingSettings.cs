using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace imbSCI.Data.data.sample
{


    /// <summary>
    /// Configuration for <see cref="sampleTake{T}"/>
    /// </summary>
    public class samplingSettings
    {

        


        /// <summary> Number of items to skip </summary>
        [Category("Count")]
        [DisplayName("skip")]
        [Description("Number of items to skip, or ID of the part to take")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")]
        public Int32 skip { get; set; } = 0;


        /// <summary>
        /// Total number of items allowed to get into sample
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public Int32 limit { get; set; } = -1;


        /// <summary>
        /// Defines number of equal parts for sampling algorithms like: n-fold, every n-th
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public Int32 parts { get; set; } = -1;

        ///// <summary>
        ///// Which block/part was taken
        ///// </summary>
        ///// <value>
        ///// The part identifier.
        ///// </value>
        //public Int32 partID { get; set; } = -1;


        /// <summary>
        /// It will return only unique instances to be collected, no overlap
        /// </summary>
        /// <value>
        ///   <c>true</c> if [only unique]; otherwise, <c>false</c>.
        /// </value>
        public Boolean onlyUnique { get; set; } = true;


        public samplingOrderEnum takeOrder { get; set; } = samplingOrderEnum.ordinal;


    }
}
