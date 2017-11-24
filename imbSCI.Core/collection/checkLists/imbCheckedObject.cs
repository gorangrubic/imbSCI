namespace imbSCI.Core.collection.checkLists
{
    #region imbVeles using

    using System;

    #endregion

   
    /// <summary>
    /// 
    /// </summary>
    public class imbCheckedObject 
    {
        public imbCheckedObject()
        {
        }

        public imbCheckedObject(Boolean __isChecked, String __value)
        {
            isChecked = __isChecked;
            value = __value;
        }

        #region --- isChecked ------- Da li je objekat chekiran

        private Boolean _isChecked;

        /// <summary>
        /// Da li je objekat chekiran
        /// </summary>
        public Boolean isChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
            }
        }

        #endregion

        #region --- value ------- Objekat

        private String _value;

        /// <summary>
        /// Objekat
        /// </summary>
        public String value
        {
            get { return _value; }
            set
            {
                _value = value;
            }
        }

        #endregion
    }
}