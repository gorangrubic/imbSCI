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

    public interface IWeightTableSetOperations
    {
        /// <summary>
        /// Sets the term weight = as nominal fequency
        /// </summary>
        void SetWeightTo_NominalFrequency();

        /// <summary>
        /// Sets the weight of each term as proportion between absolute frequency and total sum of all frequencies
        /// </summary>
        void SetWeightTo_FrequencyRatio();

        /// <summary>
        /// Sets the weights according to current TF_IDF of a term
        /// </summary>
        void SetWeightTo_TF_IDF();


    }
}