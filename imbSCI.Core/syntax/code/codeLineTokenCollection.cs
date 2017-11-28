namespace imbSCI.Core.syntax.code
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using imbSCI.Data;

    /// <summary>
    /// Jedna linija koda --- ABORTED
    /// </summary>
    public class codeLineTokenCollection : List<codeLineToken>
    {

        public codeLineTokenCollection()
        {

        }


        #region --- originalSourceCode ------- izvorni kod kojim je napravljena ova kolekcija
        private String _originalSourceCode = "";
        /// <summary>
        /// izvorni kod kojim je napravljena ova kolekcija
        /// </summary>
        public String originalSourceCode
        {
            get
            {
                return _originalSourceCode;
            }
        }
        #endregion

        public Boolean isEmpty
        {
            get { return Count == 0; }
        }

        public Boolean isCommandOnly
        {
            get { return Count == 1;
            }
        }

       

        /// <summary>
        /// Prvi token u nizu
        /// </summary>
        public codeLineToken firstToken
        {
            get
            {
                if (this.Count>0)
                {
                    return this[0];
                } else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Vraca code 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String output = "";
            //if (firstToken.originalSourceCode == "TOOL")
            //{
                
            //}
            foreach (codeLineToken tkn in this)
            {
                output = imbSciStringExtensions.add(output, tkn.ToString());
            }
            return output;
        }

        /// <summary>
        /// Token kolekcija na osnovu izvodnog
        /// </summary>
        /// <param name="__sourceCode"></param>
        public codeLineTokenCollection(String __sourceCode)
        {
            _originalSourceCode = __sourceCode;
            var tkns = __sourceCode.tokenizeCodeLine(false);
            foreach (var tkn in tkns)
            {
                codeLineToken token = null; // new codeLineToken(tkn, this);
                Add(token);

               
            }
        }


        public codeLineTokenCollection(String __sourceCode, Regex __tokenSelector, Boolean __doUseAutoconfig)
        {
            //codeLin
            if (__tokenSelector.IsMatch(__sourceCode))
            {
                MatchCollection mchs = __tokenSelector.Matches(__sourceCode);
                for (var i=0; i<mchs[0].Groups.Count; i++)
                {
                    if (__doUseAutoconfig)
                    {

                    } else
                    {

                    }
                    var token = new codeLineToken();
                 //   token.originalSourceCode = __sourceCode;

                    Add(token);
                }
               
            }
        }

        public codeLineToken addToken(String token, Int32 forceIndex=-1)
        {
            codeLineToken clt = null;// new codeLineToken(token, this);
            var i = addParam(clt, forceIndex);
            return clt;
        }

        /// <summary>
        /// Ubacuje novi parametar u niz, i podesava mu index vrednost
        /// </summary>
        /// <param name="newPar"></param>
        /// <returns></returns>
        public Int32 addParam(codeLineToken newPar, Int32 forceIndex = -1)
        {
            Int32 index = Count;
            if (forceIndex == -1)
            {
                Add(newPar);
            }
            else
            {
                this.Insert(forceIndex, newPar);
            }


            //if (!String.IsNullOrEmpty(newPar.key))
            //{
            //    keyToIndexMap.Add(newPar.key, index);
            //}

            return newPar.index;
        }


        /// <summary>
        /// Vraca parametar po indeksu
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public codeLineToken getParamByIndex(Int32 ind)
        {
            if (isEmpty) return null;
            if (ind > Count)
            {
                return null;
            }
            return this[ind];
        }

        /// <summary>
        /// Vraca parametar prema slovnom kljucu
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public codeLineToken getParamByKey(String key)
        {
            if (isEmpty) return null;
            if (String.IsNullOrEmpty(key))
            {
                return null;
            }
            key = key.Trim();
            key = key.ToUpper();

            if (keyToIndexMap.ContainsKey(key))
            {
                return this[keyToIndexMap[key]];
            }
            return null;
        }

        /// <summary>
        /// Pokusava prvo preko kljuca a onda i preko indeksa
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public codeLineToken getParamByKeyOrIndex(String key)
        {
            if (Count == 0) return null;
            if (String.IsNullOrEmpty(key))
            {
                return null;
            }
            key = key.Trim();
            key = key.ToUpper();

            if (keyToIndexMap.ContainsKey(key))
            {
                return this[keyToIndexMap[key]];
            }
            Int32 indkey = -1;

            if (Int32.TryParse(key, out indkey))
            {
                if (indkey < Count)
                {
                    return this[indkey];
                } else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Proverava da li se razlikuje izvorni source code od koda koji generise sa trenutnim podesavanjima
        /// </summary>
        /// <returns></returns>
        public Boolean isModified
        {
            get
            {
                return originalSourceCode.Trim() != ToString();
            }
        }

        /// <summary>
        /// Mapa koja povezuje slovni kljuc sa rednim mestom u listi
        /// </summary>
        protected Dictionary<String, Int32> keyToIndexMap = new Dictionary<string, int>();
      
    }
}