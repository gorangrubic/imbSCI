namespace imbSCI.Core.attributes
{
    #region imbVeles using

    using System;

    #endregion


    

    /// <summary>
    /// Pomocne informacije 
    /// </summary>
    public struct imbHelpContent
    {
        private String _description;
        private String _hints;
        private String _title;

        #region --- purpose ------- svrha opisane klase

        private String _purpose;

        /// <summary>
        /// svrha opisane klase
        /// </summary>
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.helpPurpose)]
        public String purpose
        {
            get
            {
                if (_purpose == null) return "";
                return _purpose;
            }
            set { _purpose = value; }
        }

        /// <summary>
        /// Hints
        /// </summary>
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.helpTips)]
        public string hints
        {
            get { return _hints; }
            set { _hints = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.menuHelp)]
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.helpDescription)]
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Full title
        /// </summary>
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.menuCommandTitle)]
        [imb(imbAttributeName.metaValueFromAttribute, imbAttributeName.helpTitle)]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion
    }
}