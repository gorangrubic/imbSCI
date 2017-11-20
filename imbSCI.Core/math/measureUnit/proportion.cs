namespace imbSCI.Core.math.measureUnit
{
    using System;

    /// <summary>
    /// Proportion information representing count of total i.e. 5 of 13
    /// </summary>
    public class proportion : aceMathUnitBase<int>, IAceMathUnitRatio
    {
        protected Int32 from = 0;

        protected override string format
        {
            get
            {
                return "{0:0}/{1:0}";
            }
        }

        public override String ToString()
        {
            return String.Format(format, value, from);
        }

    }

}