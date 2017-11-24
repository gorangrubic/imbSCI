namespace imbSCI.DataComplex.data
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

    /*
    public class modelEnumDataSet<T> : modelDataSet
    {
        _imbOP

        public override string VAR_LogPrefix
        {
            get
            {
                return "mds";
            } 
        }
        public override bool VAR_AllowAutoOutputToConsole
        {
            get
            {
                return false;
            }
        }


        public void buildDataSets();
    }*/

    public abstract class modelGeneralDataSet:modelDataSet
    {
        public override string VAR_LogPrefix
        {
            get
            {
                return "mds";
            }
        }
        public override bool VAR_AllowAutoOutputToConsole
        {
            get
            {
                return false;
            }
        }

        
        public abstract void buildDataSets();
    }

}