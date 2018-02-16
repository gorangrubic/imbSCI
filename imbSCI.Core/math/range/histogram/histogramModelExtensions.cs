using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;
using imbSCI.Core.extensions.table;
using imbSCI.Core.math.range.finder;

namespace imbSCI.Core.math.range.histogram
{

    public static class histogramModelExtensions {

        public static histogramModel GetHistogramModel<T>(this IEnumerable<T> sourceSet, String name, Func<T, double> selector, Int32 bins=10)
        {
            histogramModel model = new histogramModel(bins, name);
            foreach (var s in sourceSet)
            {
                model.ranger.Learn(selector(s));
            }


            model.processData();
            return model;
        }

        public static void ProcessData<T>(this histogramModel model, IEnumerable<T> sourceSet, Func<T, double> selector)
        {
            foreach (var s in sourceSet)
            {
                model.ranger.Learn(selector(s));
            }

            
            model.processData();
        }

    }

}