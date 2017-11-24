namespace imbSCI.Core.reporting.style.table
{
    using imbSCI.Core.reporting.style.core;

    /// <summary>
    /// Describe table style
    /// </summary>
    public class tableRangeStyle
    {
        
        private styleFourSide _outterLayout = new styleFourSide();
        /// <summary>
        /// Top=mergedHeader, Left=rowCounter, down=footer, right=NOT APPLUED
        /// </summary>
        public styleFourSide outterLayout
        {
            get { return _outterLayout; }
            set { _outterLayout = value; }
        }



        private styleFourSide _innerLayout = new styleFourSide();
        /// <summary>
        /// top=column heading, left=firstColumn, right=lastColumn, down=column foot
        /// </summary>
        public styleFourSide innerLayout
        {
            get { return _innerLayout; }
            set { _innerLayout = value; }
        }





    }
}
