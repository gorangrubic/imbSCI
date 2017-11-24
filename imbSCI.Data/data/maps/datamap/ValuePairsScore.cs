namespace imbSCI.Data.data.maps.datamap
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// 2013c: LowLevel resurs
    /// </summary>
    public class ValuePairsScore : imbBindable
    {
        #region --- score ------- Bindable property

        private Dictionary<String, Int32> _score = new Dictionary<string, int>();

        /// <summary>
        /// Bindable property
        /// </summary>
        public Dictionary<String, Int32> score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged("score");
            }
        }

        #endregion

        public void clear()
        {
            _score = new Dictionary<string, int>();
        }

        public Dictionary<string, int> sort()
        {
            throw new NotImplementedException();
            //   return score.SortByValue() as Dictionary<String, Int32>;
        }

        /// <summary>
        /// Vraća ključ koji ima najviše poena
        /// </summary>
        /// <returns></returns>
        public String getTopScored()
        {
            if (score.Count == 0) return "";

            String output = score.First().Key;

            foreach (String k in score.Keys)
            {
                if (score[k] > score[output]) output = k;
            }

            return output;
        }

        /// <summary>
        /// Dodaje novi string key u listu ili povecava broj bodova za postojeci
        /// </summary>
        /// <param name="stringKey"></param>
        public void Add(String stringKey)
        {
            if (!score.ContainsKey(stringKey))
            {
                score.Add(stringKey, 0);
            }
            score[stringKey]++;
        }

        /// <summary>
        /// Dodaje pojene za prosleđene parove
        /// </summary>
        /// <param name="ivp"></param>
        public void Add(IValuePairs ivp)
        {
            foreach (String k in ivp.Keys)
            {
                if (!score.ContainsKey(k))
                {
                    score.Add(k, 0);
                }
                score[k]++;
            }
        }
    }
}