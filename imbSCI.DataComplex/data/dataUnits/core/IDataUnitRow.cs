namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

    public interface IDataUnitRow: INotifyPropertyChanged
    {
        bool checkData(dataUnitRowMonitoring monitor);
        void prepare(dataUnitRowMonitoring __monitor, dataUnitBase __parent);
  

       // Int32 iteration { get; set; }
        dataUnitBase parent { get; }
    }

}