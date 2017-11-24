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
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.DataComplex.data.dataUnits.core.IDataUnitRow" />
    /// <seealso cref="imbSCI.DataComplex.data.dataUnits.core.IDataUnit" />
    public interface IDataUnitIntegrated: IDataUnitRow, IDataUnit
    {
        void setAgregateResult(IEnumerable source);
        void setDataRow(object source);
    }

}