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
    using imbSCI.Data.collection.nested;

    /// <summary>
    /// Counter - helper class keeping record of the term ocurrences
    /// </summary>
    /// <typeparam name="TWeightTableTerm">The type of the weight table term.</typeparam>
    /// <typeparam name="TWeightTable">The type of the weight table.</typeparam>
    /// <seealso cref="aceCommonTypes.collection.nested.aceDictionary2D{aceCommonTypes.collection.tf_idf.IWeightTableTerm, aceCommonTypes.collection.tf_idf.IWeightTable, System.Int32}" />
    public class weightTableTermInSetCounter<TWeightTableTerm, TWeightTable> : aceDictionary2D<IWeightTableTerm, IWeightTable, int> 
        where TWeightTable:IWeightTable
        where TWeightTableTerm:IWeightTableTerm
    {

        public int AddVote(IWeightTable targetTable, IWeightTableTerm term)
        {
            this[term, targetTable] = this[term, targetTable] + term.AFreqPoints;
            return this[term, targetTable];
        }

        /// <summary>
        /// Gets the Binary Document Frequency, i.e. number of <see cref="IWeightTable"/>s containing the term
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public int GetBDF(IWeightTableTerm term)
        {
            return Enumerable.Count<KeyValuePair<IWeightTable, int>>(this[term]);
        }

        /// <summary>
        /// Gets Apsolute frequency accross all document (summary)
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public int GetAFreq(IWeightTableTerm term)
        {
            int A = 0;
            foreach (var t in this[term]) A += t.Value;
            //this[term]
            //this[term].ForEach(x => A += x.Value);
            return A;
        }


        /// <summary>
        /// Gets all <see cref="IWeightTable"/> containing matching terms
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public List<IWeightTable> GetTablesWithTerm(IWeightTableTerm term)
        {
            List<IWeightTable> output = new List<IWeightTable>();
            foreach (IWeightTable table in this[term].Keys)
            {
                output.Add(table);
            }
            return output;
        }
    }

}