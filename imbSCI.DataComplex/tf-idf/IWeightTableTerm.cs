namespace imbSCI.DataComplex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Term that is subject of <see cref="IWeightTable"/> 
    /// </summary>
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithName" />
    public interface IWeightTableTerm:IObjectWithName
    {
        /// <summary>
        /// Defines term name and nominal form
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="nominalForm">The nominal form.</param>
        void Define(string name, string nominalForm);

        string nominalForm { get; }

        List<string> GetAllForms(bool includingNominalForm=true);

        /// <summary>
        /// Sets semantic instances for this term
        /// </summary>
        /// <param name="instances">The instances.</param>
        void SetOtherForms(IEnumerable<string> instances);

        /// <summary>
        /// Determines whether the specified <c>other</c> <see cref="IWeightTableTerm"/> is match with this one (meaning their frequencies are summed)
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if the specified other is match; otherwise, <c>false</c>.
        /// </returns>
        bool isMatch(IWeightTableTerm other);

        /// <summary>
        /// Frequency points that should be added to the term
        /// </summary>
        /// <value>
        /// a freq points.
        /// </value>
        int AFreqPoints { get;  }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        double weight { get; set; }


        int Count { get; }
    }

}