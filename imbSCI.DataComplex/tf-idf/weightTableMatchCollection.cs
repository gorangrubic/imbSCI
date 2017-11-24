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
    using imbSCI.Data;

    public class weightTableMatchCollection<TWeightTableTerm, TSecondTableTerm>:List<weightTableMatch<TWeightTableTerm, TSecondTableTerm>>
        where TWeightTableTerm : IWeightTableTerm
        where TSecondTableTerm : IWeightTableTerm
    {

        public weightTableMatchCollection(IWeightTable __first, IWeightTable __second)
        {
            first = __first;
            second = __second;
        }


        public string ToString()
        {
            string output = "";
            foreach (var mch in this)
            {
                output = output.add(mch.ToString(), " | ");
            }
            return output;
        }


        /// <summary>
        /// 
        /// </summary>
        public IWeightTable first { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public IWeightTable second { get; set; }


        public void Add(TSecondTableTerm second, TWeightTableTerm match)
        {
            //if (!ContainsKey(second)) this.Add(new weightTableMatch<TWeightTableTerm, TSecondTableTerm>(second));

            Add(new weightTableMatch<TWeightTableTerm, TSecondTableTerm>(second, match));
        }


        /// <summary>
        /// Gets the semantic similarity.
        /// </summary>
        /// <returns></returns>
        public double GetSemanticSimilarity()
        {
            double output = 0;

            double up = 0;
            double downSumA = 0;
            double downSumB = 0;


            foreach (weightTableMatch<TWeightTableTerm, TSecondTableTerm> pair in this)
            {
                var q_i = first.GetNFreq((string) pair.match.name);
                var d_i = second.GetTF_IDF((string) pair.key.name); //< -- obrni
                var sim = pair.subKey.weight;
                up += q_i * d_i * sim;

                //downSumA++;
                
            }

            downSumA = first.GetCWeight(); // +  second.GetCWeight();

            if (up != 0)
            {
                output = up / downSumA;
            }
            return output;
        }


        public double GetVSMCosineSimilarity()
        {
            double output = 0;

            double up = 0;
            double downSumA = 0;
            double downSumB = 0;


            foreach (weightTableMatch<TWeightTableTerm, TSecondTableTerm> pair in this)
            {
                up += first.GetTF_IDF(pair.key) * second.GetTF_IDF(pair.match);
                downSumA += Math.Pow(first.GetTF_IDF((string) pair.key.name), 2);
                downSumB += Math.Pow(second.GetTF_IDF((string) pair.match.name), 2);
            }

            double down = Math.Sqrt(downSumA * downSumB);

            output = up / down;
            return output;
        }
    }

}