using imbSCI.Core.extensions.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    public static class freeGraphExtensions {


       


        public static List<freeGraphNodeBase> GetQueryResultClones(this IEnumerable<freeGraphNodeBase> source, Int32 distanceIncrease = 0, Double weightFactor =1)
        {
            List<freeGraphNodeBase> output = new List<freeGraphNodeBase>();
            foreach (freeGraphNodeBase item in source)
            {
                var n = item.GetQueryResultClone(distanceIncrease);
                n.weight = n.weight * weightFactor;
                output.Add(n);
            }
            return output;
        }

        public static Dictionary<String, Double> GetWeightDictionary(this IEnumerable<freeGraphNodeBase> source)
        {
            Dictionary<String, Double> output = new Dictionary<string, double>();
            foreach (freeGraphNodeBase item in source)
            {
                output.Add(item.name, item.weight);
            }
            return output;
        }
    }

}