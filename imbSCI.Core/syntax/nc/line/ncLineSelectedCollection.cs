namespace imbSCI.Core.syntax.nc.line
{
    using imbSCI.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Kolekcija selektovanih linija
    /// </summary>
    public class ncLineSelectedCollection:ncLineCollection
    {
        public ncLineSelectedCollection()
        {
            
        }

        /// <summary>
        /// Pasivni konstruktor - nista ne kalkulise samo definise
        /// </summary>
        /// <param name="__source"></param>
        /// <param name="__criteria"></param>
        /// <param name="selected"></param>
        public ncLineSelectedCollection(ncLineCollection __source, ncLineCriteria __criteria, IEnumerable<ncLine> selected)
        {
            source = __source;
            criteria = __criteria;
            foreach (ncLine ln in selected)
            {
                Add(ln);
            }

           
        }

        /// <summary>
        /// Vraca jednolinijski opis kolekcije
        /// </summary>
        /// <returns></returns>
        public String writeInlineDescription()
        {
            String output = "Selected ";
            output += String.Format("{0} of {1}", this.Count, source.Count);

            output = output.add("using [" + criteria.GetType().Name + "] total criteria: " + criteria.criteriaCount());

            return output;
        }


        #region --- source ------- Izvorna kolekcija
        private ncLineCollection _source;
        /// <summary>
        /// Izvorna kolekcija
        /// </summary>
        public ncLineCollection source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                OnPropertyChanged("source");
            }
        }
        #endregion



        #region --- criteria ------- selektor ili prost kriterijum koji je napravio ovu kolekciju
        private ncLineCriteria _criteria;
        /// <summary>
        /// selektor ili prost kriterijum koji je napravio ovu kolekciju
        /// </summary>
        public ncLineCriteria criteria
        {
            get
            {
                return _criteria;
            }
            set
            {
                _criteria = value;
                OnPropertyChanged("criteria");
            }
        }
        #endregion
        
        
    }
}