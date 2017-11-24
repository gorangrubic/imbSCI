using System;
using System.Collections.Generic;
using System.Linq;

using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Data.interfaces
{
    public interface IPerformanceTake
    {
        Int32 id { get; set; }

        String idk { get; set; }
        DateTime samplingTime { get; set; }
        Double secondsSinceLastTake { get; set; }
        Double reading { get; set; }
        Double PerMinuteFactor { get; set; }
    }

}