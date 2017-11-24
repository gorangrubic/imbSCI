using System;
using System.Collections.Generic;
using System.Linq;

using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;
using System.Data;

namespace imbSCI.Data.interfaces
{
    public interface IPerformanceTaker
    {
        void prepare();
        

        /// <summary>
        /// 
        /// </summary>
        String name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Int32 secondsBetweenTakes { get; set; }

        /// <summary> </summary>
       // IPerformanceTake lastTake { get; }

        /// <summary>
        /// Makes take() if interval passed
        /// </summary>
        void checkTake();

        void take();
        TimeSpan GetTimeSpan();
        void LoadDataTable(DataTable input, Boolean removeCurrent = true);

        /// <summary>
        /// Gets data table with all readings
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        DataTable GetDataTable(String prefix = "");
    }

}