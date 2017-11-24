namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections;
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

    /// <summary>
    /// Integrated data deliveryInstance model keeping deliveryInstance unit and data in the same object
    /// </summary>
    /// <seealso cref="dataUnitBase" />
    /// <seealso cref="IDataUnitRow" />
    public abstract class dataUnitIntegratedModel : dataUnitBase, IDataUnitRow
    {
        public dataUnitIntegratedModel(Type __instanceType) : base(__instanceType)
        {
        }

        public int iteration => lastIteration;


        /// <summary>
        /// 
        /// </summary>
        public dataUnitBase parent { get; set; }


        /// <summary>
        /// Checks the data.
        /// </summary>
        /// <param name="monitor">The monitor.</param>
        /// <returns></returns>
        public bool checkData(dataUnitRowMonitoring monitor)
        {
            return monitor.checkData(this);
        }

        /// <summary>
        /// Prepares the specified monitor.
        /// </summary>
        /// <param name="__monitor">The monitor.</param>
        /// <param name="__parent">The parent.</param>
        public void prepare(dataUnitRowMonitoring __monitor, dataUnitBase __parent=null)
        {
            
        }

        /// <summary>
        /// Sets the agregate result.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void setAgregateResult(IEnumerable source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the data row.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void setDataRow(object source)
        {
            throw new NotImplementedException();
        }

      
    }

}