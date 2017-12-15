using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace imbSCI.Data.data.sample
{

    /// <summary>
    /// Portion of the population
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.List{T}" />
    public class sampleTake<T>:List<T>
    {

        /// <summary>
        /// Populates sample take according to settings
        /// </summary>
        /// <param name="_source">The source.</param>
        /// <param name="_settings">The settings.</param>
        public sampleTake(List<T> _source, samplingSettings _settings)
        {
            sampleSource = _source;

            settings = _settings;

            Int32 limit = -1;

            Int32 skip = -1;

            Int32 step = 1;
           

            if (settings.parts > 1)
            {
                limit = Math.Min(sampleSource.Count / settings.parts, settings.limit);

                switch (settings.takeOrder)
                {
                    case samplingOrderEnum.ordinal:
                        if (settings.skip > 0)
                        {
                            skip = settings.skip * limit;
                        }
                        break;
                    case samplingOrderEnum.randomSuffle:
                        skip = 0;
                        break;
                    case samplingOrderEnum.everyNth:
                        skip = settings.skip;
                        step = settings.parts;
                        break;
                }
                
            } else
            {
                skip = settings.skip;
                
            }


            if (limit == -1) limit = sampleSource.Count;
            if (skip == -1) skip = 0;

            Boolean go = true;
            Random rnd = new Random();
            Int32 index = skip;
            
            List<Int32> taken = new List<int>();

            Int32 i = 0;

            Int32 iLimit = (sampleSource.Count / limit) * 5;

            while (go)
            {
                i++;
                switch (settings.takeOrder)
                {
                    case samplingOrderEnum.ordinal:
                    case samplingOrderEnum.everyNth:
                        index += step;
                        if (taken.Contains(index))
                        {
                            index++;
                        }
                        break;
                    case samplingOrderEnum.randomSuffle:
                        index = rnd.Next(0, sampleSource.Count);
                        break;
                }
                
                if (index >= sampleSource.Count)
                {
                    index = index - sampleSource.Count;
                }



                if (settings.onlyUnique)
                {
                    taken.Add(index);

                    if (!Contains(sampleSource[index])) Add(sampleSource[index]);
                    
                } else
                {
                    Add(sampleSource[index]);
                }


                if (Count >= limit) { go = false; }

                if (i > iLimit) { go = false; }


            }
            
        }

       

        /// <summary>
        /// Settings used for this take
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public samplingSettings settings { get; protected set; }

        public List<T> sampleSource { get; protected set; }

        public Double takeToSourceRatio { get
            {
                return ((Double)Count) / ((Double)sampleSource.Count);
            }
        }



    }

}