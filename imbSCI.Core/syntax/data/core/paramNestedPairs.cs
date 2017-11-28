namespace imbSCI.Core.syntax.data.core
{
    using System;

    /// <summary>
    /// Nestovana grupa parametara
    /// </summary>
    public class paramNestedPairs:paramPairs
    {


        

        public paramNestedPairs(String __name)
        {
            groupName = __name;
        }

            

        #region --- groupName ------- naziv grupe parametara

        private String _groupName = "";
        /// <summary>
        /// naziv grupe parametara
        /// </summary>
        public String groupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }
        #endregion
        
    }
}