using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.attributes;
using System.ComponentModel;
using System.Text;

namespace imbSCI.Core.math.classificationMetrics
{

    /// <summary>
    /// Interface to classification report objects
    /// </summary>
    public interface IClassificationReport
    {
        String Name { get; set; }
        String Classifier { get; set; }
        Double Correct { get; set; }
        Double Wrong { get; set; }
        Double Targets { get; set; }
        Double Precision { get; set; }
        Double Recall { get; set; }
        Double F1measure { get; set; }
        classificationEvalMetricSet GetSetMetrics(classificationEvalMetricSet _metrics = null);

    }

}