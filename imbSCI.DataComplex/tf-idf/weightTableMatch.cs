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

    public class weightTableMatch<TWeightTableTerm, TSecondTableTerm> 
        where TWeightTableTerm:IWeightTableTerm 
        where TSecondTableTerm:IWeightTableTerm
    {

        public weightTableMatch(TSecondTableTerm keyTerm, TWeightTableTerm __match)
        {
            key = keyTerm;
            match = __match;
        }

        public string ToString()
        {
            string output = "[m:" + match.nominalForm + "]";
            if (subKey != null)
            {
                output +=  "=> [k:" + key.nominalForm + " -> " + subKey.nominalForm + "]";
            } else
            {
                output += "=> [k:" + key.nominalForm + "]";
            }
            return output;
        }


        /// <summary> </summary>
        public TWeightTableTerm match { get; protected set; }


        /// <summary> </summary>
        public TSecondTableTerm key { get; protected set; }


        /// <summary>
        /// 
        /// </summary>
        public IWeightTableTerm subKey { get; set; }
    }

}