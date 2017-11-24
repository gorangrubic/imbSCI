namespace imbSCI.DataComplex.special
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
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
    /// Resolver - returns aggregate results
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="aceCommonTypes.collection.special.translationTableMulti{System.Text.RegularExpressions.Regex, TValue}" />
    public class regexQuerySet<TValue>:translationTableMulti<Regex, TValue>
    {
        /// <summary>
        /// 
        /// </summary>
        public int minQL { get; set; }


        //private Int32 _maxQL;
        ///// <summary>
        ///// 
        ///// </summary>
        //public Int32 maxQL
        //{
        //    get { return _maxQL; }
        //    set { _maxQL = value; }
        //}


        public instanceCountCollection<TValue> resolveQuerySet(IEnumerable<string> inputs)
        {
            var queries = GetKeys();
            minQL = queries.Min(x => x.ToString().Length);
            //maxQL = queries.Max(x => x.ToString().Length);

            instanceCountCollection<TValue> output = new instanceCountCollection<TValue>();

            foreach (string input in inputs)
            {
                foreach (Regex rg in GetKeys())
                {
                    if (rg.IsMatch(input))
                    {
                        int points = (rg.ToString().Length - minQL) * 2;
                        GetByKey(rg).ForEach(x => output.AddInstance(x, points));
                    }
                }
            }
            return output;
        }

        public instanceCountCollection<TValue> resolveQuery(string input)
        {
            var queries = GetKeys();
            minQL = queries.Min(x => x.ToString().Length);

            instanceCountCollection<TValue> output = new instanceCountCollection<TValue>();
            foreach (Regex rg in GetKeys())
            {
                if (rg.IsMatch(input))
                {
                    int points = 1 + ((rg.ToString().Length - minQL)*2);
                    GetByKey(rg).ForEach(x => output.AddInstance(x, points));
                }
            }
            return output;
        }

        public void Add(string regexPattern, params TValue[] results)
        {
            Regex rg = new Regex(regexPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (TValue tv in results) Add(rg, tv);
        }

        public void AddRange(string regexPattern, IEnumerable<TValue> results)
        {
            Regex rg = new Regex(regexPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (TValue tv in results) Add(rg, tv);
        }
    }

}