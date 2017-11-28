namespace imbSCI.Core.syntax.nc
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.syntax.nc.line;
    using imbSCI.Core.syntax.data.files.@base;
    using imbSCI.Data.collection.special;
    using imbSCI.Data;

    /// <summary>
    /// E-mac NC compatibile 
    /// </summary>
    public class ncFile: textDataSetBase
    {

        public ncFile()
        {
            
        }

        public ncFile(String path)
        {
            load(path);

        }
        #region --- ncLines ------- kolekcija NC linija

        private ncLineCollection _ncLines = new ncLineCollection();
        /// <summary>
        /// kolekcija NC linija
        /// </summary>
        public ncLineCollection ncLines
        {
            get
            {
                return _ncLines;
            }
            set
            {
                _ncLines = value;
                OnPropertyChanged("ncLines");
            }
        }
        #endregion



        #region --- lineFlagCount ------- Broj razlicitih flagova koji se poljavjuju 

        private enumCounter<ncLineFlag> _lineFlagCount = new enumCounter<ncLineFlag>();
        /// <summary>
        /// Broj razlicitih flagova koji se poljavjuju 
        /// </summary>
        public enumCounter<ncLineFlag> lineFlagCount
        {
            get
            {
                return _lineFlagCount;
            }
            set
            {
                _lineFlagCount = value;
                OnPropertyChanged("lineFlagCount");
            }
        }
        #endregion
        


        /// <summary>
        /// Konvertuje string linije u ncLine objekte
        /// </summary>
        /// <returns></returns>
        public override bool afterLoad()
        {
            ncLines = new ncLineCollection();
            lineFlagCount.reset();

            foreach (String line in lines)
            {
                var ln = new ncLine(line, ncLines);

                lineFlagCount.count(ln.flag);

                ncLines.Add(ln);
            }

            return ncLines.Any();
        }

        /// <summary>
        /// Generise izvestaj
        /// </summary>
        /// <returns></returns>
        public override String writeDescription()
        {
            
            
            String filename = "";
            String output = base.writeDescription();

            output = output.add("DOM flags: ");
            output = output.add(lineFlagCount.writeResult("{0}({1}) "));
            return output;
        }

        public override bool processToObject(object _target)
        {
            throw new NotImplementedException();
        }

        public override bool processToDictionary()
        {
            throw new NotImplementedException();
        }

        public override bool beforeSave()
        {
            lines = new List<string>();
            foreach (ncLine line in ncLines)
            {
                String lc = line.ToString();
                lines.Add(lc);
            }
            return true;
        }

       


    }

}
