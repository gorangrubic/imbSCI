namespace imbSCI.Core.math
{
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Objekat koji opisuje dogadjaj koji se desio objektu: counter
    /// </summary>
    public class counterEventArgs
    {
        private counterEventType _type = counterEventType.unknown;

        public counterEventArgs()
        {
        }

        public String message { get; set; }

        public counterEventArgs(counterEventType __type, String __message = "")
           
        {
            message = __message;
            _type = __type;
        }


        /// <summary>
        /// Tip dogadjaja - ne moze da se prepravlja kasnije
        /// </summary>
        public counterEventType type { get; protected set; }
        
    }
}