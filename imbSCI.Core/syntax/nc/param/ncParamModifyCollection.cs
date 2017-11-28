namespace imbSCI.Core.syntax.nc.param
{
    using System;
    using System.ComponentModel;
    using imbSCI.Core.syntax.nc.line;
    using imbSCI.Data.collection;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.syntax.param;

    /// <summary>
    /// Kolekcija sa ncParamModify objektima
    /// </summary>
    public class ncParamModifyCollection:aceCollection<ncParamModify>
    {

        public ncParamModifyCollection()
        {
        }


        /// <summary>
        /// Primenjuje sva modify podesavanja
        /// </summary>
        /// <param name="line">Linija NC koda</param>
        /// <param name="doLog">Da li vraca beleske</param>
        /// <returns>Beleske - ako je doLog=False onda je empty string</returns>
        public String applyToLine(ncLine line, Boolean doLog)
        {
            String debug = "";
            if (doLog) debug = debug.log("Before: "+line.ToString());

            foreach (ncParamModify pm in this)
            {
                //var ncp = line.getParamByKeyOrIndex(pm.parameterTarget);
                //if (ncp == null)
                //{
                //    //line.addToken(pm.
                //    //if (pm.doAddOnMissing)
                //    //{
                //    //    ncp = new ncParam();
                //    //    ncp.format = pm.modificationValue.getFormatFromExample(2);
                //    //    ncp.decValue = 0;

                //    //    if (pm.parIndex > -1)
                //    //    {
                //    //        ncp.index = pm.parIndex;
                //    //        line.addParam(ncp, pm.parIndex);
                //    //    } else
                //    //    {
                //    //        ncp.key = pm.parameterTarget;
                //    //        line.parameters.addParam(ncp);
                //    //    }
                //    //}
                //} else
                //{
                //    ncp.modify(pm.modificationType, pm.modificationValue);
                //    if (pm.doEnforceFormat)
                //    {
                //        ncp.setFormat(pm.modificationValue.getFormatFromExample(0));
                //    }
                //}
                //if (ncp == null)
                //{
                //    if (doLog) debug = debug.log("Line parameter not found [" + pm.parameterTarget+"]");
                //    break;
                //}
                
                
                
                
            }
            if (doLog) debug = debug.log("After: " + line.ToString());

            return debug;
        }



        /// <summary>
        /// Creates collection witn ncParamModify items 
        /// </summary>
        /// <param name="nParams">How many ncParamModify items to setup automatically</param>
        public ncParamModifyCollection(Int32 nParams)
        {
            for (Int32 a=1; a<=nParams; a++)
            {
                ncParamModify ncPM = new ncParamModify();
                ncPM.parameterTarget = a.ToString();
                ncPM.modificationType = paramValueModificationType.increase;
                ncPM.doEnforceFormat = true;
                ncPM.doAddOnMissing = false;
                ncPM.modificationValue = "0.000";
                Add(ncPM);
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}