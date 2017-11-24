namespace imbSCI.DataComplex
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    /// Set of documents that are subject of the <see cref="IWeightTable"/>
    /// </summary>
    public interface IWeightTableSet:IEnumerable<IWeightTable>
    {

        string name { get; set; }

        /// <summary>
        /// Adds the specified document and processes all terms contained
        /// </summary>
        /// <param name="document">The document.</param>
        IWeightTable Add(IWeightTable document);


        /// <summary>
        /// Adds new IWeightTable with name nad terms collection
        /// </summary>
        /// <param name="documentName">Name of the document.</param>
        /// <param name="terms">The terms.</param>
        IWeightTable AddTable(string documentName, IEnumerable<IWeightTableTerm> terms=null);


        /// <summary>
        /// Document with summary information on the terms
        /// </summary>
        /// <value>
        /// The aggregate document.
        /// </value>
        IWeightTable AggregateDocument { get; }


        /// <summary>
        /// Adds term to the table specified
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="term">The term.</param>
        /// <param name="callTableLevelAdd">if set to <c>true</c> [call table level add].</param>
        
        void Add(IWeightTable table, IWeightTableTerm term, bool callTableLevelAdd=false);

        DataSet dataSet { get; }

        /// <summary>
        /// Gets the <see cref="IWeightTable"/> for the specified document name.
        /// </summary>
        /// <value>
        /// The <see cref="IWeightTable"/>.
        /// </value>
        /// <param name="documentName">Name of the document.</param>
        /// <returns></returns>
        IWeightTable this[string documentName] { get; }

        /// <summary>
        /// Updates the maximum AFreq and CWeight - if chagnes occured since last call.
        /// </summary>
        void updateMaxValues();

        /// <summary>
        /// Gets the table for the specified document
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        DataTable GetDataTable(string document);

        /// <summary>
        /// Gets the aggregate table.
        /// </summary>
        /// <returns></returns>
        DataTable GetAggregateDataTable();

      
        /// <summary>
        /// Gets the data set with all tables made for each document contained. Optionally creates aggregate table as the first table in the dataset.
        /// </summary>
        /// <param name="includeAggregateTable">if set to <c>true</c> [include aggregate table].</param>
        /// <returns></returns>
        DataSet GetDataSet(bool includeAggregateTable = false);

        /// <summary>
        /// Gets the binary document frequency of the specified term, i.e.: number of documents containing the term
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        double GetBDFreq(IWeightTableTerm term);

        ///// <summary>
        ///// Gets the tf idf (term frequency - inverse document frequency
        ///// </summary>
        ///// <param name="term">The term.</param>
        ///// <returns></returns>
        //Double GetTF_IDF(IWeightTableTerm term);

        /// <summary>
        /// Gets the tf idf (term frequency - inverse document frequency
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        double GetIDF(IWeightTableTerm term);

        /// <summary>
        /// Gets the binary document frequency of the specified term, i.e.: number of documents containing the term
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        double GetBDFreq(string term);

        ///// <summary>
        ///// Gets the tf idf (term frequency - inverse document frequency
        ///// </summary>
        ///// <param name="term">The term.</param>
        ///// <returns></returns>
        //Double GetTF_IDF(String term);

        /// <summary>
        /// Gets the idf - inverse document frequency
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        double GetIDF(string term);
    }

}