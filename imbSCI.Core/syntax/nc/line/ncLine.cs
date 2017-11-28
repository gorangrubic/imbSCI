namespace imbSCI.Core.syntax.nc.line
{
    using System;

    /// <summary>
    /// Jedna NC linija koja zna gde je, koji su joj parametri i kako treba da izgleda  
    /// </summary>
    public class ncLine //: codeLineTokenCollection
    {


        #region --- collection ------- referenca prema kolekciji u kojoj se nalazi linija
        private ncLineCollection _collection;
        /// <summary>
        /// referenca prema kolekciji u kojoj se nalazi linija
        /// </summary>
        public ncLineCollection collection
        {
            get
            {
                return _collection;
            }
        }
        #endregion


        #region --- index ------- pozicija u kolekciji
        private Int32 _index;
        /// <summary>
        /// pozicija u kolekciji
        /// </summary>
        public Int32 index
        {
            get
            {
                if (collection == null) return -1;
                return collection.IndexOf(this);
            }
        }
        #endregion
        



        #region --- flag ------- Line flag

        private ncLineFlag _flag = ncLineFlag.NOFLAG;
        /// <summary>
        /// Line flag
        /// </summary>
        public ncLineFlag flag
        {
            get
            {
                if (_flag == ncLineFlag.NOFLAG)
                {
                    _flag = getFlag();
                }
                return _flag;
            }

        }
        #endregion


        protected ncLineFlag getFlag()
        {
            ncLineFlag flag = ncLineFlag.WITHPARAMS;

            //if (isEmpty) return ncLineFlag.EMPTYLINE;
            //if (isCommandOnly) return ncLineFlag.NOPARAMS;
            //if (Count == 1)
            //{
            //    if (this[1].type == codeLineTokenType.alfabet)
            //    {
            //        return ncLineFlag.WITHLABEL;
            //    }

            //}
            return flag;
        }

        #region --- command ------- Naziv komande
        private String _command;
        /// <summary>
        /// Naziv komande
        /// </summary>
        public String command
        {
            get { 
            //{
            //    if (isEmpty) return "";
            //    _command = this[0].ToString();
                return "";// _command;
            }

        }
        #endregion
       
        /// <summary>
        /// Pravi NC liniju iz linije koda
        /// </summary>
        /// <param name="codeLine"></param>
        public ncLine(String codeLine, ncLineCollection __collection) //:base(codeLine)
        {
            _collection = __collection;
        }

        

       

        /*
        /// <summary>
        /// Vraca liniju koda
        /// </summary>
        /// <returns></returns>
        public String getCodeLine()
        {
            if (flag == ncLineFlag.EMPTYLINE)
            {
                return "";
            }

            String output = "";
            output = output.add(command);

            String paramLine = parameters.getCodeLine();
            output = output.add(paramLine);
            
            return output;
        }*/

       /*

        /// <summary>
        /// Generise ncLine DOM iz linije koda
        /// </summary>
        /// <param name="codeLine"></param>
        protected void setFromCodeLine(String codeLine)
        {
            parameters = new ncParamCollection();
            _originalSourceCode = codeLine;

            if (codeLine != null)
            {
                codeLine = codeLine.Trim();
            }
            if (String.IsNullOrEmpty(codeLine))
            {
                flag = ncLineFlag.EMPTYLINE;
            }
            else
            {
                codeLine = codeLine.ToUpper().Replace("  ", " ");
                codeLine = codeLine.Replace("  ", " ");
                List<String> codeLineElements = codeLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                Int32 e = 0;
                Int32 p = 0;
                foreach (String element in codeLineElements)
                {
                    if (e == 0)
                    {
                        command = element.Trim();
                        
                    }
                    else
                    {
                        ncParam ncp = new ncParam();
                        ncp.setFromString(element, e - 1);
                        parameters.addParam(ncp);
                        p++;
                    }
                    e++;
                }

                if (String.IsNullOrEmpty(command))
                {
                    flag = ncLineFlag.UNRESOLVED;

                }
                else
                {

                    if (p == 0)
                    {
                        flag = ncLineFlag.NOPARAMS;

                    }
                    else if (p == 1) 
                    {
                        if (parameters.getParamByIndex(0).valueType == ncParamValueType.label)
                        {
                            flag = ncLineFlag.WITHLABEL;
                        }
                        
                    } else
                    {
                        flag = ncLineFlag.WITHPARAMS;
                    }
                }
            }
        }

        */
        


        //#region --- parameters ------- Kolekcija parametara

        //private ncParamCollection _parameters = new ncParamCollection();
        ///// <summary>
        ///// Kolekcija parametara
        ///// </summary>
        //public ncParamCollection parameters
        //{
        //    get
        //    {
        //        return _parameters;
        //    }
        //    set
        //    {
        //        _parameters = value;
        //        OnPropertyChanged("parameters");
        //    }
        //}
        //#endregion
        
        
    }
}
